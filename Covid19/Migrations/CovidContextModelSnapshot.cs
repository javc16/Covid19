// <auto-generated />
using System;
using Covid19.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Covid19.Migrations
{
    [DbContext(typeof(CovidContext))]
    partial class CovidContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Covid19.Models.Ciudadano", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numeroIdentidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Ciudadano");
                });

            modelBuilder.Entity("Covid19.Models.ControlVacunas", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ciudadanoid")
                        .HasColumnType("int");

                    b.Property<int?>("direccionid")
                        .HasColumnType("int");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.Property<int>("idCiudadano")
                        .HasColumnType("int");

                    b.Property<int>("idDireccion")
                        .HasColumnType("int");

                    b.Property<int>("primeraDosis")
                        .HasColumnType("int");

                    b.Property<int>("segundaDosis")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ciudadanoid");

                    b.HasIndex("direccionid");

                    b.ToTable("ControlVacunas");
                });

            modelBuilder.Entity("Covid19.Models.Direccion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("centroVacunacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("colonia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("estado")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Direccion");
                });

            modelBuilder.Entity("Covid19.Models.ControlVacunas", b =>
                {
                    b.HasOne("Covid19.Models.Ciudadano", "ciudadano")
                        .WithMany()
                        .HasForeignKey("ciudadanoid");

                    b.HasOne("Covid19.Models.Direccion", "direccion")
                        .WithMany()
                        .HasForeignKey("direccionid");

                    b.Navigation("ciudadano");

                    b.Navigation("direccion");
                });
#pragma warning restore 612, 618
        }
    }
}
