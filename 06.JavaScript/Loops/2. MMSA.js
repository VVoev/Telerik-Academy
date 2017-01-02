function SortNumbers(args) {
    var len = args.length;
    var min = +args[0];
    var max = +args[0];
    var sum = 0;
    var average = 0;
    for (var i = 0; i < args.length; i++) {
        var element = +args[i];

        if (element < min) {
            min = element;
        }
        if (element > max) {
            max = element;
        }
        sum += element;
    }
    var average = +sum / len;
    console.log(`min= ${min.toFixed(2)}`);
    console.log(`max= ${max.toFixed(2)}`);
    console.log(`sum= ${sum.toFixed(2)}`);
    console.log(`avg= ${average.toFixed(2)}`);
}
SortNumbers(['5','20','40']);