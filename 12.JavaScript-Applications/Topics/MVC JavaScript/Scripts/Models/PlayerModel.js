class PlayerModel {
    constructor(baseUrl, appKey, requester, authorizationService) {
        this._baseUrl = baseUrl;
        this._appKey = appKey;
        this._requester = requester;
        this._authorizationService = authorizationService;
    }

    getPlayer(id) {
        let requestUrl = this._baseUrl+"appdata/"+this._appKey+"/table-tennis-players/"+id;
        let requestHeaders = this._authorizationService.getHeaders();

        return this._requester.get(requestUrl,requestHeaders);
    }

    getPlayers() {
        let requestUrl = this._baseUrl+"appdata/"+this._appKey+"/table-tennis-players";
        let requestHeaders = this._authorizationService.getHeaders();

        return this._requester.get(requestUrl,requestHeaders);
    }

    postPlayer(data){
        let requestUrl = this._baseUrl+"appdata/"+this._appKey+"/table-tennis-players";
        let requestHeaders = this._authorizationService.getHeaders();

        return this._requester.post(requestUrl,requestHeaders,data);
    }
}