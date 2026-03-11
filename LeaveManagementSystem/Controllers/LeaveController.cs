using LeaveManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class LeaveController : Controller
{
    private readonly ApplicationDbContext _context;

    public LeaveController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult MyLeaves()
    {
        int employeeId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));

        var leaves = _context.LeaveRequests
            .Where(x => x.EmployeeId == employeeId)
            .OrderByDescending(x => x.Id)
            .ToList();

        return View(leaves);
    }

  
    public IActionResult Apply()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Apply(LeaveRequest model)
    {
        int employeeId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));

        // Date Validation
        if (model.FromDate > model.ToDate)
        {
            ViewBag.Error = "From Date cannot be greater than To Date";
            return View();
        }

        // Overlapping Leave Validation
        var overlap = _context.LeaveRequests.Any(x =>
            x.EmployeeId == employeeId &&
            model.FromDate <= x.ToDate &&
            model.ToDate >= x.FromDate);

        if (overlap)
        {
            ViewBag.Error = "Leave already applied for these dates.";
            return View();
        }

        model.EmployeeId = employeeId;
        model.Status = "Pending";

        _context.LeaveRequests.Add(model);
        _context.SaveChanges();

        return RedirectToAction("MyLeaves");
    }

    public IActionResult ManageLeaves()
    {
        var leaves = _context.LeaveRequests
            .Include(x => x.Employee)
            .OrderByDescending(x => x.Id)
            .ToList();

        return View(leaves);
    }


    public IActionResult Approve(int id)
    {
        var leave = _context.LeaveRequests.Find(id);

        if (leave == null)
        {
            return NotFound();
        }

        leave.Status = "Approved";

        _context.SaveChanges();

        return RedirectToAction("ManageLeaves");
    }


    public IActionResult Reject(int id)
    {
        var leave = _context.LeaveRequests.Find(id);

        if (leave == null)
        {
            return NotFound();
        }

        leave.Status = "Rejected";

        _context.SaveChanges();

        return RedirectToAction("ManageLeaves");
    }

   
}