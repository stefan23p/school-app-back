using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataLibrary.Models
{
   public class ProfessorSubject
    {
        public int Professor_Id { get; set; }
        public Professor Professor { get; set; }

        public int Subject_Id { get; set; }
        public Subject Subject { get; set; }
    }
}
