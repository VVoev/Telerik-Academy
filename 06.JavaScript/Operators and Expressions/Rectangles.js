function Rectangle(number) {
    var width = number[0];
    var height = number[1];
    var area = width*height;
    var perimeter = width*2+height*2;
    console.log(area.toFixed(2) + ' ' + perimeter.toFixed(2));
}
Rectangle([ '2.5', '3' ]);
Rectangle([ '5', '5' ]);
