using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterFaker.Migrations
{
    public partial class Objects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    BlockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    ProfilePicture = table.Column<string>(nullable: true),
                    Theme = table.Column<int>(nullable: false),
                    Font = table.Column<int>(nullable: false),
                    Verified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.BlockId);
                    table.ForeignKey(
                        name: "FK_Blocks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReplyChains",
                columns: table => new
                {
                    ReplyChainId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    Theme = table.Column<int>(nullable: false),
                    Font = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyChains", x => x.ReplyChainId);
                    table.ForeignKey(
                        name: "FK_ReplyChains_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suspensions",
                columns: table => new
                {
                    SuspensionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    ProfilePicture = table.Column<string>(nullable: true),
                    Theme = table.Column<int>(nullable: false),
                    Font = table.Column<int>(nullable: false),
                    Verified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suspensions", x => x.SuspensionId);
                    table.ForeignKey(
                        name: "FK_Suspensions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tweets",
                columns: table => new
                {
                    TweetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    Body = table.Column<string>(nullable: false),
                    ProfilePicture = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    FactCheck = table.Column<string>(nullable: true),
                    Client = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Retweets = table.Column<int>(nullable: false),
                    QuoteTweets = table.Column<int>(nullable: false),
                    Likes = table.Column<int>(nullable: false),
                    Verified = table.Column<bool>(nullable: false),
                    Theme = table.Column<int>(nullable: false),
                    Font = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tweets", x => x.TweetId);
                    table.ForeignKey(
                        name: "FK_Tweets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    ReplyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReplyChainId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    ProfilePicture = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Retweets = table.Column<int>(nullable: false),
                    QuoteTweets = table.Column<int>(nullable: false),
                    Likes = table.Column<int>(nullable: false),
                    Verified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.ReplyId);
                    table.ForeignKey(
                        name: "FK_Replies_ReplyChains_ReplyChainId",
                        column: x => x.ReplyChainId,
                        principalTable: "ReplyChains",
                        principalColumn: "ReplyChainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_UserId",
                table: "Blocks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_ReplyChainId",
                table: "Replies",
                column: "ReplyChainId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplyChains_UserId",
                table: "ReplyChains",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Suspensions_UserId",
                table: "Suspensions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_UserId",
                table: "Tweets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Suspensions");

            migrationBuilder.DropTable(
                name: "Tweets");

            migrationBuilder.DropTable(
                name: "ReplyChains");
        }
    }
}
