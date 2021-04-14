using EFDataLibrary.DataAccess;
using EFDataLibrary.Models;
using EFDataLibrary.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLibrary.Repository.Repository
{
    public class ExamRepository : IExamRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly ILogger _logger;
        public ExamRepository(ILogger<ExamRepository> logger , DatabaseContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Exam>> GetAll()
        {



            return await _dbContext.Exam
                                     .Include(p => p.Professor)
                                     .Include(s => s.Subject)
                                     .AsNoTracking()
                                     .ToListAsync();
        }
        public async Task<int> AddExam(Exam exam)
        {
            try
            {
                _dbContext.Add(exam);
                await  _dbContext.SaveChangesAsync();
                

            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
            return 1;
        }

        public async Task<int> DeleteExam(int id)
        {
            try
            {
                var itemToRemove = await _dbContext.Exam.SingleOrDefaultAsync(x => x.ExamID == id);
                if (itemToRemove != null)
                {
                    _dbContext.Exam.Remove(itemToRemove);
                    await _dbContext.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return -1;
            }
        }


     
    }
}
