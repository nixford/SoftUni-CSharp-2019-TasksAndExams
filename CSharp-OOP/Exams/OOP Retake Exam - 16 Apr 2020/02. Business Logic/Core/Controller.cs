using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private IProcedure procedure;
        private readonly Dictionary<string, List<IRobot>> proceduresWithRobots;

        public Controller()
        {
            this.garage = new Garage();
            this.proceduresWithRobots = new Dictionary<string, List<IRobot>>();            
        }
        public string Charge(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = garage.Robots[robotName];
            procedure = new Charge();
            procedure.DoService(robot, procedureTime);
            AddRobotToProcedure(robot);

            return $"{robotName} had charge procedure";
        }

        private void AddRobotToProcedure(IRobot robot)
        {
            if (!proceduresWithRobots.ContainsKey(procedure.GetType().Name))
            {
                proceduresWithRobots.Add(procedure.GetType().Name, new List<IRobot>());
                proceduresWithRobots[procedure.GetType().Name].Add(robot);
            }
            else
            {
                proceduresWithRobots[procedure.GetType().Name].Add(robot);
            }
        }

        public string Chip(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = garage.Robots[robotName];
            procedure = new Chip();               
            procedure.DoService(robot, procedureTime);
            AddRobotToProcedure(robot);

            return $"{robotName} had chip procedure";
        }

        public string History(string procedureType)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"{procedureType}");

            foreach (var robot in proceduresWithRobots[procedureType])
            {
                sb.AppendLine(robot.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {

            if (robotType == nameof(HouseholdRobot))
            {                
                IRobot robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                garage.Manufacture(robot);
                return $"Robot {name} registered successfully";
            }
            else if (robotType == nameof(PetRobot))
            {
                IRobot robot = new PetRobot(name, energy, happiness, procedureTime);
                garage.Manufacture(robot);
                return $"Robot {name} registered successfully";
            }
            else if (robotType == nameof(WalkerRobot))
            {
                IRobot robot = new WalkerRobot(name, energy, happiness, procedureTime);
                garage.Manufacture(robot);
                return $"Robot {name} registered successfully";
            }
            else
            {
                return $"{robotType} type doesn't exist";
            }            
        }

        public string Polish(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = garage.Robots[robotName];
            procedure = new Polish();
            procedure.DoService(robot, procedureTime);
            AddRobotToProcedure(robot);

            return $"{robotName} had polish procedure";
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = garage.Robots[robotName];
            procedure = new Rest();
            procedure.DoService(robot, procedureTime);
            AddRobotToProcedure(robot);

            return $"{robotName} had rest procedure";
        }

        public string Sell(string robotName, string ownerName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = garage.Robots[robotName];
            garage.Sell(robotName, ownerName);

            if (robot.IsChipped)
            {
                return $"{ownerName} bought robot with chip";
            }
            else
            {
                return $"{ownerName} bought robot without chip";
            }            
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = garage.Robots[robotName];
            procedure = new TechCheck();
            procedure.DoService(robot, procedureTime);
            AddRobotToProcedure(robot);

            return $"{robotName} had tech check procedure";
        }

        public string Work(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = garage.Robots[robotName];
            procedure = new Work();
            procedure.DoService(robot, procedureTime);
            AddRobotToProcedure(robot);

            return $"{robotName} was working for {procedureTime} hours";
        }

        public void Exit ()
        {
            Environment.Exit(0);
        }
        
    }
}
