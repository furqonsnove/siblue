using siblue.Model;

namespace siblue.Service
{
    public interface IPaidLeaveApplication
    {
        public IEnumerable<PaidLeaveApplication> Get();
        public PaidLeaveApplication GetById(Guid id);
        public bool Create(PaidLeaveApplication paidLeaveApp);
        public bool Update(Guid id, PaidLeaveApplication paidLeaveApp);
        public bool Delete(Guid id);
    }
}
