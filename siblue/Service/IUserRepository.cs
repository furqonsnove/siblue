using siblue.Model;

namespace siblue.Service
{
    public interface IUserRepository
    {
        public IEnumerable<User> Get();
        public User GetById(Guid id);
        public bool Create(User user);
        public bool Update(Guid id, User user);
        public bool Delete(Guid id);
    }
}
