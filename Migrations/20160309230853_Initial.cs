using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace T2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartamentoModel",
                columns: table => new
                {
                    IdDep = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentoModel", x => x.IdDep);
                });
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    IdPersona = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdDep = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.IdPersona);
                    table.ForeignKey(
                        name: "FK_Personas_DepartamentoModel_IdDep",
                        column: x => x.IdDep,
                        principalTable: "DepartamentoModel",
                        principalColumn: "IdDep",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Personas");
            migrationBuilder.DropTable("DepartamentoModel");
        }
    }
}
