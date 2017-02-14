getId = (function () {
    let counter = 0;
    return function (x) {
        counter += 1;
        return counter;
    }
})();



class Animal{
    constructor(name,age){
        this.name = name;
        this.age = age;
        this._id = getId();
    }
}
class Cat extends Animal{
    constructor(name,age,breed){
        super(name,age);
        this.breed = breed;
    }
}

class Dog extends Animal{
    constructor(name,age,canBite){
        super(name,age);
        this.canBite = canBite;
    }
}

class Zoo{
    constructor(name){
        this.name = name;
        this.animals = [];
    }

    addAnimal(animal){
        this.animals.push(animal);
        return this;
    }

    removeAnimal(animal){
        this.animals.pop(animal);
        return this;
    }

    findById(id){
        return this.animals.filter(a =>a._id>id);
    }
}
var cat = new Cat("Djingal",1,"Street Cat");
var dog = new Dog("Petar",2,true);
var zoo = new Zoo("Stolichna");
zoo.addAnimal(cat);
zoo.addAnimal(dog);
console.log(zoo);

console.log(zoo.findById(0))



