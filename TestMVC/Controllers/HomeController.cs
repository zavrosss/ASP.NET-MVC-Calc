using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Kalkulator(double liczba1, double liczba2, string operacja, double poprzedniWynik = 0)
        {
            double wynik = poprzedniWynik;

            switch (operacja)
            {
                case "+":
                    wynik += liczba1 + liczba2;
                    break;
                case "-":
                    wynik += liczba1 - liczba2;
                    break;
                case "*":
                    wynik += liczba1 * liczba2;
                    break;
                case "/":
                    wynik += liczba2 != 0 ? liczba1 / liczba2 : double.NaN;
                    break;
            }

            ViewBag.Wynik = wynik;
            return View("Kalkulator");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}