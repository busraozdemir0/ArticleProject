using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Article.Data.Migrations
{
    /// <inheritdoc />
    public partial class dataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("25a68467-8a27-45b7-9202-50241cea50fc"), "Admin Test", new DateTime(2024, 1, 29, 16, 12, 43, 770, DateTimeKind.Local).AddTicks(6304), null, null, "images/testimage", "jpg", false, null, null },
                    { new Guid("509d3d55-646b-413b-8f3e-01c5da780f76"), "Admin Test", new DateTime(2024, 1, 29, 16, 12, 43, 770, DateTimeKind.Local).AddTicks(6355), null, null, "images/vstest", "jpg", false, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("25a68467-8a27-45b7-9202-50241cea50fc"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("509d3d55-646b-413b-8f3e-01c5da780f76"));
        }
    }
}
