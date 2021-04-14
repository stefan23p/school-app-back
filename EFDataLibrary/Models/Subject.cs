using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDataLibrary.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public int Semester { get; set; }
        public List<Exam> Exams { get; set; } = new List<Exam>();
        public ICollection<ProfessorSubject> Professors { get; set; } = new List<ProfessorSubject>();
    }
}
