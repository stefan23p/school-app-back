using EFDataLibrary.DataAccess;
using EFDataLibrary.Models;
using EFDataLibrary.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDataLibrary.Repository.Repository
{
    public class SubjectRepository : ISubjectRepository
    {

        private readonly DatabaseContext _dbContext;
        private readonly ILogger _logger;

        public SubjectRepository(DatabaseContext db, ILogger<SubjectRepository> logger)
        {
            _dbContext = db;
            _logger = logger;
        }
        public async Task<IEnumerable<Subject>> GetAll()
        {
            return await _dbContext.Subject.ToListAsync();
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            try
            {
                return await _dbContext.Subject.SingleOrDefaultAsync(s => s.SubjectID == id);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message.ToString());
                return null;
            }
        }

        public async Task<int> AddSubject(Subject subject)
        {
            try
            {
                var result = await _dbContext.Subject
                                        .AsNoTracking()
                                        .SingleOrDefaultAsync(s => s.SubjectID == subject.SubjectID);
                if (result == null)
                {
                    _dbContext.Add(subject);
                    _dbContext.SaveChanges();
                }
                else 
                {
                    _dbContext.Subject.Update(subject);
                    _dbContext.SaveChanges();
                }
                
                return 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return -1;
            }
        }

        public async Task<int> DeleteSubject(int id)
        {
            try
            {
                var itemToRemove = await _dbContext.Subject.SingleOrDefaultAsync(x => x.SubjectID == id);
                if (itemToRemove != null)
                {
                    _dbContext.Subject.Remove(itemToRemove);
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
