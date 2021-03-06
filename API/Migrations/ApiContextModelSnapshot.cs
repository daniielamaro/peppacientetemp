// <auto-generated />
using System;
using API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("API.Domain.Arquivo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Binario")
                        .HasColumnType("bytea");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Tipo")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Arquivos");
                });

            modelBuilder.Entity("API.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .HasColumnType("text");

                    b.Property<Guid?>("FotoPerfilId")
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Rg")
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FotoPerfilId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("API.Domain.User", b =>
                {
                    b.HasOne("API.Domain.Arquivo", "FotoPerfil")
                        .WithMany()
                        .HasForeignKey("FotoPerfilId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
