using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTicketBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddTheaterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TheaterId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Theaters",
                columns: table => new
                {
                    TheaterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theaters", x => x.TheaterId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_TheaterId",
                table: "Movies",
                column: "TheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Theaters_TheaterId",
                table: "Movies",
                column: "TheaterId",
                principalTable: "Theaters",
                principalColumn: "TheaterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Theaters_TheaterId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Theaters");

            migrationBuilder.DropIndex(
                name: "IX_Movies_TheaterId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TheaterId",
                table: "Movies");
        }
    }
}
