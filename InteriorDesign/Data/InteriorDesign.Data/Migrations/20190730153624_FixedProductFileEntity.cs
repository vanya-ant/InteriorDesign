namespace InteriorDesign.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class FixedProductFileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicId",
                table: "ProjectFiles",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "ProjectFiles",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProjectFiles",
                newName: "PublicId");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "ProjectFiles",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
