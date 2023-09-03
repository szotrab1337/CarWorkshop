using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly ICarWorkshopService _carWorkshopService;

        public CarWorkshopController(ICarWorkshopService carWorkshopService)
        {
            _carWorkshopService = carWorkshopService;
        }

        public async Task<IActionResult> Index()
        {
            var varWorkshops = await _carWorkshopService.GetAll();

            return View(varWorkshops);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarWorkshopDto carWorkshopDto)
        {
            if (!ModelState.IsValid)
            {
                return View(carWorkshopDto);
            }

            await _carWorkshopService.Create(carWorkshopDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
