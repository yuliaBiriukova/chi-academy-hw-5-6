using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HW_6.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    gr_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gr_name = table.Column<string>(type: "nvarchar(124)", maxLength: 124, nullable: false),
                    gr_temp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.gr_id);
                });

            migrationBuilder.CreateTable(
                name: "Analysis",
                columns: table => new
                {
                    an_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    an_name = table.Column<string>(type: "nvarchar(124)", maxLength: 124, nullable: false),
                    an_cost = table.Column<int>(type: "int", nullable: false),
                    an_price = table.Column<int>(type: "int", nullable: false),
                    an_group = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analysis", x => x.an_id);
                    table.ForeignKey(
                        name: "FK_Group",
                        column: x => x.an_group,
                        principalTable: "Groups",
                        principalColumn: "gr_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ord_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ord_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ord_an = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ord_id);
                    table.ForeignKey(
                        name: "FK_Analysis",
                        column: x => x.ord_an,
                        principalTable: "Analysis",
                        principalColumn: "an_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analysis_an_group",
                table: "Analysis",
                column: "an_group");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ord_an",
                table: "Orders",
                column: "ord_an");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Analysis");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
