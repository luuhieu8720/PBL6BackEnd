using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL6_Back_end.Migrations
{
    public partial class AddMaskPrediction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaskPredictedInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Base64String = table.Column<string>(type: "text", nullable: true),
                    PredictedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaskPredictedInfos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaskPredictedInfos");
        }
    }
}
