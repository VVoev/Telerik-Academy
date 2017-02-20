var nan = NaN;
var undef = undefined;
var text = 'Test text';
var int = 2;
var float = 2.0;
var bool = true;
var array = [1, 2, 'az', true];//Soooo smooth :D
var object = {name: 'Pesho', age: 20, male: true};
//console.log(object.name);
testFn(object.name);
function testFn(name) {
    //console.log('My name is '+ name);
}


console.log('var nan: ' + typeof nan);
console.log('var undef: ' + typeof undef);
console.log('var text: ' + typeof text);
console.log('var int: ' + typeof int);
console.log('var float: ' + typeof float);
console.log('var bool: ' + typeof bool);
console.log('var array: ' + typeof array);
console.log('var object: ' + typeof object);
console.log('var testFn: ' + typeof testFn);
