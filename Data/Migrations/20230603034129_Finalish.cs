using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EthioServices.Data.Migrations
{
    /// <inheritdoc />
    public partial class Finalish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "receiverName",
                table: "Message",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "senderName",
                table: "Message",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "receiverName",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "senderName",
                table: "Message");
        }
    }
}
