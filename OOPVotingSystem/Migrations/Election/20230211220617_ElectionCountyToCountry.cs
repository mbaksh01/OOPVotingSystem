using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OOPVotingSystem.Migrations.Election
{
    /// <inheritdoc />
    public partial class ElectionCountyToCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "County",
                table: "Elections",
                newName: "Country");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Elections",
                newName: "County");
        }
    }
}
