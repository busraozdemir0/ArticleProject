using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Article.Data.Migrations
{
    /// <inheritdoc />
    public partial class deeneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("300e565e-3fc8-4e55-9788-8a3100ca628d"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("71189e5b-4db9-42fa-9176-aa5f7a4cd492"));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SocialMedias",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "SocialMedias",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SocialMedias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "SocialMedias",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("12a6dd92-4e39-4f41-b88d-96fcf7fc1e26"), new Guid("d21f1e86-4ddf-4db0-b469-7bc63c1a7798"), "Asp.Net Core is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin Test", new DateTime(2024, 2, 11, 22, 25, 43, 718, DateTimeKind.Local).AddTicks(5703), null, null, new Guid("25a68467-8a27-45b7-9202-50241cea50fc"), false, null, null, "Asp.Net Core Deneme Makalesi", new Guid("324bdfde-4ddb-4333-9ed1-1e9e91226a73"), 15 },
                    { new Guid("c6d81173-92fb-4e3e-898d-b9b9eb1fdccf"), new Guid("6ba1f557-0cff-4ab6-8359-0ea298eeac6e"), "Visual Studio is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin Test", new DateTime(2024, 2, 11, 22, 25, 43, 718, DateTimeKind.Local).AddTicks(5712), null, null, new Guid("509d3d55-646b-413b-8f3e-01c5da780f76"), false, null, null, "Visual Studio Deneme Makalesi", new Guid("2ef7516c-3a35-4b40-a744-c3c7da3f6e20"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("47acf50f-db96-4276-afe3-b86227094670"),
                column: "ConcurrencyStamp",
                value: "277c9733-f561-4361-bf18-9bc3bd41b161");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5a445b3e-3728-4853-9362-b4fd9aab42cb"),
                column: "ConcurrencyStamp",
                value: "e8d8640b-bf3b-4325-bc8b-06dab5a20ee0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7b480a8e-6625-4f19-9378-eae2fe2da3cc"),
                column: "ConcurrencyStamp",
                value: "a4694ad5-750e-467f-9353-3675fe2cc4c5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2ef7516c-3a35-4b40-a744-c3c7da3f6e20"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6acca87d-0a62-48b1-a317-390b623080fc", "AQAAAAIAAYagAAAAEJ+8XkKrJWTh7SxQovoW5l6uwr/mi8NvTJ1QOS4XsqwAygUr2f1pgBxikQmBXLru5g==", "0b976bd1-8afa-4435-b791-c4eeb2cb6621" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("324bdfde-4ddb-4333-9ed1-1e9e91226a73"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e222c0fe-94c3-4392-8643-c85df91ea39b", "AQAAAAIAAYagAAAAEMmjDea+DM42AMdba+slFkrFX4cQ88nZnH1J0xmuca6mHA/6qVFUurTazPCU8fMP/A==", "be3fdce8-c8e6-47d7-af43-94909a92a80c" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6ba1f557-0cff-4ab6-8359-0ea298eeac6e"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 11, 22, 25, 43, 719, DateTimeKind.Local).AddTicks(1013));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d21f1e86-4ddf-4db0-b469-7bc63c1a7798"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 11, 22, 25, 43, 719, DateTimeKind.Local).AddTicks(1008));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("25a68467-8a27-45b7-9202-50241cea50fc"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 11, 22, 25, 43, 719, DateTimeKind.Local).AddTicks(2424));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("509d3d55-646b-413b-8f3e-01c5da780f76"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 11, 22, 25, 43, 719, DateTimeKind.Local).AddTicks(2441));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("12a6dd92-4e39-4f41-b88d-96fcf7fc1e26"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("c6d81173-92fb-4e3e-898d-b9b9eb1fdccf"));

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "SocialMedias");

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
    }
}
