using AutoMapper;
using CarSharingApplication.CarSharing.CarSharingProfileCommands.Queries.GetAllCarSharing;
using CarSharingApplication.CarSharing.CarSharingProfileCommands.Queries.GetByNameCarSharing;
using CarSharingDomain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CarSharingApplication.CarSharing.CarSharingProfileCommands.Commands.CreateCarSharing;
using CarSharingApplication.CarSharing.CarSharingProfileCommands.Commands.EditCarSharing;
using CarSharingApplication.CarSharing.CarSharingImage.Commands;
using CarSharingApplication.CarSharing.CarSharingProfile.Commands.DelateCarSharing;
using CarSharingApplication.CarSharing.CarSharingProfile.Queries.GetBySearchName;
using Microsoft.AspNetCore.Authorization;
namespace Car_Sharing_MVC.Controllers
{
    public class CarSharingController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ICarSharingRepositories _carSharingRepositories;
        private readonly IMapper _mapper;

        public CarSharingController(IMediator mediator,ICarSharingRepositories carSharingRepositories,IMapper mapper)
        {
            _mediator = mediator;
            _carSharingRepositories = carSharingRepositories;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string Search)
        {
            if(Search == default)
            {
                var carSharingList = await _mediator.Send(new GetAllCarSharingQuery());
                return View(carSharingList);
            }
            var CarSharingListBySearch = await _mediator.Send(new GetBySearchNameCarSharingQuery(Search));
            return View(CarSharingListBySearch);

            
        }
        [HttpGet]
        public async Task<IActionResult> GetIndexImage(Guid imageId)
        {
            var image = await _carSharingRepositories.GetImageById(imageId);

            if (image != null)
            {
                return File(image.DataFile!, image.FileType!); 
            }
            else
            {
                return NotFound();
            }
        }
        [Route("CarSharing/{Id}/Details")]
        public async Task<IActionResult> Details(Guid Id)
        {
            var dto = await _mediator.Send(new GetByIdCarSharingQuery(Id));
            
            return View(dto);
        }
         [HttpGet]
        public async Task<IActionResult> GetDetailsImage(Guid imageId)
        {
            var image = await _carSharingRepositories.GetImageById(imageId);

            if (image != null)
            {
                return File(image.DataFile!, image.FileType!); 
            }
            else
            {
                return NotFound();
            }

        }
            [Route("CarSharing/{Id}/Edit")]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var dto = await _mediator.Send(new GetByIdCarSharingQuery(Id));

            if (!dto.IsEditable)
            {
                return RedirectToAction("NoAccess");
            }

            EditCarSharingCommand command =_mapper.Map<EditCarSharingCommand>(dto);
            return View(command);
        }
        [HttpPost]
        [Route("CarSharing/{Id}/Edit")]
        public async Task<IActionResult> Edit(Guid id, [FromForm] EditCarSharingCommand command)
        {
            command.Id = id;
            if (!ModelState.IsValid)
            {
                return View(command);
            }
           
            await _mediator.Send(command);
            return RedirectToAction("Details", "CarSharing", new { Id = id });
        }
        [HttpPost]
        public async Task<IActionResult>RemoveImageinEdit(Guid imageId)
        {
            await _mediator.Send(new ImageDeleteCommand(imageId));
            return Json(new { success = true });
        }
        [HttpDelete]
        public async Task<IActionResult>Delete(Guid Id)
        {
            await _mediator.Send(new DeleteCarSharingCommand(Id));
            return Json(new { success = true });
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCarSharingCommand command, [FromForm] List<IFormFile> images)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult NoAccess()
        {
            return View();
        }
    }
}
