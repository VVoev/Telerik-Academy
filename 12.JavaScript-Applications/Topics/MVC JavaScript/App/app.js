(function () {
    let baseUrl = "https://bass.kinvey.com/";
    let appKey = "kid_HJ7Mn_m6l";
    let appSecret = "213e413341544445a845f31502d3bd41";

    let requester = new Requester();
    let authentificationService = new AuthenticationService(appKey, appSecret);

    let playerView = new PlayerView();
    let playerModel = new PlayerModel(baseUrl, appKey, requester, authentificationService)
    let playerControler = new PlayerController(playerModel,playerView);

    playerControler.getPlayers();
})()