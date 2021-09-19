using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResourcesManager.Services.ParkingPlaces.Api.Migrations
{
    public partial class UpdateReservationState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "ResourceManager.Reservation",
                table: "ReservationStates",
                type: "character varying(26)",
                maxLength: 26,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "ResourceManager.Reservation",
                table: "ReservationStates",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "now() at time zone 'utc'");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ResourceManager.Reservation",
                table: "ReservationStates",
                type: "timestamp without time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "ResourceManager.Reservation",
                table: "ReservationStates");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "ResourceManager.Reservation",
                table: "ReservationStates");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "ResourceManager.Reservation",
                table: "ReservationStates",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(26)",
                oldMaxLength: 26);
        }
    }
}
