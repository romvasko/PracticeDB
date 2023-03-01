using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeDB.Data.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employeeRoles",
                columns: table => new
                {
                    EmployeeRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeRoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeRoles", x => x.EmployeeRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "visitors",
                columns: table => new
                {
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitorPassport = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visitors", x => x.VisitorId);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeAge = table.Column<int>(type: "int", nullable: false),
                    EmployeeRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_employees_employeeRoles_EmployeeRoleId",
                        column: x => x.EmployeeRoleId,
                        principalTable: "employeeRoles",
                        principalColumn: "EmployeeRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "visitLogs",
                columns: table => new
                {
                    VisitLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitorId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visitLogs", x => x.VisitLogId);
                    table.ForeignKey(
                        name: "FK_visitLogs_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_visitLogs_visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "visitors",
                        principalColumn: "VisitorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_EmployeeRoleId",
                table: "employees",
                column: "EmployeeRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_visitLogs_RoomId",
                table: "visitLogs",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_visitLogs_VisitorId",
                table: "visitLogs",
                column: "VisitorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "visitLogs");

            migrationBuilder.DropTable(
                name: "employeeRoles");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "visitors");
        }
    }
}
