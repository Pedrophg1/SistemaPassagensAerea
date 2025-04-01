﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sistemapassagemaerea.Data;

#nullable disable

namespace Sistemapassagemaerea.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250401011901_TransactionMigrationFinizz")]
    partial class TransactionMigrationFinizz
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Sistemapassagemaerea.Domain.CompanhiaAerea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CodIATA")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EnderecoCompanhia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomeCompanhia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CompanhiasAereas");
                });

            modelBuilder.Entity("Sistemapassagemaerea.Domain.Comprovante", b =>
                {
                    b.Property<string>("CodigoPassagem")
                        .HasColumnType("text");

                    b.Property<string>("CpfPassageiro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataHoraCompra")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("NomePassageiro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ValorPassagem")
                        .HasColumnType("numeric");

                    b.HasKey("CodigoPassagem");

                    b.ToTable("Comprovantes");
                });

            modelBuilder.Entity("Sistemapassagemaerea.Domain.Passageiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Passageiros");
                });

            modelBuilder.Entity("Sistemapassagemaerea.Domain.PassagemAerea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoPassagem")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<DateTime>("DataHoraCompra")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdCompanhiaAerea")
                        .HasColumnType("integer");

                    b.Property<int>("IdPassageiro")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorPassagem")
                        .HasPrecision(12, 2)
                        .HasColumnType("numeric(12,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdCompanhiaAerea");

                    b.HasIndex("IdPassageiro");

                    b.ToTable("PassagensAereas");
                });

            modelBuilder.Entity("Sistemapassagemaerea.Domain.PassagemAerea", b =>
                {
                    b.HasOne("Sistemapassagemaerea.Domain.CompanhiaAerea", "CompanhiaAerea")
                        .WithMany("PassagensAereas")
                        .HasForeignKey("IdCompanhiaAerea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistemapassagemaerea.Domain.Passageiro", "Passageiro")
                        .WithMany("PassagensAereas")
                        .HasForeignKey("IdPassageiro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanhiaAerea");

                    b.Navigation("Passageiro");
                });

            modelBuilder.Entity("Sistemapassagemaerea.Domain.CompanhiaAerea", b =>
                {
                    b.Navigation("PassagensAereas");
                });

            modelBuilder.Entity("Sistemapassagemaerea.Domain.Passageiro", b =>
                {
                    b.Navigation("PassagensAereas");
                });
#pragma warning restore 612, 618
        }
    }
}
