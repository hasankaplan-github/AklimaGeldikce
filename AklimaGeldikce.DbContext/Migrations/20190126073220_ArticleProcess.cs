using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AklimaGeldikce.DbContext.Migrations
{
    public partial class ArticleProcess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleOperation_ArticleStatus_ArticleStatusId",
                table: "ArticleOperation");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleOperation_User_OperationUserId",
                table: "ArticleOperation");

            migrationBuilder.DropTable(
                name: "ArticleStatusArticleStatus");

            migrationBuilder.DropTable(
                name: "ArticleStatus");

            migrationBuilder.DropIndex(
                name: "IX_ArticleOperation_ArticleStatusId",
                table: "ArticleOperation");

            migrationBuilder.DropColumn(
                name: "ArticleStatusId",
                table: "ArticleOperation");

            migrationBuilder.RenameColumn(
                name: "OperationUserId",
                table: "ArticleOperation",
                newName: "ArticleStatePathId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleOperation_OperationUserId",
                table: "ArticleOperation",
                newName: "IX_ArticleOperation_ArticleStatePathId");

            migrationBuilder.AlterColumn<Guid>(
                name: "AcceptingUserId",
                table: "ArticleOperation",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "OperatorUserId",
                table: "ArticleOperation",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArticleAction",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CodeName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleAction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleState",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CodeName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleActionRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ArticleActionId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleActionRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleActionRole_ArticleAction_ArticleActionId",
                        column: x => x.ArticleActionId,
                        principalTable: "ArticleAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleActionRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleStatePath",
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
                name: "IX_ArticleOperation_AcceptingUserId",
                table: "ArticleOperation",
                column: "AcceptingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleOperation_OperatorUserId",
                table: "ArticleOperation",
                column: "OperatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleActionRole_ArticleActionId",
                table: "ArticleActionRole",
                column: "ArticleActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleActionRole_RoleId",
                table: "ArticleActionRole",
                column: "RoleId");

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
                name: "FK_ArticleOperation_User_AcceptingUserId",
                table: "ArticleOperation",
                column: "AcceptingUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleOperation_ArticleStatePath_ArticleStatePathId",
                table: "ArticleOperation",
                column: "ArticleStatePathId",
                principalTable: "ArticleStatePath",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleOperation_User_OperatorUserId",
                table: "ArticleOperation",
                column: "OperatorUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleOperation_User_AcceptingUserId",
                table: "ArticleOperation");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleOperation_ArticleStatePath_ArticleStatePathId",
                table: "ArticleOperation");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleOperation_User_OperatorUserId",
                table: "ArticleOperation");

            migrationBuilder.DropTable(
                name: "ArticleActionRole");

            migrationBuilder.DropTable(
                name: "ArticleStatePath");

            migrationBuilder.DropTable(
                name: "ArticleAction");

            migrationBuilder.DropTable(
                name: "ArticleState");

            migrationBuilder.DropIndex(
                name: "IX_ArticleOperation_AcceptingUserId",
                table: "ArticleOperation");

            migrationBuilder.DropIndex(
                name: "IX_ArticleOperation_OperatorUserId",
                table: "ArticleOperation");

            migrationBuilder.DropColumn(
                name: "OperatorUserId",
                table: "ArticleOperation");

            migrationBuilder.RenameColumn(
                name: "ArticleStatePathId",
                table: "ArticleOperation",
                newName: "OperationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleOperation_ArticleStatePathId",
                table: "ArticleOperation",
                newName: "IX_ArticleOperation_OperationUserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "AcceptingUserId",
                table: "ArticleOperation",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ArticleStatusId",
                table: "ArticleOperation",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "ArticleStatusArticleStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ChildArticleStatusId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ParentArticleStatusId = table.Column<Guid>(nullable: false)
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
                name: "IX_ArticleOperation_ArticleStatusId",
                table: "ArticleOperation",
                column: "ArticleStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleStatusArticleStatus_ChildArticleStatusId",
                table: "ArticleStatusArticleStatus",
                column: "ChildArticleStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleStatusArticleStatus_ParentArticleStatusId",
                table: "ArticleStatusArticleStatus",
                column: "ParentArticleStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleOperation_ArticleStatus_ArticleStatusId",
                table: "ArticleOperation",
                column: "ArticleStatusId",
                principalTable: "ArticleStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleOperation_User_OperationUserId",
                table: "ArticleOperation",
                column: "OperationUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
