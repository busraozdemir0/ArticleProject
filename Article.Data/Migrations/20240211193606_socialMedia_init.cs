using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Article.Data.Migrations
{
    /// <inheritdoc />
    public partial class socialMediainit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("12a6dd92-4e39-4f41-b88d-96fcf7fc1e26"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("c6d81173-92fb-4e3e-898d-b9b9eb1fdccf"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("a977b89f-e9b0-4fde-ba8b-367718752b97"), new Guid("6ba1f557-0cff-4ab6-8359-0ea298eeac6e"), "Visual Studio is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin Test", new DateTime(2024, 2, 11, 22, 36, 5, 239, DateTimeKind.Local).AddTicks(558), null, null, new Guid("509d3d55-646b-413b-8f3e-01c5da780f76"), false, null, null, "Visual Studio Deneme Makalesi", new Guid("2ef7516c-3a35-4b40-a744-c3c7da3f6e20"), 15 },
                    { new Guid("edea0cae-08ce-426b-adc7-e20a33dca278"), new Guid("d21f1e86-4ddf-4db0-b469-7bc63c1a7798"), "Asp.Net Core is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin Test", new DateTime(2024, 2, 11, 22, 36, 5, 239, DateTimeKind.Local).AddTicks(548), null, null, new Guid("25a68467-8a27-45b7-9202-50241cea50fc"), false, null, null, "Asp.Net Core Deneme Makalesi", new Guid("324bdfde-4ddb-4333-9ed1-1e9e91226a73"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("47acf50f-db96-4276-afe3-b86227094670"),
                column: "ConcurrencyStamp",
                value: "e3f9b6a4-11a9-4f41-98b1-53ebd91a35ed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5a445b3e-3728-4853-9362-b4fd9aab42cb"),
                column: "ConcurrencyStamp",
                value: "7aa2ab5a-54c5-41da-b864-d9a3eef34e95");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7b480a8e-6625-4f19-9378-eae2fe2da3cc"),
                column: "ConcurrencyStamp",
                value: "81063d87-f964-4857-8bcc-e61f42f689c3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2ef7516c-3a35-4b40-a744-c3c7da3f6e20"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "151e0f1c-9f1c-4900-9b1a-48397c4b7757", "AQAAAAIAAYagAAAAEAJ7p5H9taCXh0y5Q2V2Vb6EG2tkNGXTFo7KT2fpv6RI9U+XoagjFcCz4f+ewIXz4w==", "d3345aba-9cd6-4fe0-a866-aad843d19d77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("324bdfde-4ddb-4333-9ed1-1e9e91226a73"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edc82977-e7af-4fe3-933e-16589875b892", "AQAAAAIAAYagAAAAEMXQcB9HPukWVyf1BUksLqU8bR0j2gFPd4rMYx1NNhkGKrKoqRZckn6YI3uUE+F17g==", "30abbc38-0f6f-4f5a-9e45-f0520b469bf1" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6ba1f557-0cff-4ab6-8359-0ea298eeac6e"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 11, 22, 36, 5, 240, DateTimeKind.Local).AddTicks(5281));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d21f1e86-4ddf-4db0-b469-7bc63c1a7798"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 11, 22, 36, 5, 240, DateTimeKind.Local).AddTicks(5254));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("25a68467-8a27-45b7-9202-50241cea50fc"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 11, 22, 36, 5, 240, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("509d3d55-646b-413b-8f3e-01c5da780f76"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 11, 22, 36, 5, 240, DateTimeKind.Local).AddTicks(8636));

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "GithubUrl", "GmailUrl", "InstagramUrl", "IsDeleted", "LinkedinUrl", "ModifiedBy", "ModifiedDate", "TwitterUrl" },
                values: new object[] { 1, "Undefined", new DateTime(2024, 2, 11, 22, 36, 5, 243, DateTimeKind.Local).AddTicks(9259), null, null, "test", "test", "test", false, "test", null, null, "test" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("a977b89f-e9b0-4fde-ba8b-367718752b97"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("edea0cae-08ce-426b-adc7-e20a33dca278"));

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: 1);

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
    }
}
