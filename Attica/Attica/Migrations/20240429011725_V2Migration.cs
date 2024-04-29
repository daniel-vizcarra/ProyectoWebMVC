using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attica.Migrations
{
    /// <inheritdoc />
    public partial class V2Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "ArtPieceDV",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtPieceDV_ArtistId",
                table: "ArtPieceDV",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtPieceDV_Artist_ArtistId",
                table: "ArtPieceDV",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtPieceDV_Artist_ArtistId",
                table: "ArtPieceDV");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_ArtPieceDV_ArtistId",
                table: "ArtPieceDV");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "ArtPieceDV");
        }
    }
}
