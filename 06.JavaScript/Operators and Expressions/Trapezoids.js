function calcTrapezoidArea(number)
{
    var sideA = Number(number[0]);
    var sideB = Number(number[1]);
    var height = Number(number[2]);
    var trapezoidArea = (sideA + sideB) * height / 2;
    console.log(trapezoidArea.toFixed(7));
}