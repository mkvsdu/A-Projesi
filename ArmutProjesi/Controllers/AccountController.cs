using ArmutProjesi.Models;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ArmutProjesi.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly DatabaseContext _databaseContext;       
        private readonly KullaniciManager _kullaniciManager;

        public AccountController(DatabaseContext databaseContext, IConfiguration configuration)
        {
            this._databaseContext = databaseContext;
            this._kullaniciManager = new KullaniciManager(new EFKullaniciRepository(this._databaseContext));
        }
        [HttpGet, AllowAnonymous]
        public IActionResult Login()//Giriş 
        {
            return View();
        }
        [HttpPost, AllowAnonymous]
        public IActionResult Login(LoginModel model)//Giriş 
        {
            if (ModelState.IsValid)
            {
                //Kullanici response = _db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == model.KullaniciAdi && x.Sifre == model.Sifre);
                Kullanici response = _kullaniciManager.KullaniciBul(model.KullaniciAdi, model.Sifre);
                if (response != null)
                {
                    if (!response.Aktif)
                    {
                        ModelState.AddModelError("", "Kullanıcı Aktif Değil");
                        return View(model);
                    }

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, response.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, response.Ad ?? string.Empty));
                   // claims.Add(new Claim(ClaimTypes.Role, response.KullaniciRol));
                    claims.Add(new Claim("KullaniciAdi", response.KullaniciAdi));

                    ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Profile", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                }
            }

            return View(model);
        }
        [HttpGet, AllowAnonymous]
        public IActionResult Register()//Kayıt OL
        {
            return View();
        }
        [HttpPost, AllowAnonymous]
        public IActionResult Register(RegisterModel model)//Kayıt OL
        {
            if (ModelState.IsValid)
            {
                Kullanici newuser = new Kullanici()
                {
                    Ad = model.Ad,
                    Soyad = model.Soyad,
                    Email = model.Email,
                    Sifre = model.Sifre,
                    Cinsiyet = model.Cinsiyet,
                    KullaniciAdi = model.KullaniciAdi,
                    KayitTarihi = DateTime.Now,
                    Aktif = false,
                };
               _kullaniciManager.kullaniciAdd(newuser);
                return RedirectToAction("Profile", "Account");
            }
            return View(model);
        }
        public IActionResult UpdatePassword()//Şifre Yenileme ya da Şifremi Unuttum
        {
            return View();
        }

        public IActionResult Profile() // Profil sayfası
        {
            return View();
        }
        public IActionResult ProfileSetting() // Profil ayarları
        {
            return View();
        }
        public IActionResult ServiceSettings() // Service ayarları
        {
            return View();
        }
        public IActionResult Wallet() // Cüzdan  ayarları
        {
            return View();
        }
        public IActionResult Jobs() // işlerim
        {
            return View();
        }
        public IActionResult services() // servislerim
        {
            return View();
        }
    }
}

