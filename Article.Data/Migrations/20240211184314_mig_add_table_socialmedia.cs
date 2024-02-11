using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Article.Data.Migrations
{
    /// <inheritdoc />
    public partial class migaddtablesocialmedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("7bdf8e8d-21fa-4287-b043-aa6da9d2afb8"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("cf9077a2-9030-4701-954e-7759229a2563"));

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GmailUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwitterUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GithubUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("300e565e-3fc8-4e55-9788-8a3100ca628d"), new Guid("d21f1e86-4ddf-4db0-b469-7bc63c1a7798"), "Asp.Net Core is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin Test", new DateTime(2024, 2, 11, 21, 43, 13, 197, DateTimeKind.Local).AddTicks(7205), null, null, new Guid("25a68467-8a27-45b7-9202-50241cea50fc"), false, null, null, "Asp.Net Core Deneme Makalesi", new Guid("324bdfde-4ddb-4333-9ed1-1e9e91226a73"), 15 },
                    { new Guid("71189e5b-4db9-42fa-9176-aa5f7a4cd492"), new Guid("6ba1f557-0cff-4ab6-8359-0ea298eeac6e"), "Visual Studio is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin Test", new DateTime(2024, 2, 11, 21, 43, 13, 197, DateTimeKind.Local).AddTicks(7221), null, null, new Guid("509d3d55-646b-413b-8f3e-01c5da780f76"), false, null, null, "Visual Studio Deneme Makalesi", new Guid("2ef7516c-3a35-4b40-a744-c3c7da3f6e20"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("47acf50f-db96-4276-afe3-b86227094670"),
                column: "ConcurrencyStamp",
                value: "220ae829-6bb7-4f4e-94e0-ef6c8c8b1422");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5a445b3e-3728-4853-9362-b4fd9aab42cb"),
                column: "ConcurrencyStamp",
                value: "61be5781-0ec3-467c-a3e8-8c7e4ee9f97c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7b480a8e-6625-4f19-9378-eae2fe2da3cc"),
                column: "ConcurrencyStamp",
                value: "63ebd603-4e73-487a-9a46-5f567698458e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2ef7516c-3a35-4b40-a744-c3c7da3f6e20"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d96f2dbb-929b-463a-924a-b89d95ac7d1b", "AQAAAAIAAYagAAAAEDSaYcP5P/qFAFu3PDT7RqK24PBMDquzAnymkmatS37YK15+f3mj+DCVBlYh1OX3QQ==", "b6100c64-ca93-4341-81a1-f879421a0093" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("324bdfde-4ddb-4333-9ed1-1e9e91226a73"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59caefde-df44-478e-b9c2-53f76ef6050b", "AQAAAAIAAYagAAAAENT3/CBkuYQ2HGx4mnH/rptaJI/F5d4gLy7OaN37U4oitT8QYH5o7yFq42VqUuz+2Q==", "ed192c88-b3d7-4ce3-8215-21a2a23e0fc8" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6ba1f557-0cff-4ab6-8359-0ea298eeac6e"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 11, 21, 43, 13, 198, DateTimeKind.Local).AddTicks(3970));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d21f1e86-4ddf-4db0-b469-7bc63c1a7798"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 11, 21, 43, 13, 198, DateTimeKind.Local).AddTicks(3953));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("25a68467-8a27-45b7-9202-50241cea50fc"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 11, 21, 43, 13, 198, DateTimeKind.Local).AddTicks(5734));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("509d3d55-646b-413b-8f3e-01c5da780f76"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 11, 21, 43, 13, 198, DateTimeKind.Local).AddTicks(5739));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("300e565e-3fc8-4e55-9788-8a3100ca628d"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("71189e5b-4db9-42fa-9176-aa5f7a4cd492"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("7bdf8e8d-21fa-4287-b043-aa6da9d2afb8"), new Guid("d21f1e86-4ddf-4db0-b469-7bc63c1a7798"), "Asp.Net Core is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin Test", new DateTime(2024, 2, 9, 14, 14, 3, 781, DateTimeKind.Local).AddTicks(6565), null, null, new Guid("25a68467-8a27-45b7-9202-50241cea50fc"), false, null, null, "Asp.Net Core Deneme Makalesi", new Guid("324bdfde-4ddb-4333-9ed1-1e9e91226a73"), 15 },
                    { new Guid("cf9077a2-9030-4701-954e-7759229a2563"), new Guid("6ba1f557-0cff-4ab6-8359-0ea298eeac6e"), "Visual Studio is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin Test", new DateTime(2024, 2, 9, 14, 14, 3, 781, DateTimeKind.Local).AddTicks(6574), null, null, new Guid("509d3d55-646b-413b-8f3e-01c5da780f76"), false, null, null, "Visual Studio Deneme Makalesi", new Guid("2ef7516c-3a35-4b40-a744-c3c7da3f6e20"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("47acf50f-db96-4276-afe3-b86227094670"),
                column: "ConcurrencyStamp",
                value: "c8fd2481-69dc-435d-9aa3-40328ce5db47");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5a445b3e-3728-4853-9362-b4fd9aab42cb"),
                column: "ConcurrencyStamp",
                value: "776f4894-c93b-4dea-900e-a3a670310ea9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7b480a8e-6625-4f19-9378-eae2fe2da3cc"),
                column: "ConcurrencyStamp",
                value: "b4e70269-1db5-4c91-80a3-b52e8f5db5dd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2ef7516c-3a35-4b40-a744-c3c7da3f6e20"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5d95072-21e1-4c3f-a36f-d121ca7387c4", "AQAAAAIAAYagAAAAEC4Cq6pvrP5zz1UwAAJKfInK8YR8ww1egIdW82oz86x9MgV024R3E6sRmyjBJQPm5A==", "bce07fa7-5404-4ebc-8982-adfae4714f27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("324bdfde-4ddb-4333-9ed1-1e9e91226a73"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3edad550-882d-4ad4-8286-7f42d6a82a56", "AQAAAAIAAYagAAAAEBsiyJ3ntof7SXqnSGi1uDIuTZ9U/VTEycqtWlz5+UoGnevzu/thg7nrXz2Vn2+UDA==", "e54ed109-d226-4678-9324-030ba1cdcd03" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6ba1f557-0cff-4ab6-8359-0ea298eeac6e"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 9, 14, 14, 3, 782, DateTimeKind.Local).AddTicks(1787));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d21f1e86-4ddf-4db0-b469-7bc63c1a7798"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 9, 14, 14, 3, 782, DateTimeKind.Local).AddTicks(1782));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("25a68467-8a27-45b7-9202-50241cea50fc"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 9, 14, 14, 3, 782, DateTimeKind.Local).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("509d3d55-646b-413b-8f3e-01c5da780f76"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 9, 14, 14, 3, 782, DateTimeKind.Local).AddTicks(3173));
        }
    }
}
