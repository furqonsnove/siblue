using siblue.Model;

namespace siblue.Service;

public interface IPositionRepository
{
    public IEnumerable<Position> Get();
    public Position GetById(Guid id);
    public Position Create(Position position);
    public Position Update(Guid id, Position position);
    public bool Delete(Guid id);
    public Position ChangeStatus(Guid id);
}