using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CrudTest.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39335a37-576d-4973-9205-090282b6e877", null, "Manager", null },
                    { "a7da37d4-2f79-4d5a-b8d1-d0ba87516fea", null, "Admin", null },
                    { "be77612d-5567-4829-9f6e-906666a7f0ad", null, "Moderator", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39335a37-576d-4973-9205-090282b6e877");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7da37d4-2f79-4d5a-b8d1-d0ba87516fea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be77612d-5567-4829-9f6e-906666a7f0ad");
        }
    }
}
