using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GIBDDDatebase.Migrations
{
    /// <inheritdoc />
    public partial class addRepaymentDat111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Drivers_DriverId",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_TransportVehicle_TransportVehicleId",
                table: "Incidents");

            migrationBuilder.AlterColumn<int>(
                name: "TransportVehicleId",
                table: "Incidents",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Incidents",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Drivers_DriverId",
                table: "Incidents",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_TransportVehicle_TransportVehicleId",
                table: "Incidents",
                column: "TransportVehicleId",
                principalTable: "TransportVehicle",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Drivers_DriverId",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_TransportVehicle_TransportVehicleId",
                table: "Incidents");

            migrationBuilder.AlterColumn<int>(
                name: "TransportVehicleId",
                table: "Incidents",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Incidents",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Drivers_DriverId",
                table: "Incidents",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_TransportVehicle_TransportVehicleId",
                table: "Incidents",
                column: "TransportVehicleId",
                principalTable: "TransportVehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
