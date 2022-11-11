using AutoServiceManager.Application.Features.Cars.Commands.Create;
using AutoServiceManager.Application.Features.Cars.Commands.Delete;
using AutoServiceManager.Application.Features.Cars.Commands.Update;
using AutoServiceManager.Application.Features.Cars.Queries.GetAllCached;
using AutoServiceManager.Application.Features.Cars.Queries.GetById;
using AutoServiceManager.Web.Abstractions;
using AutoServiceManager.Web.Areas.Reception.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoServiceManager.Web.Areas.Reception.Controllers
{
    [Area("Reception")]
    public class CarController : BaseController<CarController>
    {
        public IActionResult Index()
        {
            var model = new CarViewModel();
            return View(model);
        }

        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllCarsCachedQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<CarViewModel>>(response.Data);
                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }

        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            var carsResponse = await _mediator.Send(new GetAllCarsCachedQuery());

            if (id == 0)
            {
                var carViewModel = new CarViewModel();
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", carViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetCarByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var carViewModel = _mapper.Map<CarViewModel>(response.Data);
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", carViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, CarViewModel car)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    var createCarCommand = _mapper.Map<CreateCarCommand>(car);
                    var result = await _mediator.Send(createCarCommand);
                    if (result.Succeeded)
                    {
                        id = result.Data;
                        _notify.Success($"Car with ID {result.Data} Created.");
                    }
                    else _notify.Error(result.Message);
                }
                else
                {
                    var updateCarCommand = _mapper.Map<UpdateCarCommand>(car);
                    var result = await _mediator.Send(updateCarCommand);
                    if (result.Succeeded) _notify.Information($"Car with ID {result.Data} Updated.");
                }
                var response = await _mediator.Send(new GetAllCarsCachedQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<CarViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                {
                    _notify.Error(response.Message);
                    return null;
                }
            }
            else
            {
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", car);
                return new JsonResult(new { isValid = false, html = html });
            }
        }


        [HttpPost]
        public async Task<JsonResult> OnPostDelete(int id)
        {
            var deleteCommand = await _mediator.Send(new DeleteCarCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Car with Id {id} Deleted.");
                var response = await _mediator.Send(new GetAllCarsCachedQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<CarViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                {
                    _notify.Error(response.Message);
                    return null;
                }
            }
            else
            {
                _notify.Error(deleteCommand.Message);
                return null;
            }
        }
    }
}
