var changeColor = document.getElementById('changeColor');
changeColor.addEventListener('click',function () {
    var divs = document.querySelectorAll('div');
    var bulgarianFlag = ['white','green','red']
    for(let i = 0 ; i < divs.length;i+=1){
        divs[i].style.backgroundColor = bulgarianFlag[i];
        divs[i].style.border = "1px solid black";
    }
    changeColor.parentNode.removeChild(changeColor);
})
let TA = document.getElementById('continue');
TA.addEventListener('mouseover',function () {
    TA.innerHTML = "Your Life is officially over";
    let header = document.querySelector('h1');
    header.innerText = "Welcome To Hell";
})
TA.addEventListener('dblclick',function () {
    TA.innerHTML = "Byahahah";
})
TA.addEventListener('mouseout',function () {
    let para = document.createElement('img');
    para.src = "../images/tl.jpg";
    para.style.width = '300px';
    para.style.height = '200px';
    TA.appendChild(para);
    para.innerText = 'eto me';
})
var down = false;
document.addEventListener('keypress', function (){
    down = true;
}, false);


