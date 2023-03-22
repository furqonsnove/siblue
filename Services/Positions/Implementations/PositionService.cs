using HR_Service.Data;
using HR_Service.Models.Enitty;
using HR_Service.Services.Positions.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HR_Service.Services.Positions.Implementations;

public class PositionService : IPosition<Position>
{
  private readonly ApiDBContext _api_db_context;

  public PositionService(ApiDBContext api_db_context)
  {
    _api_db_context = api_db_context;
  }

  public async Task<IEnumerable<Position>> GetAll()
  {
    var result = await _api_db_context.positions.AsNoTracking().ToListAsync();
    return result;
  }

  public Task<Position> GetById(String id)
  {
    throw new NotImplementedException();
  }

  public Task<Position> Insert(Position position)
  {
    throw new NotImplementedException();
  }
}