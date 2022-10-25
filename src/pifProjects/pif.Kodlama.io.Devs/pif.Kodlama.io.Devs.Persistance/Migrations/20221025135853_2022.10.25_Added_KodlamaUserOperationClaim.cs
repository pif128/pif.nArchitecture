using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pif.Kodlama.io.Devs.Persistance.Migrations
{
    public partial class _20221025_Added_KodlamaUserOperationClaim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                table: "UserOperationClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaims_User_UserId",
                table: "UserOperationClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOperationClaims",
                table: "UserOperationClaims");

            migrationBuilder.RenameTable(
                name: "UserOperationClaims",
                newName: "UserOperationClaim");

            migrationBuilder.RenameIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaim",
                newName: "IX_UserOperationClaim_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaim",
                newName: "IX_UserOperationClaim_OperationClaimId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "UserOperationClaim",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "KodlamaUserId",
                table: "UserOperationClaim",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOperationClaim",
                table: "UserOperationClaim",
                column: "Id");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 176, 151, 96, 71, 5, 151, 88, 142, 26, 177, 50, 51, 238, 155, 213, 8, 232, 228, 131, 245, 231, 219, 126, 156, 182, 112, 210, 136, 69, 169, 108, 238, 41, 52, 88, 163, 221, 104, 127, 225, 205, 1, 202, 212, 82, 178, 82, 63, 88, 179, 32, 87, 87, 3, 82, 234, 89, 60, 201, 221, 91, 226, 86, 174 }, new byte[] { 213, 95, 16, 44, 162, 166, 31, 9, 231, 74, 44, 201, 232, 102, 22, 11, 241, 199, 2, 215, 209, 79, 159, 45, 188, 250, 74, 239, 184, 122, 206, 150, 78, 11, 5, 1, 169, 212, 44, 201, 237, 124, 163, 120, 31, 149, 238, 180, 193, 206, 239, 157, 236, 67, 7, 19, 169, 183, 11, 11, 21, 205, 26, 205, 139, 83, 246, 103, 62, 97, 44, 5, 232, 218, 6, 80, 92, 248, 109, 134, 148, 23, 1, 236, 146, 7, 230, 91, 50, 112, 67, 159, 219, 186, 104, 139, 41, 131, 125, 43, 90, 74, 1, 122, 240, 16, 141, 67, 229, 224, 182, 191, 64, 145, 49, 204, 248, 118, 50, 252, 7, 254, 240, 80, 114, 26, 42, 111 } });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 176, 151, 96, 71, 5, 151, 88, 142, 26, 177, 50, 51, 238, 155, 213, 8, 232, 228, 131, 245, 231, 219, 126, 156, 182, 112, 210, 136, 69, 169, 108, 238, 41, 52, 88, 163, 221, 104, 127, 225, 205, 1, 202, 212, 82, 178, 82, 63, 88, 179, 32, 87, 87, 3, 82, 234, 89, 60, 201, 221, 91, 226, 86, 174 }, new byte[] { 213, 95, 16, 44, 162, 166, 31, 9, 231, 74, 44, 201, 232, 102, 22, 11, 241, 199, 2, 215, 209, 79, 159, 45, 188, 250, 74, 239, 184, 122, 206, 150, 78, 11, 5, 1, 169, 212, 44, 201, 237, 124, 163, 120, 31, 149, 238, 180, 193, 206, 239, 157, 236, 67, 7, 19, 169, 183, 11, 11, 21, 205, 26, 205, 139, 83, 246, 103, 62, 97, 44, 5, 232, 218, 6, 80, 92, 248, 109, 134, 148, 23, 1, 236, 146, 7, 230, 91, 50, 112, 67, 159, 219, 186, 104, 139, 41, 131, 125, 43, 90, 74, 1, 122, 240, 16, 141, 67, 229, 224, 182, 191, 64, 145, 49, 204, 248, 118, 50, 252, 7, 254, 240, 80, 114, 26, 42, 111 } });

            migrationBuilder.InsertData(
                table: "UserOperationClaim",
                columns: new[] { "Id", "Discriminator", "KodlamaUserId", "OperationClaimId", "UserId" },
                values: new object[] { 1, "KodlamaUserOperationClaim", 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaim",
                columns: new[] { "Id", "Discriminator", "KodlamaUserId", "OperationClaimId", "UserId" },
                values: new object[] { 2, "KodlamaUserOperationClaim", 2, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaim_KodlamaUserId",
                table: "UserOperationClaim",
                column: "KodlamaUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaim_OperationClaims_OperationClaimId",
                table: "UserOperationClaim",
                column: "OperationClaimId",
                principalTable: "OperationClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaim_User_KodlamaUserId",
                table: "UserOperationClaim",
                column: "KodlamaUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaim_User_UserId",
                table: "UserOperationClaim",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaim_OperationClaims_OperationClaimId",
                table: "UserOperationClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaim_User_KodlamaUserId",
                table: "UserOperationClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaim_User_UserId",
                table: "UserOperationClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOperationClaim",
                table: "UserOperationClaim");

            migrationBuilder.DropIndex(
                name: "IX_UserOperationClaim_KodlamaUserId",
                table: "UserOperationClaim");

            migrationBuilder.DeleteData(
                table: "UserOperationClaim",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserOperationClaim",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "UserOperationClaim");

            migrationBuilder.DropColumn(
                name: "KodlamaUserId",
                table: "UserOperationClaim");

            migrationBuilder.RenameTable(
                name: "UserOperationClaim",
                newName: "UserOperationClaims");

            migrationBuilder.RenameIndex(
                name: "IX_UserOperationClaim_UserId",
                table: "UserOperationClaims",
                newName: "IX_UserOperationClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserOperationClaim_OperationClaimId",
                table: "UserOperationClaims",
                newName: "IX_UserOperationClaims_OperationClaimId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOperationClaims",
                table: "UserOperationClaims",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 150, 76, 52, 242, 2, 47, 239, 144, 242, 185, 248, 148, 181, 95, 176, 28, 53, 81, 167, 138, 33, 23, 60, 245, 69, 54, 116, 144, 175, 63, 55, 247, 200, 151, 11, 19, 207, 90, 160, 112, 249, 129, 34, 62, 95, 94, 96, 17, 133, 2, 243, 163, 255, 164, 79, 49, 244, 3, 128, 80, 143, 44, 126, 159 }, new byte[] { 14, 176, 244, 8, 72, 212, 211, 115, 248, 176, 251, 202, 237, 242, 133, 112, 150, 133, 89, 173, 44, 196, 151, 238, 152, 124, 170, 107, 141, 118, 56, 58, 59, 239, 202, 192, 113, 166, 40, 90, 117, 175, 148, 153, 232, 71, 27, 66, 120, 53, 197, 171, 84, 151, 149, 165, 219, 148, 75, 162, 169, 237, 145, 102, 39, 44, 76, 51, 71, 108, 174, 139, 44, 34, 227, 144, 9, 240, 179, 221, 172, 154, 132, 208, 180, 248, 243, 116, 246, 150, 189, 62, 71, 254, 7, 176, 245, 204, 0, 192, 48, 4, 230, 61, 9, 228, 237, 28, 164, 177, 111, 3, 219, 16, 78, 191, 87, 137, 126, 41, 142, 106, 195, 234, 126, 35, 5, 44 } });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 150, 76, 52, 242, 2, 47, 239, 144, 242, 185, 248, 148, 181, 95, 176, 28, 53, 81, 167, 138, 33, 23, 60, 245, 69, 54, 116, 144, 175, 63, 55, 247, 200, 151, 11, 19, 207, 90, 160, 112, 249, 129, 34, 62, 95, 94, 96, 17, 133, 2, 243, 163, 255, 164, 79, 49, 244, 3, 128, 80, 143, 44, 126, 159 }, new byte[] { 14, 176, 244, 8, 72, 212, 211, 115, 248, 176, 251, 202, 237, 242, 133, 112, 150, 133, 89, 173, 44, 196, 151, 238, 152, 124, 170, 107, 141, 118, 56, 58, 59, 239, 202, 192, 113, 166, 40, 90, 117, 175, 148, 153, 232, 71, 27, 66, 120, 53, 197, 171, 84, 151, 149, 165, 219, 148, 75, 162, 169, 237, 145, 102, 39, 44, 76, 51, 71, 108, 174, 139, 44, 34, 227, 144, 9, 240, 179, 221, 172, 154, 132, 208, 180, 248, 243, 116, 246, 150, 189, 62, 71, 254, 7, 176, 245, 204, 0, 192, 48, 4, 230, 61, 9, 228, 237, 28, 164, 177, 111, 3, 219, 16, 78, 191, 87, 137, 126, 41, 142, 106, 195, 234, 126, 35, 5, 44 } });

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId",
                principalTable: "OperationClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaims_User_UserId",
                table: "UserOperationClaims",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
