(function() {
    var promise1, promise2;
    promise1 = new Promise(function (resolve, reject) {
        setTimeout(function () {
            resolve('me first');
        }, 2001);
    });

    promise2 = new Promise(function (resolve, reject) {
        setTimeout(function () {
            resolve("me second");
        }, 2000);
    });

    promise2.then(function (data) {
        console.log(data); // 'one'
    });
    promise1.then(function (data) {
        console.log(data); // 'one'
    });
}());