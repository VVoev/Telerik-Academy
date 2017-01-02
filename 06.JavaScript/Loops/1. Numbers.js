function PrintNumbers(x) {
 var number = Number(x[0]);
    var output = Print(number);
    console.log(output);

    function Print(number) {
        var sentence = '';
        for (var i = 1;i<=number;i++){
            sentence+=i+' ';
        }
        return sentence;
    }
}
PrintNumbers(['5']);
