namespace DamaGame.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

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
    }
}
