/**
 * Created by Vlado on 1/24/2017.
 */
function factorial(n) {
    if(n==0){
        return 1;
    }
    else {
        return n*factorial(n-1);
    }
}
console.log(factorial(5))
console.log(factorial(20))