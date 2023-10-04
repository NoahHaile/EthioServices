using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EthioServices.Data.Migrations
{
    /// <inheritdoc />
    public partial class WORK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "balance",
                table: "Talent",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "ownerId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "balance",
                table: "Client",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sender = table.Column<int>(type: "int", nullable: false),
                    receiver = table.Column<int>(type: "int", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropColumn(
                name: "balance",
                table: "Talent");

            migrationBuilder.DropColumn(
                name: "ownerId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "balance",
                table: "Client");
        }
    }
}
