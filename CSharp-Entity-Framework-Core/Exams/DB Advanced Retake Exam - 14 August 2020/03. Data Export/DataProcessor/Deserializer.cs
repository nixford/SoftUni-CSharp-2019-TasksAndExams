namespace SoftJail.DataProcessor
{

    using Data;
    using Microsoft.EntityFrameworkCore.Internal;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsDtos = JsonConvert.DeserializeObject<ImportDepartmentsDTO[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Department> departmentList = new List<Department>();

            foreach (var departmetDto in departmentsDtos)
            {
                if (!IsValid(departmetDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                // If a department is invalid, do not import its cells.
                // If a Department doesn’t have any Cells, he is invalid.         
                if (!departmetDto.Cells.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                // If one Cell has invalid CellNumber, don’t import the Department.
                bool isValidCellNumber = true;
                foreach (var cell in departmetDto.Cells) 
                {
                    if (cell.CellNumber < 1 || cell.CellNumber > 1000)
                    {
                        isValidCellNumber = false;
                        break;
                    }
                }

                if (!isValidCellNumber)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }                      

                var currDepartment = new Department()
                {
                    Name = departmetDto.Name,
                };

                foreach (var cell in departmetDto.Cells)
                {
                    currDepartment.Cells.Add(new Cell 
                    { 
                        CellNumber = cell.CellNumber,
                        HasWindow = cell.HasWindow,
                    });
                }
                sb.AppendLine($"Imported {currDepartment.Name} with {currDepartment.Cells.Count} cells");
                departmentList.Add(currDepartment);
            }

            context.Departments.AddRange(departmentList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDtos = JsonConvert.DeserializeObject<ImportPrisonersDTO[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Prisoner> prisonersList = new List<Prisoner>();

            foreach (var prisonerDto in prisonersDtos)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime incarcerationDate;
                bool isIncarcerationValid = DateTime.TryParseExact
                    (prisonerDto.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out incarcerationDate);

                if (!isIncarcerationValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime? releaseDate;
                if (!String.IsNullOrEmpty(prisonerDto.ReleaseDate))
                {
                    DateTime releaseDateValue;
                    bool isReleaseValid = DateTime.TryParseExact
                        (prisonerDto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out releaseDateValue);

                    if (!isReleaseValid)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }
                    releaseDate = releaseDateValue;
                }
                else
                {
                    releaseDate = null;
                }

                bool isEmailValid = true;
                foreach (var mail in prisonerDto.Mails)
                {
                    if (!IsValid(mail.Address))
                    {
                        isEmailValid = false;                       
                        break;
                    }
                }

                if (!isEmailValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime releaseDateOutPut;
                bool isReleaseValidValue = DateTime.TryParseExact
                        (prisonerDto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out releaseDateOutPut);                

                var currPrisoner = new Prisoner()
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    CellId = prisonerDto.CellId,
                };

                foreach (var mail in prisonerDto.Mails)
                {
                    currPrisoner.Mails.Add(new Mail 
                    {
                        Description = mail.Description,
                        Sender = mail.Sender,
                        Address = mail.Address,
                    });
                }

                sb.AppendLine($"Imported {currPrisoner.FullName} {currPrisoner.Age} years old");
                prisonersList.Add(currPrisoner);

            }


            context.Prisoners.AddRange(prisonersList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportOfficersDTO[]), new XmlRootAttribute("Officers"));
            var officersDtos = (ImportOfficersDTO[])xmlSerializer.Deserialize(new StringReader(xmlString));

            List<Officer> officersList = new List<Officer>();

            StringBuilder sb = new StringBuilder();

            foreach (var officerDto in officersDtos)
            {
                bool isValidPosition = Enum.TryParse(officerDto.Position, out Position currPosition);
                bool isValidWeapon = Enum.TryParse(officerDto.Weapon, out Weapon currWeapon);

                if (!IsValid(officerDto) || !isValidPosition || !isValidWeapon)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var currOfficer = new Officer()
                {
                    FullName = officerDto.FullName,
                    Salary = (officerDto.Salary),
                    Position = currPosition,
                    Weapon = currWeapon,
                    DepartmentId = officerDto.DepartmentId,
                };
                
                foreach (var dtoPrisoner in officerDto.Prisoners)
                {
                    currOfficer.OfficerPrisoners.Add(new OfficerPrisoner
                    {
                        OfficerId = currOfficer.Id,
                        PrisonerId = dtoPrisoner.Id
                    });
                }                

                officersList.Add(currOfficer);
                sb.AppendLine($"Imported {currOfficer.FullName} ({currOfficer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officersList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}