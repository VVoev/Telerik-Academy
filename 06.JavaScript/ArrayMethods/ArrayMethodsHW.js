//Problem 1
function Person(firstName, lastName, age, gender) {
    if (firstName.length < 2 || typeof firstName != 'string') {
        this.firstName = 'n/a';
    } else {
        this.firstName = firstName;
    }
    if (lastName.length < 2 || typeof lastName != 'string') {
        this.lastName = 'n/a';
    } else {
        this.lastName = lastName;
    }
    if (age <= 0 || age >= 120 || typeof age != 'number') {
        this.age = 'n/a';
    } else {
        this.age = age;
    }
    if (typeof gender !== 'boolean') {
        this.gender = 'n/a';
    } else {
        this.gender = gender;
    }

    this.printPerson = function () {
        console.log('Name: ' + this.firstName + ' ' + this.lastName);
        console.log('Age: ' + this.age);
        console.log('Male: ' + gender);
    }
}

var peopleList = [
    new Person('Batman', 'Batmanov', 25, true),
    new Person('Superman', 'Supermanov', 100, true),
    new Person('Ironman', 'Ironmanov', 40, true),
    new Person('Wonderwoman', 'Wonderwomanova', 25, false),
    new Person('Catwoman', 'Catwomanova', 23, false),
    new Person('Spiderman', 'Spindermanov', 30, true),
    new Person('Ivan', 'Ivanov', 15, true),
    new Person('Maria', 'Markova', 17, false),
    new Person('Minka', 'Minkova', 12, false),
    new Person('Pesho', 'Peshov', 10, true)
];

//Problem 2
Array.prototype.filterOverAge = function (age) {
    var arr =
        this.filter(function (a) {
                return a.age>=age;
        })
    return arr;
};

//Problem 3
Array.prototype.filterUnderaged = function(age){
    var arr =
        this.filter(function (a) {
            return a.age<age;
        })

    return arr;
};

//Problem 4
Array.prototype.avgAgeFemales  = function(){
    var arr =
        this.filter(function (a) {
            return a.gender===false;
        });
    var sum = 0;
    arr.forEach(function(element){
        sum+=element.age;
    })
    var avgAge = sum/arr.length;
    return avgAge;
};

//Problem 5
Array.prototype.findYoungest  = function(){
    var arr =
        this.sort(function (a,b) {
            return a.age- b.age;
        });

    var youngest = arr[0];
    return youngest;
};

//Problem 6
Array.prototype.groupByLetter = function(){
    var arr =
        this.sort(function(a,b){
            return a.firstName.localeCompare(b.firstName);
        });
    var group =[];
    arr.forEach(function(element, index){
        if(group[element.firstName[0].toLowerCase()]){
            group[element.firstName[0].toLowerCase()].push(element);
        }else{
            group[element.firstName[0].toLowerCase()]=[element]
        }
    });
    return group;
};

//Print people
Array.prototype.printPeople = function() {
    this.forEach(function (element, index, array) {
        array[index].printPerson();
        console.log('-----------------');
    });

};

//Test the problems

//Problem 1
peopleList.printPeople();

//Problem 2
var over18 = peopleList.filterOverAge();
over18.printPeople();

//Problem 3
var underaged = peopleList.filterUnderaged();
underaged.printPeople();

//Problem 4
var avgAgeWomen = peopleList.avgAgeFemales();
console.log(avgAgeWomen);

//Problem 5
var youngestPerson = peopleList.findYoungest();
youngestPerson.printPerson();

//Problem 6
var group = peopleList.groupByLetter();
console.log(group);


