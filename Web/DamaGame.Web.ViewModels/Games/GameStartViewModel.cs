namespace DamaGame.Web.ViewModels.Games
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc.Rendering;

    public class GameStartViewModel
    {
        public string SelectedPlayerName { get; set; }

        public virtual IEnumerable<SelectListItem> PlayersSelectList { get; set; }
    }
}
