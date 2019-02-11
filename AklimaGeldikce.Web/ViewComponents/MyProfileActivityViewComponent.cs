using AklimaGeldikce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AklimaGeldikce.Web.ViewComponents
{
    public class MyProfileActivityViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            MyProfileActivityViewModel myProfileActivityViewModel = new MyProfileActivityViewModel();
            return View("Default_AdminLte", myProfileActivityViewModel);
        }
    }
}
