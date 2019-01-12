using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AklimaGeldikce.DbContext;
using AklimaGeldikce.Entities;
using AklimaGeldikce.Web.Models;
using AklimaGeldikce.Services;
using Microsoft.AspNetCore.Http;

namespace AklimaGeldikce.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleUserService roleUserService;
        private readonly IRoleService roleService;
        private readonly IMenuItemService menuItemService;

        public AccountController(IUserService userService, IRoleUserService roleUserService, IRoleService roleService, IMenuItemService menuItemService)
        {
            this.userService = userService;
            this.roleUserService = roleUserService;
            this.roleService = roleService;
            this.menuItemService = menuItemService;
        }

        // GET: Account
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl="")
        {
            User user = this.userService.Get(u => u.Username == loginViewModel.Username && u.Password == loginViewModel.Password);
            if (user != null)
            {
                var roleUsers = await this.roleUserService.GetManyAsync(ru => ru.UserId == user.Id);
                string roleNames = "";
                IList<Role> roles = new List<Role>(roleUsers.Count);
                foreach (var roleUser in roleUsers)
                {
                    var role = this.roleService.GetById(roleUser.RoleId);
                    roleNames += role.Name + ",";
                    roles.Add(role);
                }
                roleNames = roleNames.TrimEnd(',');

                user.IsLoggedIn = true;
                user.LastLoginDate = DateTime.Now;
                this.userService.Update(user);

                Response.Cookies.Append("loggedInUserId", user.Id.ToString());
                Response.Cookies.Append("loggedInRoleNames", roleNames);
                Response.Cookies.Append("dynamicNavbar", await this.menuItemService.GetNavbarHtmlAsync(null, roles, false));
                //return RedirectToAction("ProductList", "Product");
                if (string.IsNullOrEmpty(returnUrl) == false)
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            string loggedInUserId = Request.Cookies["loggedInUserId"];
            User user = this.userService.GetById(Guid.Parse(loggedInUserId));
            if(user!=null)
            {
                user.IsLoggedIn = false;
                user.LastLogoutDate = DateTime.Now;
                this.userService.Update(user);
            }

            Response.Cookies.Append("loggedInUserId", Guid.Empty.ToString());
            Response.Cookies.Append("loggedInRoleNames", "Guest");
            Response.Cookies.Append("dynamicNavbar", "");

            return RedirectToAction("Index", "Home");
        }


        // GET: Account/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User user = this.userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("FirstName,SecondName,Username,Password,Email")] User newUser)
        {
            if(ModelState.IsValid)
            {
                var user = this.userService.Register(newUser, "User");
                if (user == null)
                {
                    // error.
                    return View(newUser);
                }

                LoginViewModel loginViewModel = new LoginViewModel() { Username = user.Username, Password = user.Password };
                return await Login(loginViewModel);
            }
            return View(newUser);
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.userService.GetAllAsync(1, 10));
        }

        // GET: Account/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,SecondName,Username,Password,Email,Id")] User user)
        {
            if (ModelState.IsValid)
            {
                this.userService.Create(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Account/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = this.userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FirstName,SecondName,Username,Password,Email,IsLoggedIn,LastLoginDate,LastLogoutDate,Id,IsDeleted")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.userService.Update(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Account/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = this.userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            this.userService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(Guid id)
        {
            return this.userService.Exists(u => u.Id == id);
        }

        // GET: Account
        public async Task<IActionResult> Authorize(Guid id)
        {
            var user = this.userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            var roleUsers = await this.roleUserService.GetManyAsync(ru => ru.UserId == id);
            foreach (var roleUser in roleUsers)
            {
                var role = this.roleService.GetById(roleUser.RoleId);
            }
            ViewBag.RoleSelectList = new SelectList(await this.roleService.GetAllAsync(), "Id", "Name");
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(Guid userId, Guid roleId)
        {
            RoleUser roleUser = this.roleUserService.Get(ru => ru.RoleId == roleId && ru.UserId == userId);
            if(roleUser==null)
            {
                roleUser = new RoleUser { UserId = userId, RoleId = roleId };
                this.roleUserService.Create(roleUser);
            }
            else
            {
                return Json(null);
            }

            var roleUsers = await this.roleUserService.GetManyAsync(ru => ru.UserId == userId);
            string roleNames = "";
            foreach (var _roleUser in roleUsers)
            {
                var role = this.roleService.GetById(_roleUser.RoleId);
                roleNames += role.Name + ",";
            }

            //JsonResult jsonResult = role == null ? Json(null) : Json(new { RoleName = role.Name });
            return Json(new { RoleNames = roleNames });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(Guid userId, Guid roleId)
        {
            RoleUser roleUser = this.roleUserService.Get(ru => ru.RoleId == roleId && ru.UserId == userId);
            if (roleUser == null)
            {
                return Json(null);
            }
            this.roleUserService.Delete(roleUser);

            var roleUsers = await this.roleUserService.GetManyAsync(ru => ru.UserId == userId);
            string roleNames = "";
            foreach (var _roleUser in roleUsers)
            {
                var role = this.roleService.GetById(_roleUser.RoleId);
                roleNames += role.Name + ",";
            }

            //JsonResult jsonResult = role == null ? Json(null) : Json(new { RoleName = role.Name });
            return Json(new { RoleNames = roleNames });
        }


    }
}
