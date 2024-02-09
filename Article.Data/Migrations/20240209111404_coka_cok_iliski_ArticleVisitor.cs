using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Article.Data.Migrations
{
    /// <inheritdoc />
    public partial class cokacokiliskiArticleVisitor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("55553eda-f54a-4760-82b1-e14cb7116ed5"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("6d801abf-1528-4cf2-8d84-60aa9120cec9"));

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitors",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVisitors", x => new { x.ArticleId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_VisitorId",
                table: "ArticleVisitors",
                column: "VisitorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitors");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("7bdf8e8d-21fa-4287-b043-aa6da9d2afb8"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("cf9077a2-9030-4701-954e-7759229a2563"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("55553eda-f54a-4760-82b1-e14cb7116ed5"), new Guid("6ba1f557-0cff-4ab6-8359-0ea298eeac6e"), "Visual Studio is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin Test", new DateTime(2024, 2, 5, 22, 2, 45, 786, DateTimeKind.Local).AddTicks(6321), null, null, new Guid("509d3d55-646b-413b-8f3e-01c5da780f76"), false, null, null, "Visual Studio Deneme Makalesi", new Guid("2ef7516c-3a35-4b40-a744-c3c7da3f6e20"), 15 },
                    { new Guid("6d801abf-1528-4cf2-8d84-60aa9120cec9"), new Guid("d21f1e86-4ddf-4db0-b469-7bc63c1a7798"), "Asp.Net Core is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin Test", new DateTime(2024, 2, 5, 22, 2, 45, 786, DateTimeKind.Local).AddTicks(6310), null, null, new Guid("25a68467-8a27-45b7-9202-50241cea50fc"), false, null, null, "Asp.Net Core Deneme Makalesi", new Guid("324bdfde-4ddb-4333-9ed1-1e9e91226a73"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("47acf50f-db96-4276-afe3-b86227094670"),
                column: "ConcurrencyStamp",
                value: "7f6ea362-81c6-493f-9342-adeafd683ece");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5a445b3e-3728-4853-9362-b4fd9aab42cb"),
                column: "ConcurrencyStamp",
                value: "a43a95e5-dad0-4cc4-9fc1-521ce0d50fea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7b480a8e-6625-4f19-9378-eae2fe2da3cc"),
                column: "ConcurrencyStamp",
                value: "60f235fd-e777-46e2-a1d8-d136510935b5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2ef7516c-3a35-4b40-a744-c3c7da3f6e20"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2e64833-2293-4d3a-847c-fe2c7704427e", "AQAAAAIAAYagAAAAEPvUKf2vS4yzdQ54HSaTFvH3P55JT/RHC45He+Rfli0A2A3M3gNodK1Kxj28sRwHxQ==", "712c4cce-3b5b-4e5d-9afc-62c06f0eb842" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("324bdfde-4ddb-4333-9ed1-1e9e91226a73"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8167b2e6-79ae-4150-92b5-a147882b0d09", "AQAAAAIAAYagAAAAECw52eqBKmJv3vefvKMboPn5Qo+roxnC0taBmpv6ynxnv6Ku1zm8k0CKp+estrDr8g==", "2d6206d7-56d9-44ed-8386-10204748649c" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6ba1f557-0cff-4ab6-8359-0ea298eeac6e"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 22, 2, 45, 786, DateTimeKind.Local).AddTicks(7945));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d21f1e86-4ddf-4db0-b469-7bc63c1a7798"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 22, 2, 45, 786, DateTimeKind.Local).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("25a68467-8a27-45b7-9202-50241cea50fc"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 22, 2, 45, 786, DateTimeKind.Local).AddTicks(9376));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("509d3d55-646b-413b-8f3e-01c5da780f76"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 5, 22, 2, 45, 786, DateTimeKind.Local).AddTicks(9382));
        }
    }
}
