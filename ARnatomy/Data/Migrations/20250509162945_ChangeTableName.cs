using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARnatomy.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.RenameTable(
                name: "Models",
                newName: "OrganModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganModels",
                table: "OrganModels",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganModels",
                table: "OrganModels");

            migrationBuilder.RenameTable(
                name: "OrganModels",
                newName: "Models");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "Id");
        }
    }
}
