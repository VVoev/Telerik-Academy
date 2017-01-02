function checkIsPointInCircle(coordinates) {
  var x = +coordinates[0],
      y = +coordinates[1],
      radius = 2;
      point = Math.sqrt((x * x) + (y * y));
  if (point > radius * radius) {
    console.log('no ' + point.toFixed(2));
  } else {
    console.log('yes ' + point.toFixed(2));
  }
}

checkIsPointInCircle(0,4);
checkIsPointInCircle(15,14);
checkIsPointInCircle(-4,-3.5);
checkIsPointInCircle(0.2,-0.8);
