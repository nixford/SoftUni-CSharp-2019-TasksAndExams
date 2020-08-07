using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ImportProjectsDTO
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; } // string instead DateTime
        
        [XmlElement("DueDate")]        
        public string DueDate { get; set; }  // string instead DateTime
        
        [XmlArray("Tasks")]
        public ImportProjectTasksDTO[] Tasks { get; set; }
    }
}
