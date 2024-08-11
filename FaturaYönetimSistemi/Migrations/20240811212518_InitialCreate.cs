using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FaturaYönetimSistemi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recipient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TCNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarsPlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentOwner = table.Column<bool>(type: "bit", nullable: false),
                    ApartmentId = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    ApartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentBlock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.ApartmentId);
                    table.ForeignKey(
                        name: "FK_Apartments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Dues",
                columns: table => new
                {
                    DuesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dues", x => x.DuesId);
                    table.ForeignKey(
                        name: "FK_Dues_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityBills",
                columns: table => new
                {
                    ElectricityBillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElectricityBillSerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElectricityBillSequenceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElectricityBillCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElectricityBillPrice = table.Column<int>(type: "int", nullable: false),
                    ElectricityBillDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ElectricityBillDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElectricityBillStatus = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityBills", x => x.ElectricityBillID);
                    table.ForeignKey(
                        name: "FK_ElectricityBills_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NaturalGasBills",
                columns: table => new
                {
                    NaturalGasBillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NaturalGasBillSerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NaturalGasBillSequenceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NaturalGasBillCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NaturalGasBillPrice = table.Column<int>(type: "int", nullable: false),
                    NaturalGasBillDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NaturalGasBilllDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NaturalGasBillStatus = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalGasBills", x => x.NaturalGasBillID);
                    table.ForeignKey(
                        name: "FK_NaturalGasBills_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaterBills",
                columns: table => new
                {
                    WaterBillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaterBillSerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaterBillSequenceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaterBillCompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaterBillPrice = table.Column<int>(type: "int", nullable: false),
                    WaterBillDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WaterBillDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaterBillStatus = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterBills", x => x.WaterBillID);
                    table.ForeignKey(
                        name: "FK_WaterBills_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_UserId",
                table: "Apartments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dues_UserID",
                table: "Dues",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityBills_UserID",
                table: "ElectricityBills",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_NaturalGasBills_UserID",
                table: "NaturalGasBills",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_WaterBills_UserID",
                table: "WaterBills",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "Dues");

            migrationBuilder.DropTable(
                name: "ElectricityBills");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "NaturalGasBills");

            migrationBuilder.DropTable(
                name: "WaterBills");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
