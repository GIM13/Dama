namespace DamaGame.Web.Controllers
{
    using System.Diagnostics;

    using DamaGame.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class BeginningController : BaseController
    {
        public IActionResult Beginning()
        {
            return this.View("Beginning");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
