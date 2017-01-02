function findThirdBit(number) {
    var number = Number(number);
    var check = 1 << 3;
    if ((number & check) >> 3 == 1) {
        console.log('1');
    } else {
        console.log('0');
    }
}