using EFDataLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataLibrary.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options): base(options) 
        {
        }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<ProfessorSubject> ProfessorSubject { get; set; }
        public DbSet<Exam> Exam { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfessorSubject>().HasKey(ps => new { ps.Professor_Id, ps.Subject_Id });
            modelBuilder.Entity<ProfessorSubject>()
                .HasOne<Professor>(ps => ps.Professor)
                .WithMany(p => p.Subjects)
                .HasForeignKey(ps => ps.Professor_Id);

            modelBuilder.Entity<ProfessorSubject>()
              .HasOne<Subject>(ps => ps.Subject)
              .WithMany(p => p.Professors)
              .HasForeignKey(ps => ps.Subject_Id);


            modelBuilder.Entity<Exam>()
                 .HasOne(e => e.Professor)
                 .WithMany(p => p.Exams)
                 .HasForeignKey(d => d.ProfessorID)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_Exam_Professor");

            modelBuilder.Entity<Exam>()
                 .HasOne(e => e.Subject)
                 .WithMany(p => p.Exams)
                 .HasForeignKey(d => d.SubjectID)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_Exam_Subject");

              modelBuilder.SeedInitialData();

        }

        

    }
}
