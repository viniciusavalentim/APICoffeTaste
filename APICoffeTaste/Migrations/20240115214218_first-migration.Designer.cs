﻿// <auto-generated />
using APICoffeTaste.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APICoffeTaste.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240115214218_first-migration")]
    partial class firstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("APICoffeTaste.Models.MetodosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Metodos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("QuantidadeDeAgua")
                        .HasColumnType("real");

                    b.Property<float>("QuantidadeDeCafe")
                        .HasColumnType("real");

                    b.Property<int>("Temperatura")
                        .HasColumnType("int");

                    b.Property<string>("Variacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Metodos");
                });
#pragma warning restore 612, 618
        }
    }
}
