function InCircleOutRect(cords) {
    var x = Number(cords[0]),
        y = Number(cords[1]);

    var isInCircle = (x - 1) * (x - 1) + (y - 1) * (y - 1) <= 1.5 * 1.5;
    var isOutRectangle = !(x >= -1 && x <= 5 && y <= 1 && y >= -1);
    if (isInCircle && isOutRectangle) {
        console.log('inside circle outside rectangle');
    } else if (isInCircle && !isOutRectangle) {
        console.log('inside circle inside rectangle');
    } else if (!isInCircle && isOutRectangle) {
        console.log('outside circle outside rectangle');
    } else {
        console.log('outside circle inside rectangle');
    }
}
