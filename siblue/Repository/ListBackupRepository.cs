using Microsoft.EntityFrameworkCore;
using siblue.Db;
using siblue.Model;
using siblue.Service;

namespace siblue.Repository
{
    public class ListBackupRepository : IListBackupRepository
    {
        private readonly ApplicationDbContext _context;

        public ListBackupRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ListBackup>> GetAllListBackupByEmployeeId(Guid id)
        {
            return await _context.ListBackups.Where(x => x.employee_id == id).ToListAsync();
        }

        public async Task<IEnumerable<ListBackupMatrix>> GetAllListBackupMatrix()
        {
            IEnumerable<ListBackup> list_backups = await _context.ListBackups.ToListAsync();

            IEnumerable<ListBackupMatrix> result = list_backups.GroupBy(x => x.employee_id)
                .Select(r => new ListBackupMatrix
                (r.Key, r.Select(i => new ListBackupBackupEmployees(i.employee_backup_id, i.level)).ToList()));

            return result;
        }

        public async Task<ListBackupMatrix?> GetListBackupMatrixByNik(string nik)
        {
            // TODO : Employee module
            IEnumerable<ListBackup> list_backups = await _context.ListBackups.Where(x => x.level == 1).ToListAsync();

            ListBackupMatrix? result = list_backups.GroupBy(x => x.employee_id)
                .Select(r => new ListBackupMatrix
                (r.Key, r.Select(i => new ListBackupBackupEmployees(i.employee_backup_id, i.level)).ToList())).FirstOrDefault();

            return result;
        }

        public async Task<IEnumerable<ListBackup>> CreateListBackupMatrix(ListBackupMatrix list_backup_matrix)
        {
            List<ListBackup> list_backups_to_create = new List<ListBackup>();

            list_backup_matrix.backup_employees.ForEach(x =>
            {
                ListBackup list_backup = new ListBackup() { employee_id = list_backup_matrix.employee_id, employee_backup_id = x.employee_id, level = x.level };
                _context.ListBackups.Add(list_backup);

                list_backups_to_create.Add(list_backup);

            });

            await _context.SaveChangesAsync();

            return list_backups_to_create;
        }

        public async Task UpdateListBackupMatrix(Guid employee_id, ListBackupMatrix list_backup_matrix)
        {
            _context.ListBackups.RemoveRange(_context.ListBackups.Where(x => x.employee_id == employee_id));

            await CreateListBackupMatrix(list_backup_matrix);

            return;
        }

    }
}
