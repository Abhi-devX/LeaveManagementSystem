using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "IT", "rahul@test.com", true, "Rahul Patil" },
                    { 2, "HR", "sneha@test.com", true, "Sneha Sharma" },
                    { 3, "Finance", "amit@test.com", true, "Amit Kulkarni" },
                    { 4, "IT", "priya@test.com", true, "Priya Deshmukh" },
                    { 5, "Sales", "rohit@test.com", true, "Rohit Singh" },
                    { 6, "HR", "neha@test.com", true, "Neha Joshi" },
                    { 7, "Marketing", "karan@test.com", true, "Karan Mehta" },
                    { 8, "Support", "pooja@test.com", true, "Pooja Verma" },
                    { 9, "IT", "aditya@test.com", true, "Aditya Patil" },
                    { 10, "Finance", "simran@test.com", true, "Simran Kaur" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "admin@example.com", "Admin", "admin123", "Admin" },
                    { 2, "employee@example.com", "Employee", "emp123", "Employee" }
                });

            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "Id", "EmployeeId", "FromDate", "Reason", "Status", "ToDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal Work", "Approved", new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medical Leave", "Pending", new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Family Function", "Approved", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_EmployeeId",
                table: "LeaveRequests",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_Employees_EmployeeId",
                table: "LeaveRequests",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_Employees_EmployeeId",
                table: "LeaveRequests");

            migrationBuilder.DropIndex(
                name: "IX_LeaveRequests_EmployeeId",
                table: "LeaveRequests");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
