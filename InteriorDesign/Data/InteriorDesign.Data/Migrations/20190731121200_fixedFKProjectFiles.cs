using Microsoft.EntityFrameworkCore.Migrations;

namespace InteriorDesign.Data.Migrations
{
    public partial class fixedFKProjectFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectFiles",
                table: "ProjectFiles");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "ProjectFiles",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProjectFiles_Id",
                table: "ProjectFiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectFiles",
                table: "ProjectFiles",
                columns: new[] { "Id", "ProjectId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProjectFiles_Id",
                table: "ProjectFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectFiles",
                table: "ProjectFiles");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "ProjectFiles",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectFiles",
                table: "ProjectFiles",
                column: "Id");
        }
    }
}
