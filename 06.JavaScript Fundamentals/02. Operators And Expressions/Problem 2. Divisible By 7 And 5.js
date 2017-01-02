function checkDivisible(number) {
  if (number % 5 === 0 && number % 7 === 0) {
    console.log('true ' + number);
 }else {
    console.log('false ' + number);
  }
}
checkDivisible(7);
checkDivisible(127);
checkDivisible(35);
checkDivisible(5);
checkDivisible(0);
