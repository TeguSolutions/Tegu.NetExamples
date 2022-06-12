using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tegu.Net.Backend.Data.SQL.Migrations
{
    public partial class DataSeedOwnedTegus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OwnedTegus",
                columns: new[] { "Id", "Name", "OwnerId", "TeguTypeId" },
                values: new object[,]
                {
                    { new Guid("317d3ecd-3a02-4e39-9e8b-b30d31494b72"), "Don't eat my shoes!", new Guid("6c266242-a52a-46d1-9083-dcf0f3745957"), 2 },
                    { new Guid("6f867827-f9bc-4163-aca1-f702430613d7"), "The Beast", new Guid("079f5040-3662-4897-b827-d3505ea2438a"), 1 },
                    { new Guid("df37fe94-6167-4be4-8270-0fdee04a83e8"), "Stop hiding!", new Guid("6c266242-a52a-46d1-9083-dcf0f3745957"), 1 },
                    { new Guid("e3757b2f-734f-43ad-b0d4-1300766ed7a0"), "No, those fingers are not food!", new Guid("6c266242-a52a-46d1-9083-dcf0f3745957"), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OwnedTegus",
                keyColumn: "Id",
                keyValue: new Guid("317d3ecd-3a02-4e39-9e8b-b30d31494b72"));

            migrationBuilder.DeleteData(
                table: "OwnedTegus",
                keyColumn: "Id",
                keyValue: new Guid("6f867827-f9bc-4163-aca1-f702430613d7"));

            migrationBuilder.DeleteData(
                table: "OwnedTegus",
                keyColumn: "Id",
                keyValue: new Guid("df37fe94-6167-4be4-8270-0fdee04a83e8"));

            migrationBuilder.DeleteData(
                table: "OwnedTegus",
                keyColumn: "Id",
                keyValue: new Guid("e3757b2f-734f-43ad-b0d4-1300766ed7a0"));
        }
    }
}
