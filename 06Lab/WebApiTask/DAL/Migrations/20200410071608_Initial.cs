using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(maxLength: 100, nullable: false),
                    Country = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, defaultValue: 0m),
                    SupplierId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ProductCategoryId);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "deserunt" },
                    { 2, "reprehenderit" },
                    { 3, "commodo" },
                    { 4, "ex" },
                    { 5, "voluptate" },
                    { 6, "irure" },
                    { 7, "fugiat" },
                    { 8, "ut" },
                    { 9, "non" },
                    { 10, "id" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "City", "Country", "SupplierName" },
                values: new object[,]
                {
                    { 15, "Macdona", "Fiji", "BRAINCLIP" },
                    { 16, "Croom", "Trinidad and Tobago", "DAYCORE" },
                    { 17, "Rose", "Austria", "ZENTRY" },
                    { 18, "Springdale", "Anguilla", "KENEGY" },
                    { 23, "Navarre", "Uganda", "FURNIGEER" },
                    { 20, "Kennedyville", "Sao Tome and Principe", "SOPRANO" },
                    { 21, "Warsaw", "French Polynesia", "KIDSTOCK" },
                    { 22, "Thynedale", "India", "SOFTMICRO" },
                    { 14, "Watrous", "French Guiana", "VETRON" },
                    { 19, "Thatcher", "Hong Kong", "ZYTREX" },
                    { 13, "Ezel", "Costa Rica", "SIGNIDYNE" },
                    { 8, "Fairlee", "Peru", "BRAINQUIL" },
                    { 11, "Farmington", "Sri Lanka", "COMVEYOR" },
                    { 10, "Hackneyville", "Kyrgyzstan", "AVENETRO" },
                    { 9, "Springhill", "Senegal", "INSURON" },
                    { 24, "Cumminsville", "Falkland Islands (Malvinas)", "ROTODYNE" },
                    { 7, "Islandia", "Comoros", "ZOINAGE" },
                    { 6, "Garberville", "Croatia (Hrvatska)", "ZEAM" },
                    { 5, "Darlington", "Brazil", "OLYMPIX" },
                    { 4, "Ladera", "Angola", "ZENSUS" },
                    { 3, "Dorneyville", "Chile", "GEEKULAR" },
                    { 2, "Rockbridge", "Tajikistan", "ZILLANET" },
                    { 1, "Cedarville", "Samoa", "AQUASURE" },
                    { 12, "Innsbrook", "Honduras", "NETUR" },
                    { 25, "Gadsden", "Brunei Darussalam", "ASSISTIA" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "Price", "SupplierId" },
                values: new object[,]
                {
                    { 19, "Blurrybus", 9524.25m, 1 },
                    { 5, "Bedder", 1241.98m, 20 },
                    { 4, "Zanity", 8401.64m, 20 },
                    { 90, "Evidends", 6289.83m, 19 },
                    { 89, "Netplax", 6091.68m, 19 },
                    { 81, "Volax", 1966.41m, 19 },
                    { 77, "Imant", 3653.63m, 19 },
                    { 61, "Nurplex", 8005.16m, 19 },
                    { 50, "Zenco", 9851.62m, 19 },
                    { 2, "Surelogic", 2334.12m, 19 },
                    { 62, "Opportech", 4351.48m, 18 },
                    { 41, "Geekmosis", 7220.78m, 18 },
                    { 28, "Xoggle", 8733.2m, 18 },
                    { 26, "Cyclonica", 7594.04m, 18 },
                    { 16, "Sportan", 7256.04m, 18 },
                    { 94, "Interfind", 9211.84m, 17 },
                    { 21, "Oatfarm", 4411.55m, 17 },
                    { 27, "Xiix", 8325.61m, 16 },
                    { 24, "Uberlux", 3979.18m, 16 },
                    { 72, "Aclima", 4961.85m, 15 },
                    { 95, "Adornica", 1218.75m, 14 },
                    { 70, "Cinaster", 8559.78m, 14 },
                    { 11, "Chillium", 6831.99m, 20 },
                    { 64, "Zepitope", 9028.79m, 14 },
                    { 43, "Tingles", 1791.16m, 20 },
                    { 85, "Arctiq", 6872.43m, 20 },
                    { 33, "Papricut", 5969.92m, 25 },
                    { 25, "Zilla", 9353.77m, 25 },
                    { 59, "Fortean", 7793.87m, 24 },
                    { 51, "Pawnagra", 7088.94m, 24 },
                    { 39, "Nurali", 8673.03m, 24 },
                    { 98, "Manufact", 2951.69m, 23 },
                    { 68, "Datacator", 9180.44m, 23 },
                    { 49, "Viocular", 6769.67m, 23 },
                    { 69, "Lumbrex", 4060.57m, 22 },
                    { 35, "Incubus", 4580.29m, 22 },
                    { 32, "Dragbot", 1303.88m, 22 },
                    { 29, "Crustatia", 3964.4m, 22 },
                    { 15, "Geekus", 6118.15m, 22 },
                    { 9, "Accusage", 3562.65m, 22 },
                    { 93, "Opticall", 4266.36m, 21 },
                    { 76, "Sarasonic", 4321.39m, 21 },
                    { 17, "Typhonica", 7623.6m, 21 },
                    { 14, "Isotrack", 8283.74m, 21 },
                    { 10, "Mantro", 9309.84m, 21 },
                    { 88, "Emtrak", 6233.53m, 20 },
                    { 86, "Savvy", 2039.21m, 20 },
                    { 52, "Lunchpod", 4265.59m, 20 },
                    { 57, "Animalia", 2476.81m, 14 },
                    { 46, "Turnabout", 4304.38m, 14 },
                    { 31, "Atgen", 6174.73m, 14 },
                    { 20, "Ecrater", 3909.1m, 6 },
                    { 56, "Singavera", 9677.02m, 5 },
                    { 55, "Enquility", 8132.19m, 5 },
                    { 53, "Quintity", 5317.28m, 5 },
                    { 23, "Enjola", 4074.97m, 5 },
                    { 1, "Boink", 3833.54m, 5 },
                    { 97, "Senmei", 1848.41m, 4 },
                    { 47, "Fangold", 6593.9m, 4 },
                    { 40, "Viagrand", 2601.61m, 4 },
                    { 30, "Eschoir", 1223.93m, 4 },
                    { 42, "Squish", 4457.24m, 3 },
                    { 73, "Nikuda", 6249.87m, 2 },
                    { 45, "Apex", 5523.95m, 2 },
                    { 18, "Boilcat", 8049.55m, 2 },
                    { 8, "Artworlds", 4923.18m, 2 },
                    { 6, "Nexgene", 7916.11m, 2 },
                    { 96, "Pathways", 7637.38m, 1 },
                    { 83, "Fanfare", 2133.37m, 1 },
                    { 80, "Extro", 5168.13m, 1 },
                    { 78, "Musanpoly", 6915.35m, 1 },
                    { 63, "Digitalus", 2484.5m, 1 },
                    { 36, "Pyramax", 5252.72m, 6 },
                    { 37, "Earbang", 6453.25m, 6 },
                    { 60, "Aquazure", 8351.02m, 6 },
                    { 67, "Liquidoc", 3746.67m, 7 },
                    { 74, "Isoternia", 6164.25m, 13 },
                    { 7, "Nixelt", 1303.18m, 13 },
                    { 99, "Comstar", 4589.45m, 12 },
                    { 84, "Geofarm", 6360.86m, 12 },
                    { 38, "Rugstars", 4765.96m, 12 },
                    { 12, "Moreganic", 2983.7m, 12 },
                    { 100, "Progenex", 5823.79m, 11 },
                    { 22, "Gluid", 1117.44m, 11 },
                    { 92, "Menbrain", 7938.13m, 10 },
                    { 65, "Sequitur", 3946.79m, 10 },
                    { 44, "Iplax", 8820.49m, 25 },
                    { 48, "Premiant", 2970.63m, 10 },
                    { 34, "Geologix", 2590.71m, 9 },
                    { 13, "Tropoli", 8489.11m, 9 },
                    { 3, "Opticon", 8289.99m, 9 },
                    { 87, "Inrt", 4533.57m, 8 },
                    { 79, "Orbixtar", 6351.83m, 8 },
                    { 75, "Farmage", 6151.61m, 8 },
                    { 66, "Webiotic", 8612.11m, 8 },
                    { 58, "Cipromox", 6505.58m, 8 },
                    { 54, "Gronk", 3174.8m, 8 },
                    { 82, "Vurbo", 3998.04m, 7 },
                    { 71, "Ecraze", 7677.83m, 9 },
                    { 91, "Kyagoro", 4981.13m, 25 }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ProductCategoryId", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 170, 6, 19 },
                    { 59, 4, 27 },
                    { 115, 7, 27 },
                    { 100, 1, 94 },
                    { 172, 10, 94 },
                    { 90, 8, 16 },
                    { 34, 4, 26 },
                    { 62, 7, 28 },
                    { 72, 5, 41 },
                    { 121, 6, 41 },
                    { 156, 5, 41 },
                    { 12, 9, 62 },
                    { 131, 10, 62 },
                    { 111, 6, 50 },
                    { 94, 6, 77 },
                    { 178, 9, 77 },
                    { 101, 6, 81 },
                    { 167, 8, 81 },
                    { 2, 3, 89 },
                    { 104, 5, 89 },
                    { 180, 1, 90 },
                    { 164, 9, 4 },
                    { 182, 5, 24 },
                    { 52, 10, 5 },
                    { 137, 4, 24 },
                    { 78, 8, 24 },
                    { 60, 5, 74 },
                    { 142, 5, 74 },
                    { 168, 6, 74 },
                    { 186, 5, 74 },
                    { 196, 6, 74 },
                    { 11, 6, 31 },
                    { 39, 5, 46 },
                    { 87, 2, 46 },
                    { 136, 7, 46 },
                    { 23, 6, 57 },
                    { 27, 6, 57 },
                    { 53, 3, 57 },
                    { 143, 7, 57 },
                    { 154, 1, 64 },
                    { 19, 1, 70 },
                    { 117, 5, 70 },
                    { 183, 7, 70 },
                    { 31, 3, 95 },
                    { 106, 7, 95 },
                    { 146, 4, 95 },
                    { 56, 2, 24 },
                    { 107, 3, 24 },
                    { 193, 8, 7 },
                    { 89, 9, 5 },
                    { 32, 8, 11 },
                    { 20, 6, 35 },
                    { 158, 9, 35 },
                    { 199, 5, 35 },
                    { 126, 8, 49 },
                    { 30, 2, 68 },
                    { 177, 9, 98 },
                    { 9, 10, 39 },
                    { 114, 3, 51 },
                    { 155, 8, 51 },
                    { 29, 10, 59 },
                    { 48, 7, 59 },
                    { 54, 10, 59 },
                    { 93, 8, 59 },
                    { 95, 5, 25 },
                    { 130, 7, 25 },
                    { 197, 5, 25 },
                    { 103, 9, 33 },
                    { 7, 7, 44 },
                    { 108, 5, 44 },
                    { 79, 3, 91 },
                    { 83, 1, 91 },
                    { 44, 7, 32 },
                    { 191, 9, 5 },
                    { 125, 8, 15 },
                    { 38, 7, 93 },
                    { 123, 2, 11 },
                    { 45, 2, 43 },
                    { 50, 1, 43 },
                    { 133, 2, 85 },
                    { 185, 1, 85 },
                    { 200, 6, 85 },
                    { 68, 4, 86 },
                    { 91, 7, 88 },
                    { 16, 3, 10 },
                    { 17, 3, 10 },
                    { 152, 2, 10 },
                    { 26, 7, 14 },
                    { 82, 6, 14 },
                    { 47, 3, 17 },
                    { 64, 6, 17 },
                    { 96, 10, 17 },
                    { 1, 1, 76 },
                    { 81, 6, 76 },
                    { 86, 10, 76 },
                    { 174, 2, 76 },
                    { 37, 4, 93 },
                    { 151, 2, 93 },
                    { 77, 9, 7 },
                    { 67, 8, 7 },
                    { 40, 2, 7 },
                    { 63, 8, 30 },
                    { 173, 1, 30 },
                    { 41, 8, 40 },
                    { 84, 8, 40 },
                    { 92, 2, 40 },
                    { 99, 1, 40 },
                    { 135, 5, 40 },
                    { 43, 8, 97 },
                    { 5, 8, 1 },
                    { 98, 1, 1 },
                    { 165, 8, 1 },
                    { 171, 8, 1 },
                    { 102, 5, 23 },
                    { 119, 10, 53 },
                    { 61, 8, 55 },
                    { 157, 7, 55 },
                    { 88, 9, 56 },
                    { 10, 9, 20 },
                    { 139, 8, 20 },
                    { 14, 8, 36 },
                    { 33, 5, 36 },
                    { 6, 8, 30 },
                    { 97, 5, 36 },
                    { 57, 5, 42 },
                    { 28, 1, 73 },
                    { 85, 10, 63 },
                    { 134, 2, 63 },
                    { 76, 8, 78 },
                    { 161, 9, 78 },
                    { 49, 2, 80 },
                    { 35, 6, 83 },
                    { 75, 7, 83 },
                    { 148, 1, 83 },
                    { 70, 1, 96 },
                    { 175, 4, 96 },
                    { 113, 10, 6 },
                    { 128, 8, 6 },
                    { 58, 3, 8 },
                    { 69, 9, 8 },
                    { 120, 6, 8 },
                    { 150, 3, 18 },
                    { 66, 8, 45 },
                    { 71, 5, 45 },
                    { 144, 9, 45 },
                    { 153, 8, 45 },
                    { 8, 8, 73 },
                    { 51, 5, 73 },
                    { 163, 6, 36 },
                    { 13, 10, 37 },
                    { 42, 6, 67 },
                    { 110, 4, 71 },
                    { 4, 7, 48 },
                    { 132, 10, 48 },
                    { 179, 1, 48 },
                    { 46, 6, 65 },
                    { 129, 2, 65 },
                    { 194, 5, 65 },
                    { 184, 9, 92 },
                    { 189, 4, 92 },
                    { 22, 2, 22 },
                    { 55, 7, 100 },
                    { 73, 7, 100 },
                    { 188, 2, 100 },
                    { 169, 8, 12 },
                    { 176, 6, 12 },
                    { 118, 6, 38 },
                    { 80, 8, 84 },
                    { 122, 10, 84 },
                    { 140, 2, 84 },
                    { 105, 4, 99 },
                    { 24, 1, 7 },
                    { 124, 5, 34 },
                    { 181, 6, 13 },
                    { 166, 9, 13 },
                    { 3, 6, 13 },
                    { 74, 4, 67 },
                    { 192, 2, 67 },
                    { 65, 7, 82 },
                    { 160, 4, 82 },
                    { 15, 4, 54 },
                    { 25, 3, 54 },
                    { 149, 7, 54 },
                    { 198, 4, 58 },
                    { 21, 5, 66 },
                    { 147, 3, 66 },
                    { 145, 6, 91 },
                    { 187, 6, 66 },
                    { 141, 4, 79 },
                    { 195, 2, 79 },
                    { 18, 8, 87 },
                    { 127, 1, 87 },
                    { 162, 1, 87 },
                    { 109, 4, 3 },
                    { 112, 6, 3 },
                    { 116, 9, 3 },
                    { 138, 1, 3 },
                    { 159, 7, 3 },
                    { 36, 10, 75 },
                    { 190, 8, 91 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
