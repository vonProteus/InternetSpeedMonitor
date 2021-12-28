using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InternetSpeedMonitor.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "SpeedResults",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Download = table.Column<int>(type: "integer", nullable: false),
                    Upload = table.Column<int>(type: "integer", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ping = table.Column<TimeSpan>(type: "interval", nullable: false),
                    URL = table.Column<string>(type: "text", nullable: false),
                    RawJson = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeedResults", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpeedResults_Timestamp",
                schema: "public",
                table: "SpeedResults",
                column: "Timestamp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpeedResults",
                schema: "public");
        }
    }
}
