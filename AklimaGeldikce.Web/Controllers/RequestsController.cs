using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AklimaGeldikce.DbContext;
using AklimaGeldikce.Entities;
using AklimaGeldikce.Services;
using AklimaGeldikce.Web.ActionFilterAttributes;

namespace AklimaGeldikce.Web.Controllers
{
    [AuthorizeActionFilter]
    public class RequestsController : Controller
    {
        private readonly IRequestService requestService;
        private readonly IRoleRequestService roleRequestService;
        private readonly IRoleService roleService;

        public RequestsController(IRequestService requestService, IRoleRequestService roleRequestService, IRoleService roleService)
        {
            this.requestService = requestService;
            this.roleRequestService = roleRequestService;
            this.roleService = roleService;
        }

        // GET: Requests
        public async Task<IActionResult> Index()
        {
            return View(await this.requestService.GetAllAsync());
        }

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = this.requestService.GetById(id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Requests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Controller,Action")] Request request)
        {
            if (ModelState.IsValid)
            {
                this.requestService.Create(request);
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = this.requestService.GetById(id);
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Controller,Action,Id")] Request request)
        {
            if (id != request.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.requestService.Update(request);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = this.requestService.GetById(id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var request = this.requestService.GetById(id);
            this.requestService.Delete(request);
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(Guid id)
        {
            return this.requestService.Exists(e => e.Id == id);
        }

        public async Task<IActionResult> Authorize(Guid id)
        {
            var request = this.requestService.GetById(id);
            if (request == null)
            {
                return NotFound();
            }
            var roleRequests = await this.roleRequestService.GetManyAsync(rr => rr.RequestId == id);
            foreach (var roleRequest in roleRequests)
            {
                var role = this.roleService.GetById(roleRequest.RoleId);
            }
            ViewBag.RoleSelectList = new SelectList(await this.roleService.GetAllAsync(), "Id", "Name");
            return View(request);
        }

        [HttpPost]
        public async Task<JsonResult> AddRole(Guid requestId, Guid roleId)
        {
            var roleRequest = this.roleRequestService.Get(ru => ru.RoleId == roleId && ru.RequestId == requestId);
            if (roleRequest == null)
            {
                roleRequest = new RoleRequest { RequestId = requestId, RoleId = roleId };
                this.roleRequestService.Create(roleRequest);
            }
            else
            {
                return Json(null);
            }

            var roleRequests = await this.roleRequestService.GetManyAsync(ru => ru.RequestId == requestId);
            string roleNames = "";
            foreach (var _roleRequest in roleRequests)
            {
                var role = this.roleService.GetById(_roleRequest.RoleId);
                roleNames += role.Name + ",";
            }

            //JsonResult jsonResult = role == null ? Json(null) : Json(new { RoleName = role.Name });
            return Json(new { RoleNames = roleNames });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(Guid requestId, Guid roleId)
        {
            var roleRequest = this.roleRequestService.Get(ru => ru.RoleId == roleId && ru.RequestId == requestId);
            if (roleRequest == null)
            {
                return Json(null);
            }
            this.roleRequestService.Delete(roleRequest);

            var roleRequests = await this.roleRequestService.GetManyAsync(ru => ru.RequestId == requestId);
            string roleNames = "";
            foreach (var _roleRequest in roleRequests)
            {
                var role = this.roleService.GetById(_roleRequest.RoleId);
                roleNames += role.Name + ",";
            }

            //JsonResult jsonResult = role == null ? Json(null) : Json(new { RoleName = role.Name });
            return Json(new { RoleNames = roleNames });
        }

    }
}
