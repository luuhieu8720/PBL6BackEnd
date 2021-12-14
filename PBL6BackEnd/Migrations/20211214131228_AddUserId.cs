using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PBL6_Back_end.Migrations
{
    public partial class AddUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "MaskPredictedInfos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MaskPredictedInfos_UserId",
                table: "MaskPredictedInfos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaskPredictedInfos_Users_UserId",
                table: "MaskPredictedInfos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaskPredictedInfos_Users_UserId",
                table: "MaskPredictedInfos");

            migrationBuilder.DropIndex(
                name: "IX_MaskPredictedInfos_UserId",
                table: "MaskPredictedInfos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MaskPredictedInfos");
        }
    }
}
