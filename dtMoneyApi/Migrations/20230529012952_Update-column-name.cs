using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dtMoneyApi.Migrations
{
    /// <inheritdoc />
    public partial class Updatecolumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Transactions",
                newName: "Amount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Transactions",
                newName: "Quantity");
        }
    }
}
