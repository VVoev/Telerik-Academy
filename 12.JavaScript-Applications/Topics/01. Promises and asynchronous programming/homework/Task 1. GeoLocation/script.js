(function () {
    let locationElement = document.getElementById("location");
    let link = document.createElement('a');

    function getGeolocationPositionPromise() {
        return new Promise((resolve, reject) => {
            navigator.geolocation.getCurrentPosition(
                (position) => {resolve(position)},
                (error) => {reject(error)});
        });
    }

    function parseCordinates(cordinates) {
        let cordinatesDetails = cordinates.coords;
        let latitude = cordinatesDetails.latitude;
        let longitude = cordinatesDetails.longitude;
        return {lat: latitude, long: longitude};
    }

    function makeLink(details) {
        let href = "http://maps.googleapis.com/maps/api/staticmap?center=" + details.lat + "," + details.long + "&zoom=13&size=500x500&sensor=false";
        link.href = href;
        return href;
    }

    function showError(error) {
        console.log(error)
    }

    function autoLoad(href) {
        setTimeout(function () {
            document.location.href = href;
        },5000)
    }

    getGeolocationPositionPromise()
        .then(parseCordinates)
        .then(makeLink)
        .then(autoLoad)
        .catch(showError)

    link.innerText = "click here to see your location";
    locationElement.appendChild(link);
}());