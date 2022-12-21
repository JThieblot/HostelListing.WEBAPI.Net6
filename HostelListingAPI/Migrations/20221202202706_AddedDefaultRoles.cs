using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HostelListingAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34dd3906-b4a7-4072-9ac9-ab53389c6087", "6190caf4-f0ab-47a7-bf82-1f0cb4cd583a", "Administrator", "ADMINISTRATOR" },
                    { "e313b415-19e7-40ec-9264-82a53221ecbc", "2fe5c6f2-e497-4034-a8ba-951dd9b58785", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34dd3906-b4a7-4072-9ac9-ab53389c6087");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e313b415-19e7-40ec-9264-82a53221ecbc");
        }
    }
}
