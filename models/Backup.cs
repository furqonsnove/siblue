using System;
using System.ComponentModel.DataAnnotations;

namespace HR_Service.models
{
	public class Backup
	{
        [Key, Required]
        public Guid id { get; set; }

        [Required]
        public Guid employee_id { get; set; }

        [Required]
        public Guid employee_backup_id { get; set; }

        [Required]
        public int level { get; set; }

        [Required]
        public DateTime created_at { get; set; }

        [Required]
        public DateTime updated_at { get; set; }

        [Required]
        public DateTime? deleted_at { get; set; }
    }
}

