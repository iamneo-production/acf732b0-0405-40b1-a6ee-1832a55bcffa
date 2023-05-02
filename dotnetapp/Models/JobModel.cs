using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class JobModel
    {
        [Key]
        public int JobId { get; set; }
        public string JobDescription { get; set; }

        public string JobLocation { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string WagePerDay { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<JobSeekerModel>? JobSeekers { get; set; }
    }
}
