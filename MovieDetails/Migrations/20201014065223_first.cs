using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDetails.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Movie_Name = table.Column<string>(nullable: true),
                    Movie_Description = table.Column<string>(nullable: true),
                    DateAndTime = table.Column<string>(nullable: true),
                    MoviePicture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DateAndTime", "MoviePicture", "Movie_Description", "Movie_Name" },
                values: new object[] { 1, "21/11/2020", "###", "THis is a action movie", "James Bond" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DateAndTime", "MoviePicture", "Movie_Description", "Movie_Name" },
                values: new object[] { 2, "22/11/2020", "###", "This is a adventures movie", "Jumanji" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
