using siblue.Model;

namespace siblue.Service;

public interface IEmployeeRepository
{
    public IEnumerable<Employee> Get();
    public Employee GetById(Guid id);
    public Task<Employee> Create(Employee emp);
    public Employee Update(Guid id, Employee emp);
    public bool Delete(Guid id);

}