﻿// <auto-generated />
using System;
using AklimaGeldikce.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AklimaGeldikce.DbContext.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190208172636_Refactoring")]
    partial class Refactoring
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AklimaGeldikce.Entities.AppLevelLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("Controller");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LogDate");

                    b.Property<Guid?>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("AppLevelLog");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AuthorId");

                    b.Property<string>("Content");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Title");

                    b.Property<int>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.ArticleAction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodeName");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.ToTable("ArticleAction");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.ArticleActionRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ArticleActionId");

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleActionId");

                    b.HasIndex("RoleId");

                    b.ToTable("ArticleActionRole");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.ArticleOperation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AcceptingUserId");

                    b.Property<Guid>("ArticleId");

                    b.Property<Guid>("ArticleStateTransitionId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("OperationDate");

                    b.Property<Guid?>("OperatorUserId");

                    b.HasKey("Id");

                    b.HasIndex("AcceptingUserId");

                    b.HasIndex("ArticleId");

                    b.HasIndex("ArticleStateTransitionId");

                    b.HasIndex("OperatorUserId");

                    b.ToTable("ArticleOperation");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.ArticleState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodeName");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.ToTable("ArticleState");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.ArticleStateTransition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ArticleActionId");

                    b.Property<Guid?>("DestinationArticleStateId");

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid?>("SourceArticleStateId");

                    b.HasKey("Id");

                    b.HasIndex("ArticleActionId");

                    b.HasIndex("DestinationArticleStateId");

                    b.HasIndex("SourceArticleStateId");

                    b.ToTable("ArticleStateTransition");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<Guid?>("ParentCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.CategoryArticle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ArticleId");

                    b.Property<Guid>("CategoryId");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryArticle");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid?>("OwnerArticleId");

                    b.Property<Guid?>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerArticleId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.MenuItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("Controller");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<Guid?>("ParentMenuItemId");

                    b.HasKey("Id");

                    b.HasIndex("ParentMenuItemId");

                    b.ToTable("MenuItem");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<Guid>("FromId");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsRead");

                    b.Property<DateTime>("MessageDate");

                    b.Property<string>("Subject");

                    b.Property<Guid>("ToId");

                    b.HasKey("Id");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsRead");

                    b.Property<DateTime>("NotificationDate");

                    b.Property<Guid>("ToId");

                    b.HasKey("Id");

                    b.HasIndex("ToId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("Controller");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.RoleMenuItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("MenuItemId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleMenuItem");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.RoleRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("RequestId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleRequest");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.RoleUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("RoleId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsLoggedIn");

                    b.Property<DateTime?>("LastLoginDate");

                    b.Property<DateTime?>("LastLogoutDate");

                    b.Property<string>("Password");

                    b.Property<string>("SecondName");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.AppLevelLog", b =>
                {
                    b.HasOne("AklimaGeldikce.Entities.User", "Owner")
                        .WithMany("AppLevelLogs")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.Article", b =>
                {
                    b.HasOne("AklimaGeldikce.Entities.User", "Author")
                        .WithMany("Articles")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.ArticleActionRole", b =>
                {
                    b.HasOne("AklimaGeldikce.Entities.ArticleAction", "ArticleAction")
                        .WithMany("ArticleActionRoles")
                        .HasForeignKey("ArticleActionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AklimaGeldikce.Entities.Role", "Role")
                        .WithMany("ArticleActionRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.ArticleOperation", b =>
                {
                    b.HasOne("AklimaGeldikce.Entities.User", "AcceptingUser")
                        .WithMany()
                        .HasForeignKey("AcceptingUserId");

                    b.HasOne("AklimaGeldikce.Entities.Article", "Article")
                        .WithMany("ArticleOperations")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AklimaGeldikce.Entities.ArticleStateTransition", "ArticleStateTransition")
                        .WithMany()
                        .HasForeignKey("ArticleStateTransitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AklimaGeldikce.Entities.User", "OperatorUser")
                        .WithMany("ArticleOperations")
                        .HasForeignKey("OperatorUserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.ArticleStateTransition", b =>
                {
                    b.HasOne("AklimaGeldikce.Entities.ArticleAction", "ArticleAction")
                        .WithMany("ArticleStateTransitions")
                        .HasForeignKey("ArticleActionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AklimaGeldikce.Entities.ArticleState", "DestinationArticleState")
                        .WithMany("DestinationArticleStateTransitions")
                        .HasForeignKey("DestinationArticleStateId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AklimaGeldikce.Entities.ArticleState", "SourceArticleState")
                        .WithMany("SourceArticleStateTransitions")
                        .HasForeignKey("SourceArticleStateId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.Category", b =>
                {
                    b.HasOne("AklimaGeldikce.Entities.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.CategoryArticle", b =>
                {
                    b.HasOne("AklimaGeldikce.Entities.Article", "Article")
                        .WithMany("CategoryArticles")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AklimaGeldikce.Entities.Category", "Category")
                        .WithMany("CategoryArticles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.Comment", b =>
                {
                    b.HasOne("AklimaGeldikce.Entities.Article", "OwnerArticle")
                        .WithMany("Comments")
                        .HasForeignKey("OwnerArticleId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("AklimaGeldikce.Entities.User", "Owner")
                        .WithMany("Comments")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.MenuItem", b =>
                {
                    b.HasOne("AklimaGeldikce.Entities.MenuItem", "ParentMenuItem")
                        .WithMany("ChildMenuItems")
                        .HasForeignKey("ParentMenuItemId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.Message", b =>
                {
                    b.HasOne("AklimaGeldikce.Entities.User", "From")
                        .WithMany("SentMessages")
                        .HasForeignKey("FromId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AklimaGeldikce.Entities.User", "To")
                        .WithMany("ReceivedMessages")
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.Notification", b =>
                {
                    b.HasOne("AklimaGeldikce.Entities.User", "To")
                        .WithMany("Notifications")
                        .HasForeignKey("ToId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.RoleMenuItem", b =>
                {
                    b.HasOne("AklimaGeldikce.Entities.MenuItem", "MenuItem")
                        .WithMany("RoleMenuItems")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AklimaGeldikce.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.RoleRequest", b =>
                {
                    b.HasOne("AklimaGeldikce.Entities.Request", "Request")
                        .WithMany("RoleRequests")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AklimaGeldikce.Entities.Role", "Role")
                        .WithMany("RoleRequests")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AklimaGeldikce.Entities.RoleUser", b =>
                {
                    b.HasOne("AklimaGeldikce.Entities.Role", "Role")
                        .WithMany("RoleUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AklimaGeldikce.Entities.User", "User")
                        .WithMany("RoleUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
