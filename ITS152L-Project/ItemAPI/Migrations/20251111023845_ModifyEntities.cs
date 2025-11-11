using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITS152L_Project.Migrations
{
    /// <inheritdoc />
    public partial class ModifyEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_password_reset_tokens_Users_UserId",
                table: "password_reset_tokens");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_password_reset_tokens",
                table: "password_reset_tokens");

            migrationBuilder.RenameTable(
                name: "password_reset_tokens",
                newName: "PasswordResetTokens");

            migrationBuilder.RenameIndex(
                name: "IX_password_reset_tokens_UserId",
                table: "PasswordResetTokens",
                newName: "IX_PasswordResetTokens_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_password_reset_tokens_Token_UserId_IsUsed_Expiry",
                table: "PasswordResetTokens",
                newName: "IX_PasswordResetTokens_Token_UserId_IsUsed_Expiry");

            migrationBuilder.RenameIndex(
                name: "IX_password_reset_tokens_Token",
                table: "PasswordResetTokens",
                newName: "IX_PasswordResetTokens_Token");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PasswordResetTokens",
                table: "PasswordResetTokens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PasswordResetTokens_Users_UserId",
                table: "PasswordResetTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PasswordResetTokens_Users_UserId",
                table: "PasswordResetTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PasswordResetTokens",
                table: "PasswordResetTokens");

            migrationBuilder.RenameTable(
                name: "PasswordResetTokens",
                newName: "password_reset_tokens");

            migrationBuilder.RenameIndex(
                name: "IX_PasswordResetTokens_UserId",
                table: "password_reset_tokens",
                newName: "IX_password_reset_tokens_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PasswordResetTokens_Token_UserId_IsUsed_Expiry",
                table: "password_reset_tokens",
                newName: "IX_password_reset_tokens_Token_UserId_IsUsed_Expiry");

            migrationBuilder.RenameIndex(
                name: "IX_PasswordResetTokens_Token",
                table: "password_reset_tokens",
                newName: "IX_password_reset_tokens_Token");

            migrationBuilder.AddPrimaryKey(
                name: "PK_password_reset_tokens",
                table: "password_reset_tokens",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.AddForeignKey(
                name: "FK_password_reset_tokens_Users_UserId",
                table: "password_reset_tokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
