
(function () {
    var canvas = document.getElementById("curves-canvas"),
        ctx = canvas.getContext("2d");

    ctx.beginPath();

    ctx.lineWidth = 2;
    ctx.moveTo(188, 130);
    ctx.bezierCurveTo(150,10,350,10,188,300,20);
    ctx.stroke();
    ctx.bezierCurveTo(-150,10,350,10,188,300,20);
    ctx.fillStyle = 'red';
    ctx.fill();
    ctx.fillStyle = 'black';
    ctx.fill();

}());
