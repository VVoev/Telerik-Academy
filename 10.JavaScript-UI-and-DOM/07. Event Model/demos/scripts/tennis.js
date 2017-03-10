let maLong = document.querySelectorAll('a')[0];
maLong.addEventListener('click',function () {
    maLong.href = "https://www.youtube.com/watch?v=onEkHHWzxW0";
})
maLong.addEventListener('mouseenter',function () {
    let img  = document.createElement('img');
    img.src = "../images/long.png";
    let tr = document.querySelectorAll('tr')[0];
    tr.appendChild(img);
})
maLong.addEventListener('mouseleave',function () {
    let img = document.querySelector('img');
    img.parentNode.removeChild(img);
})




let sort = document.getElementById('sort');
sort.addEventListener('click',function () {
    let ratings = document.getElementsByClassName('rating');
    let players = document.getElementsByClassName('players');
    let allPlayers ={
        ranklist:[]
    };

    let ratingsArr = [].slice.call(ratings);
    let playersArr = [].slice.call(players);

    let ratingsNumbers = [];
    let playerNames = [];
    ratingsArr.forEach(r=>{
        ratingsNumbers.push(r.innerText);
    })
    playersArr.forEach(p=>{
        playerNames.push(p.innerText);
    })


    ratingsNumbers.forEach(function(value, index) {
        allPlayers.ranklist.push({
            name:playerNames[index],
            rating:value
        })
    });

    function compare(a,b) {
        if (a.rating < b.rating)
            return -1;
        if (a.rating > b.rating)
            return 1;
        return 0;
    }

    allPlayers.ranklist.sort((a,b)=>a.rating-b.rating);
    let ol = document.createElement('ol');
    allPlayers.ranklist.forEach(p=>{
        let li = document.createElement('li');
        ol.appendChild(li);
        li.innerHTML = p.name +" "+ p.rating
    })
    let body = document.querySelector('body');
    body.appendChild(ol);
})
let inputPlayer = document.getElementById('addPlayer');
let inputRating = document.getElementById('addRating');
inputPlayer.addEventListener('mouseover',function () {
    inputPlayer.value ='';
})
inputRating.addEventListener('mouseover',function () {
    inputRating.value = '';
})

let addPlayerButton = document.getElementById('addP');
let addRatingButton = document.getElementById('addR');

addPlayerButton.addEventListener('click',function () {
    let table = document.querySelector('table');
    let tr = document.createElement('tr');
    let td = document.createElement('td');
    td.classList = 'players';
    tr.appendChild(td);
    td.innerText = inputPlayer.value;
    table.appendChild(tr);
})
addRatingButton.addEventListener('click',function () {
    let tr = document.querySelectorAll('tr');
    let last = tr.length-1;
    let td = document.createElement('td');
    td.classList = 'rating';
    td.innerText = inputRating.value;
    tr[last].appendChild(td);
})
let search = document.getElementById('search');
search.addEventListener('click',function () {
    let input = document.getElementById('video');
    let searchWord = input.value;
    let playersAll = document.getElementsByClassName('players');
    let players = [].slice.call(playersAll);
    players.forEach(x=>{
        if(x.innerText === searchWord){
            alert('You have this Player')
        }
    })
    
})



