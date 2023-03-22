using Microsoft.AspNetCore.Mvc;
using siblue.Model;
using siblue.Service;

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
}