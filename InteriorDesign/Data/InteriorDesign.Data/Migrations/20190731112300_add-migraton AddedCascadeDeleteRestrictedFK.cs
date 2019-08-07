namespace InteriorDesign.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class addmigratonAddedCascadeDeleteRestrictedFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DesignBoards_Projects_ProjectId",
                table: "DesignBoards");

            migrationBuilder.DropForeignKey(
                name: "FK_DesignReferences_DesignBoards_DesignBoardId",
                table: "DesignReferences");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFiles_Projects_ProjectId",
                table: "ProjectFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectReviews_Projects_ProjectId",
                table: "ProjectReviews");

            migrationBuilder.DropIndex(
                name: "IX_ProjectReviews_ProjectId",
                table: "ProjectReviews");

            migrationBuilder.DropIndex(
                name: "IX_ProjectFiles_ProjectId",
                table: "ProjectFiles");

            migrationBuilder.DropIndex(
                name: "IX_DesignReferences_DesignBoardId",
                table: "DesignReferences");

            migrationBuilder.DropIndex(
                name: "IX_DesignBoards_ProjectId",
                table: "DesignBoards");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "ProjectReviews",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "ProjectFiles",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DesignBoardId",
                table: "DesignReferences",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "DesignBoards",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DesignBoards_Projects_Id",
                table: "DesignBoards",
                column: "Id",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DesignReferences_DesignBoards_Id",
                table: "DesignReferences",
                column: "Id",
                principalTable: "DesignBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFiles_Projects_Id",
                table: "ProjectFiles",
                column: "Id",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectReviews_Projects_Id",
                table: "ProjectReviews",
                column: "Id",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DesignBoards_Projects_Id",
                table: "DesignBoards");

            migrationBuilder.DropForeignKey(
                name: "FK_DesignReferences_DesignBoards_Id",
                table: "DesignReferences");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectFiles_Projects_Id",
                table: "ProjectFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectReviews_Projects_Id",
                table: "ProjectReviews");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "ProjectReviews",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "ProjectFiles",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DesignBoardId",
                table: "DesignReferences",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "DesignBoards",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectReviews_ProjectId",
                table: "ProjectReviews",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFiles_ProjectId",
                table: "ProjectFiles",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignReferences_DesignBoardId",
                table: "DesignReferences",
                column: "DesignBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignBoards_ProjectId",
                table: "DesignBoards",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_DesignBoards_Projects_ProjectId",
                table: "DesignBoards",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DesignReferences_DesignBoards_DesignBoardId",
                table: "DesignReferences",
                column: "DesignBoardId",
                principalTable: "DesignBoards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectFiles_Projects_ProjectId",
                table: "ProjectFiles",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectReviews_Projects_ProjectId",
                table: "ProjectReviews",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
