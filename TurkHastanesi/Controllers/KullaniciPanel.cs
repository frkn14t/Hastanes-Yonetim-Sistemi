using HastaneBolu.Models;
using Microsoft.AspNetCore.Mvc;

public class AdminPanelController : Controller
{
    private readonly HastaneBoluDBContext _context;

    public AdminPanelController(HastaneBoluDBContext context)
    {
        _context = context;
    }

    private bool IsAdminLoggedIn()
    {
        return HttpContext.Session.GetString("Admin") != null;
    }

    public IActionResult Index()
    {
        if (!IsAdminLoggedIn())
            return RedirectToAction("Login", "Admin");

        return View();
    }
    public IActionResult Asistanlar()
    {
        return View("~/Views/Admin/Asistanlar/Index.cshtml"); // Asistanlar/Index.cshtml sayfasını admin paneline dahil eder
    }
}
