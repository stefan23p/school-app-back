using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDataLibrary.Models
{
    public class Professor
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProfessorID { get; set; }
        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Address { get; set; }
        public List<Exam> Exams { get; set; } = new List<Exam>();

        public List<ProfessorSubject> Subjects { get; set; } = new List<ProfessorSubject>();

        [NotMapped]
        public List<ProfessorSubject> NewSubjectsToChange { get; set; } = new List<ProfessorSubject>();
    }
}
