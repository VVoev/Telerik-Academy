function outer(x) {
    function middle(y) {
        function inner(z) {
            return x + ' ' + y + ' ' + z;
        }
        return inner;
    }
    return middle;
}

function a(first) {
    function b(second) {
        function c(last){
            return first+' '+second+' '+last;
        }
        return c;
    }
    return b;
}


var system = outer(4);
system = system(4);
system = system(2);
console.log('System ' + system);

var names = outer('Peter');
names = names('Georgiev');
names = names('Petrov');
console.log('Hi! I am ' + names);/**
 * Created by Vlado on 1/28/2017.
 */

var action = a('I');
action = action('was');
action = action('here');

console.log(action)
