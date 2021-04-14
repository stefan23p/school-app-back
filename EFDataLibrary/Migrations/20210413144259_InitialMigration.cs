using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataLibrary.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    ProfessorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ExamsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.ProfessorID);
                });


            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Semester = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    ExamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<string>(nullable: true),
                    numberOfTasks = table.Column<int>(nullable: true),
                    criteria = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    ProfessorID = table.Column<int>(nullable: true),
                    SubjectID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.ExamID);
                    table.ForeignKey(
                        name: "FK_Exam_Professor_ProfessorID",
                        column: x => x.ProfessorID,
                        principalTable: "Professor",
                        principalColumn: "ProfessorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exam_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorSubject",
                columns: table => new
                {
                    Professor_Id = table.Column<int>(nullable: false),
                    Subject_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorSubject", x => new { x.Professor_Id, x.Subject_Id });
                    table.ForeignKey(
                        name: "FK_ProfessorSubject_Professor_Professor_Id",
                        column: x => x.Professor_Id,
                        principalTable: "Professor",
                        principalColumn: "ProfessorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorSubject_Subject_Subject_Id",
                        column: x => x.Subject_Id,
                        principalTable: "Subject",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "ProfessorID", "Address", "ExamsId", "LastName", "Name" },
                values: new object[,]
                {
                    { 1, "Makedonska,Beograd", 0, "Markovic", "Marko" },
                    { 2, "Goce Delceva,Beograd", 0, "Popovic", "Milos" },
                    { 3, "Svetosavska,Beograd", 0, "Milosevic", "Milica" }
                });

          

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "SubjectID", "Name", "Semester" },
                values: new object[,]
                {
                    { 1, "Mathematics", 1 },
                    { 2, "Operative systems", 1 },
                    { 3, "Economics", 2 },
                    { 4, "Marketing", 2 }
                });


            migrationBuilder.InsertData(
                table: "ProfessorSubject",
                columns: new[] { "Professor_Id", "Subject_Id" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 3, 3 },
                    { 2, 2 },
                    { 1, 2 },
                    { 1, 1 }
                });

           

            migrationBuilder.InsertData(
                table: "Exam",
                columns: new[] { "ExamID", "ProfessorID", "SubjectID", "criteria", "date", "numberOfTasks", "type" },
                values: new object[,]
                {
                    { 4, 1, 2, "easy", "02-05-2021", 5, "Exam" },
                    { 1, 1, 1, "hard", "02-05-2021", 5, "Exam" },
                    { 3, 2, 3, "hard","02-05-2021", 4, "Exam" },
                    { 5, 3, 1, "easy", "02-05-2021", 5, "Coloquium" },
                    { 2, 3, 2, "medium", "02-05-2021", 3, "Coloquium" }
                });
            migrationBuilder.CreateIndex(
                name: "IX_Exam_ProfessorID",
                table: "Exam",
                column: "ProfessorID");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_SubjectID",
                table: "Exam",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorSubject_Subject_Id",
                table: "ProfessorSubject",
                column: "Subject_Id");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "ProfessorSubject");

            

            migrationBuilder.DropTable(
                name: "Professor");

           

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
