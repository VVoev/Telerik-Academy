let isClean = true;

let cleanTheRoom = function (p) {
    return new Promise((resolve,reject)=>{
        if(isClean){
            resolve("Room is Clean");
        }
        else{
            reject("Room is not Clean");
        }
    })
};

let throwTheGarbage = function (p) {
    return new Promise((resolve,reject)=>{
        if(isClean){
            resolve("Gargabe is thrown");
        }
        else{
            reject("Gargabe is not thrown");
        }
    })
};



let letsGoToIceCreamShop = function (p) {
    return new Promise((resolve,reject)=>{
        resolve("Ok Lets go")
        reject("You haven`t done your tasks")
    })
}

cleanTheRoom().then(function (result) {
    return cleanTheRoom(result)
}).then(function (result) {
    console.log(result);
    return throwTheGarbage(result)
}).then(function (result) {
    console.log(result);
    return letsGoToIceCreamShop(result)
}).then(function (result) {
    console.log(`You have finished ${result}`)
})
.catch(function (error) {
    console.log(error)
})