let number
let image;
let selected;
image = document.getElementsByTagName('img')[0];


let promiseOne = new Promise(function (resolve,reject) {
    resolve(number = (Math.random(0,100)*100));
    reject('Cannot load picture');
})

promiseOne
    .then(function(data) {
        if(data>50){
            selected = 'cat';
            return selected;
        }
        else{
            selected = 'dog'
            return selected;
        }
    })
    .then(function (data) {
        if(data === 'dog'){
            image.src = 'imgs/loko.jpg';
            image.name = 'dog';
            return image
        }
            image.src = 'imgs/cat.jpg';
            image.name = 'cat';
            return image
    })
    .then(function (data) {
        let h1 = document.getElementsByTagName('h1')[0];
        let name = h1.innerText;
        let newName = name.substring(0,11);
        h1.innerText = `${newName} ${data.name}`
        return data;
    })
    .then(function (data) {
        setTimeout(function (x) {
            window.location.reload(true);
        },200)
        })
    .catch(function(error) {
        console.log(error);
    })

