using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnapCash.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updatev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Registers_registerid",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "payee",
                table: "Transfers");

            migrationBuilder.RenameColumn(
                name: "registerid",
                table: "Transfers",
                newName: "payerId");

            migrationBuilder.RenameColumn(
                name: "payer",
                table: "Transfers",
                newName: "payeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_registerid",
                table: "Transfers",
                newName: "IX_Transfers_payerId");

            migrationBuilder.RenameColumn(
                name: "senha",
                table: "Registers",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "saldo",
                table: "Registers",
                newName: "Saldo");

            migrationBuilder.RenameColumn(
                name: "nomeCompleto",
                table: "Registers",
                newName: "NomeCompleto");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Registers",
                newName: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_payeeId",
                table: "Transfers",
                column: "payeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Registers_payeeId",
                table: "Transfers",
                column: "payeeId",
                principalTable: "Registers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Registers_payerId",
                table: "Transfers",
                column: "payerId",
                principalTable: "Registers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Registers_payeeId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Registers_payerId",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Transfers_payeeId",
                table: "Transfers");

            migrationBuilder.RenameColumn(
                name: "payerId",
                table: "Transfers",
                newName: "registerid");

            migrationBuilder.RenameColumn(
                name: "payeeId",
                table: "Transfers",
                newName: "payer");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_payerId",
                table: "Transfers",
                newName: "IX_Transfers_registerid");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Registers",
                newName: "senha");

            migrationBuilder.RenameColumn(
                name: "Saldo",
                table: "Registers",
                newName: "saldo");

            migrationBuilder.RenameColumn(
                name: "NomeCompleto",
                table: "Registers",
                newName: "nomeCompleto");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Registers",
                newName: "email");

            migrationBuilder.AddColumn<int>(
                name: "payee",
                table: "Transfers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Registers_registerid",
                table: "Transfers",
                column: "registerid",
                principalTable: "Registers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
