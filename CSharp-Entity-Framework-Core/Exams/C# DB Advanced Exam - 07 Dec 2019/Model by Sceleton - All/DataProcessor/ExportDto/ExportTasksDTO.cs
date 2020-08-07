using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class ExportTasksDTO
    {
        [JsonProperty("Name")]
        public string TaskName { get; set; }

        [JsonProperty("OpenDate")]
        public string OpenDate { get; set; }

        [JsonProperty("DueDate")]
        public string DueDate { get; set; }

        [JsonProperty("LabelType")]
        public LabelType LabelType { get; set; }

        [JsonProperty("ExecutionType")]
        public ExecutionType ExecutionType { get; set; }

    }
}

