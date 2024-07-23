using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Quiz.Api.Data.EntityFrameworkCore.Migrations
{
    public partial class AddTableToeicScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToeicScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfCorrect = table.Column<int>(type: "int", nullable: true),
                    Score = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToeicScores", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "83daf5f8-ec4a-4b4d-b879-60c03b661b31");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c3f087a2-48d5-4e09-8a63-8830a7b5b4e3"),
                column: "ConcurrencyStamp",
                value: "7992bb63-a242-40c5-99c4-b649464dccba");

            migrationBuilder.InsertData(
                table: "ToeicScores",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "NumberOfCorrect", "Score", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, null, null, null, null, 0, 5, 1, null, null },
                    { 2, null, null, null, null, 1, 5, 1, null, null },
                    { 3, null, null, null, null, 2, 5, 1, null, null },
                    { 4, null, null, null, null, 3, 10, 1, null, null },
                    { 5, null, null, null, null, 4, 15, 1, null, null },
                    { 6, null, null, null, null, 5, 20, 1, null, null },
                    { 7, null, null, null, null, 6, 25, 1, null, null },
                    { 8, null, null, null, null, 7, 30, 1, null, null },
                    { 9, null, null, null, null, 8, 35, 1, null, null },
                    { 10, null, null, null, null, 9, 40, 1, null, null },
                    { 11, null, null, null, null, 10, 45, 1, null, null },
                    { 12, null, null, null, null, 11, 50, 1, null, null },
                    { 13, null, null, null, null, 12, 55, 1, null, null },
                    { 14, null, null, null, null, 13, 60, 1, null, null },
                    { 15, null, null, null, null, 14, 65, 1, null, null },
                    { 16, null, null, null, null, 15, 70, 1, null, null },
                    { 17, null, null, null, null, 16, 75, 1, null, null },
                    { 18, null, null, null, null, 17, 80, 1, null, null },
                    { 19, null, null, null, null, 18, 85, 1, null, null },
                    { 20, null, null, null, null, 19, 90, 1, null, null },
                    { 21, null, null, null, null, 20, 95, 1, null, null },
                    { 22, null, null, null, null, 21, 100, 1, null, null },
                    { 23, null, null, null, null, 22, 105, 1, null, null },
                    { 24, null, null, null, null, 23, 110, 1, null, null },
                    { 25, null, null, null, null, 24, 115, 1, null, null },
                    { 26, null, null, null, null, 25, 120, 1, null, null },
                    { 27, null, null, null, null, 26, 125, 1, null, null },
                    { 28, null, null, null, null, 27, 130, 1, null, null },
                    { 29, null, null, null, null, 28, 135, 1, null, null },
                    { 30, null, null, null, null, 29, 140, 1, null, null },
                    { 31, null, null, null, null, 30, 145, 1, null, null },
                    { 32, null, null, null, null, 31, 150, 1, null, null },
                    { 33, null, null, null, null, 32, 155, 1, null, null },
                    { 34, null, null, null, null, 33, 160, 1, null, null },
                    { 35, null, null, null, null, 34, 165, 1, null, null },
                    { 36, null, null, null, null, 35, 170, 1, null, null },
                    { 37, null, null, null, null, 36, 175, 1, null, null },
                    { 38, null, null, null, null, 37, 180, 1, null, null },
                    { 39, null, null, null, null, 38, 185, 1, null, null },
                    { 40, null, null, null, null, 39, 190, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "ToeicScores",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "NumberOfCorrect", "Score", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 41, null, null, null, null, 40, 195, 1, null, null },
                    { 42, null, null, null, null, 41, 200, 1, null, null },
                    { 43, null, null, null, null, 42, 205, 1, null, null },
                    { 44, null, null, null, null, 43, 210, 1, null, null },
                    { 45, null, null, null, null, 44, 215, 1, null, null },
                    { 46, null, null, null, null, 45, 220, 1, null, null },
                    { 47, null, null, null, null, 46, 225, 1, null, null },
                    { 48, null, null, null, null, 47, 230, 1, null, null },
                    { 49, null, null, null, null, 48, 235, 1, null, null },
                    { 50, null, null, null, null, 49, 240, 1, null, null },
                    { 51, null, null, null, null, 50, 245, 1, null, null },
                    { 52, null, null, null, null, 51, 250, 1, null, null },
                    { 53, null, null, null, null, 52, 255, 1, null, null },
                    { 54, null, null, null, null, 53, 260, 1, null, null },
                    { 55, null, null, null, null, 54, 265, 1, null, null },
                    { 56, null, null, null, null, 55, 270, 1, null, null },
                    { 57, null, null, null, null, 56, 275, 1, null, null },
                    { 58, null, null, null, null, 57, 280, 1, null, null },
                    { 59, null, null, null, null, 58, 285, 1, null, null },
                    { 60, null, null, null, null, 59, 290, 1, null, null },
                    { 61, null, null, null, null, 60, 295, 1, null, null },
                    { 62, null, null, null, null, 61, 300, 1, null, null },
                    { 63, null, null, null, null, 62, 305, 1, null, null },
                    { 64, null, null, null, null, 63, 310, 1, null, null },
                    { 65, null, null, null, null, 64, 315, 1, null, null },
                    { 66, null, null, null, null, 65, 320, 1, null, null },
                    { 67, null, null, null, null, 66, 325, 1, null, null },
                    { 68, null, null, null, null, 67, 330, 1, null, null },
                    { 69, null, null, null, null, 68, 335, 1, null, null },
                    { 70, null, null, null, null, 69, 340, 1, null, null },
                    { 71, null, null, null, null, 70, 345, 1, null, null },
                    { 72, null, null, null, null, 71, 350, 1, null, null },
                    { 73, null, null, null, null, 72, 355, 1, null, null },
                    { 74, null, null, null, null, 73, 360, 1, null, null },
                    { 75, null, null, null, null, 74, 365, 1, null, null },
                    { 76, null, null, null, null, 75, 370, 1, null, null },
                    { 77, null, null, null, null, 76, 375, 1, null, null },
                    { 78, null, null, null, null, 77, 380, 1, null, null },
                    { 79, null, null, null, null, 78, 385, 1, null, null },
                    { 80, null, null, null, null, 79, 390, 1, null, null },
                    { 81, null, null, null, null, 80, 395, 1, null, null },
                    { 82, null, null, null, null, 81, 400, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "ToeicScores",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "NumberOfCorrect", "Score", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 83, null, null, null, null, 82, 405, 1, null, null },
                    { 84, null, null, null, null, 83, 410, 1, null, null },
                    { 85, null, null, null, null, 84, 415, 1, null, null },
                    { 86, null, null, null, null, 85, 420, 1, null, null },
                    { 87, null, null, null, null, 86, 425, 1, null, null },
                    { 88, null, null, null, null, 87, 430, 1, null, null },
                    { 89, null, null, null, null, 88, 435, 1, null, null },
                    { 90, null, null, null, null, 89, 440, 1, null, null },
                    { 91, null, null, null, null, 90, 445, 1, null, null },
                    { 92, null, null, null, null, 91, 450, 1, null, null },
                    { 93, null, null, null, null, 92, 455, 1, null, null },
                    { 94, null, null, null, null, 93, 460, 1, null, null },
                    { 95, null, null, null, null, 94, 465, 1, null, null },
                    { 96, null, null, null, null, 95, 470, 1, null, null },
                    { 97, null, null, null, null, 96, 475, 1, null, null },
                    { 98, null, null, null, null, 97, 480, 1, null, null },
                    { 99, null, null, null, null, 98, 485, 1, null, null },
                    { 100, null, null, null, null, 99, 490, 1, null, null },
                    { 101, null, null, null, null, 100, 495, 1, null, null },
                    { 102, null, null, null, null, 0, 5, 2, null, null },
                    { 103, null, null, null, null, 1, 15, 2, null, null },
                    { 104, null, null, null, null, 2, 20, 2, null, null },
                    { 105, null, null, null, null, 3, 25, 2, null, null },
                    { 106, null, null, null, null, 4, 30, 2, null, null },
                    { 107, null, null, null, null, 5, 35, 2, null, null },
                    { 108, null, null, null, null, 6, 40, 2, null, null },
                    { 109, null, null, null, null, 7, 45, 2, null, null },
                    { 110, null, null, null, null, 8, 50, 2, null, null },
                    { 111, null, null, null, null, 9, 55, 2, null, null },
                    { 112, null, null, null, null, 10, 60, 2, null, null },
                    { 113, null, null, null, null, 11, 65, 2, null, null },
                    { 114, null, null, null, null, 12, 70, 2, null, null },
                    { 115, null, null, null, null, 13, 75, 2, null, null },
                    { 116, null, null, null, null, 14, 80, 2, null, null },
                    { 117, null, null, null, null, 15, 85, 2, null, null },
                    { 118, null, null, null, null, 16, 90, 2, null, null },
                    { 119, null, null, null, null, 17, 95, 2, null, null },
                    { 120, null, null, null, null, 18, 100, 2, null, null },
                    { 121, null, null, null, null, 19, 105, 2, null, null },
                    { 122, null, null, null, null, 20, 110, 2, null, null },
                    { 123, null, null, null, null, 21, 115, 2, null, null },
                    { 124, null, null, null, null, 22, 120, 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "ToeicScores",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "NumberOfCorrect", "Score", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 125, null, null, null, null, 23, 125, 2, null, null },
                    { 126, null, null, null, null, 24, 130, 2, null, null },
                    { 127, null, null, null, null, 25, 135, 2, null, null },
                    { 128, null, null, null, null, 26, 140, 2, null, null },
                    { 129, null, null, null, null, 27, 145, 2, null, null },
                    { 130, null, null, null, null, 28, 150, 2, null, null },
                    { 131, null, null, null, null, 29, 155, 2, null, null },
                    { 132, null, null, null, null, 30, 160, 2, null, null },
                    { 133, null, null, null, null, 31, 165, 2, null, null },
                    { 134, null, null, null, null, 32, 170, 2, null, null },
                    { 135, null, null, null, null, 33, 175, 2, null, null },
                    { 136, null, null, null, null, 34, 180, 2, null, null },
                    { 137, null, null, null, null, 35, 185, 2, null, null },
                    { 138, null, null, null, null, 36, 190, 2, null, null },
                    { 139, null, null, null, null, 37, 195, 2, null, null },
                    { 140, null, null, null, null, 38, 200, 2, null, null },
                    { 141, null, null, null, null, 39, 205, 2, null, null },
                    { 142, null, null, null, null, 40, 210, 2, null, null },
                    { 143, null, null, null, null, 41, 215, 2, null, null },
                    { 144, null, null, null, null, 42, 220, 2, null, null },
                    { 145, null, null, null, null, 43, 225, 2, null, null },
                    { 146, null, null, null, null, 44, 230, 2, null, null },
                    { 147, null, null, null, null, 45, 235, 2, null, null },
                    { 148, null, null, null, null, 46, 240, 2, null, null },
                    { 149, null, null, null, null, 47, 245, 2, null, null },
                    { 150, null, null, null, null, 48, 250, 2, null, null },
                    { 151, null, null, null, null, 49, 255, 2, null, null },
                    { 152, null, null, null, null, 50, 260, 2, null, null },
                    { 153, null, null, null, null, 51, 265, 2, null, null },
                    { 154, null, null, null, null, 52, 270, 2, null, null },
                    { 155, null, null, null, null, 53, 275, 2, null, null },
                    { 156, null, null, null, null, 54, 280, 2, null, null },
                    { 157, null, null, null, null, 55, 285, 2, null, null },
                    { 158, null, null, null, null, 56, 290, 2, null, null },
                    { 159, null, null, null, null, 57, 295, 2, null, null },
                    { 160, null, null, null, null, 58, 300, 2, null, null },
                    { 161, null, null, null, null, 59, 305, 2, null, null },
                    { 162, null, null, null, null, 60, 310, 2, null, null },
                    { 163, null, null, null, null, 61, 315, 2, null, null },
                    { 164, null, null, null, null, 62, 320, 2, null, null },
                    { 165, null, null, null, null, 63, 325, 2, null, null },
                    { 166, null, null, null, null, 64, 330, 2, null, null }
                });

            migrationBuilder.InsertData(
                table: "ToeicScores",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "NumberOfCorrect", "Score", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 167, null, null, null, null, 65, 335, 2, null, null },
                    { 168, null, null, null, null, 66, 340, 2, null, null },
                    { 169, null, null, null, null, 67, 345, 2, null, null },
                    { 170, null, null, null, null, 68, 350, 2, null, null },
                    { 171, null, null, null, null, 69, 355, 2, null, null },
                    { 172, null, null, null, null, 70, 360, 2, null, null },
                    { 173, null, null, null, null, 71, 365, 2, null, null },
                    { 174, null, null, null, null, 72, 370, 2, null, null },
                    { 175, null, null, null, null, 73, 375, 2, null, null },
                    { 176, null, null, null, null, 74, 380, 2, null, null },
                    { 177, null, null, null, null, 75, 385, 2, null, null },
                    { 178, null, null, null, null, 76, 390, 2, null, null },
                    { 179, null, null, null, null, 77, 395, 2, null, null },
                    { 180, null, null, null, null, 78, 400, 2, null, null },
                    { 181, null, null, null, null, 79, 405, 2, null, null },
                    { 182, null, null, null, null, 80, 410, 2, null, null },
                    { 183, null, null, null, null, 81, 415, 2, null, null },
                    { 184, null, null, null, null, 82, 420, 2, null, null },
                    { 185, null, null, null, null, 83, 425, 2, null, null },
                    { 186, null, null, null, null, 84, 430, 2, null, null },
                    { 187, null, null, null, null, 85, 435, 2, null, null },
                    { 188, null, null, null, null, 86, 440, 2, null, null },
                    { 189, null, null, null, null, 87, 445, 2, null, null },
                    { 190, null, null, null, null, 88, 450, 2, null, null },
                    { 191, null, null, null, null, 89, 455, 2, null, null },
                    { 192, null, null, null, null, 90, 460, 2, null, null },
                    { 193, null, null, null, null, 91, 465, 2, null, null },
                    { 194, null, null, null, null, 92, 470, 2, null, null },
                    { 195, null, null, null, null, 93, 475, 2, null, null },
                    { 196, null, null, null, null, 94, 480, 2, null, null },
                    { 197, null, null, null, null, 95, 485, 2, null, null },
                    { 198, null, null, null, null, 96, 490, 2, null, null },
                    { 199, null, null, null, null, 97, 495, 2, null, null },
                    { 200, null, null, null, null, 98, 495, 2, null, null },
                    { 201, null, null, null, null, 99, 495, 2, null, null },
                    { 202, null, null, null, null, 100, 495, 2, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "ToeicScores");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "bddda18e-184b-469d-9a95-2147657ff641");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c3f087a2-48d5-4e09-8a63-8830a7b5b4e3"),
                column: "ConcurrencyStamp",
                value: "1674f761-8b19-47c8-b3d4-91f6d5b144fc");
        }
    }
}
