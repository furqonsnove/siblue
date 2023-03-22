using siblue.Db;
using siblue.Model;
using siblue.Service;

namespace siblue.Repository;

public class PositionRepository: IPositionRepository
{
    private readonly ApplicationDbContext _context;

    public PositionRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Position> Get()
    {
        return _context.Positions.ToList();
    }

    public Position GetById(Guid id)
    {
        return _context.Positions.Find(id)!;
    }

    public Position Create(Position position)
    {
        _context.Positions.Add(position);
        _context.SaveChanges();
        return position;
    }

    public Position Update(Guid id, Position position)
    {
        _context.Positions.Update(position);
        _context.SaveChanges();
        return position;
    }

    public bool Delete(Guid id)
    {
        var pos = _context.Positions.Find(id)!;
        _context.Positions.Remove(pos);
        _context.SaveChanges();
        return true;
    }

    public Position ChangeStatus(Guid id)
    {
        var pos = _context.Positions.Find(id)!;
        pos.IsActive = !pos.IsActive;
        _context.SaveChanges();
        return pos;
    }
}