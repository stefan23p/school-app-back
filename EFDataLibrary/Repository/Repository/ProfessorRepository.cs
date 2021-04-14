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
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly ILogger _logger;

        public ProfessorRepository(DatabaseContext db, ILogger<ProfessorRepository> logger)
        {
            _dbContext = db;
            _logger = logger;
        }
        public async Task<IEnumerable<Professor>> GetAll()
        {
            return await _dbContext.Professor
                                     .Include(s => s.Subjects)
                                     .ThenInclude(ps => ps.Subject)
                                     .AsNoTracking()
                                     .ToListAsync();
        }

        public async Task<int> AddProfessor(Professor professor)
        {
            try
            {

                var result = await _dbContext.Professor
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.ProfessorID == professor.ProfessorID);
                if (result == null)
                {
                   await  _dbContext.AddAsync(professor);
                   await _dbContext.SaveChangesAsync();
                    try
                    {
                        for (int i = 0; i < professor.NewSubjectsToChange.Count; i++)
                        {
                            professor.NewSubjectsToChange[i].Professor_Id = professor.ProfessorID; 
                        }

                        _dbContext.AddRange(professor.NewSubjectsToChange);
                       await  _dbContext.SaveChangesAsync();
                        return 0;
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e.ToString());
                        return -1;
                    }
                }
                else
                {
                        try
                        {
                             _dbContext.Update(professor);
                            await _dbContext.SaveChangesAsync();


                            _dbContext.AddRange(professor.NewSubjectsToChange);
                            await   _dbContext.SaveChangesAsync();
                            return 0;
                        }
                        catch (Exception e)
                        {
                            _logger.LogError(e.ToString());
                            return -1;
                        }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return -1;
            }
        }

        public async Task<int> DeleteProfessor(int id)
        {
            try
            {
                var itemToRemove = await _dbContext.Professor.SingleOrDefaultAsync(x => x.ProfessorID == id); 
                if (itemToRemove != null)
                {
                    _dbContext.Professor.Remove(itemToRemove);
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


        public async Task<Professor> GetProfessorById(int id)
        {
            try
            {
                return await _dbContext.Professor
                                    .Include(s => s.Subjects)
                                    .ThenInclude(s => s.Subject)
                                    .SingleOrDefaultAsync(s => s.ProfessorID == id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return null;
            }
        }

    
      
        
    }
}
