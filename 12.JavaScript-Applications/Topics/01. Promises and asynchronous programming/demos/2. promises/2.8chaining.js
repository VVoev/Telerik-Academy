let counter = 0 ;
let time = 1000;
let counterProm = function () {
    return new Promise((resolve,reject)=>{
        setTimeout(()=>{
            if(counter>4){
                reject(console.log("Condition Failed"));
            }
            else{
                console.log(`promise number ${++counter} resolved for ${time}seconds`)
                 resolve();
            }

        },time)
    })
}

counterProm().then(function () {
    return counterProm()
}).then(function () {
    return counterProm()
}).then(function () {
    return counterProm()
}).then(function () {
    return counterProm()
}).then(function () {
    return counterProm()
}).then(function () {
    return counterProm()
}).then(function () {
    return counterProm()
}
).catch(function () {
    console.log("Finish")
})


// // Given async function sayHi
// function sayHi() {
//     return new Promise((resolve) => {
//         setTimeout(() => {
//             console.log('Hi');
//             resolve();
//         }, 3000);
//     });
// }
//
// // And an array of async functions to loop through
// const asyncArray = [sayHi, sayHi, sayHi];
//
// // We create the start of a promise chain
// let chain = Promise.resolve();
//
// // And append each function in the array to the promise chain
// for (const func of asyncArray) {
//     chain = chain.then(func);
// }
//
// // Output:
// // Hi
// // Hi (After 3 seconds)
// // Hi (After 3 more seconds)



