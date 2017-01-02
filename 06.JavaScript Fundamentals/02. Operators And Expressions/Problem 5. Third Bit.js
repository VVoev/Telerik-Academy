function findThirdBit(number) {
    var check = 1 << 3;
  if ((number & check) >> 3 == 1) {
    console.log('1');
  } else {
    console.log('0');
  }
}

findThirdBit(5);
findThirdBit(15);
findThirdBit(701);
findThirdBit(32768);
findThirdBit(255);
findThirdBit(111);
