using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.SqlMigrations.Migrations
{
    /// <inheritdoc />
    public partial class Adddefaultflagtocategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "TransactionCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "TransactionCategories");
        }
    }
}
