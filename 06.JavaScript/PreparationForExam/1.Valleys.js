function solve(input) {
    let numbers = input[0].split(' ').map(Number);
    let peaks = [];

    numbers.forEach(function (number, index) {
        if (isPeak(index)) {
            peaks.push(index);
        }
    });
    let maxValleySum =0 ;

    for(let i = 1 ; i < peaks.length;i+=1){
        let startIndex = peaks[i-1];
        let endIndex = peaks[i];
        let valleySum = 0;
        for (let j = startIndex; j<= endIndex; j+=1){
            valleySum+=numbers[j];
        }
        maxValleySum < valleySum ?
                                   maxValleySum=valleySum :
                                   maxValleySum=maxValleySum;

    }
    console.log(maxValleySum)


    function isPeak(index) {
        if (index === 0 || index === numbers.length - 1) {
            return true;
        }
        if (numbers[index] > numbers[index + 1] && numbers[index] > numbers[index - 1]) {
            return true;
        }
        return false;
    }
}

arr =["5 1 7 6 5 6 4 2 3 8"];
arr1 =["5 1 7 4 8"];

solve(arr);
solve(arr1);





