using EFDataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFDataLibrary.Repository.Interfaces
{
    public interface IProfessorRepository
    {
        Task<IEnumerable<Professor>> GetAll();
        Task<Professor> GetProfessorById(int id);
        Task<int> DeleteProfessor(int id);
        Task<int> AddProfessor(Professor professor);
    }
}
