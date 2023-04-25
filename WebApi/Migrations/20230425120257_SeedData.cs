using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImagePath", "Name", "Price", "Stock" },
                values: new object[] { 1, new DateTime(2023, 4, 22, 15, 2, 57, 721, DateTimeKind.Local).AddTicks(148), null, "Bilgisayar", 15000m, 300 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImagePath", "Name", "Price", "Stock" },
                values: new object[] { 2, new DateTime(2023, 4, 20, 15, 2, 57, 721, DateTimeKind.Local).AddTicks(5074), null, "Telefon", 5000m, 500 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImagePath", "Name", "Price", "Stock" },
                values: new object[] { 3, new DateTime(2023, 4, 17, 15, 2, 57, 721, DateTimeKind.Local).AddTicks(5088), null, "Klavye", 500m, 450 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
