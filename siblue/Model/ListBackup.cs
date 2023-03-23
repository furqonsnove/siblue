using System.ComponentModel.DataAnnotations;

namespace siblue.Model;

public record ListBackupBackupEmployees(Guid employee_id, int level);
public record ListBackupMatrix(Guid employee_id, List<ListBackupBackupEmployees> backup_employees);

public class ListBackup
{
    [Key, Required]
    public Guid id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid employee_id { get; set; }

    [Required]
    public Guid employee_backup_id { get; set; }

    [Required]
    public int level { get; set; }

    [Required]
    public DateTime created_at { get; set; } = DateTime.UtcNow.AddHours(7);

    [Required]
    public DateTime updated_at { get; set; } = DateTime.UtcNow.AddHours(7);

    public DateTime? deleted_at { get; set; }

}