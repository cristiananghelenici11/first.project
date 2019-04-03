using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityRating.Data.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UniversityId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UniversityId",
                table: "Comments",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentUniversitiesToUniversity",
                table: "Comments",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentUniversitiesToUniversity",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UniversityId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "Comments");
        }
    }
}
