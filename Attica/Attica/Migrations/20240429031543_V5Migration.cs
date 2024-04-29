using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attica.Migrations
{
    /// <inheritdoc />
    public partial class V5Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GalleryId",
                table: "ArtPieceDV",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GalleryDV",
                columns: table => new
                {
                    GalleryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryDV", x => x.GalleryId);
                });

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

            migrationBuilder.DropTable(
                name: "GalleryDV");

            migrationBuilder.DropIndex(
                name: "IX_ArtPieceDV_GalleryId",
                table: "ArtPieceDV");

            migrationBuilder.DropColumn(
                name: "GalleryId",
                table: "ArtPieceDV");
        }
    }
}
