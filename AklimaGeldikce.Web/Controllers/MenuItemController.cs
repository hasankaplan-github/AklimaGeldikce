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
    public class MenuItemController : Controller
    {
        private readonly IMenuItemService menuItemService;
        private readonly IRoleMenuItemService roleMenuItemService;
        private readonly IRoleService roleService;

        public MenuItemController(IMenuItemService menuItemService, IRoleMenuItemService roleMenuItemService, IRoleService roleService)
        {
            this.menuItemService = menuItemService;
            this.roleMenuItemService = roleMenuItemService;
            this.roleService = roleService;
        }

        // GET: MenuItem
        public async Task<IActionResult> Index()
        {
            var menuItems = await this.menuItemService.GetAllAsync();
            foreach (var menuItem in menuItems)
            {
                var parentMenuItem = this.menuItemService.GetById(menuItem.ParentMenuItemId);
            }
            return View(menuItems);
        }

        // GET: MenuItem/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = this.menuItemService.GetById(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            var parentMenuItem = this.menuItemService.GetById(menuItem.ParentMenuItemId);

            return View(menuItem);
        }

        // GET: MenuItem/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ParentMenuItemSelectList"] = new SelectList(await this.menuItemService.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: MenuItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Controller,Action,ParentMenuItemId,Order")] MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                this.menuItemService.Create(menuItem);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentMenuItemSelectList"] = new SelectList(await this.menuItemService.GetAllAsync(), "Id", "Name", menuItem.ParentMenuItemId);
            return View(menuItem);
        }

        // GET: MenuItem/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = this.menuItemService.GetById(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            ViewData["ParentMenuItemSelectList"] = new SelectList(await this.menuItemService.GetAllAsync(), "Id", "Name", menuItem.ParentMenuItemId);
            return View(menuItem);
        }

        // POST: MenuItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Controller,Action,ParentMenuItemId,Order,Id")] MenuItem menuItem)
        {
            if (id != menuItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.menuItemService.Update(menuItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuItemExists(menuItem.Id))
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
            ViewData["ParentMenuItemSelectList"] = new SelectList(await this.menuItemService.GetAllAsync(), "Id", "Name", menuItem.ParentMenuItemId);
            return View(menuItem);
        }

        // GET: MenuItem/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menuItem = this.menuItemService.GetById(id);
            var parentMenuItem = this.menuItemService.GetById(menuItem.ParentMenuItemId);
            if (menuItem == null)
            {
                return NotFound();
            }

            return View(menuItem);
        }

        // POST: MenuItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            this.menuItemService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool MenuItemExists(Guid id)
        {
            return this.menuItemService.Exists(mi => mi.Id == id);
        }

        // GET: MenuItem
        public async Task<IActionResult> Authorize(Guid id)
        {
            var menuItem = this.menuItemService.GetById(id);
            if (menuItem == null)
            {
                return NotFound();
            }
            var roleMenuItems = await this.roleMenuItemService.GetManyAsync(rmi => rmi.MenuItemId == id);
            foreach (var roleMenuItem in roleMenuItems)
            {
                var role = this.roleService.GetById(roleMenuItem.RoleId);
            }
            ViewBag.RoleSelectList = new SelectList(await this.roleService.GetAllAsync(), "Id", "Name");
            return View(menuItem);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(Guid menuItemId, Guid roleId)
        {
            var roleMenuItem = this.roleMenuItemService.Get(rmi => rmi.RoleId == roleId && rmi.MenuItemId == menuItemId);
            if (roleMenuItem == null)
            {
                roleMenuItem = new RoleMenuItem { MenuItemId = menuItemId, RoleId = roleId };
                this.roleMenuItemService.Create(roleMenuItem);
            }
            else
            {
                return Json(null);
            }

            var roleMenuItems = await this.roleMenuItemService.GetManyAsync(ru => ru.MenuItemId == menuItemId);
            string roleNames = "";
            foreach (var _roleMenuItem in roleMenuItems)
            {
                var role = this.roleService.GetById(_roleMenuItem.RoleId);
                roleNames += role.Name + ",";
            }

            //JsonResult jsonResult = role == null ? Json(null) : Json(new { RoleName = role.Name });
            return Json(new { RoleNames = roleNames });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(Guid menuItemId, Guid roleId)
        {
            var roleMenuItem = this.roleMenuItemService.Get(ru => ru.RoleId == roleId && ru.MenuItemId == menuItemId);
            if (roleMenuItem == null)
            {
                return Json(null);
            }
            this.roleMenuItemService.Delete(roleMenuItem);

            var roleMenuItems = await this.roleMenuItemService.GetManyAsync(ru => ru.MenuItemId == menuItemId);
            string roleNames = "";
            foreach (var _roleMenuItem in roleMenuItems)
            {
                var role = this.roleService.GetById(_roleMenuItem.RoleId);
                roleNames += role.Name + ",";
            }

            //JsonResult jsonResult = role == null ? Json(null) : Json(new { RoleName = role.Name });
            return Json(new { RoleNames = roleNames });
        }
    }
}
