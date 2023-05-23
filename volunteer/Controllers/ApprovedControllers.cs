using Microsoft.AspNetCore.Mvc;
using volunteer.Data;
using volunteer.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using volunteer.Models;


namespace volunteer.Controllers
{
    public class ApprovedPostController : Controller
    {
        private readonly VolunteerContext _context;
        public readonly IMapper _mapper;
        public ApprovedPostController(VolunteerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }
        [HttpGet]
        [Route("api/[Controller]/[Action]")]

        public ICollection<Aprovedpost> GetAllMentors()
        {
            return _context.Aprovedposts.ToList();
        }
        [HttpPost]
        [Route("api/[Controller]/[Action]")]
        public IActionResult CreateApproved(AprovedDTO approvedDTO)
        {
            if (approvedDTO == null)
                return NoContent();

            var AprovedPost = new Aprovedpost
            {
                ApprovedPostId = approvedDTO.ApprovedPostId,
                Postname = approvedDTO.Postname,
                Approvedby = approvedDTO.Approvedby,
                Postdescribtion = approvedDTO.Postdescribtion,



            };
            _context.Aprovedposts.Add(AprovedPost);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        [Route("api/[Controller]/[Action]")]
        public IActionResult Updateapproved(int? ApprovedPostId, AprovedDTO? aprovedDTO)
        {
            if (ApprovedPostId == null)
                return NoContent();

            if (aprovedDTO.Postname == null
                && aprovedDTO.Approvedby == null )
                return StatusCode(404, "Enter Some data !");
            //before updATE
            var StudentToUpdate = _context.Aprovedposts
                .AsNoTracking()
                .FirstOrDefault(s => s.ApprovedPostId == ApprovedPostId);
            if (StudentToUpdate == null)
                return NoContent();

            ////Update the exist student
            //StudentToUpdate.Name = studentDTO.Name;
            //StudentToUpdate.Age = studentDTO.Age;
            //StudentToUpdate.PhoneNumber = studentDTO.PhoneNumber;
            //StudentToUpdate.Gender = studentDTO.Gender;
            //StudentToUpdate.UpdateDate = DateTime.Now;
            //StudentToUpdate.UpdateBy = "Ruaa";

            var UpdatedStudent = _mapper.Map<AprovedDTO, Aprovedpost>(aprovedDTO);
            UpdatedStudent.ApprovedPostId = StudentToUpdate.ApprovedPostId;
            UpdatedStudent.Postname = StudentToUpdate.Postname;


            _context.Aprovedposts.Update(UpdatedStudent);
            _context.SaveChanges();
            return Ok();

        }


    }
}