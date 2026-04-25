using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinFlow.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkflowFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "WorkflowTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "WorkflowTasks",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "WorkflowTasks");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "WorkflowTasks");
        }
    }
}
