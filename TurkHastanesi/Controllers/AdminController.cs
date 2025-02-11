using Microsoft.AspNetCore.Mvc;

namespace HastaneBolu.Controllers
{
    public class AdminController : Controller
    {
        // Giriş sayfası
        public IActionResult Login()
        {
            return View();
        }

        // Giriş işlemi
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Basit giriş kontrolü (gerçek projelerde veritabanı ile doğrulama yapılmalı)
            if (username == "admin" && password == "admin2003")
            {
                // Giriş başarılı ise, admin sayfasına yönlendir
                return RedirectToAction("KullaniciPanel");
            }

            // Giriş başarısız ise, hata mesajı ile tekrar giriş sayfasına dön
            ViewBag.ErrorMessage = "Geçersiz kullanıcı adı veya şifre!";
            return View();
        }

        // Admin paneli (Giriş sonrası gösterilecek sayfa)
        public IActionResult KullaniciPanel()
        {
            return View();
        }

        // Çıkış işlemi
        public IActionResult Logout()
        {
            // Kullanıcıyı çıkış yapmaya yönlendir
            return RedirectToAction("Login");
        }
    }
}