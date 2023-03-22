using siblue.Model;

namespace siblue.Service;
    public interface ILogNotifRepository
    {
        public IEnumerable<LogNotif> Get();
        public LogNotif GetById(Guid id);
        public bool Create(LogNotif lnotif);
        public bool Update(Guid id, LogNotif lnotif);
        public bool Delete(Guid id);
    }
