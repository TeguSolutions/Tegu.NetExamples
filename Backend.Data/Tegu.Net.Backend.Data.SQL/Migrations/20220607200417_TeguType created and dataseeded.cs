using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tegu.Net.Backend.Data.SQL.Migrations
{
    public partial class TeguTypecreatedanddataseeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeguTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LatinName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeguTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TeguTypes",
                columns: new[] { "Id", "Color", "FullName", "LatinName", "Name" },
                values: new object[] { 1, "Black & White", "Argentine Black and White Tegu", "Salvator Merianae", "B&W Tegu" });

            migrationBuilder.InsertData(
                table: "TeguTypes",
                columns: new[] { "Id", "Color", "FullName", "LatinName", "Name" },
                values: new object[] { 2, "Red", "Argentine Red Tegu", "Salvator Rufescens", "Red Tegu" });

            migrationBuilder.InsertData(
                table: "TeguTypes",
                columns: new[] { "Id", "Color", "FullName", "LatinName", "Name" },
                values: new object[] { 3, "Gold", "Colombian Tegu", "Tupinambis Teguixin", "Gold Tegu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeguTypes");
        }
    }
}
