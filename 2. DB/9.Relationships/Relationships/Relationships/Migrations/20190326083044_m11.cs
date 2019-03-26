using Microsoft.EntityFrameworkCore.Migrations;

namespace Relationships.DAL.Migrations
{
    public partial class m11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Email", "FirstName", "Idnp", "LastName", "Phone", "UniversityId" },
                values: new object[] { 1L, null, "wqrewqr", 0L, null, 1356, 1L });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "State", "Street", "StudentId", "ZipCode" },
                values: new object[] { 1L, "Chisinau", "ssde", null, 1L, "erw" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
