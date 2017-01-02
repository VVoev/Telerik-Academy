function BiggestOfFive(numbers) {
    var first = Number(numbers[0]),
        second = Number(numbers[1]),
        third = Number(numbers[2]),
        fourth = Number(numbers[3]),
        five = Number(numbers[4]);

    var biggest = Compare(first, second, third, fourth, five);
    console.log(biggest);


    function Compare(x, y, z, z1, z2) {
        return Math.max(x, y, z, z1, z2);
    }
}
BiggestOfFive(['10', '20', '30','40', '50']);
