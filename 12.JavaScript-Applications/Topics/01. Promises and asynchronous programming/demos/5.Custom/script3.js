let p1 = new Promise(
    function(resolve, reject) {
        console.log("task1 started.");
        setTimeout(function() {
            resolve("task1 result");
            console.log("task1 finished.");
        }, 1000);
    }
);


let p2 = new Promise(
    function(resolve, reject) {
        console.log("task2 started.");
        setTimeout(function() {
            resolve("task2 result");
            console.log("task2 finished.");
        }, 1500);
    }
);

