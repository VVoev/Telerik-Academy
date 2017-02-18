//Fill
var arr = [1,2,3,4,5,6,7,8,9,10];//arr.fill(value)
arr.fill(10,5,7);			     //arr.fill(value, start)
console.log(arr);                //arr.fill(value, start, end)
function smallerThanFive(number) {
	return number<=5;
}

//Filter
let smallNumbers = arr.filter(smallerThanFive);
console.log(smallNumbers);

var myCats = [
			{name: "Djingle", age:23,happy:true},
			{name: "Marta", age:43,happy:true},
			{name: "Jim", age:101,happy:false},
			{name: "Stuart", age:67,happy:false} ,
			{name:"Marta",age:42,happy:true}
			];


var oldCats = myCats.filter(function (x) {
	return x.age>42;
})
console.log(oldCats)

var fruits = ['apple', 'banana', 'grapes', 'mango', 'orange'];
function filterItems(query) {
	return fruits.filter(function(el) {
		return el.toLowerCase().indexOf(query.toLowerCase()) > -1;
	})
}
var sortedF = filterItems('g')
console.log(sortedF);

//Find
var inventory = [
	{name: 'Jack Daniels', quantity: 2,price:35},
	{name: 'Jonny Walker', quantity: 0,price:22},
	{name: 'Chivas Regal', quantity: 5,price:52},
	{name: 'Singleton', quantity: 5,price:74},
	{name: 'Flirt', quantity: 42,price:9.80},


];

var mostExpensive = (function () {
	return function () {
		var price = 0;
		var name = 0;
		let index = 0 ;
		for(let i of inventory){
			index+=1;
			if(i.price>price){
				price = i.price;
				name=i.name;
			}
		}
		return `${price} leva is the most Expensive alkoxol  ${name} in our inventory Cheers`;
	}
})();
console.log(mostExpensive())
var someNumbers = [10,20,30,40,50,60,70,80];
console.log(someNumbers.find(x=>x>10));
//return the firstElemet if existing or undefined if not existing

function isPrime(element, index, array) {
	var start = 2;
	while (start <= Math.sqrt(element)) {
		if (element % start++ < 1) {
			return false;
		}
	}
	return element > 1;
}

console.log([4, 6, 8, 12].find(isPrime)); // undefined, not found
console.log([4, 5, 8, 12].find(isPrime)); // 5


//Foreach
inventory.forEach(x=>console.log(x));
myCats.forEach(x=>x['food']="Whiskas");
console.log(myCats)//Cats now have also have favorite food

function Counter() {
	this.sum = 0;
	this.count = 0;
}
Counter.prototype.add = function(array) {
	array.forEach(function(entry) {
		this.sum += entry;
		++this.count;
	}, this);
	// ^---- Note
};

var obj = new Counter();
obj.add([2, 5, 9]);
obj.add([3])
obj.count
// 3
obj.sum
// 16
console.log(obj)



//Includes
var maleNames = ['Vlado','Spas','Mitko','Petar','Stoqn','Mixail'];
console.log(maleNames.includes('Vlado'))//True
console.log(maleNames.includes('Mitko',3))//False

//indexOf
console.log(maleNames.indexOf('Vlado'))//0 Exist
console.log(maleNames.indexOf('Kiril'))//-1 Not Existing

//Map
var someNumbers = [5,10,15,20];
var roots = someNumbers.map(function (x) {
	return x*2;
})
//someNumbers = [5,10,15,20];
//roots = [ 10, 20, 30, 40 ];

var map = Array.prototype.map;
var a = map.call('Hello World', function(x) {
	return x.charCodeAt(0);
});
// a now equals [72, 101, 108, 108, 111, 32, 87, 111, 114, 108, 100]

var kvArray = [{key: 1, value: 10},
	{key: 2, value: 20},
	{key: 3, value: 30}];

var reformattedArray = kvArray.map(function(obj) {
	var rObj = {};
	rObj[obj.key] = obj.value;
	return rObj;
});

// reformattedArray is now [{1: 10}, {2: 20}, {3: 30}],

// kvArray is still:
// [{key: 1, value: 10},
//  {key: 2, value: 20},
var animals = [
	{ species: 'Lion', name: 'King' },
	{ species: 'Whale', name: 'Fail' }
];

for (var i = 0; i < animals.length; i++) {
	(function(i) {
		this.print = function() {
			console.log('#' + i + ' ' + this.species
				+ ': ' + this.name);
		}
		this.print();
	}).call(animals[i], i);
}

for (let i in myCats) {
	(function(i) {
		this.print = function() {
			console.log('#' + i + ' ' + this.name
				+ ': ' + this.age);
		}
		this.print();
	}).call(myCats[i], i);
}

