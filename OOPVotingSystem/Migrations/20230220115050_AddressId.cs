using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OOPVotingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddressId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parties_Addresses_OperationAddressId",
                table: "Parties");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.RenameColumn(
                name: "OperationAddressId",
                table: "Parties",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Parties_OperationAddressId",
                table: "Parties",
                newName: "IX_Parties_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_Addresses_AddressId",
                table: "Parties",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parties_Addresses_AddressId",
                table: "Parties");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Parties",
                newName: "OperationAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Parties_AddressId",
                table: "Parties",
                newName: "IX_Parties_OperationAddressId");

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    PartyId = table.Column<string>(type: "TEXT", nullable: false),
                    ElectionId = table.Column<string>(type: "TEXT", nullable: false),
                    TotalBudget = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => new { x.PartyId, x.ElectionId });
                    table.ForeignKey(
                        name: "FK_Budgets_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    PartyId = table.Column<string>(type: "TEXT", nullable: false),
                    ElectionId = table.Column<string>(type: "TEXT", nullable: false),
                    TotalCost = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => new { x.PartyId, x.ElectionId });
                    table.ForeignKey(
                        name: "FK_Costs_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Costs_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Costs_ElectionId",
                table: "Costs",
                column: "ElectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_Addresses_OperationAddressId",
                table: "Parties",
                column: "OperationAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
