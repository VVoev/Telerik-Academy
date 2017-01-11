function getLargestNumber(args) {
    var input = args[0].split(' ').map(Number),
        firstNumber = input[0],
        secondNumber = input[1],
        thirdNumber = input[2];

    if (getMax(firstNumber, secondNumber) > thirdNumber) {
        return getMax(firstNumber, secondNumber);
    } else {
        return thirdNumber;
    }

    function getMax(first, second) {
        return first > second ? first : second;
    }
}