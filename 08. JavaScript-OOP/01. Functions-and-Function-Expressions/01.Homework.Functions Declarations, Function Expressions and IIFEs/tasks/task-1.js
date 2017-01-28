/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

function solve() {

	function sum(array) {

		function hasNumberValues(array) {
			return array.every(function (num) {
				return !isNaN(num);
			});
		}

		if (array.length === 0) {
			return null;
		}
		if (!array) {
			throw 'Parameter not passed to function';
		}
		if (!hasNumberValues(array)) {
			throw "All array elements must be numbers";
		}

		return array.map(Number)
			.reduce(function (num1, num2) {
				return num1 + num2;
			});


	}
	return sum;
}



module.exports = solve;
