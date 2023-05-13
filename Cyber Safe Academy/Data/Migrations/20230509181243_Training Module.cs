using Microsoft.EntityFrameworkCore.Migrations;

namespace Cyber_Safe_Academy.Data.Migrations
{
    public partial class TrainingModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create the "TrainingModules" table with "Id" and "Name" columns
            migrationBuilder.CreateTable(
              name: "TrainingModules",
              columns: table => new
              {
                  Id = table.Column<int>(nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  Name = table.Column<string>(nullable: true)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_TrainingModules", x => x.Id);
              });
            // Create the "TrainingModuleMaterials" table with "Id", "TrainingModuleId", and "Material" columns
            // Add a foreign key constraint to associate the "TrainingModuleMaterials" with "TrainingModules" table
            migrationBuilder.CreateTable(
                name: "TrainingModuleMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingModuleId = table.Column<int>(nullable: false),
                    Material = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingModuleMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingModuleMaterials_TrainingModules_TrainingModuleId",
                        column: x => x.TrainingModuleId,
                        principalTable: "TrainingModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Create an index on the "TrainingModuleMaterials" table to optimize queries involving the "TrainingModuleId" column
            migrationBuilder.CreateIndex(
                name: "IX_TrainingModuleMaterials_TrainingModuleId",
                table: "TrainingModuleMaterials",
                column: "TrainingModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the "TrainingModuleMaterials" and "TrainingModules" tables
            migrationBuilder.DropTable(
               name: "TrainingModuleMaterials");

            migrationBuilder.DropTable(
                name: "TrainingModules");
        }
    }
}
