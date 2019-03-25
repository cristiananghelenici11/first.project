using Microsoft.EntityFrameworkCore.Migrations;

namespace Relationships.DAL.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Address", "Age", "Contact", "Description", "Name" },
                values: new object[] { 1L, "Studentilor", 30, "245322", "utm-----", "UTM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
