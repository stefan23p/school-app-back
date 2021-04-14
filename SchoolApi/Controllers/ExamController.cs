using EFDataLibrary.DataAccess;
using EFDataLibrary.Models;
using EFDataLibrary.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SchoolApi.Controllers
{
    [Route("api/exams")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamRepository _examRepository;
        public ExamController( IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetExams()
        {
            var result = await _examRepository.GetAll();
            return Ok(result);
        }

        [HttpPost("addExam")]
        public async Task<IActionResult> AddExam([FromBody] Exam exam)
        {
            var result = await _examRepository.AddExam(exam);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var result = await _examRepository.DeleteExam(id);
            return Ok(result);
        }



    }
}
