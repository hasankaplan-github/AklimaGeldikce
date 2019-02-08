using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AklimaGeldikce.DbContext.Migrations
{
    public partial class Refactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleOperation_ArticleStatePath_ArticleStatePathId",
                table: "ArticleOperation");

            migrationBuilder.DropTable(
                name: "ArticleStatePath");

            migrationBuilder.RenameColumn(
                name: "ArticleStatePathId",
                table: "ArticleOperation",
                newName: "ArticleStateTransitionId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleOperation_ArticleStatePathId",
                table: "ArticleOperation",
                newName: "IX_ArticleOperation_ArticleStateTransitionId");

            migrationBuilder.CreateTable(
                name: "ArticleStateTransition",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SourceArticleStateId = table.Column<Guid>(nullable: true),
                    DestinationArticleStateId = table.Column<Guid>(nullable: true),
                    ArticleActionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleStateTransition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleStateTransition_ArticleAction_ArticleActionId",
                        column: x => x.ArticleActionId,
                        principalTable: "ArticleAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleStateTransition_ArticleState_DestinationArticleStateId",
                        column: x => x.DestinationArticleStateId,
                        principalTable: "ArticleState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticleStateTransition_ArticleState_SourceArticleStateId",
                        column: x => x.SourceArticleStateId,
                        principalTable: "ArticleState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleStateTransition_ArticleActionId",
                table: "ArticleStateTransition",
                column: "ArticleActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleStateTransition_DestinationArticleStateId",
                table: "ArticleStateTransition",
                column: "DestinationArticleStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleStateTransition_SourceArticleStateId",
                table: "ArticleStateTransition",
                column: "SourceArticleStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleOperation_ArticleStateTransition_ArticleStateTransitionId",
                table: "ArticleOperation",
                column: "ArticleStateTransitionId",
                principalTable: "ArticleStateTransition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleOperation_ArticleStateTransition_ArticleStateTransitionId",
                table: "ArticleOperation");

            migrationBuilder.DropTable(
                name: "ArticleStateTransition");

            migrationBuilder.RenameColumn(
                name: "ArticleStateTransitionId",
                table: "ArticleOperation",
                newName: "ArticleStatePathId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleOperation_ArticleStateTransitionId",
                table: "ArticleOperation",
                newName: "IX_ArticleOperation_ArticleStatePathId");

            migrationBuilder.CreateTable(
                name: "ArticleStatePath",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ArticleActionId = table.Column<Guid>(nullable: false),
                    DestinationArticleStateId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SourceArticleStateId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleStatePath", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleStatePath_ArticleAction_ArticleActionId",
                        column: x => x.ArticleActionId,
                        principalTable: "ArticleAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleStatePath_ArticleState_DestinationArticleStateId",
                        column: x => x.DestinationArticleStateId,
                        principalTable: "ArticleState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticleStatePath_ArticleState_SourceArticleStateId",
                        column: x => x.SourceArticleStateId,
                        principalTable: "ArticleState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleStatePath_ArticleActionId",
                table: "ArticleStatePath",
                column: "ArticleActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleStatePath_DestinationArticleStateId",
                table: "ArticleStatePath",
                column: "DestinationArticleStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleStatePath_SourceArticleStateId",
                table: "ArticleStatePath",
                column: "SourceArticleStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleOperation_ArticleStatePath_ArticleStatePathId",
                table: "ArticleOperation",
                column: "ArticleStatePathId",
                principalTable: "ArticleStatePath",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
