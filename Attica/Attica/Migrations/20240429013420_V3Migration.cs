using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Attica.Migrations
{
    /// <inheritdoc />
    public partial class V3Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtPieceDV_Artist_ArtistId",
                table: "ArtPieceDV");

            migrationBuilder.DropColumn(
                name: "Artist",
                table: "ArtPieceDV");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "ArtPieceDV",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtPieceDV_Artist_ArtistId",
                table: "ArtPieceDV",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtPieceDV_Artist_ArtistId",
                table: "ArtPieceDV");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "ArtPieceDV",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "ArtPieceDV",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtPieceDV_Artist_ArtistId",
                table: "ArtPieceDV",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId");
        }
    }
}
