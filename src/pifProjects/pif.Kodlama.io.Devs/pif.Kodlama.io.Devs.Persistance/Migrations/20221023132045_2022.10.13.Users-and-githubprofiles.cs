using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pif.Kodlama.io.Devs.Persistance.Migrations
{
    public partial class _20221013Usersandgithubprofiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgrammingLanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Technologies_ProgrammingLanguages_ProgrammingLanguageId",
                        column: x => x.ProgrammingLanguageId,
                        principalTable: "ProgrammingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AuthenticatorType = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GithubProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GithubAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GithubProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GithubProfiles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId" },
                values: new object[,]
                {
                    { 1, "WPF", 1 },
                    { 2, "Asp.NET", 1 },
                    { 3, "JPS", 2 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AuthenticatorType", "Discriminator", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "KodlamaUser", "pif@pif128.com", "pif", "128", new byte[] { 150, 76, 52, 242, 2, 47, 239, 144, 242, 185, 248, 148, 181, 95, 176, 28, 53, 81, 167, 138, 33, 23, 60, 245, 69, 54, 116, 144, 175, 63, 55, 247, 200, 151, 11, 19, 207, 90, 160, 112, 249, 129, 34, 62, 95, 94, 96, 17, 133, 2, 243, 163, 255, 164, 79, 49, 244, 3, 128, 80, 143, 44, 126, 159 }, new byte[] { 14, 176, 244, 8, 72, 212, 211, 115, 248, 176, 251, 202, 237, 242, 133, 112, 150, 133, 89, 173, 44, 196, 151, 238, 152, 124, 170, 107, 141, 118, 56, 58, 59, 239, 202, 192, 113, 166, 40, 90, 117, 175, 148, 153, 232, 71, 27, 66, 120, 53, 197, 171, 84, 151, 149, 165, 219, 148, 75, 162, 169, 237, 145, 102, 39, 44, 76, 51, 71, 108, 174, 139, 44, 34, 227, 144, 9, 240, 179, 221, 172, 154, 132, 208, 180, 248, 243, 116, 246, 150, 189, 62, 71, 254, 7, 176, 245, 204, 0, 192, 48, 4, 230, 61, 9, 228, 237, 28, 164, 177, 111, 3, 219, 16, 78, 191, 87, 137, 126, 41, 142, 106, 195, 234, 126, 35, 5, 44 }, true, "pif128" },
                    { 2, 0, "KodlamaUser", "pif2@pif128.com", "pif2", "128", new byte[] { 150, 76, 52, 242, 2, 47, 239, 144, 242, 185, 248, 148, 181, 95, 176, 28, 53, 81, 167, 138, 33, 23, 60, 245, 69, 54, 116, 144, 175, 63, 55, 247, 200, 151, 11, 19, 207, 90, 160, 112, 249, 129, 34, 62, 95, 94, 96, 17, 133, 2, 243, 163, 255, 164, 79, 49, 244, 3, 128, 80, 143, 44, 126, 159 }, new byte[] { 14, 176, 244, 8, 72, 212, 211, 115, 248, 176, 251, 202, 237, 242, 133, 112, 150, 133, 89, 173, 44, 196, 151, 238, 152, 124, 170, 107, 141, 118, 56, 58, 59, 239, 202, 192, 113, 166, 40, 90, 117, 175, 148, 153, 232, 71, 27, 66, 120, 53, 197, 171, 84, 151, 149, 165, 219, 148, 75, 162, 169, 237, 145, 102, 39, 44, 76, 51, 71, 108, 174, 139, 44, 34, 227, 144, 9, 240, 179, 221, 172, 154, 132, 208, 180, 248, 243, 116, 246, 150, 189, 62, 71, 254, 7, 176, 245, 204, 0, 192, 48, 4, 230, 61, 9, 228, 237, 28, 164, 177, 111, 3, 219, 16, 78, 191, 87, 137, 126, 41, 142, 106, 195, 234, 126, 35, 5, 44 }, true, "2pif128" }
                });

            migrationBuilder.InsertData(
                table: "GithubProfiles",
                columns: new[] { "Id", "GithubAddress", "UserId" },
                values: new object[] { 1, "/pif128", 1 });

            migrationBuilder.InsertData(
                table: "GithubProfiles",
                columns: new[] { "Id", "GithubAddress", "UserId" },
                values: new object[] { 2, "/aaa", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_GithubProfiles_UserId",
                table: "GithubProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_ProgrammingLanguageId",
                table: "Technologies",
                column: "ProgrammingLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GithubProfiles");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
