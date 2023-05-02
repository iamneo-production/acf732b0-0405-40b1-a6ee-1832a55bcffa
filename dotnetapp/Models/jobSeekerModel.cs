
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class jobSeekerModel
    {
        [Key]
        public string personId { get; set; }
        public string personName { get; set; }
        public string personAddress { get; set; }
        public string personExp { get; set; }
        public string personPhone { get; set; }
        public string PersonEmail { get; set; }
        public int? JobId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public JobModel? Job { get; set; }



    }
}
