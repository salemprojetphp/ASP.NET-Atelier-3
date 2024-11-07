using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFrstMVCApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "MembershipTypeId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MembershipTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    signupFee = table.Column<float>(type: "real", nullable: false),
                    durationInMonths = table.Column<int>(type: "int", nullable: false),
                    discountRate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieClients",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieClients", x => new { x.MovieId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_MovieClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieClients_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_MembershipTypeId",
                table: "Clients",
                column: "MembershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieClients_ClientId",
                table: "MovieClients",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_MembershipTypes_MembershipTypeId",
                table: "Clients",
                column: "MembershipTypeId",
                principalTable: "MembershipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_MembershipTypes_MembershipTypeId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "MembershipTypes");

            migrationBuilder.DropTable(
                name: "MovieClients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_MembershipTypeId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "MembershipTypeId",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Customers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");
        }
    }
}
