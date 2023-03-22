using siblue.Db;
using siblue.Model;
using siblue.Service;

namespace siblue.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
            //throw new NotImplementedException();
        }
        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Create(User user)
        {
            throw new NotImplementedException();
        }

        public bool Update(Guid id, User user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
