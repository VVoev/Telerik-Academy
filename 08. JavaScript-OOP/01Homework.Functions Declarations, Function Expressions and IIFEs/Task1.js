/*Write a function that sums an array of numbers:

    Numbers must be always of type Number
Returns null if the array is empty
Throws Error if the parameter is not passed (undefined)
Throws if any of the elements is not convertible to Number
*/

function sum(array) {

    function hasNumberValues(array) {
        return array.every(function (num) {
            return !isNaN(num);
        });
    }

    if(array.length==0){
        return null;
    }

    if(!Array){
        throw 'Params not passed to function';
    }

    if(!hasNumberValues(array)){
        throw 'all arrays elements must be numbers'
    }

    let sum =  array.map(Number).reduce(function (a,b) {
        return a+b;
    },0);
}
sum([1,2,3])
sum([])

