using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthenticationServer.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedAOneToOneConnectionBetweenUserAndClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessTokens_AspNetUsers_SubjectId",
                schema: "identity",
                table: "AccessTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorizationCodes_AspNetUsers_SubjectId",
                schema: "identity",
                table: "AuthorizationCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorizationCodes_Clients_ClientId",
                schema: "identity",
                table: "AuthorizationCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_SubjectId",
                schema: "identity",
                table: "RefreshTokens");

            migrationBuilder.AddColumn<Guid>(
                name: "ContactUserId",
                schema: "identity",
                table: "Clients",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                schema: "identity",
                table: "AuthorizationCodes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                schema: "identity",
                table: "AuthorizationCodes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                schema: "identity",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ContactUserId",
                schema: "identity",
                table: "Clients",
                column: "ContactUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccessTokens_AspNetUsers_SubjectId",
                schema: "identity",
                table: "AccessTokens",
                column: "SubjectId",
                principalSchema: "identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorizationCodes_AspNetUsers_SubjectId",
                schema: "identity",
                table: "AuthorizationCodes",
                column: "SubjectId",
                principalSchema: "identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorizationCodes_Clients_ClientId",
                schema: "identity",
                table: "AuthorizationCodes",
                column: "ClientId",
                principalSchema: "identity",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_ContactUserId",
                schema: "identity",
                table: "Clients",
                column: "ContactUserId",
                principalSchema: "identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_SubjectId",
                schema: "identity",
                table: "RefreshTokens",
                column: "SubjectId",
                principalSchema: "identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessTokens_AspNetUsers_SubjectId",
                schema: "identity",
                table: "AccessTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorizationCodes_AspNetUsers_SubjectId",
                schema: "identity",
                table: "AuthorizationCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorizationCodes_Clients_ClientId",
                schema: "identity",
                table: "AuthorizationCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_ContactUserId",
                schema: "identity",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_SubjectId",
                schema: "identity",
                table: "RefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ContactUserId",
                schema: "identity",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ContactUserId",
                schema: "identity",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientId",
                schema: "identity",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                schema: "identity",
                table: "AuthorizationCodes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                schema: "identity",
                table: "AuthorizationCodes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_AccessTokens_AspNetUsers_SubjectId",
                schema: "identity",
                table: "AccessTokens",
                column: "SubjectId",
                principalSchema: "identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorizationCodes_AspNetUsers_SubjectId",
                schema: "identity",
                table: "AuthorizationCodes",
                column: "SubjectId",
                principalSchema: "identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorizationCodes_Clients_ClientId",
                schema: "identity",
                table: "AuthorizationCodes",
                column: "ClientId",
                principalSchema: "identity",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_SubjectId",
                schema: "identity",
                table: "RefreshTokens",
                column: "SubjectId",
                principalSchema: "identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
