function checkPointInFigures(coords){
  var x = +coords[0];
      y = +coords[1],
      r = 1.5,
      insideCircle = (x - 1) * (x - 1) + (y - 1) * (y - 1) <= r * r,
      insideRectangle = (x >= -1) && (x <= 5) && (y >= -1) && (y <= 1);
  if (insideCircle && insideRectangle) {
      console.log('inside circle inside rectangle');
  } else if ((insideCircle === false) && (insideRectangle)) {
      console.log('outside circle inside rectangle');
  } else if ((insideCircle) && (insideRectangle === false)) {
      console.log('inside circle outside rectangle');
  } else if ((insideCircle === false) && (insideRectangle === false)) {
      console.log('outside circle outside rectangle');
  }
}

checkPointInFigures(2.5,2);
checkPointInFigures(0,1);
checkPointInFigures(2.5,1);
checkPointInFigures(1,2);
