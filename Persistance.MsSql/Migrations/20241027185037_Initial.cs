using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistance.MsSql.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    SeatsCount = table.Column<byte>(type: "tinyint", nullable: false),
                    DealerSiteUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    BodyTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_BodyType_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalTable: "BodyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BodyType",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { new Guid("03e69151-869f-4f0e-8faa-b9d2c71e86d5"), new DateTime(2024, 10, 27, 23, 50, 37, 332, DateTimeKind.Local).AddTicks(9828), "Купе", null },
                    { new Guid("2c0da9d1-2030-4ba6-9f7f-5dd29d3d1aa1"), new DateTime(2024, 10, 27, 23, 50, 37, 332, DateTimeKind.Local).AddTicks(9822), "Хэтчбек", null },
                    { new Guid("684fe536-4f2a-4b0e-80ab-d4fc7274e8ad"), new DateTime(2024, 10, 27, 23, 50, 37, 332, DateTimeKind.Local).AddTicks(9826), "Внедорожник", null },
                    { new Guid("9ccb0d7c-38ef-4fe7-8d0e-21be476aea28"), new DateTime(2024, 10, 27, 23, 50, 37, 332, DateTimeKind.Local).AddTicks(9825), "Минивэн", null },
                    { new Guid("cac696ca-9bb5-493b-8b45-76f3c55b5747"), new DateTime(2024, 10, 27, 23, 50, 37, 332, DateTimeKind.Local).AddTicks(9823), "Универсал", null },
                    { new Guid("f2979d54-aad6-4f6f-85c1-3e76f897dec0"), new DateTime(2024, 10, 27, 23, 50, 37, 332, DateTimeKind.Local).AddTicks(9811), "Седан", null }
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { new Guid("12fa5a31-559a-4cf0-a883-f0f1f112c229"), new DateTime(2024, 10, 27, 23, 50, 37, 333, DateTimeKind.Local).AddTicks(5811), "Toyota", null },
                    { new Guid("2bad76c9-4343-4b5d-baee-10c9d5cd8d56"), new DateTime(2024, 10, 27, 23, 50, 37, 333, DateTimeKind.Local).AddTicks(5810), "Nissan", null },
                    { new Guid("66c35efd-17d2-432c-a087-13cf87fcaf11"), new DateTime(2024, 10, 27, 23, 50, 37, 333, DateTimeKind.Local).AddTicks(5802), "Ford", null },
                    { new Guid("9d6380d2-56c4-4765-9b54-abdb1e9063d1"), new DateTime(2024, 10, 27, 23, 50, 37, 333, DateTimeKind.Local).AddTicks(5808), "Jeep", null },
                    { new Guid("eeb47be5-5e22-4b55-86ac-bb6926f19023"), new DateTime(2024, 10, 27, 23, 50, 37, 333, DateTimeKind.Local).AddTicks(5791), "Audi", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_BodyTypeId",
                table: "Car",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_BrandId",
                table: "Car",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "BodyType");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
