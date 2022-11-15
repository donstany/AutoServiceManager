using System.Collections.Generic;
using System.Threading.Tasks;
using AutoServiceManager.Application.Features.CarOrders.Queries.GetAllCached;
using AutoServiceManager.Application.Features.CarOrdersView.Queries.GetAllCached;
using AutoServiceManager.Web.Abstractions;
using AutoServiceManager.Web.Areas.Reception.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoServiceManager.Web.Areas.Reception.Controllers
{
    [Area("Reception")]
    [Authorize(Roles = "SuperAdmin, Basic")]
    public class CarOrdersReportViewController : BaseController<CarOrdersReportViewController>
    {
        public IActionResult Index()
        {
            var model = new CarOrdersReportViewModel();
            return View(model);
        }

        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllCarOrdersReportViewCachedQuery());
            if (response.Succeeded)
            {
                List<GetAllCarOrdersReportViewCachedResponse> resp = response.Data;
                var viewModel = _mapper.Map<List<CarOrdersReportViewModel>>(resp);
                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }
    }
}