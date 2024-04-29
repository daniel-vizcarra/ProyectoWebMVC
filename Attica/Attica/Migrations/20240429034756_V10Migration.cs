using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attica.Migrations
{
    /// <inheritdoc />
    public partial class V10Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtPieceDV_GalleryDV_GalleryId",
                table: "ArtPieceDV");

            migrationBuilder.DropIndex(
                name: "IX_ArtPieceDV_GalleryId",
                table: "ArtPieceDV");

            migrationBuilder.DropColumn(
                name: "ArtPieceId",
                table: "GalleryDV");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "GalleryDV",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GalleryDV",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GalleryId",
                table: "ArtPieceDV",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArtPieceDV_GalleryId",
                table: "ArtPieceDV",
                column: "GalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtPieceDV_GalleryDV_GalleryId",
                table: "ArtPieceDV",
                column: "GalleryId",
                principalTable: "GalleryDV",
                principalColumn: "GalleryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtPieceDV_GalleryDV_GalleryId",
                table: "ArtPieceDV");

            migrationBuilder.DropIndex(
                name: "IX_ArtPieceDV_GalleryId",
                table: "ArtPieceDV");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "GalleryDV");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "GalleryDV",
                newName: "Address");

            migrationBuilder.AddColumn<int>(
                name: "ArtPieceId",
                table: "GalleryDV",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "GalleryId",
                table: "ArtPieceDV",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ArtPieceDV_GalleryId",
                table: "ArtPieceDV",
                column: "GalleryId",
                unique: true,
                filter: "[GalleryId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtPieceDV_GalleryDV_GalleryId",
                table: "ArtPieceDV",
                column: "GalleryId",
                principalTable: "GalleryDV",
                principalColumn: "GalleryId");
        }
    }
}
