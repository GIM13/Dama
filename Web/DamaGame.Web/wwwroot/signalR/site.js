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

        //let game = "";



        document.getElementById("game").innerHTML = game;
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