/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function solve() {
	 function findPrimes(array) {
		let arr = [];
		let index ;

		if(array.length!=2){
			throw 'Please provide correct range to find numbers'
		}
		if(isItANumber(array[0]) || isItANumber[array[1]]){
			throw 'The params of the functions is not a number'
		}
		let lower = array[0];let upper = array[1];
		for(let i = lower;i<upper;i+=1){
			if(isITaPrimeNumber){
				arr.push(i);
			}
		}
		return arr;
	}

	//Custom function
	function  isItANumber(number) {
		return !isNaN(number);
	}
	function isITaPrimeNumber(number) {
		if(num<2){
			return false;
		}
		if(num===2){
			return true;
		}
		for (var i = 2, len = Math.sqrt(num); i <= len; i += 1) {
			if (num % i === 0) {
				return false;
			}
		}
		return true;
	}
	return findPrimes;
}

module.exports = solve;
