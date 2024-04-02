using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZipLink.Core.Migrations
{
    public partial class AddNumberofclicksfieldinUrltbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Numberofclicks",
                table: "Urls",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numberofclicks",
                table: "Urls");
        }
    }
}
