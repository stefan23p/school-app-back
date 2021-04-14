using EFDataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataLibrary
{
    public static  class ModelBuilderExtension
    {
       
        public static void SeedInitialData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor>()
                .HasData(
                new Professor {ProfessorID = 1, Name = "Marko", LastName = "Markovic", Address = "Makedonska,Beograd" },
                new Professor { ProfessorID = 2, Name = "Milos", LastName = "Popovic", Address = "Goce Delceva,Beograd" },
                new Professor { ProfessorID = 3, Name = "Milica", LastName = "Milosevic", Address = "Svetosavska,Beograd" }
                );
            modelBuilder.Entity<Subject>()
                .HasData(
                new Subject { SubjectID = 1, Name = "Mathematics", Semester = 1 },
                new Subject { SubjectID = 2, Name = "Operative systems", Semester = 1 },
                new Subject { SubjectID = 3, Name = "Economics", Semester = 2 },
                new Subject { SubjectID = 4, Name = "Marketing", Semester = 2 }
                );
            modelBuilder.Entity<ProfessorSubject>()
                .HasData(
                new ProfessorSubject { Professor_Id = 1, Subject_Id = 1 },
                new ProfessorSubject { Professor_Id = 1, Subject_Id = 2 },
                new ProfessorSubject { Professor_Id = 2, Subject_Id = 2 },
                new ProfessorSubject { Professor_Id = 3, Subject_Id = 3 },
                new ProfessorSubject { Professor_Id = 1, Subject_Id = 4 }
                );
         

            modelBuilder.Entity<Exam>()
                .HasData(
                new Exam {ExamID =1, type = "Exam", criteria = "hard", date = "02-05-2021", numberOfTasks = 5,ProfessorID =1,SubjectID=1 },
                new Exam { ExamID = 2, type = "Coloquium", criteria = "medium",date= "02-05-2021", numberOfTasks = 3,ProfessorID=1,SubjectID =2 },
                new Exam { ExamID = 3, type = "Exam", criteria = "hard", date = "02-05-2021", numberOfTasks = 4,ProfessorID=2,SubjectID = 4 },
                new Exam { ExamID = 4, type = "Exam", criteria = "easy", date = "02-05-2021", numberOfTasks = 5,ProfessorID =3,SubjectID=5 },
                new Exam { ExamID = 5, type = "Coloquium", criteria = "easy", date = "02-05-2021", numberOfTasks = 5,ProfessorID =4,SubjectID=2 }
                );


        }
    }
}
