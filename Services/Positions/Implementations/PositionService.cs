using HR_Service.Controllers;
using HR_Service.Data;
using HR_Service.DTO;
using HR_Service.Models;
using HR_Service.Models.Enitty;
using HR_Service.Services.Positions.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HR_Service.Services.Positions.Implementations;

public class PositionService : IPosition
{
    private readonly ApiDBContext _api_db_context;

    public PositionService(ApiDBContext api_db_context)
    {
        _api_db_context = api_db_context;
    }

    public async Task<IEnumerable<Position>> GetAll(string search)
    {
        var result = await _api_db_context.positions
            .Where(x => search == "" || x.code.ToUpper().Contains(search.ToUpper()) || x.name.ToLower().Contains(search.ToLower()))
            .AsNoTracking().ToListAsync();
        return result;
    }

    public async Task<Position> GetById(Guid id)
    {
        var result = await _api_db_context.positions.FirstOrDefaultAsync(x => x.id == id);
        if (result == null)
            throw new Exception("Not Found");
        return result;
    }

    public async Task<Position> Insert(PositionDTO input)
    {
        if (await IsPositionCodeExist(input.code))
            throw new Exception("Position code already exists");
        if (input.code.Length > 5)
            throw new Exception("Position code must contain max 5 characters");
        try
        {
            var obj = new Position
            {
                code = input.code.ToUpper(),
                name = input.name,
                is_active = input.is_active,
                level = input.level
            };
            _api_db_context.positions.Add(obj);
            await _api_db_context.SaveChangesAsync();
            await InsertLogAudit("Add Data Position", $"Add Position: Name {obj.name}, code {obj.code}, level {obj.level}, is_active {obj.is_active}");
            return obj;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error: {ex.Message}");
        }

    }

    public Task<Position> Update(Guid id, PositionDTO input)
    {
        // check code exist or not
        // check if there is any employee that use that position if input.is_active=false
        // add log audit
        throw new NotImplementedException();
    }

    public Task<Position> UpdateStatus(Guid id, bool is_active)
    {
        // check if there is any employee that use that position
        // add log audit
        throw new NotImplementedException();
    }

    private async Task<bool> IsPositionCodeExist(string code)
    {
        return await _api_db_context.positions.AnyAsync(x => x.code.ToUpper() == code.ToUpper());
    }

    private async Task<LogAudit> InsertLogAudit(string activity, string detail)
    {
        var log_audit = new LogAudit
        {
            modul = "Position",
            activity = activity,
            detail = detail,
            created_at = DateTime.UtcNow.AddHours(7),
            updated_at = DateTime.UtcNow.AddHours(7),
        };
        _api_db_context.log_audit.Add(log_audit);
        await _api_db_context.SaveChangesAsync();
        return log_audit;
    }
}