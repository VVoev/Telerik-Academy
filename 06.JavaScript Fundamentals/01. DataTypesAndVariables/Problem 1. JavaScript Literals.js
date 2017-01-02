var nan = NaN;
var undefine = undefined;
var someText = 'Hello, JavaScript';
var int = 10;
var float = 10.77;
var bool = false;
var firstArray = [0,1,1,2,3,5,8,13,21]; // Yes, this is Fibonacci sequence.
var object = {name:'Donald Trump', age:55, male:true, job:'US President'};

// Get type of foreach declared variable.
typeof(nan);
typeof(undefine);
typeof(someText);
typeof(int);
typeof(float);
typeof(bool);
typeof(firstArray);
typeof(object);
console.log(object.job);
testFunction(object.job);
main();


function main(){
  console.log('Hello, world of JavaScript Developers!');
  console.log(typeof(nan));
  console.log(typeof(undefine));
  console.log(typeof(someText));
  console.log(typeof(int));
  console.log(typeof(float));
  console.log(typeof(bool));
  console.log(typeof(firstArray));
  console.log(typeof(object));
}
function testFunction(job){
  console.log('My next job will be ' + job);
}
