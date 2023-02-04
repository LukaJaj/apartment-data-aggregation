using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dataaggregation.Migrations
{
    /// <inheritdoc />
    public partial class ChangedAggregatedTableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "obj_gv_type",
                table: "ApartmentsAggregated");

            migrationBuilder.DropColumn(
                name: "obj_number",
                table: "ApartmentsAggregated");

            migrationBuilder.DropColumn(
                name: "obt_name",
                table: "ApartmentsAggregated");

            migrationBuilder.DropColumn(
                name: "pl_time",
                table: "ApartmentsAggregated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "obj_gv_type",
                table: "ApartmentsAggregated",
                type: "varchar(256)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "obj_number",
                table: "ApartmentsAggregated",
                type: "varchar(256)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "obt_name",
                table: "ApartmentsAggregated",
                type: "varchar(256)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pl_time",
                table: "ApartmentsAggregated",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
