using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class JobSeekerModel
    {
        [Key]
        public int PersonId { get; set; }

        public string PersonName { get; set; }

        public string JobAdress { get; set; }

        public string PersonExp { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        public int? JobId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public JobModel? Job { get; set; }

    }
}
