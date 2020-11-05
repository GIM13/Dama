namespace DamaGame.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PlayersController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
