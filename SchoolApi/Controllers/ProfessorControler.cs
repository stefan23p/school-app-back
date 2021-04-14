using EFDataLibrary.DataAccess;
using EFDataLibrary.Models;
using EFDataLibrary.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SchoolApi.Controllers
{
    [Route("api/professor/")]
    [ApiController]
    public class ProfessorControler : ControllerBase
    {
        private readonly IProfessorRepository _professorRepository;
        public ProfessorControler( IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetProfessors()
        {
            var result = await _professorRepository.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfessorById(int id)
        {
            var result = await _professorRepository.GetProfessorById(id);
            return Ok(result);
        }

        [HttpPost("addProfessor")]
        public async Task<IActionResult> AddProfessor([FromBody] Professor professor)
        {
            if (ModelState.IsValid)
            {
                var result = await _professorRepository.AddProfessor(professor);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            if (ModelState.IsValid)
            {
              var result = await _professorRepository.DeleteProfessor(id);
              return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
