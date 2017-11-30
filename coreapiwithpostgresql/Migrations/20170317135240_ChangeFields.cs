using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coreapiwithpostgresql.Migrations
{
    public partial class ChangeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateStart",
                table: "Todos",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateFinish",
                table: "Todos",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateStart",
                table: "Todos",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateFinish",
                table: "Todos",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
