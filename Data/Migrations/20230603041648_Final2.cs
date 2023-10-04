using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EthioServices.Data.Migrations
{
    /// <inheritdoc />
    public partial class Final2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "money",
                table: "Balance",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "money",
                table: "Balance");
        }
    }
}
