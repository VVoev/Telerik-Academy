
const KinveyRequester = (function () {
    const baseUrl = "https://baas.kinvey.com/";
    const appKey = "kid_HJ7Mn_m6l";
    const appSecret = "213e413341544445a845f31502d3bd41";
    const kinveyAppAuthHeaders = {
        'Authorization': "Basic " + btoa(appKey + ":" + appSecret),
    };

    function loginUser(username, password) {
        return $.ajax({
            method: "POST",
            url: baseUrl + "user/" + appKey + "/login",
            headers: kinveyAppAuthHeaders,
            data: {username, password}
        });
    }

    function registerUser(username, password) {
        return $.ajax({
            method: "POST",
            url: baseUrl + "user/" + appKey + "/",
            headers: kinveyAppAuthHeaders,
            data: {username, password}
        });
    }

    function getKinveyUserAuthHeaders() {
        return {
            'Authorization': "Kinvey " + sessionStorage.getItem('authToken'),
        };
    }

    function logoutUser() {
        return $.ajax({
            method: "POST",
            url: baseUrl + "user/" + appKey + "/_logout",
            headers: getKinveyUserAuthHeaders(),
        });
    }

    function findAllPlayers() {
        return $.ajax({
            method: "GET",
            url: baseUrl + "appdata/" + appKey + "/table-tennis-players",
            headers: getKinveyUserAuthHeaders()
        });
    }

    function findPlayerById(playerId) {
        return $.ajax({
            method: "GET",
            url: baseUrl + "appdata/" + appKey + "/table-tennis-players/" + playerId,
            headers: getKinveyUserAuthHeaders()
        });
    }

    function createPlayer(name, blade, rubbers,rating) {
        return $.ajax({
            method: "POST",
            url: baseUrl + "appdata/" + appKey + "/table-tennis-players",
            headers: getKinveyUserAuthHeaders(),
            data: {name, blade, rubbers,rating}
        });
    }

    function editPlayer(playerId, name, blade, rubbers,rating) {
        return $.ajax({
            method: "PUT",
            url: baseUrl + "appdata/" + appKey + "/table-tennis-players/" + playerId,
            headers: getKinveyUserAuthHeaders(),
            data: {name, blade, rubbers,rating}
        });
    }

    function deletePlayer(playerId) {
        return $.ajax({
            method: "DELETE",
            url: baseUrl + "appdata/" + appKey + "/table-tennis-players/" + playerId,
            headers: getKinveyUserAuthHeaders()
        });
    }

    return {
        loginUser, registerUser, logoutUser,
        findAllPlayers, createPlayer, findPlayerById, editPlayer, deletePlayer
    }
})();

