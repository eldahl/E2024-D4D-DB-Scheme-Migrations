using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ActivityMonitorAPI.Migrations
{
    /// <inheritdoc />
    public partial class efconstraintsandadddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "categoryName",
                table: "Activities",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "ActivityCategory",
                column: "catName",
                values: new object[]
                {
                    "Afk",
                    "Gaming",
                    "Leisure",
                    "Meeting",
                    "Research",
                    "Work"
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "email", "userName" },
                values: new object[,]
                {
                    { 1, "larsGmanHenning@gmail.com", "Lars Henning" },
                    { 2, "Paludan@gmail.com", "Peter Paludan" },
                    { 3, "henribobendi@gmail.com", "Henriette" },
                    { 4, "JensJensJens@gmail.com", "Jens Jensen" },
                    { 5, "belastende@gmail.com", "Bent Belastende" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "id", "activityDescription", "categoryName", "nameActivity" },
                values: new object[,]
                {
                    { 1, "Actively using IDE", "Work", "Coding" },
                    { 2, "Relaxing on youtube", "Leisure", "Watching youtube" },
                    { 3, "Acquiring new knowledge", "Research", "Stackoverflow" },
                    { 4, "PC is idle", "Afk", "No user activity" },
                    { 5, "Planning..? Shittalking..? Its on discord at least.", "Meeting", "Discord Meeting" },
                    { 6, "Limiting EXP waste", "Gaming", "Playing OSRS" }
                });

            migrationBuilder.InsertData(
                table: "ActivityCategories",
                columns: new[] { "id", "activityId", "durationTime", "startTime" },
                values: new object[,]
                {
                    { 1, 1, new TimeSpan(0, 2, 0, 0, 0), new DateTime(2024, 9, 23, 16, 42, 43, 476, DateTimeKind.Local).AddTicks(3843) },
                    { 2, 2, new TimeSpan(0, 2, 0, 0, 0), new DateTime(2024, 9, 23, 16, 42, 43, 476, DateTimeKind.Local).AddTicks(3913) },
                    { 3, 3, new TimeSpan(0, 2, 0, 0, 0), new DateTime(2024, 9, 23, 16, 42, 43, 476, DateTimeKind.Local).AddTicks(3915) },
                    { 4, 4, new TimeSpan(0, 2, 0, 0, 0), new DateTime(2024, 9, 23, 16, 42, 43, 476, DateTimeKind.Local).AddTicks(3916) },
                    { 5, 5, new TimeSpan(0, 2, 0, 0, 0), new DateTime(2024, 9, 23, 16, 42, 43, 476, DateTimeKind.Local).AddTicks(3918) },
                    { 6, 6, new TimeSpan(0, 2, 0, 0, 0), new DateTime(2024, 9, 23, 16, 42, 43, 476, DateTimeKind.Local).AddTicks(3919) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCategories_activityId",
                table: "ActivityCategories",
                column: "activityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_categoryName",
                table: "Activities",
                column: "categoryName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_activityCategory",
                table: "Activities",
                column: "categoryName",
                principalTable: "ActivityCategory",
                principalColumn: "catName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityDuration_Activity",
                table: "ActivityCategories",
                column: "activityId",
                principalTable: "Activities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_activityCategory",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityDuration_Activity",
                table: "ActivityCategories");

            migrationBuilder.DropIndex(
                name: "IX_ActivityCategories_activityId",
                table: "ActivityCategories");

            migrationBuilder.DropIndex(
                name: "IX_Activities_categoryName",
                table: "Activities");

            migrationBuilder.DeleteData(
                table: "ActivityCategories",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ActivityCategories",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ActivityCategories",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ActivityCategories",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ActivityCategories",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ActivityCategories",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ActivityCategory",
                keyColumn: "catName",
                keyValue: "Afk");

            migrationBuilder.DeleteData(
                table: "ActivityCategory",
                keyColumn: "catName",
                keyValue: "Gaming");

            migrationBuilder.DeleteData(
                table: "ActivityCategory",
                keyColumn: "catName",
                keyValue: "Leisure");

            migrationBuilder.DeleteData(
                table: "ActivityCategory",
                keyColumn: "catName",
                keyValue: "Meeting");

            migrationBuilder.DeleteData(
                table: "ActivityCategory",
                keyColumn: "catName",
                keyValue: "Research");

            migrationBuilder.DeleteData(
                table: "ActivityCategory",
                keyColumn: "catName",
                keyValue: "Work");

            migrationBuilder.DropColumn(
                name: "categoryName",
                table: "Activities");
        }
    }
}
