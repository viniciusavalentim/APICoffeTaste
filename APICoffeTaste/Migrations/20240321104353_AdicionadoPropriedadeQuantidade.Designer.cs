﻿// <auto-generated />
using APICoffeeTaste.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APICoffeeTaste.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240321104353_AdicionadoPropriedadeQuantidade")]
    partial class AdicionadoPropriedadeQuantidade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("APICoffeeTaste.Models.BebidasGeladasModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacoes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BebidasGeladas");
                });

            modelBuilder.Entity("APICoffeeTaste.Models.CafesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MetodoId")
                        .HasColumnType("int");

                    b.Property<string>("Variacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MetodoId");

                    b.ToTable("Cafes");
                });

            modelBuilder.Entity("APICoffeeTaste.Models.IngredientesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BebidasGeladasId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantidade")
                        .HasColumnType("float");

                    b.Property<string>("Unidade")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BebidasGeladasId");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("APICoffeeTaste.Models.MetodosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Metodos")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Metodos");
                });

            modelBuilder.Entity("APICoffeeTaste.Models.ReceitasModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CafeId")
                        .HasColumnType("int");

                    b.Property<float>("Granulometria")
                        .HasColumnType("real");

                    b.Property<float>("QuantidadeDeAgua")
                        .HasColumnType("real");

                    b.Property<float>("QuantidadeDeCafe")
                        .HasColumnType("real");

                    b.Property<int>("Temperatura")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CafeId")
                        .IsUnique();

                    b.ToTable("Receitas");
                });

            modelBuilder.Entity("APICoffeeTaste.Models.CafesModel", b =>
                {
                    b.HasOne("APICoffeeTaste.Models.MetodosModel", "Metodo")
                        .WithMany("Cafes")
                        .HasForeignKey("MetodoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Metodo");
                });

            modelBuilder.Entity("APICoffeeTaste.Models.IngredientesModel", b =>
                {
                    b.HasOne("APICoffeeTaste.Models.BebidasGeladasModel", "BebidasGeladas")
                        .WithMany("Ingredientes")
                        .HasForeignKey("BebidasGeladasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BebidasGeladas");
                });

            modelBuilder.Entity("APICoffeeTaste.Models.ReceitasModel", b =>
                {
                    b.HasOne("APICoffeeTaste.Models.CafesModel", "Cafe")
                        .WithOne("Receita")
                        .HasForeignKey("APICoffeeTaste.Models.ReceitasModel", "CafeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cafe");
                });

            modelBuilder.Entity("APICoffeeTaste.Models.BebidasGeladasModel", b =>
                {
                    b.Navigation("Ingredientes");
                });

            modelBuilder.Entity("APICoffeeTaste.Models.CafesModel", b =>
                {
                    b.Navigation("Receita");
                });

            modelBuilder.Entity("APICoffeeTaste.Models.MetodosModel", b =>
                {
                    b.Navigation("Cafes");
                });
#pragma warning restore 612, 618
        }
    }
}