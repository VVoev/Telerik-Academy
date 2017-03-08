window.onload = function () {
    let theCanvas = document.getElementById('bulgarian-flag');
    var canvasCtx = theCanvas.getContext("2d");
    canvasCtx.fillStyle = 'white';
    canvasCtx.fillRect(10,10,300,100);
    canvasCtx.strokeRect(10,10,300,100)
    canvasCtx.fillStyle = 'green';
    canvasCtx.fillRect(10,110,300,100);
    canvasCtx.strokeRect(10,110,300,100)
    canvasCtx.fillStyle = 'red';
    canvasCtx.fillRect(10,210,300,100);
    canvasCtx.strokeRect(10,210,300,100)
    canvasCtx.fillStyle="black";
    canvasCtx.fillRect(10,310,15,500)
}