using siblue.Model;

namespace siblue.Service;

public interface IEmployeeRepository
{
    public IEnumerable<Employee> Get();
    public Employee GetById(Guid id);
    public bool Create(Employee emp);
    public bool Update(Guid id, Employee emp);
    public bool Delete(Guid id);
}