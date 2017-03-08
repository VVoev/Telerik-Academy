var canvas = document.getElementById('bike');
var ctx = canvas.getContext('2d');
var centerX = canvas.width / 2;
var centerY = canvas.height / 2;
ctx.lineWidth = 3;
ctx.fillStyle='#00d4b4';
ctx.font='50px Arial';
ctx.fillText('Bike',200,100);

//Begin draw
ctx.beginPath();


//Paddles
ctx.arc(centerX,centerY,25,0,2*Math.PI);
ctx.moveTo(centerX-40+5,centerY+20+10);
ctx.lineTo(400,300);
ctx.moveTo(centerX+45+5,centerY-25);
ctx.lineTo(400,300);
ctx.stroke();

//Rear Wheel
ctx.beginPath();
ctx.arc(centerX-centerX/2,centerY,60,0,2*Math.PI);
ctx.fill();
ctx.stroke();

//Front wheel
ctx.beginPath();
ctx.arc(centerX+centerX/2,centerY,60,0,2*Math.PI);
ctx.fill();
ctx.stroke();

//Saddle
ctx.moveTo(240,180);
ctx.lineTo(300,180);
ctx.stroke();

//Steering
ctx.moveTo(480,150);
ctx.lineTo(500,180);
ctx.moveTo(500,180);
ctx.lineTo(460,180)
ctx.moveTo(500,180);
ctx.lineTo(600,300);
ctx.stroke();

//Saddle to Paddles
ctx.moveTo(240,180);
ctx.lineTo(400,300);
ctx.stroke();




