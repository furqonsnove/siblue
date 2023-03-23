using MessagePack;
using Microsoft.AspNetCore.Mvc;
using siblue.Model;
using siblue.Service;

namespace siblue.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _repo;

    private readonly ILogAuditRepository _repoAudit;


    public EmployeeController(IEmployeeRepository repo, ILogAuditRepository repoAudit)
    {
        _repo = repo;
        _repoAudit = repoAudit;
    }

    [HttpGet(Name = "GetEmployee")]
    public IEnumerable<Employee> GetEmployees()
    {
        var laudit = new LogAudit()
        {
            Modul = "Employee",
            Activity = "Get",
            Detail = $"Employee Data",

        };

        _repoAudit.Create(laudit);

        return _repo.Get();
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(Employee emp)
    {
        var result = await _repo.Create(emp);

        var laudit = new LogAudit()
        {
            Modul = "Employee",
            Activity = "Create",
            Detail = $"Employee Data",

        };

        _repoAudit.Create(laudit);

        return new ObjectResult(new Response().Send("Employee created", result, StatusCodes.Status201Created));
    }

}