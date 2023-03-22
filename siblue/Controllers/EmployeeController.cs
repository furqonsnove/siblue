using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using siblue.Model;
using siblue.Service;
using System.Threading.Tasks;

namespace siblue.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _repo;

    public EmployeeController(IEmployeeRepository repo)
    {
        _repo = repo;
    }

    [HttpGet(Name = "GetEmployee")]
    public IEnumerable<Employee> GetEmployees()
    {
        return _repo.Get();
    }

    [HttpPost]
    public async Task<IActionResult>  CreateEmployee(Employee emp)
    {
        var result = await _repo.Create(emp);
        return new ObjectResult(new Response().Send("Employee created", result, StatusCodes.Status201Created));
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> ChangeStatus(Guid id)
    {
        var result = await _repo.ChangeStatus(id);
        return new ObjectResult(new Response().Send("Employee status changed", result, StatusCodes.Status200OK));

    }
}