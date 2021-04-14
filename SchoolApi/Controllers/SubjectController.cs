using EFDataLibrary.DataAccess;
using EFDataLibrary.Models;
using EFDataLibrary.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SchoolApi.Controllers
{
    [Route("api/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetSubjects()
        {
            var result = await _subjectRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectsById(int id)
        {
            var result = await _subjectRepository.GetSubjectById(id);
            return Ok(result);
        }

        [HttpPost("addSubject")]
        public async Task<IActionResult> AddSubject([FromBody]Subject subject)
        {
            var result = await _subjectRepository.AddSubject(subject);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var result = await _subjectRepository.DeleteSubject(id);
            return Ok(result);
        }

    }
}
