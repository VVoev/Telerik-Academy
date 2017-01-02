function calcTrapezoidArea(args) {
  var sideA = +args[0];
  var sideB = +args[1];
  var height = +args[2];
  var trapezoidArea = (sideA + sideB) * height / 2;

  console.log(trapezoidArea.toFixed(7));
}

calcTrapezoidArea(5,7,12);
calcTrapezoidArea(2,1,33);
calcTrapezoidArea(8.5,4.3,2.7);
calcTrapezoidArea(0.222,0.333,0.555);
calcTrapezoidArea(100,200,300);
