class AuthenticationService {
    constructor(appKey, appSecret) {
        this._appKey = appKey;
        this._appSecret = appSecret;
    }

    isLoggedIn() {
        return sessionStorage.getItem("authToken");
    }

    getHeaders() {

        let headers = {
            "contentType": "application/json"
        };

        if (this.isLoggedIn()) {
            headers["Authorization"] = "Basic " + this.isLoggedIn();
        } else {
            headers["Authorization"] = "Basic " + btoa(this._appKey + ":" + this._appSecret);
        }

        return headers;
    }
}