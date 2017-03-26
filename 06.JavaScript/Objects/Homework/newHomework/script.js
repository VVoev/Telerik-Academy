let input = document.querySelectorAll('input');


for(let i = 0 ; i<input.length;i++){
    input[i].addEventListener('click',function (ev) {
        let target = ev.target;
        target.className = "checked";

        let inputs = document.querySelectorAll('input');
        for(let i = 0; i<input.length;i++){
            if(inputs[i].className !=='checked' && inputs[i].id !== 'submitButton'){
                inputs[i].disabled = true;
            }
        }



    },false)
}





