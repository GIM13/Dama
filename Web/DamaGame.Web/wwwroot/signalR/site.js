let connection = null;

setupConnection = () => {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("/allgameshub")
        .build();

    connection.on("AllGames", function (newModel) {
        document.model = this.newModel;
    });

    connection.start()
        .catch(err => console.error(err.toString()));
};

setupConnection();

document.getElementById("startGame").addEventListener("click", e => {
    e.preventDefault();

    const selectedPlayerName = document.getElementById("selectedPlayerName").nodeValue;

    fetch("/Games/NewGame",
        {
            method: "POST",
            body: JSON.stringify({ selectedPlayerName }),
            headers: {
                'content-type': 'application/json'
            }
        })
        .then("/Games/AllGames");
});