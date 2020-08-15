namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using System.Text;
    using TeisterMask.Data.Models;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using System.Globalization;
    using System.Linq;
    using Microsoft.SqlServer.Server;
    using TeisterMask.Data.Models.Enums;
    using Microsoft.VisualBasic;
    using Castle.Core.Internal;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectsDTO[]), new XmlRootAttribute("Projects"));
            var projectsDtos = (ImportProjectsDTO[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Project> projectsList = new List<Project>();

            StringBuilder sb = new StringBuilder();

            foreach (var projectDto in projectsDtos)
            {

                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;                    
                }

                DateTime projectOpenDate;
                bool isProjectOpenDateValid = DateTime.TryParseExact
                    (projectDto.OpenDate, "dd/MM/yyyy", 
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out projectOpenDate);

                if (!isProjectOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? projectDueDate;

                if (!String.IsNullOrEmpty(projectDto.DueDate))
                {
                    // If I do receive DueDate in XML
                    DateTime projectDueDateValue;
                    bool isProjectDueDateValid = DateTime.TryParseExact
                    (projectDto.DueDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out projectDueDateValue); 

                    if (!isProjectDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    projectDueDate = projectDueDateValue;
                }
                else
                {
                    projectDueDate = null;
                }
                

                var currProject = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate,

                };

                foreach (var task in projectDto.Tasks)
                {
                    if (!IsValid(task))
                    { 
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;
                    bool isTaskOpenDateValid = DateTime.TryParseExact
                        (task.OpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out taskOpenDate);

                    if (!isTaskOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskDueDate;
                    bool isTaskDueDateValid = DateTime.TryParseExact
                        (task.DueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out taskDueDate);

                    if (!isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < projectOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (projectDueDate.HasValue)
                    {
                        if (taskDueDate > projectDueDate.Value)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }

                    currProject.Tasks.Add(new Task
                    {
                        Name = task.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)task.ExecutionType,
                        LabelType = (LabelType)task.LabelType,
                    });
                }

                sb.AppendLine(String.Format(SuccessfullyImportedProject, currProject.Name, currProject.Tasks.Count));

                projectsList.Add(currProject);



            }

            context.Projects.AddRange(projectsList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesDtos = JsonConvert.DeserializeObject<ImportEmployeesDTO[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Employee> employeesList = new List<Employee>();

            foreach (var employeeDto in employeesDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currEmployee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                };

                foreach (var task in employeeDto.Tasks)
                {
                    if (!context.Tasks.Any(t => t.Id == task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }   

                    if (!currEmployee.EmployeesTasks.Any(t => t.TaskId == task))
                    {
                        currEmployee.EmployeesTasks.Add(new EmployeeTask
                        {
                            TaskId = task,
                        });
                    }                   

                }

                employeesList.Add(currEmployee);
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, currEmployee.Username, currEmployee.EmployeesTasks.Count));

            }

            context.Employees.AddRange(employeesList);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}