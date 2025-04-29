using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnapCash.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    payer = table.Column<int>(type: "INTEGER", nullable: false),
                    payee = table.Column<int>(type: "INTEGER", nullable: false),
                    registerid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transfers_Registers_registerid",
                        column: x => x.registerid,
                        principalTable: "Registers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_registerid",
                table: "Transfers",
                column: "registerid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transfers");
        }
    }
}
