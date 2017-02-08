class Person {
    constructor(name, age) {
        this._name = name;
        this._age = age
    }
    introduce(){
        console.log(`Hello my name is ${this._name} and i am ${this._age} old`)
    }

    get age(){
        return this._age;
    }
    set age(value){
        this._age=value;
    }

    get name(){
        return this._name;
    }
    set name(value){
        if(typeof (value)!=='string'){
            throw new Error("Invalid name")
        }
        this._name=value
    }
}
var p = new Person("Ivan",28);
p.age=44;
p.introduce();
console.log(p.name)
p.name="Kiro";
console.log(p.name)
p.name=22;
console.log(p.name)



