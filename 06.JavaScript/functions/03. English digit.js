function Digit(numbers) {
  var number =Number(numbers);
    var remainder = number%10;

    var res = SayLastDigit(remainder);
    console.log(res)
    function SayLastDigit (x) {
        switch (x){
            case 1:return("one");
            case 2:return("two");
            case 3:return("three");
            case 4:return("four");
            case 5:return("five");
            case 6:return("six");
            case 7:return("seven");
            case 8:return("eight");
            case 9:return("nine");
            case 0:return("zero");
        }
    }
}
Digit(42);
