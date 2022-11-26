using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WatchHistoryItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoppedTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Watched = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchHistoryItem", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WatchHistoryItem_UserId_MovieId",
                table: "WatchHistoryItem",
                columns: new[] { "UserId", "MovieId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WatchHistoryItem");
        }
    }
}
