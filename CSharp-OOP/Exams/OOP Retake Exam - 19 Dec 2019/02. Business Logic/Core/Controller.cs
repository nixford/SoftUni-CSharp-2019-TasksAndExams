using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Models.Workshops.Contracts;
using SantaWorkshop.Repositories;
using SantaWorkshop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs;
        private PresentRepository presents;
        private IDwarf currDwarf;
        private IInstrument instrument;
        private IPresent currPresent;
        private IWorkshop workshop;

        public Controller()
        {
            dwarfs = new DwarfRepository();
            presents = new PresentRepository();
            workshop = new Workshop();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            if (dwarfType == nameof(HappyDwarf))
            {
                currDwarf = new HappyDwarf(dwarfName);
                dwarfs.Add(currDwarf);
                return $"Successfully added {dwarfType} named {dwarfName}.";
            }
            else if (dwarfType == nameof(SleepyDwarf))
            {
                currDwarf = new SleepyDwarf(dwarfName);
                dwarfs.Add(currDwarf);
                return $"Successfully added {dwarfType} named {dwarfName}.";
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            currDwarf = dwarfs.Models.FirstOrDefault(d => d.Name == dwarfName);
            if (currDwarf == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }
            instrument = new Instrument(power);
            currDwarf.AddInstrument(instrument);
            return $"Successfully added instrument with power {power} to dwarf {currDwarf.Name}!";
        }

        public string AddPresent(string presentName, int energyRequired)
        {
            currPresent = new Present(presentName, energyRequired);
            presents.Add(currPresent);
            return $"Successfully added Present: {presentName}!";
        }

        public string CraftPresent(string presentName)
        {  
            var suitableDwarfs = dwarfs.Models.Where(d => d.Energy >= 50).ToList();
            if (suitableDwarfs == null)
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }

            IPresent presentForCraft = presents.Models.FirstOrDefault(p => p.Name == presentName);

            while (suitableDwarfs.Any())
            {
                IDwarf mostReadyDwarf = suitableDwarfs.OrderByDescending(d => d.Energy).First();

                workshop.Craft(presentForCraft, mostReadyDwarf);

                if (presentForCraft.IsDone())
                {
                    break;
                }
            }

            if (presentForCraft.IsDone())
            {                
                return $"Present {presentName} is done.";
            }
            else
            {
                return $"Present {presentName} is not done.";
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            var presentsDone = presents.Models.Where(p => p.IsDone()).ToList();

            sb.AppendLine($"{presentsDone.Count} presents are done!");
            sb.AppendLine("Dwarfs info:");

            foreach (var dwarf in dwarfs.Models)
            {
                sb.AppendLine($"Name: {dwarf.Name}")
                  .AppendLine($"Energy: {dwarf.Energy}")
                  .AppendLine($"Instruments: {dwarf.Instruments.Count} not broken left");
            }

            return sb.ToString().TrimEnd();
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
