using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CrudTest.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedFirstNameLastName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d4746fc-9177-42fb-a7e4-63c294d1eddd", null, "Admin", null },
                    { "a06d1d9a-abf8-403a-8b1c-17e83444d465", null, "Manager", null },
                    { "ca3abce8-ffd7-4d25-964c-c8e93de036d7", null, "Moderator", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d4746fc-9177-42fb-a7e4-63c294d1eddd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06d1d9a-abf8-403a-8b1c-17e83444d465");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca3abce8-ffd7-4d25-964c-c8e93de036d7");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "DisplayName");

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
    }
}
