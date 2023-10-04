using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EthioServices.Data.Migrations
{
    /// <inheritdoc />
    public partial class WORK2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "read",
                table: "Message",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "read",
                table: "Message");
        }
    }
}
