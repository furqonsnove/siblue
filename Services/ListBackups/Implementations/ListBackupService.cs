
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

        public async Task<IEnumerable<ListBackupMatrix>> GetListBackupMatrix()
        {
            var list_backups = await _api_db_context.list_backup.AsNoTracking().ToListAsync();

            var result = list_backups.GroupBy(x => x.employee_id)
                .Select(r => new ListBackupMatrix
                (r.Key, r.Select(i => new ListBackupBackupEmployees(i.employee_backup_id, i.level)).ToList()));

            return result;
        }
    }
}

