(function () {
    let baseUrl = "https://bass.kinvey.com/";
    let appKey = "kid_BkZElJp6x";
    let appSecret = "f28b29d97c554c13ac9e3e9341b1b809";

    let requester = new Requester();
    let authentificationService = new AuthenticationService(appKey, appSecret);

    let playerView = new PlayerView();
    let playerModel = new PlayerModel(baseUrl, appKey, requester, authentificationService)
    let playerControler = new PlayerController(playerModel,playerView);

    playerControler.getPlayers();
})()