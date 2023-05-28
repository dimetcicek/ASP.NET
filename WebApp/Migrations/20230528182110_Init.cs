using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => new { x.UserId, x.AddressId });
                    table.ForeignKey(
                        name: "FK_UserAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAddresses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12fddf82-afca-405b-9c7a-f827156eb4b1", "99a86d6d-e357-496b-8fbb-295190f39f4c", "User", "USER" },
                    { "f0237b71-fe5d-40b5-af1a-f703e065998d", "bfc0e556-1074-4579-a3be-2403a602bcbd", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "HyperX Cloud II Gaming Headset i rött och svart har en avancerad USB audio control box med inbyggt DSP ljudkort, detta stärker ljud och tal så att du får en optimal gaming upplevelse. Med virtual 7.1 surround sound i kombination med stängda kåpor upplever du en detaljrikedom du tidigare aldrig hört! Mikrofon och ljud har separata volymkontroller som gör det lätt att höja och sänka volymen oberoende av varandra. Kompatibelt med PC & Mac via USB och stereokompatibelt med PS4, Xbox One1 och mobil. ", "https://assets.mmsrg.com/isr/166325/c1/-/ASSET_MMS_80726870/fee_786_587_png/HYPERX-Cloud-II-Wireless---Tr%C3%A5dl%C3%B6st-Gamingheadset-f%C3%B6r-PC--PS4-%26-Nintendo-Switch", 119m, "HyperX Cloud 2" },
                    { 2, "Den här formen kommer från vår prisbelönta DeathAdder-ergonomi och är utformad för små till medelstora handstorlekar och är mångsidig nog för att passa de flesta greppstilar. Till nollkostnad för att bygga hållfasthet har chassit också kastat bort mer vikt så att du kan dra av enkla svepningar och spela under långa timmar i komfort.\r\n\r\nMed förbättrad taktilitet för skarpare och mer tillfredsställande klick aktiverar omkopplarna i denna lilla ergonomiska spelmus med en branschledande responstid på 0,2 millisekunder. Genom att använda en infraröd ljusstråle istället för fysisk kontakt för att registrera varje klick, tar denna form av aktivering bort behovet av avstängningsfördröjning och utlöser aldrig oavsiktliga klick, vilket ger dig närmare kontroll och felfri utförande. ", "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcSYnJyGs3FmYgpXDPlRqMFwRU86cUlY6PCE0gedPYcUeCnvTXYFoZfPOxoIVlGCTgifbnT72rKoctXdXEhKRWDyGrpWn8P2y2xxfBotAEOU0jeeCf0qRzmHSSCUfXd1aH9_VUva&usqp=CAc", 123m, "Razer Deathadder" },
                    { 3, "MSI GF63 Thin bärbar dator för gaming är byggd med både hållbarhet och prestanda i åtanke. Tack vare metallchassit och det långvariga batteriet kan du ta ditt spelande på språng utan att behöva oroa dig", "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcRqyp5LozRGVoVB47jxuVY0FQV4d55gzmijVDef8TPGFWWBEODjL1aqADg-r_vUDj5hLM83XgRq44jVIIvpcrma44d_FE7IAcyyDR6BK1pfx7-GF2TBqoQ&usqp=CAc", 1200m, "MSI GF63" },
                    { 4, "Varje detalj i GMMK 2 Pre-built från Glorius har noggrant utformats för att ge dig den ultimata skriv- och spelupplevelsen. Den anodiserade aluminiumramen ger en solid grund för de inkluderade double-shot keycapsen, som använder ett rent typsnitt som aldrig bleknar. Hotswap-stöd gör att användarna enkelt kan koppla in sin önskade switchar. Glorious linjära Fox-switchar och stabilisatorer är pre-lubed för att vara mjuka, och det tjocka interna skummaterialet säkerställer en förstklassig ljudkvalitet. ", "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcRn6vt-ynbab_gYnu59ovKYcf9m26C-fS3oMoDv4YvYWWnNluIBJFdKZe3WKa2WsUsVv57hpVBULm9Qcr4ouhoEIlIeyNeDLqyZJ9zwftuSI8JlAHVl4v68TcycE5WRbBzpnw&usqp=CAc", 79m, "Glorious GMMK 2" },
                    { 5, "G2412 från MSI är en bildskärm perfekt för gaming. G2412 gamingskärm har 23.8” och levererar hela 170 bilder per sekund med sin FreeSync Premium teknologi med en otroligt snabb responstid på endast 1ms. Bildskärmen har 16.7 miljoner färger, 1100:1 i kontrast och ett brett bildförhållande på 16:9 med en justerbar lutning på -5° ~ 20°.", "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcRhk2LD0zCMVYuQh7Tn4ScDBHkaTG8z4iRdps16e41PWFTRi2QxGRnlhPKiWB3POnhG1HogyH0kEj0zQ4LmglNMzkt1wzyAkyABkFuDDJrp7EusG14v04W7Mr33AuLrneJBeQ&usqp=CAc", 135m, "MSI G2412" },
                    { 6, "Model O är en solid mus som har egenskaper de flesta tillverkare bara drömmer om att få använda när de tillverkar gamingmöss. Nu tar dom steget upp till nästa nivå med en av de mest avancerade sensorer som någonsin konstruerats, deras egna BAMF-sensor. Model-O Wireless utnyttjar kraften i BAMF sensoren och det isiga, släta glidet från deras G-skates för att ge dig maximal kontroll, minimalt med friktion och noll fördröjning.", "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcTwCW8aB33v_fsuHcPMsk999ZuffyecrPaOqKrCC5tEO4SUHXDPzg5B0YkdoMP3xkgfsXle90CJ27tBs_I1de6EqM8K9nZVQQ-JNMys5IRBkmISVTfwn_AF5fDi2Z51_6aqSNg&usqp=CAc", 59m, "Glorious Model O" },
                    { 7, "Hör och låt som ett proffs med Logitech PRO X. Med Blue VOICE-mikrofonteknik och nästa generations 7.1-surroundljud. Det externa USB-ljudkortet ger dig högkvalitativ kristallklart ljud. Designat för turneringar med nedladdningsbara ljud EQ. ", "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcSSA1T7g6EGImiCBiOhngW2vye9UiKz1otq2vZfPweJcytckNt2y67r9L5wxrsYDc79dOk92zcIEJXh7fy9EHku4oBlZ-DeLPYn1sRh7ewh6C8GFNQzOQ1xKcrXoBQNJy9G8A&usqp=CAc", 44m, "Logitech G PRO X" },
                    { 8, "Byggt för proffsen, inifrån och ut. Med sin kompakta design utan numerisk knappsats frigör det mekaniska speltangentbordet Logitech G® PRO bordsyta för lågkänsliga musrörelser. Clicky-brytare i proffsklass ger hörbar återkoppling. Med programmerbar LIGHTSYNC RGB och inbyggt minne kan du lagra anpassade belysningsmönster för turneringar.", "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcR-Ia36fWUj3UynzprsqdYtaEyKvN6N6ABt3bt4z5_nXXr6lFIGWnhRQkIKLrjjRG-WTizzqnR_TdmhgOpK-q7nuMFSlbCbD6toYEEzPGPdtPb5mLEUe8jiQg&usqp=CAc", 62m, "Logitech G PRO " },
                    { 9, "Extra bred musmatta med högkvalitativ ultravävd yta som har utmärkt glidförmåga, sydda kanter och halkskyddad undersida.", "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcSzFXVTBEfegK4S687W39k16CHUJRCC-IeYLPAGquVEiMTjhJHgltLVsf3lhBRrRpS9Pb2xdrGtiXRTyHg83Ye7GxfamA9dqnHsonkyNqCnWcZTiZiZknLmG0Me-FtYso0Ftw&usqp=CAc", 13m, "Steelseries QcK" }
                });

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
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 3 },
                    { 9, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_TagId",
                table: "ProductTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_AddressId",
                table: "UserAddresses",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ContactForms");

            migrationBuilder.DropTable(
                name: "ProductTags");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
