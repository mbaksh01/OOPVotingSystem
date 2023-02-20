using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OOPVotingSystem.Migrations
{
    /// <inheritdoc />
    public partial class NullableCandidateId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_People_CandidateId",
                table: "Votes");

            migrationBuilder.AlterColumn<string>(
                name: "CandidateId",
                table: "Votes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_People_CandidateId",
                table: "Votes",
                column: "CandidateId",
                principalTable: "People",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_People_CandidateId",
                table: "Votes");

            migrationBuilder.AlterColumn<string>(
                name: "CandidateId",
                table: "Votes",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_People_CandidateId",
                table: "Votes",
                column: "CandidateId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
