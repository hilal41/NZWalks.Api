using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.Api.Migrations
{
    /// <inheritdoc />
    public partial class defCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5cf21b0c-4d90-480b-8ace-dc6da688abd1"), "Hard" },
                    { new Guid("a4eb412c-cd0b-4fae-93de-5280b7f98cba"), "Medium" },
                    { new Guid("e3cb226c-f92b-4699-aed3-5f688ed43baf"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("5cf21b0c-4d90-480b-8ace-dc6da688abd1"), "OT", "Other", "https://example.com/region3.jpg" },
                    { new Guid("a4eb412c-cd0b-4fae-93de-5280b7f98cba"), "SI", "South Island", "https://example.com/region2.jpg" },
                    { new Guid("e3cb226c-f92b-4699-aed3-5f688ed43baf"), "NI", "North Island", "https://example.com/region1.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5cf21b0c-4d90-480b-8ace-dc6da688abd1"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a4eb412c-cd0b-4fae-93de-5280b7f98cba"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("e3cb226c-f92b-4699-aed3-5f688ed43baf"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("5cf21b0c-4d90-480b-8ace-dc6da688abd1"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("a4eb412c-cd0b-4fae-93de-5280b7f98cba"));

            migrationBuilder.DeleteData(
                table: "regions",
                keyColumn: "Id",
                keyValue: new Guid("e3cb226c-f92b-4699-aed3-5f688ed43baf"));
        }
    }
}
