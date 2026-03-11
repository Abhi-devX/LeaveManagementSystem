using Microsoft.AspNetCore.Mvc;

public class AuthController : Controller
{
    private readonly ApplicationDbContext _context;

    public AuthController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Login Page
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var user = _context.Users
            .FirstOrDefault(x => x.Email == email && x.Password == password);

        if (user != null)
        {
            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("Role", user.Role);

            if (user.Role == "Admin")
                return RedirectToAction("AdminDashboard", "Dashboard");
            else
                return RedirectToAction("EmployeeDashboard", "Dashboard");
        }

        ViewBag.Error = "Invalid email or password";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}