function compareBrackets(input) {
    var text = input[0];
    var counter = 0 ;
    compare(text,counter);



    function compare() {
        for(var i = 0; i<text.length;i++){
            if(text[i]==')'){
                counter++;
            }
            if(text[i]=='('){
                counter--;
            }
        }
        counter == 0 ? console.log("Correct") : console.log("Incorrect");
    }

}

compareBrackets([ '((a+b)/5-d)' ]);
compareBrackets([ ')(a+b))' ]);
