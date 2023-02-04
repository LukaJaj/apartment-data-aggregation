using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dataaggregation.Migrations
{
    /// <inheritdoc />
    public partial class ChangedAggregationCOlumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sum_p_minus",
                table: "ApartmentsAggregated");

            migrationBuilder.DropColumn(
                name: "sum_p_plus",
                table: "ApartmentsAggregated");

            migrationBuilder.AddColumn<decimal>(
                name: "p_minus",
                table: "ApartmentsAggregated",
                type: "numeric(6,2)",
                precision: 6,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "p_plus",
                table: "ApartmentsAggregated",
                type: "numeric(6,2)",
                precision: 6,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "p_minus",
                table: "ApartmentsAggregated");

            migrationBuilder.DropColumn(
                name: "p_plus",
                table: "ApartmentsAggregated");

            migrationBuilder.AddColumn<float>(
                name: "sum_p_minus",
                table: "ApartmentsAggregated",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "sum_p_plus",
                table: "ApartmentsAggregated",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
