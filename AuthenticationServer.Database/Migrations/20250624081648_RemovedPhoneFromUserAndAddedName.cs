using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthenticationServer.Database.Migrations
{
    /// <inheritdoc />
    public partial class RemovedPhoneFromUserAndAddedName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientScope_Clients_ClientId",
                schema: "identity",
                table: "ClientScope");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientScope_Scopes_ScopeId",
                schema: "identity",
                table: "ClientScope");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientScope",
                schema: "identity",
                table: "ClientScope");

            migrationBuilder.RenameTable(
                name: "ClientScope",
                schema: "identity",
                newName: "ClientScopes",
                newSchema: "identity");

            migrationBuilder.RenameIndex(
                name: "IX_ClientScope_ScopeId",
                schema: "identity",
                table: "ClientScopes",
                newName: "IX_ClientScopes_ScopeId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "identity",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientScopes",
                schema: "identity",
                table: "ClientScopes",
                columns: new[] { "ClientId", "ScopeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClientScopes_Clients_ClientId",
                schema: "identity",
                table: "ClientScopes",
                column: "ClientId",
                principalSchema: "identity",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientScopes_Scopes_ScopeId",
                schema: "identity",
                table: "ClientScopes",
                column: "ScopeId",
                principalSchema: "identity",
                principalTable: "Scopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientScopes_Clients_ClientId",
                schema: "identity",
                table: "ClientScopes");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientScopes_Scopes_ScopeId",
                schema: "identity",
                table: "ClientScopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientScopes",
                schema: "identity",
                table: "ClientScopes");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "identity",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "ClientScopes",
                schema: "identity",
                newName: "ClientScope",
                newSchema: "identity");

            migrationBuilder.RenameIndex(
                name: "IX_ClientScopes_ScopeId",
                schema: "identity",
                table: "ClientScope",
                newName: "IX_ClientScope_ScopeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientScope",
                schema: "identity",
                table: "ClientScope",
                columns: new[] { "ClientId", "ScopeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClientScope_Clients_ClientId",
                schema: "identity",
                table: "ClientScope",
                column: "ClientId",
                principalSchema: "identity",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientScope_Scopes_ScopeId",
                schema: "identity",
                table: "ClientScope",
                column: "ScopeId",
                principalSchema: "identity",
                principalTable: "Scopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
