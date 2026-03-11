using LeaveManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

public class EmployeeController : Controller
{
    private readonly ApplicationDbContext _context;

    public EmployeeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(string search)
    {
        var employees = from e in _context.Employees
                        select e;

        if (!string.IsNullOrEmpty(search))
        {
            employees = employees.Where(x =>
                x.Name.Contains(search) ||
                x.Department.Contains(search));
        }

        return View(employees.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Employee model)
    {
        model.IsActive = true;

        _context.Employees.Add(model);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var employee = _context.Employees.Find(id);

        return View(employee);
    }

    [HttpPost]
    public IActionResult Edit(Employee model)
    {
        _context.Employees.Update(model);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Deactivate(int id)
    {
        var employee = _context.Employees.Find(id);

        employee.IsActive = false;

        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}