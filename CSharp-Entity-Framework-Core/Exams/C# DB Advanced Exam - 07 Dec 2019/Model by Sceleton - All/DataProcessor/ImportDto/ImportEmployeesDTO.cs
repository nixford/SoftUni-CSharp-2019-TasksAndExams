using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeesDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        [JsonProperty("Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [JsonProperty("Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[0-9]{3}-[0-9]{3}-[0-9]{4}$")]
        [JsonProperty("Phone")]
        public string Phone { get; set; }
        
        public int[] Tasks { get; set; }

    }
}
