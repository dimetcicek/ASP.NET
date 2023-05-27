using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class ContactForms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactForms", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12fddf82-afca-405b-9c7a-f827156eb4b1",
                column: "ConcurrencyStamp",
                value: "66a70c88-8eb2-4092-998f-1788c1cbcc78");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0237b71-fe5d-40b5-af1a-f703e065998d",
                column: "ConcurrencyStamp",
                value: "3327ad36-6c6d-4e86-b36d-0a17600a1fdd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b9ae07c-75ef-4582-bd11-2b17ca2e0a97",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "062e10a0-3034-4751-b665-b4af2d722430", "AQAAAAIAAYagAAAAEGzKRGe6rBR7LfLJqAKmpX/FT4M7X8P6HxpVI0/i9OjyH28AkWeEPwXWGXgdVpaobw==", "ecd898c0-3e63-419b-ac8a-6d35b138b1f3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactForms");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12fddf82-afca-405b-9c7a-f827156eb4b1",
                column: "ConcurrencyStamp",
                value: "1a994645-c957-4e31-a21f-43411a09b9a7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0237b71-fe5d-40b5-af1a-f703e065998d",
                column: "ConcurrencyStamp",
                value: "97850147-2244-49e8-b0f3-8a249e8beec4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b9ae07c-75ef-4582-bd11-2b17ca2e0a97",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38636c53-c418-44e4-b0a8-a0e7495615b6", "AQAAAAIAAYagAAAAEFI3CDFXf7h9L2tNR6OBRyBq7n1vDDrtWXc7RZCfVQuTljrH7+3V7ve31v97rumO3Q==", "69fb4480-b34e-4aee-9a55-b96458354f1e" });
        }
    }
}
