
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
using siblue.Model;
using siblue.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Net.WebRequestMethods;

namespace siblue.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly ILogAuditRepository _repoAudit;


        public AuthController(IAuthRepository repo, ILogAuditRepository repoAudit)
        {
            _repo = repo;
            _repoAudit = repoAudit;
        }

        [HttpPost(Name = "Login")]
        public IActionResult Login(string nik, string password)
        {
            var result = _repo.Login(nik, password);


            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ijurkbdlhmklqacwqzdxmkkhvqowlyqa"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:7218/",
                audience: "https://localhost:7218/",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(6),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            var data = new ObjectResult(new
            {
                name = result.Name,
                nik = result.Nik,
                gender = result.Gender,
                token = tokenString
            });

            var laudit = new LogAudit()
            {
                Modul = "Authenctication",
                Activity = "Login",
                Detail = $"{nik}",

            };

/*            System.Diagnostics.Debug.WriteLine(laudit.ToJson());*/

            _repoAudit.Create(laudit);


            return new ObjectResult(new Response().Send("Success", data, StatusCodes.Status200OK));
        }

        [HttpPut(Name = "ResetPassword")]
        public IActionResult ResetPassword(string password, string nik)
        {

            var result = _repo.ResetPassword(password, nik);

            System.Diagnostics.Debug.WriteLine($"User = {password}");

            var laudit = new LogAudit()
            {
                Modul = "Authenctication",
                Activity = "Reset Password",
                Detail = $"{nik}",

            };

            /*            System.Diagnostics.Debug.WriteLine(laudit.ToJson());*/

            _repoAudit.Create(laudit);


            return new ObjectResult(new Response().SendMessage($"{result}", StatusCodes.Status200OK));


        }

        [HttpPost(Name = "CreatePin")]
        public IActionResult CreatePin(string pin, string nik)
        {

            var result = _repo.NewPin(pin, nik);

            var laudit = new LogAudit()
            {
                Modul = "Authenctication",
                Activity = "Create New Pin",
                Detail = $"{nik}",

            };

            /*            System.Diagnostics.Debug.WriteLine(laudit.ToJson());*/

            _repoAudit.Create(laudit);


            return new ObjectResult(new Response().SendMessage($"{result}", StatusCodes.Status200OK));

        }

        [HttpPut(Name = "UpdatePin")]
        public IActionResult UpdatePin(string pin, string nik)
        {

            var result = _repo.UpdatePin(pin, nik);

            var laudit = new LogAudit()
            {
                Modul = "Authenctication",
                Activity = "Update Pin",
                Detail = $"{nik}",

            };

            /*            System.Diagnostics.Debug.WriteLine(laudit.ToJson());*/

            _repoAudit.Create(laudit);


            return new ObjectResult(new Response().SendMessage($"{result}", StatusCodes.Status200OK));


        }
    }
}
