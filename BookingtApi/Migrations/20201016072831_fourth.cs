using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingtApi.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookingts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    seatno = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Datetopresent = table.Column<string>(nullable: true),
                    MovieDetailsId = table.Column<int>(nullable: false),
                    MovieName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookingts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookingts");
        }
    }
}
