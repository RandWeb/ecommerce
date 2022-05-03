using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pranca.Infrastructure.EFCore.Migrations
{
    public partial class AddSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccessLevelId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AccessLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 150, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessLevels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "PageName", "ParentId", "Sort" },
                values: new object[] { new Guid("beed997c-058d-4a61-8e14-ae8a005aa70d"), "3b2e478b-55f0-4c41-9bd8-a6516d321d93", "دسترسی مدیر کل", "FullControl", "FULLCONTROL", "FullControl", new Guid("00000000-0000-0000-0000-000000000000"), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccessLevelId",
                table: "Users",
                column: "AccessLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AccessLevels_AccessLevelId",
                table: "Users",
                column: "AccessLevelId",
                principalTable: "AccessLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AccessLevels_AccessLevelId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AccessLevels");

            migrationBuilder.DropIndex(
                name: "IX_Users_AccessLevelId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("beed997c-058d-4a61-8e14-ae8a005aa70d"));

            migrationBuilder.DropColumn(
                name: "AccessLevelId",
                table: "Users");
        }
    }
}
