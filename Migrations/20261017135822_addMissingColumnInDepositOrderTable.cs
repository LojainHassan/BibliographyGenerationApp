using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliographyGenerationApp.Migrations
{
    /// <inheritdoc />
    public partial class addMissingColumnInDepositOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeweyClassificationInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeweyClassificationInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepositOrderInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepositorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeweyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeweyClassificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositOrderInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositOrderInfo_DeweyClassificationInfo_DeweyClassificationId",
                        column: x => x.DeweyClassificationId,
                        principalTable: "DeweyClassificationInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepositOrderBookInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepositOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Isbn = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PublicationYear = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositOrderBookInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositOrderBookInfo_DepositOrderInfo_DepositOrderId",
                        column: x => x.DepositOrderId,
                        principalTable: "DepositOrderInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepositOrderBookInfo_DepositOrderId",
                table: "DepositOrderBookInfo",
                column: "DepositOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositOrderInfo_DeweyClassificationId",
                table: "DepositOrderInfo",
                column: "DeweyClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositOrderInfo_OrderNumber",
                table: "DepositOrderInfo",
                column: "OrderNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepositOrderBookInfo");

            migrationBuilder.DropTable(
                name: "DepositOrderInfo");

            migrationBuilder.DropTable(
                name: "DeweyClassificationInfo");
        }
    }
}
