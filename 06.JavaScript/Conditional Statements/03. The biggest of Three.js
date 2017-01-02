function BiggestOfThree(numbers) {
  var first =  Number(numbers[0]),
      second = Number(numbers[1]),
      third =  Number(numbers[2]);

    var biggest = Compare(first,second,third);
    console.log(biggest);


    function  Compare(x,y,z) {
        return Math.max(x,y,z);
    }
}
BiggestOfThree(['5', '2', '2']);
BiggestOfThree(['10', '15', '20']);
