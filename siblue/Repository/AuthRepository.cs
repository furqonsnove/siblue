using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using NuGet.Protocol;
using siblue.Db;
using siblue.Model;
using siblue.Service;

namespace siblue.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Employee? Login(string nik, string password)
        {
            var passHash = BCrypt.Net.BCrypt.HashPassword(password);

            var employee =  _context.Employees.Include(e => e.User).Where(e => e.Nik == nik).FirstOrDefault();

            var comparePass = BCrypt.Net.BCrypt.Verify(password, passHash);

            System.Diagnostics.Debug.WriteLine(comparePass);


            if (employee == null) {
                throw new Exception("Unauthorized");
            }

            if (comparePass == false)
            {
                throw new Exception("Unauthorized");
            }

            var res = new Employee();

            res.Name = employee.Name;
            res.Nik = employee.Nik;
            res.Gender = employee.Gender;

            System.Diagnostics.Debug.WriteLine(employee.Name);
            return res;

        }

        public string ResetPassword(string password, string nik)
        {
            var employee = _context.Employees.Include(e => e.User).Where(e => e.Nik == nik).FirstOrDefault();


            var passHash = BCrypt.Net.BCrypt.HashPassword(password);

            var comparePass = BCrypt.Net.BCrypt.Verify(password, employee.User.Password);


            if (comparePass == true)
            {
                return "Password Same As Old";

            }

            employee.User.Password = passHash;

            _context.SaveChanges();

            return "Password Changed";

        }

        public string NewPin(string pin, string nik)
        {
            var employee = _context.Employees.Include(e => e.User).Where(e => e.Nik == nik).FirstOrDefault();

            employee.User.Pin = BCrypt.Net.BCrypt.HashPassword(pin); ;

            _context.SaveChanges();

            return "Pin Created";

        }

        public string UpdatePin(string pin, string nik)
        {
            var employee = _context.Employees.Include(e => e.User).Where(e => e.Nik == nik).FirstOrDefault();

            employee.User.Pin = BCrypt.Net.BCrypt.HashPassword(pin);

            var comparePin = BCrypt.Net.BCrypt.Verify(pin, employee.User.Pin);


            if (comparePin == true)
            {
                return "Pin Same As Old";

            }

            _context.SaveChanges();

            return "Pin Update";

        }


    }
}
