using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthenticationServer.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangedForeignkeyConnectionBetweenRoleUserRoleUserClaimAndClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_Clients_AppId",
                schema: "identity",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_AppId",
                schema: "identity",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "AppId",
                schema: "identity",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                schema: "identity",
                table: "AspNetUserRoles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                schema: "identity",
                table: "AspNetUserClaims",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId1",
                schema: "identity",
                table: "AspNetUserClaims",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_ClientId",
                schema: "identity",
                table: "AspNetUserRoles",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_ClientId",
                schema: "identity",
                table: "AspNetUserClaims",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_ClientId1",
                schema: "identity",
                table: "AspNetUserClaims",
                column: "ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_Clients_ClientId",
                schema: "identity",
                table: "AspNetUserClaims",
                column: "ClientId",
                principalSchema: "identity",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_Clients_ClientId1",
                schema: "identity",
                table: "AspNetUserClaims",
                column: "ClientId1",
                principalSchema: "identity",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Clients_ClientId",
                schema: "identity",
                table: "AspNetUserRoles",
                column: "ClientId",
                principalSchema: "identity",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_Clients_ClientId",
                schema: "identity",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_Clients_ClientId1",
                schema: "identity",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Clients_ClientId",
                schema: "identity",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_ClientId",
                schema: "identity",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserClaims_ClientId",
                schema: "identity",
                table: "AspNetUserClaims");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserClaims_ClientId1",
                schema: "identity",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "ClientId",
                schema: "identity",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "ClientId",
                schema: "identity",
                table: "AspNetUserClaims");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                schema: "identity",
                table: "AspNetUserClaims");

            migrationBuilder.AddColumn<Guid>(
                name: "AppId",
                schema: "identity",
                table: "AspNetRoles",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_AppId",
                schema: "identity",
                table: "AspNetRoles",
                column: "AppId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_Clients_AppId",
                schema: "identity",
                table: "AspNetRoles",
                column: "AppId",
                principalSchema: "identity",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
