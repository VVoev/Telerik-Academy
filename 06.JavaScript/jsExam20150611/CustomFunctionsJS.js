/*Removes the first element found from left to right in the array
 Second argument should be truthy to remove all elements*/
Array.prototype.remove = function(arg, all){
    for(var i = 0; i < this.length; i++){
        if(this[i] === arg){
            this.splice(i,1);

            if(!all)
                break;
            else
                i--;
        }
    }
};
//---------------------------------------------------
//Removes the element at the position
Array.prototype.removeAt = function(position){
    this.splice(position,1);
};
//---------------------------------------------------
//Removes all elements of the array
Array.prototype.clear = function(){
    this.length = 0;
};
//---------------------------------------------------
//inserts an element at a given position
Array.prototype.insertAt = function(arg, position){
    this.splice(position, 0, arg);
};
//---------------------------------------------------
//Checks if the array contains the given element
Array.prototype.contains = function(arg){
    for(var i = 0; i < this.length; i++)
        if(this[i] === arg)
            return true;
    return false;
};
//---------------------------------------------------
//Counts the occurrences of a given element in array
Array.prototype.occurs = function(arg){
    var counter = 0;

    for(var i = 0; i< this.length; i++){
        if(this[i] === arg)
            counter++;
    }

    return counter;
};
//---------------------------------------------------
//Как да взимам и използвам информация от html
function calcExp() {
    var argument = document.getElementById('evaluate').value;
    var evaluate = eval(argument);
    //console.log(evaluate);
    if (evaluate === undefined) {
        document.getElementById('display').innerHTML = 'Type something to evaluate.';
    }
    else {
        document.getElementById('display').innerHTML = evaluate;
        document.getElementById('evaluate').value = '';
    }
}
//---------------------------------------------------
//Reverse regex
// ^((?!(regex)).)*
//Multiple times regex
function main(input) {
    var reg = /<p>(.*?)<\/p>/g;
    var match = reg.exec(input);

    while(match!==null) {
        console.log(match);
        match = reg.exec(input);
    }
}
//---------------------------------------------------
//Regex
var pattern = new RegExp('<div','g');
return html.match(pattern).length;
//---------------------------------------------------
//Average of array
function averageArray(arr) {
    var sum = arr.reduce(function (a, b) {
        return a + b;
    });
    var avg = sum / arr.length;
    return avg.toFixed(2);
}
//Sort by key
function sortObj(arr) {
    // Setup Arrays
    var sortedKeys = new Array();
    var sortedObj = {};

    // Separate keys and sort them
    for (var i in arr) {
        sortedKeys.push(i);
    }
    sortedKeys.sort();

    // Reconstruct sorted obj based on keys
    for (var i in sortedKeys) {
        sortedObj[sortedKeys[i]] = arr[sortedKeys[i]];
    }
    return sortedObj;
}
//---------------------------------------------------
//Sort object by...
function sortObjByWeight(arr) {
    // Setup Arrays
    var sortedKeys = new Array();
    var sortedObj = {};
    // Separate obj in array and sort them
    for (var i in arr) {
        arr[i]['key'] = i;
        sortedKeys.push(arr[i]);
    }
    sortedKeys.sort(function (x, y) {
        return x['kg'] - y['kg'];
    });

    // Reconstruct sorted obj based on keys
    for (var i in sortedKeys) {
        sortedObj[sortedKeys[i]['key']] = sortedKeys[i];
        delete sortedKeys[i]['key'];
    }
    return sortedObj;
}
//---------------------------------------------------
