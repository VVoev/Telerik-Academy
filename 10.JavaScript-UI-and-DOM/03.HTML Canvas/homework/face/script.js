var canvas = document.getElementById('canvas');
var ctx = canvas.getContext('2d');
var ctx3D = canvas.getContext('2d');
var centerX = canvas.width/2;
var centerY = canvas.height/2;

ctx.lineWidth = 2;
ctx.fillStyle = 'dodgerblue';

ctx.beginPath();
ctx.ellipse(290, 350, 15, 45, 140, 0, 2 * Math.PI);
ctx.moveTo(centerX+100,centerY);
ctx.arc(centerX,centerY,100,0,Math.PI*2);
ctx.fill();
ctx.moveTo(290,315);
ctx.lineTo(270,315);
ctx.lineTo(290,265);
ctx.moveTo(270,260);
ctx.ellipse(250, 260, 20, 10, 0, 0, 2 * Math.PI);
ctx.moveTo(350,260);
ctx.ellipse(330, 260, 20, 10, 0, 0, 2 * Math.PI);
ctx.moveTo(410,210);
ctx.stroke();


ctx.beginPath();
ctx.ellipse(300, 210, 110, 20, 0,1.68*Math.PI,  1.32*Math.PI);
ctx.fillStyle = 'blue';
ctx.fill();
ctx.stroke();

ctx.beginPath();
ctx.moveTo(360,193);
ctx.ellipse(300, 193, 60, 20, 0, 0, Math.PI);
ctx.lineTo(240,75);
ctx.lineTo(240,193);
ctx.ellipse(300,75,60,20,0,Math.PI,0);
ctx.closePath();
ctx.fillStyle = 'blue';
ctx.fill();
ctx.stroke();


ctx.beginPath();
ctx.ellipse(300,75,60,20,0,0,Math.PI);
ctx.fillStyle = 'blue';
ctx.stroke();

ctx.beginPath();
ctx.ellipse(245, 260, 4, 9, 0, 0, 2 * Math.PI);
ctx.moveTo(329,260);
ctx.ellipse(325, 260, 4, 9, 0, 0, 2 * Math.PI);
ctx.fillStyle = 'black';
ctx.fill();
ctx.stroke();

