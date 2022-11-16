using AutoServiceManager.Application.Enums;
using AutoServiceManager.Application.Features.CarOrders.Commands.Create;
using AutoServiceManager.Application.Features.CarOrders.Commands.Delete;
using AutoServiceManager.Application.Features.CarOrders.Commands.Update;
using AutoServiceManager.Application.Features.CarOrders.Queries.GetAllCached;
using AutoServiceManager.Application.Features.CarOrders.Queries.GetById;
using AutoServiceManager.Application.Features.Cars.Queries.GetAllCached;
using AutoServiceManager.Application.Interfaces.Shared;
using AutoServiceManager.Infrastructure.Identity.Models;
using AutoServiceManager.Web.Abstractions;
using AutoServiceManager.Web.Areas.Reception.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoServiceManager.Web.Areas.Reception.Controllers
{
    [Area("Reception")]
    public class CarOrderController : BaseController<CarOrderController>
    {
        private readonly IAuthenticatedUserService _userService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public CarOrderController(IAuthenticatedUserService userService, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var model = new CarOrderViewModel();
            return View(model);
        }

        public async Task<IActionResult> LoadAll()
        {
            var tupleUserRole = await GetCurrentUserAndRole(_userService, _userManager);

            var response = await _mediator.Send(new GetAllCarOrdersCachedQuery() { UserId = tupleUserRole.CurrentUserId, RoleName = tupleUserRole.CurrentRoleName });
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<CarOrderViewModel>>(response.Data);
                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }

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
                        carOrderViewModel.Cars = new SelectList(carViewModel, nameof(CarViewModel.Id), nameof(CarViewModel.Make), null, null);
                    }
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", carOrderViewModel) });
                }
                return null;
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, CarOrderViewModel carOrder)
        {
            if (ModelState.IsValid)
            {
                var tupleUserRole = await GetCurrentUserAndRole(_userService, _userManager);

                if (id == 0)
                {
                    var createCarOrderCommand = _mapper.Map<CreateCarOrderCommand>(carOrder);
                    createCarOrderCommand.RoleName = tupleUserRole.CurrentRoleName;
                    createCarOrderCommand.UserId = tupleUserRole.CurrentUserId;

                    var result = await _mediator.Send(createCarOrderCommand);
                    if (result.Succeeded)
                    {
                        id = result.Data;
                        _notify.Success($"CarOrder with ID {result.Data} Created.");
                    }
                    else _notify.Error(result.Message);
                }
                else
                {
                    var updateCarOrderCommand = _mapper.Map<UpdateCarOrderCommand>(carOrder);
                    updateCarOrderCommand.RoleName = tupleUserRole.CurrentRoleName;
                    updateCarOrderCommand.UserId = tupleUserRole.CurrentUserId;

                    var result = await _mediator.Send(updateCarOrderCommand);
                    if (result.Succeeded) _notify.Information($"CarOrder with ID {result.Data} Updated.");
                }

                var response = await _mediator.Send(new GetAllCarOrdersCachedQuery() { UserId = tupleUserRole.CurrentUserId, RoleName = tupleUserRole.CurrentRoleName });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<CarOrderViewModel>>(response.Data);
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
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", carOrder);
                return new JsonResult(new { isValid = false, html = html });
            }
        }

        [HttpPost]
        public async Task<JsonResult> OnPostDelete(int id)
        {
            var tupleUserRole = await GetCurrentUserAndRole(_userService, _userManager);

            var deleteCommand = await _mediator.Send(new DeleteCarOrderCommand { Id = id, UserId = tupleUserRole.CurrentUserId, RoleName = tupleUserRole.CurrentRoleName });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Product with Id {id} Deleted.");
                var response = await _mediator.Send(new GetAllCarOrdersCachedQuery() { UserId = tupleUserRole.CurrentUserId, RoleName = tupleUserRole.CurrentRoleName });
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<CarOrderViewModel>>(response.Data);
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

        private async Task<(string CurrentUserId, string CurrentRoleName)> GetCurrentUserAndRole(IAuthenticatedUserService userService, UserManager<ApplicationUser> userManager)
        {
            var currentUserId = _userService.UserId;
            var currentRoleName = Roles.Basic.ToString();

            var user = await _userManager.FindByIdAsync(currentUserId);
            if (await _userManager.IsInRoleAsync(user, Roles.SuperAdmin.ToString()))
            {
                currentRoleName = Roles.SuperAdmin.ToString();
            }
            return (currentUserId, currentRoleName);
        }
    }
}