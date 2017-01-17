function  substring(text) {
    var searchingWord = text[0];
    var text = text[1];
    var number = checkHowManyRepeatsInText(searchingWord,text);
    console.log(number);
    
    
    
    function checkHowManyRepeatsInText (word,text) {
        text.toLowerCase();
        var b= text.search(word);
        return b;
    }

}
substring(['in','We are living in an yellow submarine. We don\'t have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.']);
