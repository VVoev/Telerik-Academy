/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function solve() {
	return function findPrimes(from,to) {
		let arr = [];
		let array = [from,to];

		if(!isItANumber(from) || !isItANumber(to)){
			throw "error";
		}
		if(!array){
			throw  "Error "
		}
		if(array.length!=2){
			throw 'Please provide correct range to find numbers'
		}

		let lower = Number(array[0]);let upper = Number(array[1]);
		for(let i = lower;i<=upper;i+=1){
			if(isITaPrimeNumber(i)){
				arr.push(i);
			}
		}
		return arr;
	};

	//Custom function
	function  isItANumber(number) {
		return !isNaN(number);
	}
	function isITaPrimeNumber(number) {
		if(number<2){
			return false;
		}
		if(number===2){
			return true;
		}
		for (var i = 2, len = Math.sqrt(number); i <= len; i += 1) {
			if (number % i === 0) {
				return false;
			}
		}
		return true;
	}
}

 module.exports = solve;
