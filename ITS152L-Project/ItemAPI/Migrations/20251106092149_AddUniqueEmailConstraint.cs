/**
* Developed by Group 9:
     * Ken Aliling
     * Carl Norbi Felonia
     * Cedrick Miguel Kaneko
     * Amar Jacob Pajarito
     * Dino Alfred Timbol
 **/


using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITS152L_Project.Migrations
{
    public partial class AddUniqueEmailConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Remove duplicate emails (keep oldest)
            migrationBuilder.Sql(@"
                WITH DuplicateEmails AS (
                    SELECT 
                        Id,
                        UserName,
                        ROW_NUMBER() OVER (PARTITION BY LOWER(UserName) ORDER BY Id ASC) as RowNum
                    FROM Users
                )
                DELETE FROM DuplicateEmails WHERE RowNum > 1
            ");

            // Normalize all existing emails to lowercase
            migrationBuilder.Sql(@"
                UPDATE Users 
                SET UserName = LOWER(UserName)
            ");

            // Remove users with empty or NULL emails
            migrationBuilder.Sql(@"
                DELETE FROM Users
                WHERE UserName IS NULL OR LTRIM(RTRIM(UserName)) = ''
            ");

            // Ensure column type is suitable for indexing
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            // Create unique index on UserName
            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName_Unique",
                table: "Users",
                column: "UserName",
                unique: true
            );

            // Add check constraint to prevent empty emails
            migrationBuilder.Sql(@"
                ALTER TABLE Users 
                ADD CONSTRAINT CK_Users_UserName_NotEmpty 
                CHECK (LEN(LTRIM(RTRIM(UserName))) > 0)
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER TABLE Users 
                DROP CONSTRAINT IF EXISTS CK_Users_UserName_NotEmpty
            ");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserName_Unique",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
