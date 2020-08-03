using Military.Contracts;
using Military.Core.Contracts;
using Military.Exceptions;
using Military.IO.Contracts;
using Military.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Military.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private ICollection<ISoldier> soldures;

        public Engine()
        {
            this.soldures = new List<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;

            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(' ',
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string soldureType = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];

                ISoldier soldier = null;

                if (soldureType == "Private")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (soldureType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                    foreach (var pid in cmdArgs.Skip(5))
                    {
                        ISoldier privateToAdd = this.soldures
                            .First(s => s.Id == int.Parse(pid));

                        general.AddPrivate(privateToAdd);
                    }

                    soldier = general;

                }
                else if (soldureType == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];
                    try
                    {
                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                        string[] repairArgs = cmdArgs
                            .Skip(6)
                            .ToArray();

                        for (int i = 0; i < repairArgs.Length; i+= 2)
                        {
                            string partName = repairArgs[i];
                            int hoursWorked = int.Parse(repairArgs[i + 1]);

                            IRepair repair = new Repair(partName, hoursWorked);

                            engineer.AddRepair(repair);
                        }

                        soldier = engineer;
                    }
                    catch (InvalidCorpsException ex)
                    {
                        continue;
                        throw;
                    }


                }
                else if (soldureType == "Commando")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];

                    try
                    {
                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                        string[] missionArgs = cmdArgs
                            .Skip(6)
                            .ToArray();

                        for (int i = 0; i < missionArgs.Length; i += 2)
                        {
                            try
                            {
                                string missionCodeNAme = missionArgs[i];
                                string missionState = missionArgs[i + 1];
                                IMission mission = new Mission(missionCodeNAme, missionState);

                                commando.AddMission(mission);
                            }
                            catch (InvalidMissionStateException ex)
                            {
                                continue;
                                throw;
                            }                          
                        }

                        soldier = commando;
                    }
                    catch (InvalidCorpsException ex)
                    {
                        continue;
                        throw;
                    }


                }
                else if (soldureType == "Spy")
                {
                    int codeNumber = int.Parse(cmdArgs[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }

                if (soldier != null)
                {
                    this.soldures.Add(soldier);
                }                
            }

            foreach (var soldier in this.soldures)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }
    }
}
