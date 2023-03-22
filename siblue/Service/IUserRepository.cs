using siblue.Model;

namespace siblue.Service
{
    public interface IUserRepository
    {
        public IEnumerable<User> Get();
        public User GetById(Guid id);
        public User Create(User user);
        public User Update(Guid id, User user);
        public bool Delete(Guid id);
    }
}
