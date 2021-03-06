﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Relationships.DAL.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Address", "Age", "Contact", "Description", "Name" },
                values: new object[] { 4L, "Studentilor", 30, "245322", "utm-----", "UTM" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Address", "Age", "Contact", "Description", "Name" },
                values: new object[] { 5L, "Studentilor", 30, "245322", "utm-----", "UTM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Address", "Age", "Contact", "Description", "Name" },
                values: new object[] { 2L, "Studentilor", 30, "245322", "utm-----", "UTM" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Address", "Age", "Contact", "Description", "Name" },
                values: new object[] { 3L, "Studentilor", 30, "245322", "utm-----", "UTM" });
        }
    }
}
