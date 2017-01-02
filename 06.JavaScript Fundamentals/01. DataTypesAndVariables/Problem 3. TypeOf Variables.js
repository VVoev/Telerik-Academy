var notANumber = NaN;
var notDefined = undefined;
var someText = 'Please, get type of me.';
var int = 69;
var float = 33.33;
var bool = true;
var lostNumbers = [4,8,15,16,23,42, 'LOST']; // LOST numbers.
var object = {name:'Valeri Bojinov', age:32, male:true, job:'Searching little kittens'};

// Get type of foreach declared variable.
typeof(notANumber);
typeof(notDefined);
typeof(someText);
typeof(int);
typeof(float);
typeof(bool);
typeof(lostNumbers);
typeof(object);

main();

function main(){
  console.log('Hello, world of JavaScript Developers!');
  console.log(typeof(notANumber));
  console.log(typeof(notDefined));
  console.log(typeof(someText));
  console.log(typeof(int));
  console.log(typeof(float));
  console.log(typeof(bool));
  console.log(typeof(lostNumbers));
  console.log(typeof(object));
}
