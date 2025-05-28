using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthenticationServer.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppId",
                schema: "identity",
                table: "AspNetRoles",
                type: "uuid",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "App",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    KeyName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_AppId",
                schema: "identity",
                table: "AspNetRoles",
                column: "AppId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_App_AppId",
                schema: "identity",
                table: "AspNetRoles",
                column: "AppId",
                principalSchema: "identity",
                principalTable: "App",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_App_AppId",
                schema: "identity",
                table: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "App",
                schema: "identity");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_AppId",
                schema: "identity",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "AppId",
                schema: "identity",
                table: "AspNetRoles");
        }
    }
}
