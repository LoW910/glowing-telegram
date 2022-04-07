using ElkPrep.Server.Interfaces;
using ElkPrep.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ElkPrep.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrowController : ControllerBase
    {
        private readonly IArrow _IArrow;

        public ArrowController(IArrow iArrow)
        {
            _IArrow = iArrow;
        }


        // Get list of all arrows
        [HttpGet("")]
        public async Task<List<Arrow>> GetArrows()
        {
            return await Task.FromResult(_IArrow.GetAllArrows());
        }

        // Get Arrow by id
        [HttpGet("{id}")]
        public ActionResult<Arrow> GetArrow(int id)
        {
            Arrow arrow = _IArrow.GetArrow(id);
            if (arrow != null)
            {
                return arrow;
            }
            return NotFound();
        }

        // Create Arrow
        [HttpPost("add")]
        public void CreateArrow(Arrow arrow)
        {
            _IArrow.AddArrow(arrow);
        }

        // Update Arrow
        [HttpPut("update/{id}")]
        public void UpdateArrow(Arrow arrow)
        {
            _IArrow.UpdateArrow(arrow);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteArrow(int id)
        {
            _IArrow.DeleteArrow(id);
            return Ok();
        }

    }
}
