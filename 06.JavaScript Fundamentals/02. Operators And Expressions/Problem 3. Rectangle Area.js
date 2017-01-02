function calcRectangleArea(number){
  var width = +number[0],
      height = +number[1];
  var area = width * height;
  var perimeter = 2 * (width + height);
  console.log(area.toFixed(2) + ' ' + perimeter.toFixed(2));
}
calcRectangleArea(5.4,7.2);
calcRectangleArea(5.4,9);
calcRectangleArea(5.1,7.9);
calcRectangleArea(5.6,7.7);
