using ElkPrep.Server.Interfaces;
using ElkPrep.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ElkPrep.Server.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class BowController : ControllerBase
    {

        private readonly IBow _IBow;

        public BowController(IBow bow)
        {
            _IBow = bow;
        }

        // Get all bows
        [HttpGet("")]
        public async Task<List<Bow>> GetBows()
        {
            return await Task.FromResult(_IBow.GetAllBows());
        }


        // Get Bow by id
        [HttpGet("{id}")]
        public ActionResult<Bow> GetBow(int id)
        {
            Bow bow = _IBow.GetBow(id);
            if(bow != null)
            {
                return bow;
            }
            return NotFound();
        }

        // Create Bow
        [HttpPost("add")]
        public void CreateBow(Bow bow)
        {
            _IBow.AddBow(bow);
        }

        // Update Bow
        [HttpPut("update/{id}")]
        public void UpdateBow(Bow bow)
        {
            _IBow.UpdateBow(bow);
        }

        // Delete Bow
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteBow(int id)
        {
                _IBow.DeleteBow(id);
                return Ok();
        }

    }
}
