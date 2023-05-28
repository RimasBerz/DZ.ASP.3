using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using WebApplication1.Servicies;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IDateService _dateService;
        private readonly TimeService _timeService;
        private readonly DateTimeService _dateTimeService;
        public HomeController(ILogger<HomeController> logger,
            IDateService dateService,
            TimeService timeService,
            DateTimeService dateTimeService)
        {
            _logger = logger;
            _dateService = dateService;
            _timeService = timeService;
            _dateTimeService = dateTimeService;
        }
        public ViewResult Data()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Intro()
        {
            return View();
        }
        public IActionResult Razor()
        {
            return View();
        }
        public ViewResult Servicies()
        {
            ViewData["date"] = _dateService.GetDate();
            ViewData["time"] = _timeService.GetTime();
            ViewData["datetime"] = _dateTimeService.GetNow();

            ViewData["datetime-hash"] = _dateTimeService.GetHashCode();
            ViewData["date-hash"] = _dateService.GetHashCode();
            ViewData["time-hash"] = _timeService.GetHashCode();
          
            ViewData["ctrl"] = this.GetHashCode();
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public class YourController : Controller
        {
            private readonly IValidatorService _validatorService;

            public YourController(IValidatorService validatorService)
            {
                _validatorService = validatorService;
            }

            public IActionResult Action()
            {
                ViewData["res"] = new bool[] {
            _validatorService.ValidateLogin("NormalLogin1"),
            _validatorService.ValidateLogin("Normal_Login_2"),
            _validatorService.ValidateLogin("In-valid login"),
            _validatorService.ValidateLogin("$ invalid ++"),
        };

                return View();
            }
        }
    }
}