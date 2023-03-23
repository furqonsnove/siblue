using Microsoft.AspNetCore.Mvc;
using siblue.Model;
using siblue.Service;

namespace siblue.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionController
{
    private readonly IPositionRepository _repo;
    private readonly ILogAuditRepository _repoAudit;

    public PositionController(IPositionRepository repo, ILogAuditRepository repoAudit)
    {
        _repo = repo;
        _repoAudit = repoAudit;
    }

    [HttpGet(Name = "Get Position")]
    public IActionResult GetPositions()
    {
        var result = _repo.Get();

        var laudit = new LogAudit()
        {
            Modul = "Positions",
            Activity = "Get",
            Detail = $"Position Data",

        };

        _repoAudit.Create(laudit);
        return new ObjectResult(new Response().Send("Positions Fetched", result, StatusCodes.Status200OK));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var result = _repo.GetById(id);


        var laudit = new LogAudit()
        {
            Modul = "Positions",
            Activity = "Details",
            Detail = $"Position Data",

        };

        _repoAudit.Create(laudit);

        return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
    } 

    [HttpPost]
    public IActionResult CreateUser(Position position)
    {
        var result = _repo.Create(position);

        var laudit = new LogAudit()
        {
            Modul = "Positions",
            Activity = "Create",
            Detail = $"Position Data",

        };

        _repoAudit.Create(laudit);


        return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created };
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdatePosition(Guid id, Position position)
    {
        var result = _repo.Update(id, position);


        var laudit = new LogAudit()
        {
            Modul = "Positions",
            Activity = "Update",
            Detail = $"Position Data",

        };

        _repoAudit.Create(laudit);

        return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeletePosition(Guid id)
    {
        var result = _repo.Delete(id);


        var laudit = new LogAudit()
        {
            Modul = "Positions",
            Activity = "Delete",
            Detail = $"Position Data",

        };

        _repoAudit.Create(laudit);

        return new ObjectResult(null) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpPut("{id:guid}/status")]
    public IActionResult ChangePositionStatus(Guid id)
    {
        var result = _repo.ChangeStatus(id);

        var laudit = new LogAudit()
        {
            Modul = "Positions",
            Activity = "Change",
            Detail = $"Position Status Data",

        };

        _repoAudit.Create(laudit);

        return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
    }
}