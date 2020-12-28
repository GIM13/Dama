let connection = null;

setupConnection = () => {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("/allgameshub")
        .build();

    connection.on("AllGames", function (newModel) {

        let newAllGames = "";

        if (newModel.waitinPlayer != null) {
            newAllGames = `<h6 class="text-md-center">Player-${newModel.waitinPlayer.name}  = VS =  Waiting for a new player</h6>
        <br/>`
        }

        newModel.games.forEach(x => newAllGames +=
            `<a class="text-white" asp-area="" asp-controller="Games" asp-action="Game">Player-${x.leftPlayer.name}  = VS =  Player-${x.rightPlayer.name}</a>
        <br/>`);

        document.getElementById("allGames").innerHTML = newAllGames;
    });

    connection.on("Game", function (game) {

        let gameText = "";

        gameText = `<h1 class="card-title text-center text-primary"> ${game.LeftPlayer.Name}    &    ${game.RightPlayer.Name}</h1>`

        let positions = game.Playground.Positions.ToList();

        gameText +=
            `<div class="row-cols-1">
            <a id="A1" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "A1").Name}</a>

            <a id="A4" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "A4").Name}</a>

            <a id="A8" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "A8").Name}</a>
        </div>
        <div class="row-cols-1">
            <a id="B2" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "B2").Name}</a>

            <a id="B4" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "B4").Name}</a>

            <a id="B7" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "B7").Name}</a>
        </div>
        <div class="row-cols-1">
            <a id="C3" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "C3").Name}</a>

            <a id="C4" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "C4").Name}</a>

            <a id="C6" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "C6").Name}</a>
        </div>
        <div class="row-cols-1">
            <a id="D1" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "D1").Name}</a>

            <a id="D2" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "D2").Name}</a>

            <a id="D3" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "D3").Name}</a>
            <a id="E6" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "E6").Name}</a>

            <a id="E7" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "E7").Name}</a>

            <a id="E8" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "E8").Name}</a>
        </div>
        <div class="row-cols-1">
            <a id="F3" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "F3").Name}</a>

            <a id="F5" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "F5").Name}</a>

            <a id="F6" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "F6").Name}</a>
        </div>
        <div class="row-cols-1">
            <a id="G2" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "G2").Name}</a>

            <a id="G5" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "G5").Name}</a>

            <a id="G7" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "G7").Name}</a>
        </div>
        <div class="row-cols-1">
            <a id="H1" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "H1").Name}</a>

            <a id="H5" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "H5").Name}</a>

            <a id="H8" class="btn btn-primary" asp-controller="Players" asp-action="AddPlayer">${positions.Find(x => x.Name == "H8").Name}</a>
        </div>`;


        document.getElementById("game").innerHTML = gameText;
    });

    connection.start()
        .catch(err => console.error(err.toString()));
};

setupConnection();

document.getElementById("startGame").addEventListener("click", e => {
    //e.preventDefault();
    //const selectedPlayerName = document.getElementById("selectedPlayerName").value;

    //fetch("/Games/NewGameAsync",
    //    {
    //        method: "POST",
    //        body: JSON.stringify({ selectedPlayerName }),
    //        headers: {
    //            'content-type': 'application/json'
    //        }
    //    });
    connection.invoke("AllGamesRefreshAsync");
    connection.invoke("NewGameAsync");
});