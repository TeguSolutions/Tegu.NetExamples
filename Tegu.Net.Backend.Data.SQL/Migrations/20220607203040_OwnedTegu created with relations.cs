using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tegu.Net.Backend.Data.SQL.Migrations
{
    public partial class OwnedTegucreatedwithrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OwnedTegus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeguTypeId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedTegus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnedTegus_TeguTypes_TeguTypeId",
                        column: x => x.TeguTypeId,
                        principalTable: "TeguTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OwnedTegus_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OwnedTegus_OwnerId",
                table: "OwnedTegus",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedTegus_TeguTypeId",
                table: "OwnedTegus",
                column: "TeguTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnedTegus");
        }
    }
}
