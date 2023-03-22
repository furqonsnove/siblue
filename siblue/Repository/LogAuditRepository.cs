using siblue.Db;
using siblue.Model;

namespace siblue.Repository
{
    public class LogAuditRepository
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

        public LogAudit Create(LogAudit laudit)
        {
            throw new NotImplementedException();
        }

        public LogAudit Update(Guid id, LogAudit laudit)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }


}
