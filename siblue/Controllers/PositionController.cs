using Microsoft.AspNetCore.Mvc;
using siblue.Model;
using siblue.Service;

namespace siblue.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController
    {
        private readonly IPositionRepository _repo;

        public PositionController(IPositionRepository repo)
        {
            _repo = repo;
        }

        [HttpGet(Name = "Get Position")]
        public IActionResult GetPositions()
        {
            var result = _repo.Get();
            return new ObjectResult(new Response().Send("Positions Fetched", result, StatusCodes.Status200OK));
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var result = _repo.GetById(id);
            return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpPost]
        public IActionResult CreateUser(Position position)
        {
            var result = _repo.Create(position);
            return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdatePosition(Guid id, Position position)
        {
            var result = _repo.Update(id, position);
            return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeletePosition(Guid id)
        {
            var result = _repo.Delete(id);
            return new ObjectResult(null) { StatusCode = StatusCodes.Status200OK };
        }

        [HttpPut("{id:guid}/status")]
        public IActionResult ChangePositionStatus(Guid id)
        {
            var result = _repo.ChangeStatus(id);
            return new ObjectResult(result) { StatusCode = StatusCodes.Status200OK };
        }
    }
}

