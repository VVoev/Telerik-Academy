function sortNumbers(numbers) {
    var first =  Number(numbers[0]),
        second = Number(numbers[1]),
        third =  Number(numbers[2]);
    var biggest = Math.max(first,second,third);
    var smallest = Math.min(first,second,third);
    var medium = FindMedium(first,second,third,biggest,smallest);
    console.log(biggest+' '+medium+' '+smallest);


    function FindMedium() {
        if(first>smallest && first<biggest){
            return first;
        }else if(second>smallest && second<biggest){
            return second}
        else {
            return third;
        }
    }
}
sortNumbers(['5', '1', '2']);
sortNumbers(['50', '1', '200']);

