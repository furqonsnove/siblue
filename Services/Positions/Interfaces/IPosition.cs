
namespace HR_Service.Services.Positions.Interfaces;

public interface IPosition<Position>
{
  Task<IEnumerable<Position>> GetAll();
  Task<Position> GetById(string id);
  Task<Position> Insert(Position position);
}