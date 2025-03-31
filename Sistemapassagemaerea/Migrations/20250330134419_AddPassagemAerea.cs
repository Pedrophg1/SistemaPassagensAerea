using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Sistemapassagemaerea.Migrations
{
    /// <inheritdoc />
    public partial class AddPassagemAerea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanhiasAereas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodIATA = table.Column<string>(type: "text", nullable: false),
                    NomeCompanhia = table.Column<string>(type: "text", nullable: false),
                    EnderecoCompanhia = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanhiasAereas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passageiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cpf = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PassagensAereas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoPassagem = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    DataHoraCompra = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValorPassagem = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    IdPassageiro = table.Column<int>(type: "integer", nullable: false),
                    IdCompanhiaAerea = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassagensAereas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassagensAereas_CompanhiasAereas_IdCompanhiaAerea",
                        column: x => x.IdCompanhiaAerea,
                        principalTable: "CompanhiasAereas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassagensAereas_Passageiros_IdPassageiro",
                        column: x => x.IdPassageiro,
                        principalTable: "Passageiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassagensAereas_IdCompanhiaAerea",
                table: "PassagensAereas",
                column: "IdCompanhiaAerea");

            migrationBuilder.CreateIndex(
                name: "IX_PassagensAereas_IdPassageiro",
                table: "PassagensAereas",
                column: "IdPassageiro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassagensAereas");

            migrationBuilder.DropTable(
                name: "CompanhiasAereas");

            migrationBuilder.DropTable(
                name: "Passageiros");
        }
    }
}
