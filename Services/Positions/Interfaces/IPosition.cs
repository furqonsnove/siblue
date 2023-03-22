
using HR_Service.Controllers.Positions;
using HR_Service.Models.Enitty;

namespace HR_Service.Services.Positions.Interfaces;

public interface IPosition
{
  Task<IEnumerable<Position>> GetAll();
  Task<Position> GetById(Guid id);
  Task<Position> Insert(PositionInput position);
  Task<Position> Update(Guid id, PositionInput position);
  Task<Position> UpdateStatus(Guid id, bool is_active);
}