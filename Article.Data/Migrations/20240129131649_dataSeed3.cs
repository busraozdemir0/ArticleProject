using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Article.Data.Migrations
{
    /// <inheritdoc />
    public partial class dataSeed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("30c02a5d-5ddf-46c0-9ae8-49cfc44137a1"), new Guid("6ba1f557-0cff-4ab6-8359-0ea298eeac6e"), "Visual Studio is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin Test", new DateTime(2024, 1, 29, 16, 16, 49, 525, DateTimeKind.Local).AddTicks(2596), null, null, new Guid("509d3d55-646b-413b-8f3e-01c5da780f76"), false, null, null, "Visual Studio Deneme Makalesi", 15 },
                    { new Guid("4d10db70-dc45-4b7c-9dd4-00729bc5b9ee"), new Guid("d21f1e86-4ddf-4db0-b469-7bc63c1a7798"), "Asp.Net Core is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin Test", new DateTime(2024, 1, 29, 16, 16, 49, 525, DateTimeKind.Local).AddTicks(2586), null, null, new Guid("25a68467-8a27-45b7-9202-50241cea50fc"), false, null, null, "Asp.Net Core Deneme Makalesi", 15 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6ba1f557-0cff-4ab6-8359-0ea298eeac6e"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 29, 16, 16, 49, 525, DateTimeKind.Local).AddTicks(8215));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d21f1e86-4ddf-4db0-b469-7bc63c1a7798"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 29, 16, 16, 49, 525, DateTimeKind.Local).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("25a68467-8a27-45b7-9202-50241cea50fc"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 29, 16, 16, 49, 526, DateTimeKind.Local).AddTicks(1617));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("509d3d55-646b-413b-8f3e-01c5da780f76"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 29, 16, 16, 49, 526, DateTimeKind.Local).AddTicks(1626));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("30c02a5d-5ddf-46c0-9ae8-49cfc44137a1"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("4d10db70-dc45-4b7c-9dd4-00729bc5b9ee"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6ba1f557-0cff-4ab6-8359-0ea298eeac6e"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 29, 16, 15, 19, 686, DateTimeKind.Local).AddTicks(4947));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d21f1e86-4ddf-4db0-b469-7bc63c1a7798"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 29, 16, 15, 19, 686, DateTimeKind.Local).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("25a68467-8a27-45b7-9202-50241cea50fc"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 29, 16, 15, 19, 686, DateTimeKind.Local).AddTicks(6784));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("509d3d55-646b-413b-8f3e-01c5da780f76"),
                column: "CreatedDate",
                value: new DateTime(2024, 1, 29, 16, 15, 19, 686, DateTimeKind.Local).AddTicks(6789));
        }
    }
}
