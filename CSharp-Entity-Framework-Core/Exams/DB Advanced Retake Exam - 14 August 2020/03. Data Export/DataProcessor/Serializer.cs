﻿namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                .Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new PrisonerDto()
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Select(po => new OfficerDto()
                        {
                            OfficerName = po.Officer.FullName,
                            Department = po.Officer.Department.Name
                        })
                        .OrderBy(o => o.OfficerName)
                        .ToArray(),
                    TotalOfficerSalary = Math.Round(p.PrisonerOfficers.Sum(po => po.Officer.Salary), 2)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            string result = JsonConvert.SerializeObject(prisoners, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] searchedPrisoners = prisonersNames.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var prisoners = context
                .Prisoners
                .Where(p => searchedPrisoners.Contains(p.FullName))
                .Select(p => new PrisonerXmlDto()
                {
                    Id = p.Id,                    
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Name = p.FullName,
                    Messages = p.Mails
                        .Select(m => new MailXmlDto()
                        {
                            Description = ReverseAlgorithn(m.Description)
                        })
                        .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(PrisonerXmlDto[]), new XmlRootAttribute("Prisoners"));
            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            serializer.Serialize(new StringWriter(sb), prisoners, xmlNamespaces);

            return sb.ToString().Trim();
        }

        private static string ReverseAlgorithn(string description)
        {
            string result = string.Empty;
            for (int i = description.Length - 1; i >= 0; i--)
            {
                result += description[i];
            }

            return result;
        }
    }
}