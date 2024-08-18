using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task1.Migrations
{
    /// <inheritdoc />
    public partial class SetNullOnDeleting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_InVoices_InvoiceId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InVoices",
                table: "InVoices");

            migrationBuilder.RenameTable(
                name: "InVoices",
                newName: "Invoices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Invoices_InvoiceId",
                table: "Products",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Invoices_InvoiceId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "InVoices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InVoices",
                table: "InVoices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_InVoices_InvoiceId",
                table: "Products",
                column: "InvoiceId",
                principalTable: "InVoices",
                principalColumn: "Id");
        }
    }
}
