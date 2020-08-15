﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class ImportProjectTasksDTO
    {
       
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [XmlElement("Name")]
        public string Name { get; set; }

       
        [Required]
        [XmlElement("OpenDate")]
        public string OpenDate { get; set; } // string instead DateTime

        
        [Required]
        [XmlElement("DueDate")]
        public string DueDate { get; set; } // string instead DateTime
        
        [Required]
        [Range(0, 3)]
        [XmlElement("ExecutionType")]
        public int ExecutionType { get; set; } // int instead enum in order to be accepted with cast in code logic
                
        [Required]
        [Range(0, 4)]
        [XmlElement("LabelType")]
        public int LabelType { get; set; }
    }
}
