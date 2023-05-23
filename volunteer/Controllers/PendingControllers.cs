using Microsoft.AspNetCore.Mvc;
using volunteer.Data;
using volunteer.DTO;
using volunteer.Models;

namespace Massarat.Controllers
{
    public class PendingPostController : Controller
    {
        private readonly VolunteerContext _context;

        public PendingPostController(VolunteerContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/[Controller]/[Action]")]

        public ICollection<Pendingpost> GetAllPending()
        {
            return _context.Pendingposts.ToList();
        }





        [HttpGet]
        [Route("api/[Controller]/[Action]")]
        public IActionResult GetPendingPostByID(int? PendingpostId)
        {
            if (PendingpostId == null)
                return NoContent();

            var PendingInfo = _context.Pendingposts.FirstOrDefault(m => m.PendingpostId == PendingpostId);

            if (PendingInfo == null)
            {
                return NoContent();
            }

            var PendingDTO = new pendingDTO()
            {
                PostName = PendingInfo.PostName,
                UserId = PendingInfo.UserId,

            };
            return Ok(PendingDTO);
        }
    }
}
