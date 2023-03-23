using siblue.Model;

namespace siblue.Service
{
    public interface IListBackupRepository
    {
        Task<IEnumerable<ListBackup>> GetAllListBackupByEmployeeId(Guid id);
        Task<IEnumerable<ListBackupMatrix>> GetAllListBackupMatrix();
        Task<ListBackupMatrix?> GetListBackupMatrixByNik(string nik);
        Task<IEnumerable<ListBackup>> CreateListBackupMatrix(ListBackupMatrix list_backup_matrix);
        Task UpdateListBackupMatrix(Guid employee_id, ListBackupMatrix list_backup_matrix);

    }
}
