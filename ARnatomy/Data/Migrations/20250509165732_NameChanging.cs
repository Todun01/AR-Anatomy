using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARnatomy.Data.Migrations
{
    /// <inheritdoc />
    public partial class NameChanging : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_OrganModels_OrganModelsId",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_OrganModelsId",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "OrganModelsId",
                table: "Feedback");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_OrganModelId",
                table: "Feedback",
                column: "OrganModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_OrganModels_OrganModelId",
                table: "Feedback",
                column: "OrganModelId",
                principalTable: "OrganModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_OrganModels_OrganModelId",
                table: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Feedback_OrganModelId",
                table: "Feedback");

            migrationBuilder.AddColumn<int>(
                name: "OrganModelsId",
                table: "Feedback",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_OrganModelsId",
                table: "Feedback",
                column: "OrganModelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_OrganModels_OrganModelsId",
                table: "Feedback",
                column: "OrganModelsId",
                principalTable: "OrganModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
