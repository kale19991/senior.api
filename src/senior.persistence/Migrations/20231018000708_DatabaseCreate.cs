using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace senior.persistence.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "locality",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(7)", maxLength: 7, nullable: false),
                    City = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    State = table.Column<string>(type: "CHAR(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locality_City",
                table: "locality",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_Locality_State",
                table: "locality",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "user",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "locality");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
