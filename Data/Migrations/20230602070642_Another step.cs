using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EthioServices.Data.Migrations
{
    /// <inheritdoc />
    public partial class Anotherstep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "JobStatus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId1",
                table: "JobStatus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TalentId",
                table: "JobStatus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TalentId1",
                table: "JobStatus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TalentId2",
                table: "JobStatus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    moneySpent = table.Column<double>(type: "float", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<double>(type: "float", nullable: false),
                    postedJobs = table.Column<int>(type: "int", nullable: false),
                    activeJobs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Talent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<double>(type: "float", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    portfolioUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rating = table.Column<double>(type: "float", nullable: false),
                    acceptedJobs = table.Column<int>(type: "int", nullable: false),
                    appliedJobs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talent", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobStatus_ClientId",
                table: "JobStatus",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_JobStatus_ClientId1",
                table: "JobStatus",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_JobStatus_TalentId",
                table: "JobStatus",
                column: "TalentId");

            migrationBuilder.CreateIndex(
                name: "IX_JobStatus_TalentId1",
                table: "JobStatus",
                column: "TalentId1");

            migrationBuilder.CreateIndex(
                name: "IX_JobStatus_TalentId2",
                table: "JobStatus",
                column: "TalentId2");

            migrationBuilder.AddForeignKey(
                name: "FK_JobStatus_Client_ClientId",
                table: "JobStatus",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobStatus_Client_ClientId1",
                table: "JobStatus",
                column: "ClientId1",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobStatus_Talent_TalentId",
                table: "JobStatus",
                column: "TalentId",
                principalTable: "Talent",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobStatus_Talent_TalentId1",
                table: "JobStatus",
                column: "TalentId1",
                principalTable: "Talent",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobStatus_Talent_TalentId2",
                table: "JobStatus",
                column: "TalentId2",
                principalTable: "Talent",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobStatus_Client_ClientId",
                table: "JobStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_JobStatus_Client_ClientId1",
                table: "JobStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_JobStatus_Talent_TalentId",
                table: "JobStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_JobStatus_Talent_TalentId1",
                table: "JobStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_JobStatus_Talent_TalentId2",
                table: "JobStatus");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Talent");

            migrationBuilder.DropIndex(
                name: "IX_JobStatus_ClientId",
                table: "JobStatus");

            migrationBuilder.DropIndex(
                name: "IX_JobStatus_ClientId1",
                table: "JobStatus");

            migrationBuilder.DropIndex(
                name: "IX_JobStatus_TalentId",
                table: "JobStatus");

            migrationBuilder.DropIndex(
                name: "IX_JobStatus_TalentId1",
                table: "JobStatus");

            migrationBuilder.DropIndex(
                name: "IX_JobStatus_TalentId2",
                table: "JobStatus");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "JobStatus");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "JobStatus");

            migrationBuilder.DropColumn(
                name: "TalentId",
                table: "JobStatus");

            migrationBuilder.DropColumn(
                name: "TalentId1",
                table: "JobStatus");

            migrationBuilder.DropColumn(
                name: "TalentId2",
                table: "JobStatus");
        }
    }
}
