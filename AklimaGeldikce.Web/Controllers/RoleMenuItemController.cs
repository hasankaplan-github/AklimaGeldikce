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

namespace AklimaGeldikce.Web.Controllers
{
    public class RoleMenuItemController : Controller
    {
        private readonly IRoleMenuItemService roleMenuItemService;
        private readonly IMenuItemService menuItemService;
        private readonly IRoleService roleService;

        public RoleMenuItemController(IRoleMenuItemService roleMenuItemService, IMenuItemService menuItemService, IRoleService roleService)
        {
            this.roleMenuItemService = roleMenuItemService;
            this.roleService = roleService;
            this.menuItemService = menuItemService;
        }

        // GET: RoleMenuItem
        public async Task<IActionResult> Index()
        {
            var roleMenuItems = await this.roleMenuItemService.GetAllAsync();
            foreach (var roleMenuItem in roleMenuItems)
            {
                var menuItem = this.menuItemService.GetById(roleMenuItem.MenuItemId);
                var role = this.roleService.GetById(roleMenuItem.RoleId);
            }
            return View(roleMenuItems);
        }

        // GET: RoleMenuItem/Create
        public async Task<IActionResult> Create()
        {
            ViewData["MenuItemSelectList"] = new SelectList(await this.menuItemService.GetAllAsync(), "Id", "Name");
            ViewData["RoleSelectList"] = new SelectList(await this.roleService.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: RoleMenuItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,MenuItemId")] RoleMenuItem roleMenuItem)
        {
            if (ModelState.IsValid)
            {
                this.roleMenuItemService.Create(roleMenuItem);
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuItemSelectList"] = new SelectList(await this.menuItemService.GetAllAsync(), "Id", "Name", roleMenuItem.MenuItemId);
            ViewData["RoleSelectList"] = new SelectList(await this.roleService.GetAllAsync(), "Id", "Name", roleMenuItem.RoleId);
            return View(roleMenuItem);
        }

        // GET: RoleMenuItem/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleMenuItem = this.roleMenuItemService.GetById(id);
            if (roleMenuItem == null)
            {
                return NotFound();
            }
            ViewData["MenuItemSelectList"] = new SelectList(await this.menuItemService.GetAllAsync(), "Id", "Name", roleMenuItem.MenuItemId);
            ViewData["RoleSelectList"] = new SelectList(await this.roleService.GetAllAsync(), "Id", "Name", roleMenuItem.RoleId);
            return View(roleMenuItem);
        }

        // POST: RoleMenuItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("RoleId,MenuItemId,Id")] RoleMenuItem roleMenuItem)
        {
            if (id != roleMenuItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.roleMenuItemService.Update(roleMenuItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleMenuItemExists(roleMenuItem.Id))
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
            ViewData["MenuItemSelectList"] = new SelectList(await this.menuItemService.GetAllAsync(), "Id", "Name", roleMenuItem.MenuItemId);
            ViewData["RoleSelectList"] = new SelectList(await this.roleService.GetAllAsync(), "Id", "Name", roleMenuItem.RoleId);
            return View(roleMenuItem);
        }

        // GET: RoleMenuItem/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleMenuItem = this.roleMenuItemService.GetById(id);
            if (roleMenuItem == null)
            {
                return NotFound();
            }
            var menuItem = this.menuItemService.GetById(roleMenuItem.MenuItemId);
            var role = this.roleService.GetById(roleMenuItem.RoleId);

            return View(roleMenuItem);
        }

        // POST: RoleMenuItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            this.roleMenuItemService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RoleMenuItemExists(Guid id)
        {
            return this.roleMenuItemService.Exists(e => e.Id == id);
        }
    }
}
