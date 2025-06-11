using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthenticationServer.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangedClientAndAddedClientScope : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowedScopes",
                schema: "identity",
                table: "Clients");

            migrationBuilder.CreateTable(
                name: "ClientScope",
                schema: "identity",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScopeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientScope", x => new { x.ClientId, x.ScopeId });
                    table.ForeignKey(
                        name: "FK_ClientScope_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "identity",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientScope_Scopes_ScopeId",
                        column: x => x.ScopeId,
                        principalSchema: "identity",
                        principalTable: "Scopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientScope_ScopeId",
                schema: "identity",
                table: "ClientScope",
                column: "ScopeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientScope",
                schema: "identity");

            migrationBuilder.AddColumn<List<string>>(
                name: "AllowedScopes",
                schema: "identity",
                table: "Clients",
                type: "text[]",
                nullable: false);
        }
    }
}
