using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => new { x.ProductId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ProductTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 1, "Det ursprungliga HyperX Cloud II är ett ultrabekvämt gamingheadset med utmärkt ljud. ", "https://assets.mmsrg.com/isr/166325/c1/-/ASSET_MMS_80726870/fee_786_587_png/HYPERX-Cloud-II-Wireless---Tr%C3%A5dl%C3%B6st-Gamingheadset-f%C3%B6r-PC--PS4-%26-Nintendo-Switch", 1190m, "Logitech MK540 Advanced" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { 1, "new" },
                    { 2, "featured" },
                    { 3, "popular" }
                });

            migrationBuilder.InsertData(
                table: "ProductTags",
                columns: new[] { "ProductId", "TagId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_TagId",
                table: "ProductTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTags");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12fddf82-afca-405b-9c7a-f827156eb4b1",
                column: "ConcurrencyStamp",
                value: "4774c8ed-fb1b-49a4-9c1e-46a74309080d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0237b71-fe5d-40b5-af1a-f703e065998d",
                column: "ConcurrencyStamp",
                value: "da0000b6-0fd7-4939-a7ec-73f071e76a94");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b9ae07c-75ef-4582-bd11-2b17ca2e0a97",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcb15c69-a9d9-42e2-b591-9cecc6396c11", "AQAAAAIAAYagAAAAEDV9yi3VpA7cZULP0/WVYdZFXuyjB5fQjP9GUnNZqDc8iu+h15V1zkUPCMKMsXyJiw==", "a3b00cb3-dce0-4057-abb1-363174bb4b04" });
        }
    }
}
