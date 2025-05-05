using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameTemplateColumnOnStepParameterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StepParameters_StepParameterTemplates_TemplateId",
                table: "StepParameters");

            migrationBuilder.RenameColumn(
                name: "TemplateId",
                table: "StepParameters",
                newName: "StepParameterTemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_StepParameters_TemplateId",
                table: "StepParameters",
                newName: "IX_StepParameters_StepParameterTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_StepParameters_StepParameterTemplates_StepParameterTemplate~",
                table: "StepParameters",
                column: "StepParameterTemplateId",
                principalTable: "StepParameterTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StepParameters_StepParameterTemplates_StepParameterTemplate~",
                table: "StepParameters");

            migrationBuilder.RenameColumn(
                name: "StepParameterTemplateId",
                table: "StepParameters",
                newName: "TemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_StepParameters_StepParameterTemplateId",
                table: "StepParameters",
                newName: "IX_StepParameters_TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_StepParameters_StepParameterTemplates_TemplateId",
                table: "StepParameters",
                column: "TemplateId",
                principalTable: "StepParameterTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
