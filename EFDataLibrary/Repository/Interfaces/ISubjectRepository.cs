using EFDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLibrary.Repository.Interfaces
{
   public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAll();
        Task<Subject> GetSubjectById(int id);
        Task<int> AddSubject(Subject subject);
        Task<int> DeleteSubject(int id);
    }
}
