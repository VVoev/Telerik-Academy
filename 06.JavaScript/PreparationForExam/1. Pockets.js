function solve(information){
     const numbers = information[0].split(' ').map(Number);
    let peakIndexes = [];
    for(let i = 1; i<numbers.length-1; i+=1){
        //Check for peak
        if(numbers[i]>numbers[i-1] && numbers[i]>numbers[i+1]){
            peakIndexes.push(i);
        }
    }

    let pocketSum = 0;
    for (let i =1;i<numbers.length-1;i+=1){
        if(peakIndexes.indexOf(i-1) >=0 && peakIndexes.indexOf(i+1)>=0){
            pocketSum+=numbers[i];
        }
    }
    console.log(pocketSum);
}
arr  = ["53 20 1 30 2 40 3 10 1"];
arr1 = ["53 20 1 30 30 2 40 3 10 1"];
arr2 = ["53 20 1 30 2 40 3 3 10 1"];
solve(arr);
solve(arr1);
solve(arr2);
