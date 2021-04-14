using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataLibrary.Models
{
   public class Exam
    {
        public int ExamID { get; set; }
        public string date { get; set; }
        public int numberOfTasks { get; set; }
        public string criteria { get; set; }
        public string type { get; set; }
        public Professor Professor { get; set; }
        public int? ProfessorID { get; set; }
        public Subject Subject { get; set; }
        public int? SubjectID { get; set; }

    }
}
