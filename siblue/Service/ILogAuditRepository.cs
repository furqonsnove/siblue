using siblue.Model;

namespace siblue.Service
{
    public interface ILogAudit
    {
        public IEnumerable<LogAudit> Get();
        public LogAudit GetById(Guid id);
        public LogAudit Create(LogAudit laudit);
        public LogAudit Update(Guid id, LogAudit laudit);
        public bool Delete(Guid id);
    }
}
