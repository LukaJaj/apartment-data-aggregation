using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dataaggregation.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    network = table.Column<string>(type: "varchar(256)", nullable: false),
                    obtname = table.Column<string>(name: "obt_name", type: "varchar(256)", nullable: false),
                    objgvtype = table.Column<string>(name: "obj_gv_type", type: "varchar(256)", nullable: false),
                    objnumber = table.Column<string>(name: "obj_number", type: "varchar(256)", nullable: false),
                    pplus = table.Column<decimal>(name: "p_plus", type: "numeric(6,2)", precision: 6, scale: 2, nullable: false),
                    pltime = table.Column<string>(name: "pl_time", type: "text", nullable: false),
                    pminus = table.Column<decimal>(name: "p_minus", type: "numeric(6,2)", precision: 6, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentsAggregated",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    network = table.Column<string>(type: "varchar(256)", nullable: false),
                    obtname = table.Column<string>(name: "obt_name", type: "varchar(256)", nullable: false),
                    objgvtype = table.Column<string>(name: "obj_gv_type", type: "varchar(256)", nullable: false),
                    objnumber = table.Column<string>(name: "obj_number", type: "varchar(256)", nullable: false),
                    sumpplus = table.Column<float>(name: "sum_p_plus", type: "real", nullable: false),
                    pltime = table.Column<string>(name: "pl_time", type: "text", nullable: false),
                    sumpminus = table.Column<float>(name: "sum_p_minus", type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentsAggregated", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "ApartmentsAggregated");
        }
    }
}
