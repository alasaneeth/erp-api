using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP_API.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class ModifyCustomertypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceAmount",
                table: "CustomerTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "InvoiceAmount",
                table: "CustomerTypes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
