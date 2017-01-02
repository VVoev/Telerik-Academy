function findThirdDigit(number) {
  if (number < 699) {
    console.log('false 0');
  } else {
    number /= 100;
    if ((number | 0) % 10 === 7) {
      console.log('true');
    } else if ((number | 0) % 10 !== 7){
      console.log('false ' + parseInt((number % 10)));
    }
  }
}

findThirdDigit(7);
findThirdDigit(8887920);
findThirdDigit(888700);
findThirdDigit(777);
