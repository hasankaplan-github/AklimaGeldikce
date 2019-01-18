using Microsoft.EntityFrameworkCore.Migrations;

namespace AklimaGeldikce.DbContext.Migrations
{
    public partial class PostRenamedAsArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPost_Post_PostId",
                table: "CategoryPost");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_OwnerPostId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "OwnerPostId",
                table: "Comment",
                newName: "OwnerArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_OwnerPostId",
                table: "Comment",
                newName: "IX_Comment_OwnerArticleId");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "CategoryPost",
                newName: "ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryPost_PostId",
                table: "CategoryPost",
                newName: "IX_CategoryPost_ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPost_Post_ArticleId",
                table: "CategoryPost",
                column: "ArticleId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_OwnerArticleId",
                table: "Comment",
                column: "OwnerArticleId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryPost_Post_ArticleId",
                table: "CategoryPost");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_OwnerArticleId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "OwnerArticleId",
                table: "Comment",
                newName: "OwnerPostId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_OwnerArticleId",
                table: "Comment",
                newName: "IX_Comment_OwnerPostId");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "CategoryPost",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryPost_ArticleId",
                table: "CategoryPost",
                newName: "IX_CategoryPost_PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryPost_Post_PostId",
                table: "CategoryPost",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Post_OwnerPostId",
                table: "Comment",
                column: "OwnerPostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
