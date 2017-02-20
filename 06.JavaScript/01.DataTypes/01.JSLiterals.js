var nan = NaN;
var undef = undefined;
var text = 'Test text';
var int = 2;
var float = 2.0;
var bool = true;
var array = [1,2,'az',true];//Soooo smooth :D
var object = {name:'Pesho', age:20, male:true};
console.log(object.name);
testFn(object.name);

function testFn(name){
    console.log('My name is '+ name);
}