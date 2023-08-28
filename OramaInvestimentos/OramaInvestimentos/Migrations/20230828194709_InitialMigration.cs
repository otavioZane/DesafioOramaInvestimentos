using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OramaInvestimentos.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerID = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    email = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    password = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    salt = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerID);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    accountID = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerID = table.Column<long>(type: "BIGINT", nullable: false),
                    balance = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false, defaultValue: 10000m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.accountID);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Customers_customerID",
                        column: x => x.customerID,
                        principalTable: "Customers",
                        principalColumn: "customerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialTransactions",
                columns: table => new
                {
                    transactionID = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountID = table.Column<long>(type: "BIGINT", nullable: false),
                    type = table.Column<string>(type: "VARCHAR(3)", maxLength: 3, nullable: false),
                    assetID = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    totalValue = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialTransactions", x => x.transactionID);
                    table.ForeignKey(
                        name: "FK_FinancialTransactions_BankAccounts_accountID",
                        column: x => x.accountID,
                        principalTable: "BankAccounts",
                        principalColumn: "accountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialAssets",
                columns: table => new
                {
                    assetID = table.Column<long>(type: "BIGINT", nullable: false),
                    name = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    price = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialAssets", x => x.assetID);
                    table.ForeignKey(
                        name: "FK_FinancialAssets_FinancialTransactions_assetID",
                        column: x => x.assetID,
                        principalTable: "FinancialTransactions",
                        principalColumn: "transactionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_customerID",
                table: "BankAccounts",
                column: "customerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_email",
                table: "Customers",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinancialTransactions_accountID",
                table: "FinancialTransactions",
                column: "accountID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialAssets");

            migrationBuilder.DropTable(
                name: "FinancialTransactions");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
