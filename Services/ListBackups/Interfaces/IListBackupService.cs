using System;
using HR_Service.Models;
using HR_Service.Services.ListBackups.Implementations;

namespace HR_Service.Services.ListBackups.Interfaces
{
    public record ListBackupBackupEmployees(Guid employee_id, int level);
    public record ListBackupMatrix(Guid employee_id, List<ListBackupBackupEmployees> backup_employees);

    public interface IListBackupService
    {
        Task<IEnumerable<ListBackupMatrix>> GetListBackupMatrix();
    }
}

