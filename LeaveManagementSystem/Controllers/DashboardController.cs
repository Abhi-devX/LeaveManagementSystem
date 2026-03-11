using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Admin Dashboard
    public IActionResult AdminDashboard()
    {
        if (HttpContext.Session.GetString("Role") != "Admin")
        {
            return RedirectToAction("Login", "Auth");
        }

        ViewBag.TotalEmployees = _context.Employees.Count();
        ViewBag.PendingLeaves = _context.LeaveRequests.Count(x => x.Status == "Pending");
        ViewBag.ApprovedLeaves = _context.LeaveRequests.Count(x => x.Status == "Approved");

        return View();
    }

    // Employee Dashboard
    public IActionResult EmployeeDashboard()
    {
        if (HttpContext.Session.GetString("Role") != "Employee")
        {
            return RedirectToAction("Login", "Auth");
        }

        int employeeId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));

        ViewBag.MyLeaves = _context.LeaveRequests.Count(x => x.EmployeeId == employeeId);
        ViewBag.PendingLeaves = _context.LeaveRequests.Count(x => x.EmployeeId == employeeId && x.Status == "Pending");
        ViewBag.ApprovedLeaves = _context.LeaveRequests.Count(x => x.EmployeeId == employeeId && x.Status == "Approved");

        return View();
    }
}