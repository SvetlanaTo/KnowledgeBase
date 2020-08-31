using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KnowledgeBase.Migrations
{
    public partial class _2808 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SimilarArticles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SefName = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    PublishEndDate = table.Column<DateTime>(nullable: false),
                    PublishStartDate = table.Column<DateTime>(nullable: false),
                    IsDraft = table.Column<int>(nullable: false),
                    Relevance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimilarArticles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TopTagItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ratio = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FontSize = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopTagItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SimilarArticles");

            migrationBuilder.DropTable(
                name: "TopTagItems");
        }
    }
}
