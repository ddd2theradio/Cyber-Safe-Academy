using Microsoft.EntityFrameworkCore.Migrations;

namespace Cyber_Safe_Academy.Data.Migrations
{
    public partial class Quiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create the "Quiz" table with "ID", "Name", and "TrainingModuleID" columns
            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingModuleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.ID);
                });

            // Create the "QuizQuestion" table with "ID", "QuizID", "Question", "CorrectAnswer", "IncorrectAnswer1", "IncorrectAnswer2", and "IncorrectAnswer3" columns
            // Add a foreign key constraint to associate the "QuizQuestion" table with the "Quiz" table
            migrationBuilder.CreateTable(
                name: "QuizQuestion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuizID = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncorrectAnswer1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncorrectAnswer2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncorrectAnswer3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QuizQuestion_Quiz_QuizID",
                        column: x => x.QuizID,
                        principalTable: "Quiz",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            // Create an index on the "QuizQuestion" table to optimize queries involving the "QuizID" column
            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_QuizID",
                table: "QuizQuestion",
                column: "QuizID");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the "QuizQuestion" and "Quiz" tables
            migrationBuilder.DropTable(
                name: "QuizQuestion");


            migrationBuilder.DropTable(
                name: "Quiz");

        }
    }
}
