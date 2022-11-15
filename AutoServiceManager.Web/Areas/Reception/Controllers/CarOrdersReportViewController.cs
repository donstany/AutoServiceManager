using System.Collections.Generic;
using System.Threading.Tasks;
using AutoServiceManager.Application.Features.CarOrders.Queries.GetAllCached;
using AutoServiceManager.Domain.Entities.Reception;
using AutoServiceManager.Web.Abstractions;
using AutoServiceManager.Web.Areas.Reception.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoServiceManager.Web.Areas.Reception.Controllers
{
    [Area("Reception")]
    public class CarOrdersReportViewController : BaseController<CarOrdersReportViewController>
    {
        public IActionResult Index()
        {
            var model = new CarOrdersReportView();
            return View(model);
        }

        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllCarOrdersReportViewCachedQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<CarOrdersReportViewModel>>(response.Data);
                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }
    }
}