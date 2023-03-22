using siblue.Model;

namespace siblue.Service
{
    public interface ILogAuditRepository
    {
        public IEnumerable<LogAudit> Get();
        public LogAudit GetById(Guid id);
        public bool Create(LogAudit laudit);
        public bool Update(Guid id, LogAudit laudit);
        public bool Delete(Guid id);
    }
}
