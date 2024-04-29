using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attica.Migrations
{
    /// <inheritdoc />
    public partial class V8Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ArtPieceDV_GalleryId",
                table: "ArtPieceDV");

            migrationBuilder.AddColumn<int>(
                name: "ArtPieceId",
                table: "GalleryDV",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArtPieceDV_GalleryId",
                table: "ArtPieceDV",
                column: "GalleryId",
                unique: true,
                filter: "[GalleryId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ArtPieceDV_GalleryId",
                table: "ArtPieceDV");

            migrationBuilder.DropColumn(
                name: "ArtPieceId",
                table: "GalleryDV");

            migrationBuilder.CreateIndex(
                name: "IX_ArtPieceDV_GalleryId",
                table: "ArtPieceDV",
                column: "GalleryId");
        }
    }
}
