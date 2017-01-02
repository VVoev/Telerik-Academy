function checkIsPointInCircle(coordinates)
{
    let x = Number(coordinates[0]);
    let y = Number(coordinates[1]);
    let distance = Math.sqrt((x - 0) * (x - 0) + (y - 0) * (y - 0)).toFixed(2);
    if (distance <= 2) {
        console.log("yes " + distance);
    }
    else{
        console.log("no " + distance);
    }
}
checkIsPointInCircle(10,15);
