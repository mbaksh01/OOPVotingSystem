using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OOPVotingSystem.Migrations.Election
{
    /// <inheritdoc />
    public partial class AddedElectionName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Elections",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Elections");
        }
    }
}
