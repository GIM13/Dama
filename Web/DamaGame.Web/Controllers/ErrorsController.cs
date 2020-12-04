namespace DamaGame.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ErrorsController : BaseController
    {
        public IActionResult RemovePlayerError()
        {
            return this.View();
        }

        public IActionResult AddPlayerError()
        {
            return this.View();
        }

        public IActionResult ReserveColorError()
        {
            return this.View();
        }
    }
}
