using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudTest.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d4746fc-9177-42fb-a7e4-63c294d1eddd",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "1", "Admin" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06d1d9a-abf8-403a-8b1c-17e83444d465",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "2", "Manager" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca3abce8-ffd7-4d25-964c-c8e93de036d7",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "3", "Moderator" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d4746fc-9177-42fb-a7e4-63c294d1eddd",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06d1d9a-abf8-403a-8b1c-17e83444d465",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca3abce8-ffd7-4d25-964c-c8e93de036d7",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { null, null });
        }
    }
}
