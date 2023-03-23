using siblue.Db;
using siblue.Model;
using siblue.Service;

namespace siblue.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Employee> Get()
    {
        return _context.Employees.ToList();
        //throw new NotImplementedException();
    }

    public Employee GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Employee> Create(Employee emp)
    {
        var user = new User();
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        emp.UserId = user.Id;
        _context.Employees.Add(emp);
        await _context.SaveChangesAsync();
        return emp;
    }

    public Employee Update(Guid id, Employee emp)
    {
        throw new NotImplementedException();
    }

    public bool Delete(Guid id)
    {
        throw new NotImplementedException();
    }

}