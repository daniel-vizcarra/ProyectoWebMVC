using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attica.Migrations
{
    /// <inheritdoc />
    public partial class V6Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtPieceDV_GalleryDV_GalleryId",
                table: "ArtPieceDV");

            migrationBuilder.AlterColumn<int>(
                name: "GalleryId",
                table: "ArtPieceDV",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtPieceDV_GalleryDV_GalleryId",
                table: "ArtPieceDV",
                column: "GalleryId",
                principalTable: "GalleryDV",
                principalColumn: "GalleryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtPieceDV_GalleryDV_GalleryId",
                table: "ArtPieceDV");

            migrationBuilder.AlterColumn<int>(
                name: "GalleryId",
                table: "ArtPieceDV",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtPieceDV_GalleryDV_GalleryId",
                table: "ArtPieceDV",
                column: "GalleryId",
                principalTable: "GalleryDV",
                principalColumn: "GalleryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
