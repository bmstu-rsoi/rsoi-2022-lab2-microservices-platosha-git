using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cars.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    car_uid = table.Column<Guid>(type: "uuid", nullable: false),
                    brand = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    model = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    registration_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    power = table.Column<int>(type: "integer", nullable: true),
                    price = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    availability = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "cars_car_uid_key",
                table: "cars",
                column: "car_uid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cars");
        }
    }
}
