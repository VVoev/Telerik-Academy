function Multiplication(numbers) {
 var first = Number(numbers[0]),
     second = Number(numbers[1]),
     third = Number(numbers[2]);

    var product = first * second * third;
    if(product==0){
        console.log(0);
    }else if(product<0)
    {
        console.log('-');
    }else{
        console.log('+');
    }
}
Multiplication(['5', '2', '2']);
Multiplication(['-2', '-2', '1']);
Multiplication(['0', '-2.5', '4']);
