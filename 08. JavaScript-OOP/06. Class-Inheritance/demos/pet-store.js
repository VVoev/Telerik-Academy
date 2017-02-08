const petStore = (function () {

    class Animal{
        constructor(name,age,sound){
            this._name=name;
            this._age=age;
            this._sound=sound;
        }

        get name(){return this._name;}
        set name(value){
            if(typeof(value)!=='string' || value.length<2){
                throw new Error("Name must be a string value and at least 2 symbols")
            }
            this._name=value;
        }

        get age(){return this._age;}
        set age(value){
            if(value<0){
                throw new Error("Age cannot be negative number")
            }
            this._age=value;
        }

        get sound(){return this._sound;}
        set sound(value){
            if(typeof(value)!=='string'){
                throw new Error('Sound should be a string')
            }
            this._sound=value;
        }

        makeSound(){
            console.log(this.sound);
        }
        toString(){
            return `${this.name} is ${this.age} years old `
        }
    }

    class Cat extends  Animal{
        constructor(name,age,color){
            super(name,age,'mew')
            this.color=color;
        }
        toString(){
            return `${super.toString()} ${this.color}`
        }
    }

    class MythicalHydra extends  Animal{
        constructor(name,age,headCount){
            super(name,age,"Raaaaaa");
            if(headCount<2){
                throw new Error('Hydra should have at least 2 heads')
            }
            this._headcount=headCount;

        }

        get headCount(){return this._headcount;}
        growHead(){
            this._headcount+=1;
            this.makeSound()
        }

        toString(){
            return `${super.toString()} and its a mythic hydra with ${this.headCount} heads!`
        }

    }

    class Dog extends Animal{
        constructor(name,age,owner,iq){
            super(name,age,'Bafffff');
            if(owner===undefined){
                owner='street dog';
            }
            this._owner = owner;
            if(iq<0){
                throw new Error('Cannot put a negative IQ for a dog');
            }
            this._iq=iq;
        }

        get iq(){return this._iq};
        get owner(){return this._owner;}
        set owner(value){
            this._owner=value;
        }

        toString(){
            var noOwnerMaybe =this._owner=="street dog" ? "":"with owner";
            return `${super.toString()} ${noOwnerMaybe} ${this.owner} and its quite smart with IQ ${this.iq}`
        }
    }

    class Bird extends Animal{
        constructor(name,age,canFly){
            super(name,age,"peow")
            this._name=name;
            this._age=age;
            this._canFly= canFly;
        }
        get CanFly(){return this._canFly;}
        set CanFly(value){
            this._canFly=value;
        }

        toString(){
            return `${super.toString()} and cannot fly and like to ${this.sound} ${this.sound}`
        }
    }

    return {
        getCat: function(name, age, color) {
            return new Cat(name, age, color);
        },
        getHydra: function(name, age, headsCount) {
            return new MythicalHydra(name, age, headsCount);
        },
        getDog: function (name,age,owner,iq) {
            return new Dog(name,age,owner,iq);
        },
        getBird: function (name,age,canFly) {
            return new Bird("Tweety",2,canFly)
        }
    };

} ());
let djingal = petStore.getCat("Djingal",1,"Oranjev");
let lamyataSpaska = petStore.getHydra("Spas",134,2);
let kucho = petStore.getDog("m",3,undefined,1);
let bird = petStore.getBird("Tweerty",4,false)

djingal.makeSound();
console.log(djingal.toString());

lamyataSpaska.makeSound();
console.log(lamyataSpaska.toString())

kucho.makeSound();
console.log(kucho.toString())

bird.makeSound();
console.log(bird.toString())



