var numbers = [5,10,15,20,30,40,50,60,65,66,70];
var names = ["Michael","Anton","Ivan","Juma","Kumar","Bill","Mike"];

function isPrime(x,numbers) {
    if(x%2==0){
        numbers.push(x);
    }
    return false;
}
var nov =[];
numbers.forEach(x=>isPrime(x,nov)); //[ 10, 20, 30, 40, 50, 60, 66, 70 ]

console.log(names.filter(x =>x.includes('M')));//[ 'Michael', 'Mike' ]



// Shows all indexes, not just those that have been assigned values
var c = [];
var sorted = names.sort((x,y)=>x.localeCompare(y));
console.log(sorted);

