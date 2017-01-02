function checkIsPrime(number) {
  var primePretendent = parseInt(number),
    numberSqrt = Math.sqrt(primePretendent);
  if (primePretendent <= 1) {
    console.log(false);
  } else {
    for (var i = 2; i <= numberSqrt; i += 1) {
      if (primePretendent % i == 0) {
        console.log(false);
        return;
      }
    }
    console.log(true);
  }
}

checkIsPrime(-3);
checkIsPrime(88);
checkIsPrime(0);
checkIsPrime(99);
