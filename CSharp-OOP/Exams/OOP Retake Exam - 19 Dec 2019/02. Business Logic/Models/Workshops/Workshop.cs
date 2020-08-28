﻿using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Instruments.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        private IInstrument instrument;

        public Workshop()
        {

        }

        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (dwarf.Energy > 0 && dwarf.Instruments.Any())
            {
                instrument = dwarf.Instruments.First();
                while (!present.IsDone() &&
                    dwarf.Energy > 0 &&
                    !instrument.IsBroken())
                {
                    dwarf.Work();
                    present.GetCrafted();
                    instrument.Use();
                }

                if (instrument.IsBroken())
                {
                    dwarf.Instruments.Remove(instrument);
                }

                if (present.IsDone())
                {
                    break;
                }
            }
        }
    }
}
