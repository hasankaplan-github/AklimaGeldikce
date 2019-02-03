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
    public class NotificationController : Controller
    {
        //private readonly AppDbContext _context;
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        /*
        public NotificationController(AppDbContext context)
        {
            _context = context;
        }
        */

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            // var appDbContext = _context.Notification.Include(n => n.To);
            //return View(await appDbContext.ToListAsync());

            string loggedInUserId = Request.Cookies["loggedInUserId"];
            Guid loggedInUserIdGuid = Guid.Parse(loggedInUserId);
            var notifications = await this.notificationService.GetManyAsync(x => x.ToId == loggedInUserIdGuid, x => x.OrderByDescending(y => y.NotificationDate));

            return View(notifications);
        }

        // GET: Notifications/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*
            var notification = await _context.Notification
                .Include(n => n.To)
                .FirstOrDefaultAsync(m => m.Id == id);
                */
            var notification = this.notificationService.GetById(id);
            string loggedInUserId = Request.Cookies["loggedInUserId"];
            Guid loggedInUserIdGuid = Guid.Parse(loggedInUserId);

            if (notification == null || notification.ToId != loggedInUserIdGuid)
            {
                return NotFound();
            }

            return View(notification);
        }

        /*
        // GET: Notifications/Create
        public IActionResult Create()
        {
            ViewData["ToId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Content,IsRead,ToId,NotificationDate,Id,IsDeleted")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                notification.Id = Guid.NewGuid();
                _context.Add(notification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ToId"] = new SelectList(_context.User, "Id", "Id", notification.ToId);
            return View(notification);
        }

        // GET: Notifications/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notification.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            ViewData["ToId"] = new SelectList(_context.User, "Id", "Id", notification.ToId);
            return View(notification);
        }

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Content,IsRead,ToId,NotificationDate,Id,IsDeleted")] Notification notification)
        {
            if (id != notification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationExists(notification.Id))
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
            ViewData["ToId"] = new SelectList(_context.User, "Id", "Id", notification.ToId);
            return View(notification);
        }

        // GET: Notifications/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notification
                .Include(n => n.To)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var notification = await _context.Notification.FindAsync(id);
            _context.Notification.Remove(notification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificationExists(Guid id)
        {
            return _context.Notification.Any(e => e.Id == id);
        }
        */
    }
}
