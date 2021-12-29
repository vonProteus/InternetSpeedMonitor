using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternetSpeedMonitor.Migrations
{
    public partial class PingAsDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "alter table public.\"SpeedResults\" alter column \"Ping\" type double precision using EXTRACT(mseconds from \"Ping\")");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Ping",
                schema: "public",
                table: "SpeedResults",
                type: "interval",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
