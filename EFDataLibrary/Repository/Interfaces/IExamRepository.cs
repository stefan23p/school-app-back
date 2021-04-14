using EFDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLibrary.Repository.Interfaces
{
    public interface IExamRepository
    {
        Task<IEnumerable<Exam>> GetAll();
        Task<int> AddExam(Exam exam);
        Task<int> DeleteExam(int id);
    }
}
