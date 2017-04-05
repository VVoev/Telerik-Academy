(function () {
    let span = document.getElementById('message');
    span.innerText = 5;


    function redicectPromise() {
        return new Promise((resolve,reject)=>{
            "use strict";
            resolve("Go to other Page");
            reject("Problem with the code");
        })
    }

    function redirect() {
        setTimeout(function () {
            document.location.href = "http://telerikacademy.com/";
        },5000)

    }

    function showError(error) {
        console.log(error)
    }

    setInterval(function () {
        span.innerText -=1;
    },1000)

    redicectPromise()
        .then(redirect)
        .catch(showError)

})();