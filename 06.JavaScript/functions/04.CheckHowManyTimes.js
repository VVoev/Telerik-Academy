function checkHowManyTimes(size,arr, digit) {
    var count = 0;
    var masiv = arr.split(' ');
    for (var i = 0; i<masiv.length;i++){
        if(masiv[i]==digit){
            count++;
        }
    }
    return count;

}
checkHowManyTimes('8','28 6 21 6 -7856 73 73 -56','73');
