using System;
using HR_Service.Models;
using HR_Service.Services.ListBackups.Implementations;

namespace HR_Service.Services.ListBackups.Interfaces
{
    public interface IListBackupService
    {
        Task<IEnumerable<ListBackupMatrix>> GetAllListBackupMatrix();
        Task<ListBackupMatrix?> GetListBackupMatrixByNik(string nik);
        Task<IEnumerable<ListBackup>> CreateListBackupMatrix(ListBackupMatrix list_backup_matrix);
    }
}

