
/* GET
 https://baas.kinvey.com/appdata/kid_HJ7Mn_m6l/table-tennis-players
 
 Post
 
 Put
 
 Delete
 
 
 */

(function loadStatistics() {
    let url = "https://baas.kinvey.com/appdata/kid_HJ7Mn_m6l/table-tennis-players";
    let getRequest = {
        method:'GET',
        url:url,
        authorization:"Basic Z3Vlc3Q6Z3Vlc3Q="
    }
    $.get(getRequest)
        .then(loadData)
        .catch(displayError);


    function loadData(data) {
        console.log(data)
    }

    function displayError(error) {
        console.log(error)
    }
}());
