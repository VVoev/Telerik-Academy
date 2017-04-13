let x = function () {
    console.log("I am called from outside the function")
}
let y = function (callback) {
    console.log("do smth");
    callback();
}

y(x);



let add = function (a,b) {
    return a+b;
};

let multi = function (a,b) {
    return a*b;
};

let calc = function (num1,num2,callback) {
    return callback(num1,num2)
};

// console.log(calc(5,3,add))

let items = [{num:1,fruit:"Apple"},{num:2,fruit:"Orange"},{num:3,fruit:"Grape"}];
let sorted = items.sort(function (item1,item2) {
    if(item1.num<item2.num){
        return 1;
    }
    else{
        return -1;
    }
});

let academy = {
    name:"Telerik",
    number:1,
    students:{
        id1:[{name:"Vlado",FAK:2023067},{name:"Kiro",FAK:8050601},{name:"Cveko",FAK:1234567}],
        bestStudents:[{students:[
            {
                bestTrainer:[{
                    name:"Kenov",
                    car:"BMW"
                }]
            }
        ]}]

    }
}

//Convert to JSON
let jsonAcademy = JSON.stringify(academy);
//Convert TO JavaS
let script = JSON.parse(jsonAcademy)

console.log(academy.students.id1[2].name)
let trainer = academy.students.bestStudents[0].students[0].bestTrainer[0];
trainer.car = "Audi"
console.log(trainer);
trainer['car'] = 'BMW';
console.log(trainer);









