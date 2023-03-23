using HR_Service.DTO;
using HR_Service.Models.Enitty;

namespace HR_Service.Services.Positions.Interfaces;

public interface IPosition
{
    Task<IEnumerable<Position>> GetAll(string search);
    Task<Position> GetById(Guid id);
    Task<Position> Insert(PositionDTO position);
    Task<Position> Update(Guid id, PositionDTO position);
    Task<Position> UpdateStatus(Guid id, bool is_active);
}