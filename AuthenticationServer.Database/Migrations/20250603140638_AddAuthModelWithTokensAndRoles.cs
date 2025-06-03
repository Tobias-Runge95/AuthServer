using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthenticationServer.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthModelWithTokensAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_App_AppId",
                schema: "identity",
                table: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "UserApp",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "App",
                schema: "identity");

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<string>(type: "text", nullable: false),
                    ClientName = table.Column<string>(type: "text", nullable: false),
                    ClientType = table.Column<string>(type: "text", nullable: false),
                    ClientSecretHash = table.Column<string>(type: "text", nullable: false),
                    RedirectUris = table.Column<List<string>>(type: "text[]", nullable: false),
                    AllowedGrantTypes = table.Column<List<string>>(type: "text[]", nullable: false),
                    AllowedScopes = table.Column<List<string>>(type: "text[]", nullable: false),
                    JwksUri = table.Column<string>(type: "text", nullable: false),
                    PublicKeyPem = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scopes",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessTokens",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TokenId = table.Column<string>(type: "text", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: true),
                    IssuedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Revoked = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessTokens_AspNetUsers_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccessTokens_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "identity",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorizationCodes",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    RedirectUri = table.Column<string>(type: "text", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: true),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RequestedScopes = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizationCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorizationCodes_AspNetUsers_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuthorizationCodes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "identity",
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: true),
                    IssuedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Revoked = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_SubjectId",
                        column: x => x.SubjectId,
                        principalSchema: "identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "identity",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClients",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClients", x => new { x.UserId, x.AppId });
                    table.ForeignKey(
                        name: "FK_UserClients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClients_Clients_AppId",
                        column: x => x.AppId,
                        principalSchema: "identity",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessTokenScopes",
                schema: "identity",
                columns: table => new
                {
                    AccessTokenId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScopeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessTokenScopes", x => new { x.AccessTokenId, x.ScopeId });
                    table.ForeignKey(
                        name: "FK_AccessTokenScopes_AccessTokens_AccessTokenId",
                        column: x => x.AccessTokenId,
                        principalSchema: "identity",
                        principalTable: "AccessTokens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessTokenScopes_Scopes_ScopeId",
                        column: x => x.ScopeId,
                        principalSchema: "identity",
                        principalTable: "Scopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorizationCodeScopes",
                schema: "identity",
                columns: table => new
                {
                    AuthorizationCodeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScopeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizationCodeScopes", x => new { x.AuthorizationCodeId, x.ScopeId });
                    table.ForeignKey(
                        name: "FK_AuthorizationCodeScopes_AuthorizationCodes_AuthorizationCod~",
                        column: x => x.AuthorizationCodeId,
                        principalSchema: "identity",
                        principalTable: "AuthorizationCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorizationCodeScopes_Scopes_ScopeId",
                        column: x => x.ScopeId,
                        principalSchema: "identity",
                        principalTable: "Scopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessTokens_ClientId",
                schema: "identity",
                table: "AccessTokens",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessTokens_SubjectId",
                schema: "identity",
                table: "AccessTokens",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessTokenScopes_ScopeId",
                schema: "identity",
                table: "AccessTokenScopes",
                column: "ScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizationCodes_ClientId",
                schema: "identity",
                table: "AuthorizationCodes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizationCodes_SubjectId",
                schema: "identity",
                table: "AuthorizationCodes",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizationCodeScopes_ScopeId",
                schema: "identity",
                table: "AuthorizationCodeScopes",
                column: "ScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_ClientId",
                schema: "identity",
                table: "RefreshTokens",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_SubjectId",
                schema: "identity",
                table: "RefreshTokens",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClients_AppId",
                schema: "identity",
                table: "UserClients",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_Clients_AppId",
                schema: "identity",
                table: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AccessTokenScopes",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AuthorizationCodeScopes",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "RefreshTokens",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserClients",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AccessTokens",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "AuthorizationCodes",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Scopes",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "identity");

            migrationBuilder.CreateTable(
                name: "App",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    KeyName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserApp",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserApp", x => new { x.UserId, x.AppId });
                    table.ForeignKey(
                        name: "FK_UserApp_App_AppId",
                        column: x => x.AppId,
                        principalSchema: "identity",
                        principalTable: "App",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserApp_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserApp_AppId",
                schema: "identity",
                table: "UserApp",
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
    }
}
