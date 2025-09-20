using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITS152L_Project.Migrations
{
    /// <inheritdoc />
    public partial class itemdataadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Brand", "Code", "Name", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "Penguin", 1001, "Book", 10, 10.5 },
                    { 2, "Safegaurd", 1002, "Soap", 10, 12.5 },
                    { 3, "Clear", 1003, "Shampoo", 10, 8.5 },
                    { 4, "Durex", 1004, "Condom", 10, 6.5 },
                    { 5, "Logitech", 1005, "Mouse", 10, 20.5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
