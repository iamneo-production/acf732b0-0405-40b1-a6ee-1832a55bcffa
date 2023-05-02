using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class JobModel
    {
        [Key]
        public int jobId { get; set; }
        public string jobDescription { get; set; }
        public string jobLocation { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public string wagePerDay { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<jobSeekerModel>? JobSeekers { get; set; }

    }
}
