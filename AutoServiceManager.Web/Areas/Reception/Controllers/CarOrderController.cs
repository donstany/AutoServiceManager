using AutoServiceManager.Application.Constants;
using AutoServiceManager.Application.Features.CarOrders.Queries.GetAllCached;
using AutoServiceManager.Application.Features.CarOrders.Queries.GetById;
using AutoServiceManager.Application.Features.Cars.Queries.GetAllCached;
using AutoServiceManager.Web.Abstractions;
using AutoServiceManager.Web.Areas.Reception.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoServiceManager.Web.Areas.Reception.Controllers
{
    [Area("Reception")]
    public class CarOrderController : BaseController<CarOrderController>
    {
        public IActionResult Index()
        {
            var model = new CarOrderViewModel();
            return View(model);
        }

        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllCarOrdersCachedQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<CarOrderViewModel>>(response.Data);
                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }

        [Authorize(Policy = Permissions.Users.View)]
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
            var carsResponse = await _mediator.Send(new GetAllCarsCachedQuery());

            if (id == 0)
            {
                var carOrderViewModel = new CarOrderViewModel();
                if (carsResponse.Succeeded)
                {
                    var carViewModel = _mapper.Map<List<CarViewModel>>(carsResponse.Data);
                    carOrderViewModel.Cars = new SelectList(carViewModel, nameof(CarViewModel.Id), nameof(CarViewModel.Make), null, null);
                }
                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", carOrderViewModel) });
            }
            else
            {
                var response = await _mediator.Send(new GetCarOrderByIdQuery() { Id = id });
                if (response.Succeeded)
                {
                    var carOrderViewModel = _mapper.Map<CarOrderViewModel>(response.Data);
                    if (carsResponse.Succeeded)
                    {
                        var carViewModel = _mapper.Map<List<CarViewModel>>(carsResponse.Data);
                        //TODO add in Make + Color + Plate as label in dropdown
                        carOrderViewModel.Cars = new SelectList(carViewModel, nameof(CarViewModel.Id), nameof(CarViewModel.Make), null, null);
                    }
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", carOrderViewModel) });
                }
                return null;
            }
        }

        //TODO
    }
}