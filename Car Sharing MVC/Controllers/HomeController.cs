using Car_Sharing_MVC.Models;
using CarSharingApplication.CarSharing.CarSharingProfileCommands.Queries.GetAllCarSharing;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Car_Sharing_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var carSharingList = await _mediator.Send(new GetAllCarSharingQuery());
            return View(carSharingList);
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
