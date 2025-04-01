using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sistemapassagemaerea.Migrations
{
    /// <inheritdoc />
    public partial class TransactionMigrationFinal5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comprovantes",
                table: "Comprovantes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Comprovantes");

            migrationBuilder.DropColumn(
                name: "NumeroPassagem",
                table: "Comprovantes");

            migrationBuilder.AlterColumn<string>(
                name: "NomePassageiro",
                table: "Comprovantes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoPassagem",
                table: "Comprovantes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CpfPassageiro",
                table: "Comprovantes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHoraCompra",
                table: "Comprovantes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "ValorPassagem",
                table: "Comprovantes",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comprovantes",
                table: "Comprovantes",
                column: "CodigoPassagem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comprovantes",
                table: "Comprovantes");

            migrationBuilder.DropColumn(
                name: "CodigoPassagem",
                table: "Comprovantes");

            migrationBuilder.DropColumn(
                name: "CpfPassageiro",
                table: "Comprovantes");

            migrationBuilder.DropColumn(
                name: "DataHoraCompra",
                table: "Comprovantes");

            migrationBuilder.DropColumn(
                name: "ValorPassagem",
                table: "Comprovantes");

            migrationBuilder.AlterColumn<string>(
                name: "NomePassageiro",
                table: "Comprovantes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Comprovantes",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "NumeroPassagem",
                table: "Comprovantes",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comprovantes",
                table: "Comprovantes",
                column: "Id");
        }
    }
}
