var input = document.querySelector('input');
let button = document.querySelectorAll('button')[0];
button.addEventListener('click',function () {
    let student = input.value;
    let school = document.getElementById('school');
    let div = document.createElement('div');
    div.innerText = student;
    div.classList = 'Otlichnici';
    school.appendChild(div);
})
let button1 = document.querySelectorAll('button')[1];
let input2 = document.getElementById('remove');
button1.addEventListener('click',function () {
    let target = input2.value;
    let divs = document.querySelectorAll('div');

    try {
        for(let div of divs){
            if(div.innerText === target){
                return div.parentNode.removeChild(div);
            }
        }
        throw "No Such User"
    }
    catch (e){
        alert("No Such User");
    }
})

