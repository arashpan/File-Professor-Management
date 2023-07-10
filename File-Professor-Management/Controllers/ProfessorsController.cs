using File_Professor_Management.Data;
using File_Professor_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace File_Professor_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorsController : Controller
    {
        private readonly FileProfessorManagementAPIDbContext dbContext;

        public ProfessorsController(FileProfessorManagementAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<Professor>> GetAll()
        {
            return (await dbContext.Professors.ToListAsync());
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetProfessor([FromRoute] Guid id)
        {
            var prof = await dbContext.Professors.FindAsync(id);
            if (prof != null)
            {
                return Ok(prof);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddProfessor(AddProfessorRequest addProfessorRequest)
        {
            Professor professor = new Professor()
            {
                Id = Guid.NewGuid(),
                Address = addProfessorRequest.Address,
                Age = addProfessorRequest.Age,
                Email = addProfessorRequest.Email,
                FirstName = addProfessorRequest.FirstName,
                LastName = addProfessorRequest.LastName,
                Lisence = addProfessorRequest.Lisence,
                PhoneNumber = addProfessorRequest.PhoneNumber,
            };

            await dbContext.Professors.AddAsync(professor);
            await dbContext.SaveChangesAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest(professor);
            }
            return Ok(professor);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateProfessor([FromRoute] Guid id, UpdateProfessorRequest updateProfessor)
        {
            var prof = await dbContext.Professors.FindAsync(id);
            if (prof != null)
            {
                prof.Age = updateProfessor.Age;
                prof.Lisence = updateProfessor.Lisence;
                prof.Email = updateProfessor.Email;
                prof.Address = updateProfessor.Address;
                prof.PhoneNumber = updateProfessor.PhoneNumber;
                prof.FirstName = updateProfessor.FirstName;
                prof.LastName = updateProfessor.LastName;

                await dbContext.SaveChangesAsync();
                return Ok(prof);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> RemoveProfessor([FromRoute] Guid id)
        {
            var prof = await dbContext.Professors.FindAsync(id);
            if (prof != null)
            {
                dbContext.Professors.Remove(prof);
                await dbContext.SaveChangesAsync();
                return Ok(prof);
            }
            return NotFound();
        }
    }
}
