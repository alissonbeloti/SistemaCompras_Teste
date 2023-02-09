using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaCompra.API.Migrations
{
    public partial class AddSolicitacaoAndItensCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("df58aceb-e0a0-468d-a912-0ea099694657"));

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Preco", "Situacao" },
                values: new object[] { new Guid("29592a7d-9db3-4dae-aabd-018be59a28b3"), 1, "Descricao01", "Produto01", 100m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: new Guid("29592a7d-9db3-4dae-aabd-018be59a28b3"));

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Categoria", "Descricao", "Nome", "Preco", "Situacao" },
                values: new object[] { new Guid("df58aceb-e0a0-468d-a912-0ea099694657"), 1, "Descricao01", "Produto01", 100m, 1 });
        }
    }
}
