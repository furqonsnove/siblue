
using siblue.Model;

namespace siblue.Service
{
    public interface IAuthRepository
    {
        public Employee Login(string nik, string password);
        public string ResetPassword(string password, string nik);

        public string NewPin(string pin, string nik);

        public string UpdatePin(string pin, string nik);




    }
}
