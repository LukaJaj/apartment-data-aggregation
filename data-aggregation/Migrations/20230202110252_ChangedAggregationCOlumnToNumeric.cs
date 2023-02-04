using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dataaggregation.Migrations
{
    /// <inheritdoc />
    public partial class ChangedAggregationCOlumnToNumeric : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "p_plus",
                table: "ApartmentsAggregated",
                type: "numeric(9,6)",
                precision: 9,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(6,2)",
                oldPrecision: 6,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "p_minus",
                table: "ApartmentsAggregated",
                type: "numeric(7,5)",
                precision: 7,
                scale: 5,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(6,2)",
                oldPrecision: 6,
                oldScale: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "p_plus",
                table: "ApartmentsAggregated",
                type: "numeric(6,2)",
                precision: 6,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(9,6)",
                oldPrecision: 9,
                oldScale: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "p_minus",
                table: "ApartmentsAggregated",
                type: "numeric(6,2)",
                precision: 6,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(7,5)",
                oldPrecision: 7,
                oldScale: 5);
        }
    }
}
