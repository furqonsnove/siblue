using NuGet.Protocol;
using siblue.Db;
using siblue.Model;
using siblue.Service;
using SQLitePCL;

namespace siblue.Repository
{
    public class LogAuditRepository : ILogAuditRepository
    {
        private readonly ApplicationDbContext _context;
        public LogAuditRepository(ApplicationDbContext context) {
            _context = context;
        }

        public IEnumerable<LogAudit> Get()
        {
            return _context.LogAudits.ToList();
            //throw new NotImplementedException();
        }

        public LogAudit GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Create(LogAudit laudit)
        {

            if (laudit != null) { 
                _context.LogAudits.Add(laudit);
                _context.SaveChanges();

                return true;
            }

            return false;

        }

        public bool Update(Guid id, LogAudit laudit)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
