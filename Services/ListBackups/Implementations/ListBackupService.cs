
using System;
using HR_Service.Data;
using HR_Service.Models;
using HR_Service.Models.Enitty;
using HR_Service.Services.ListBackups.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HR_Service.Services.ListBackups.Implementations
{
    public class ListBackupService : IListBackupService
    {
        private readonly ApiDBContext _api_db_context;

        public ListBackupService(ApiDBContext api_db_context)
        {
            _api_db_context = api_db_context;
        }

        public async Task<IEnumerable<ListBackupMatrix>> GetAllListBackupMatrix()
        {
            IEnumerable<ListBackup> list_backups = await _api_db_context.list_backup.AsNoTracking().ToListAsync();

            IEnumerable<ListBackupMatrix> result = list_backups.GroupBy(x => x.employee_id)
                .Select(r => new ListBackupMatrix
                (r.Key, r.Select(i => new ListBackupBackupEmployees(i.employee_backup_id, i.level)).ToList()));

            return result;
        }

        public async Task<ListBackupMatrix?> GetListBackupMatrixByNik(string nik)
        {
            // TODO : Employee module
            IEnumerable<ListBackup> list_backups = await _api_db_context.list_backup.AsNoTracking().Where(x => x.level == 1).ToListAsync();

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
                _api_db_context.list_backup.Add(list_backup);

                list_backups_to_create.Add(list_backup);

            });

            await _api_db_context.SaveChangesAsync();

            return list_backups_to_create;
        }
    }
}

