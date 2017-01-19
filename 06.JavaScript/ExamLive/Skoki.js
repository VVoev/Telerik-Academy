function solve(args) {
    args.shift();
    let input = args.map(Number);
    //console.log(input);
    let check = input[0];
    let result = check%2===0 ? 0 : 1;

    for(let i = 0; i<input.length+1;i+=1){
        let number = input[i];
        //console.log(`You are here ${number}`);
        if(number%2==1){
            result*=number;
            result%=1024;
            //console.log(result);
        }
        else if(number%2==0){
            result+=number;
            i+=1;
            result%=1024;
            //console.log(result);
        }
    }
    console.log(`${result}`);

}
arr1 = ['10', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'];
arr2 = ['9', '9', '9', '9', '9', '9', '9', '9', '9', '9'];
arr3 = ['3','4','2','2'];
solve(arr1);
solve(arr2);
solve(arr3);





