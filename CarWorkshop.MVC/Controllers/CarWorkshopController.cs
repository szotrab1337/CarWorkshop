using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops;
using CarWorkshop.Application.Commands.CreateCarWorkshop;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly IMediator _mediator;

        public CarWorkshopController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var varWorkshops = await _mediator.Send(new GetAllCarWorkshopsQuery());

            return View(varWorkshops);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarWorkshopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
