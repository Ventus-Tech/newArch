using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using t.Models;

namespace T2.Migrations
{
    [DbContext(typeof(AppicaContext))]
    partial class AppicaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("t.Models.DepartamentoModel", b =>
                {
                    b.Property<int>("IdDep")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Descripcion");

                    b.HasKey("IdDep");
                });

            modelBuilder.Entity("t.Models.Personas", b =>
                {
                    b.Property<int?>("IdPersona")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdDep");

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.Property<string>("Telefono")
                        .IsRequired();

                    b.HasKey("IdPersona");
                });

            modelBuilder.Entity("t.Models.Personas", b =>
                {
                    b.HasOne("t.Models.DepartamentoModel")
                        .WithMany()
                        .HasForeignKey("IdDep");
                });
        }
    }
}
