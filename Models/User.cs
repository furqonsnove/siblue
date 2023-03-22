using System.ComponentModel.DataAnnotations;

namespace HR_Service.Models
{
    public class User
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string pin { get; set; }

        [Required]
        public DateTime password_expired_at { get; set; }

        [Timestamp]
        public DateTime created_at { get; set; }

        [Timestamp]
        public DateTime updated_at { get; set;}

        [Timestamp]
        public DateTime deleted_at { get;set; }


    }
}
