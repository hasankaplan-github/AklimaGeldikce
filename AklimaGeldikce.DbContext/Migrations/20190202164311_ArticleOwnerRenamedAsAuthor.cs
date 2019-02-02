using Microsoft.EntityFrameworkCore.Migrations;

namespace AklimaGeldikce.DbContext.Migrations
{
    public partial class ArticleOwnerRenamedAsAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_User_OwnerId",
                table: "Article");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Article",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Article_OwnerId",
                table: "Article",
                newName: "IX_Article_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_User_AuthorId",
                table: "Article",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_User_AuthorId",
                table: "Article");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Article",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Article_AuthorId",
                table: "Article",
                newName: "IX_Article_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_User_OwnerId",
                table: "Article",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
