using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Data.Model
{
    public class Employee
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("lastname")]
        public string lastname { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public DateTime dateOfBirth { get; set; }

        [JsonPropertyName("employmentStartDate")]
        public DateTime employmentStartDate { get; set; }

        [JsonPropertyName("employmentEndDate")]
        public DateTime employmentEndDate { get; set; }

        public string GetFullName()
        {
            return this.name + " " + this.lastname;
        }
    }
}
