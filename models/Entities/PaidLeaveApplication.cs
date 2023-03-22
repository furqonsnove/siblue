using System;
using System.ComponentModel.DataAnnotations;

namespace HR_Service.Models
{
    public class PaidLeaveApplication
    {
        [Key, Required]
        public Guid id { get; set; }

        [Required]
        public Guid employee_id { get; set; }

        [Required]
        public Guid employee_backup_id { get; set; }

        [Required]
        public Guid reviewer_id { get; set; }

        [Required]
        public string application_status { get; set; } = String.Empty;

        [Required]
        public string description { get; set; } = String.Empty;

        [Required]
        public DateTime paid_leave_start_date { get; set; }

        [Required]
        public DateTime paid_leave_end_date { get; set; }

        [Required]
        public DateTime expired_at { get; set; }

        [Required]
        public DateTime created_at { get; set; } = DateTime.UtcNow.AddHours(7);

        [Required]
        public DateTime updated_at { get; set; } = DateTime.UtcNow.AddHours(7);

        public DateTime? deleted_at { get; set; }
    }
}

