using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AklimaGeldikce.DbContext.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Post_OwnerPostId",
                table: "Comment");

            migrationBuilder.DropTable(
                name: "CategoryPost");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.RenameColumn(
                name: "OwnerPostId",
                table: "Comment",
                newName: "OwnerArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_OwnerPostId",
                table: "Comment",
                newName: "IX_Comment_OwnerArticleId");

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true),
                    ViewCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ArticleStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryArticle",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    ArticleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryArticle_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryArticle_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleOperation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ArticleId = table.Column<Guid>(nullable: false),
                    ArticleStatusId = table.Column<Guid>(nullable: false),
                    OperationDate = table.Column<DateTime>(nullable: false),
                    OperationUserId = table.Column<Guid>(nullable: false),
                    AcceptingUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleOperation_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleOperation_ArticleStatus_ArticleStatusId",
                        column: x => x.ArticleStatusId,
                        principalTable: "ArticleStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleOperation_User_OperationUserId",
                        column: x => x.OperationUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleStatusArticleStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ParentArticleStatusId = table.Column<Guid>(nullable: false),
                    ChildArticleStatusId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleStatusArticleStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleStatusArticleStatus_ArticleStatus_ChildArticleStatusId",
                        column: x => x.ChildArticleStatusId,
                        principalTable: "ArticleStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticleStatusArticleStatus_ArticleStatus_ParentArticleStatusId",
                        column: x => x.ParentArticleStatusId,
                        principalTable: "ArticleStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_OwnerId",
                table: "Article",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleOperation_ArticleId",
                table: "ArticleOperation",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleOperation_ArticleStatusId",
                table: "ArticleOperation",
                column: "ArticleStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleOperation_OperationUserId",
                table: "ArticleOperation",
                column: "OperationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleStatusArticleStatus_ChildArticleStatusId",
                table: "ArticleStatusArticleStatus",
                column: "ChildArticleStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleStatusArticleStatus_ParentArticleStatusId",
                table: "ArticleStatusArticleStatus",
                column: "ParentArticleStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryArticle_ArticleId",
                table: "CategoryArticle",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryArticle_CategoryId",
                table: "CategoryArticle",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Article_OwnerArticleId",
                table: "Comment",
                column: "OwnerArticleId",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Article_OwnerArticleId",
                table: "Comment");

            migrationBuilder.DropTable(
                name: "ArticleOperation");

            migrationBuilder.DropTable(
                name: "ArticleStatusArticleStatus");

            migrationBuilder.DropTable(
                name: "CategoryArticle");

            migrationBuilder.DropTable(
                name: "ArticleStatus");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.RenameColumn(
                name: "OwnerArticleId",
                table: "Comment",
                newName: "OwnerPostId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_OwnerArticleId",
                table: "Comment",
                newName: "IX_Comment_OwnerPostId");

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ViewCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPost",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PostId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryPost_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPost_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPost_CategoryId",
                table: "CategoryPost",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPost_PostId",
                table: "CategoryPost",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_OwnerId",
                table: "Post",
                column: "OwnerId");

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
