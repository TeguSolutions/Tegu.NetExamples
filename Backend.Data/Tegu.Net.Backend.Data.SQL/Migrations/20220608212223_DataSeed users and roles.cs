using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tegu.Net.Backend.Data.SQL.Migrations
{
    public partial class DataSeedusersandroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash" },
                values: new object[,]
                {
                    { new Guid("079f5040-3662-4897-b827-d3505ea2438a"), "bwtegu@tegu.net", "B&W", "Tegu", "$2a$11$z9bxZR2dYitdeBHvV1dVDOvERirnnEDkEwAH0tBxwunzFU0Z7omRG" },
                    { new Guid("28218d70-5b0d-4d19-8171-1cae6ae75d30"), "notegu@tegu.net", "No", "Tegu", "$2a$11$CYcwsHlqq1qV77xdsUae3.OsTWD3GCm5P7716vnVdsw1wJHeEdQZ2" },
                    { new Guid("6c266242-a52a-46d1-9083-dcf0f3745957"), "mixedtegu@tegu.net", "Mixed", "Tegu", "$2a$11$cMGAh5FAcAnSd53qRDwq8OaEZlnqVE39l5cZ7mTE3KZmHli55wsnG" },
                    { new Guid("b1ad8f85-f34a-4b0f-bf63-bfeb5f6173f4"), "admintegu@tegu.net", "Admin", "Tegu", "$2a$11$E67YeDjnVXx47x7aPanznu2BT6Yql.0i1EvuY3MQhM4KcxbN9ljbu" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, new Guid("079f5040-3662-4897-b827-d3505ea2438a") },
                    { 2, new Guid("6c266242-a52a-46d1-9083-dcf0f3745957") },
                    { 1, new Guid("b1ad8f85-f34a-4b0f-bf63-bfeb5f6173f4") },
                    { 2, new Guid("b1ad8f85-f34a-4b0f-bf63-bfeb5f6173f4") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, new Guid("079f5040-3662-4897-b827-d3505ea2438a") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, new Guid("6c266242-a52a-46d1-9083-dcf0f3745957") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, new Guid("b1ad8f85-f34a-4b0f-bf63-bfeb5f6173f4") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, new Guid("b1ad8f85-f34a-4b0f-bf63-bfeb5f6173f4") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("28218d70-5b0d-4d19-8171-1cae6ae75d30"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("079f5040-3662-4897-b827-d3505ea2438a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6c266242-a52a-46d1-9083-dcf0f3745957"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b1ad8f85-f34a-4b0f-bf63-bfeb5f6173f4"));
        }
    }
}
