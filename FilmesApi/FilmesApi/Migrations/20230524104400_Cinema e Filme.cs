using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesApi.Migrations
{
    public partial class CinemaeFilme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Movies_MovieId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Cinemas_CinemaId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Movies_MovieId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_MovieId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                columns: new[] { "MovieId", "CinemaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Cinemas_CinemaId",
                table: "Sessions",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Movies_MovieId",
                table: "Sessions",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Cinemas_CinemaId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Movies_MovieId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Sessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Sessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MovieId",
                table: "Sessions",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieId",
                table: "Movies",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Movies_MovieId",
                table: "Movies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Cinemas_CinemaId",
                table: "Sessions",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Movies_MovieId",
                table: "Sessions",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
