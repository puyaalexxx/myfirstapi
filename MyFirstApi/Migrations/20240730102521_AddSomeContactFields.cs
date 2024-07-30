using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyFirstApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeContactFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("5f97acc6-567d-4692-ab4b-12b758a247a3"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("81bb59e4-d0ca-4ac8-a1f8-a0972f2e8588"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("e1d710ee-73ec-4a90-ae69-8efad20fdf9e"));

            migrationBuilder.AlterColumn<string>(
                name: "ContactName",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AddColumn<Guid>(
                name: "ContactId",
                table: "Invoices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Contacts",
                type: "varchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contacts",
                type: "varchar(64)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contacts",
                type: "varchar(64)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "varchar(128)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Contacts",
                type: "varchar(64)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Contacts",
                type: "varchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Contacts",
                type: "varchar(64)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Contacts",
                type: "varchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Contacts",
                type: "varchar(64)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Contacts",
                type: "varchar(16)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ContactId",
                table: "Invoices",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceNumber",
                table: "Invoices",
                column: "InvoiceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Email",
                table: "Contacts",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Contacts_ContactId",
                table: "Invoices",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Contacts_ContactId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ContactId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_InvoiceNumber",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_Email",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "ContactName",
                table: "Invoices",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(32)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(64)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(64)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)");

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Amount", "ContactName", "Description", "DueDate", "InvoiceDate", "InvoiceNumber", "Status" },
                values: new object[,]
                {
                    { new Guid("5f97acc6-567d-4692-ab4b-12b758a247a3"), 200m, "Captain America", "Invoice for the first month", new DateTimeOffset(new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-002", "AwaitPayment" },
                    { new Guid("81bb59e4-d0ca-4ac8-a1f8-a0972f2e8588"), 100m, "Iron Man", "Invoice for the first month", new DateTimeOffset(new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-001", "AwaitPayment" },
                    { new Guid("e1d710ee-73ec-4a90-ae69-8efad20fdf9e"), 300m, "Thor", "Invoice for the first month", new DateTimeOffset(new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "INV-003", "Draft" }
                });
        }
    }
}
