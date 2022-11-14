using AutoServiceManager.Domain.Entities.Reception;
using AutoServiceManager.Web.Abstractions;
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
    }
}