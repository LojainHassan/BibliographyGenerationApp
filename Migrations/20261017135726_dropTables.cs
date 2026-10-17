using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliographyGenerationApp.Migrations
{
    /// <inheritdoc />
    public partial class dropTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepositOrderToBook");

            migrationBuilder.DropTable(
                name: "DepositOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepositOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepositorName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepositOrderToBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepositOrderId = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Isbn = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PublicationYear = table.Column<int>(type: "int", nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositOrderToBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositOrderToBook_DepositOrder_DepositOrderId",
                        column: x => x.DepositOrderId,
                        principalTable: "DepositOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepositOrder_OrderNumber",
                table: "DepositOrder",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepositOrderToBook_DepositOrderId",
                table: "DepositOrderToBook",
                column: "DepositOrderId");
        }
    }
}
