using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dataaggregation.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentsAggregated",
                table: "ApartmentsAggregated");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ApartmentsAggregated");

            migrationBuilder.RenameColumn(
                name: "network",
                table: "ApartmentsAggregated",
                newName: "Network");

            migrationBuilder.AlterColumn<string>(
                name: "Network",
                table: "ApartmentsAggregated",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentsAggregated",
                table: "ApartmentsAggregated",
                column: "Network");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentsAggregated",
                table: "ApartmentsAggregated");

            migrationBuilder.RenameColumn(
                name: "Network",
                table: "ApartmentsAggregated",
                newName: "network");

            migrationBuilder.AlterColumn<string>(
                name: "network",
                table: "ApartmentsAggregated",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "ApartmentsAggregated",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentsAggregated",
                table: "ApartmentsAggregated",
                column: "Id");
        }
    }
}
