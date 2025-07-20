using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideoRentalApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    AgeRestriction = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSubscriptionExpired = table.Column<bool>(type: "bit", nullable: false),
                    SubscriptionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Part = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cast_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RentedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rental_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rental_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "AgeRestriction", "Duration", "Genre", "IsAvailable", "Language", "Quantity", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 16, 2.1600000000000001, 5, true, 1, 1, new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" },
                    { 2, 18, 2.2799999999999998, 5, true, 1, 1, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { 3, 16, 2.7999999999999998, 1, true, 1, 1, new DateTime(2014, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Accountant" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Age", "CardNumber", "CreatedOn", "Email", "FirstName", "IsSubscriptionExpired", "LastName", "SubscriptionType" },
                values: new object[,]
                {
                    { 1, 28, 1111222233334444L, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "stefan123@example.com", "Stefan", false, "Stefanovski", 3 },
                    { 2, 36, 2222333355556666L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bobbobski@example.com", "Bob", false, "Bobski", 2 },
                    { 3, 19, 5555666688881111L, new DateTime(2023, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "petko5@example.com", "Petko", true, "Petkovski", 1 },
                    { 4, 39, 555511114545000L, new DateTime(2024, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "ivanaIv@example.com", "Ivana", false, "Ivanovska", 3 },
                    { 5, 23, 1122334455667788L, new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "jovana19@example.com", "Jovana", false, "Jovanovska", 1 }
                });

            migrationBuilder.InsertData(
                table: "Cast",
                columns: new[] { "Id", "MovieId", "Name", "Part" },
                values: new object[,]
                {
                    { 1, 1, "Keanu Reeves", 1 },
                    { 2, 1, "Anne Moss", 3 },
                    { 3, 2, "Leonardo DiCaprio", 1 },
                    { 4, 3, "Matthew Brown", 2 }
                });

            migrationBuilder.InsertData(
                table: "Rental",
                columns: new[] { "Id", "MovieId", "RentedOn", "ReturnedOn", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 2, 2, new DateTime(2025, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 3, 1, new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cast_MovieId",
                table: "Cast",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_MovieId",
                table: "Rental",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_UserId",
                table: "Rental",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cast");

            migrationBuilder.DropTable(
                name: "Rental");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
