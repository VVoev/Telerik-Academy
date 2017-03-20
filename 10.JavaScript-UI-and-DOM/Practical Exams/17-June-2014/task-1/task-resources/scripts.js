function createImagesPreviewer(selector, items) {
    'use strict';

    let root = document.querySelector(selector);
    let fragment = document.createDocumentFragment();

    let leftDiv = document.createElement('div');
    leftDiv.style.display = 'inline-block';
    leftDiv.style.width = '75%';
    leftDiv.style.float = 'left';
    let leftH1 = document.createElement('h1');

    leftH1.style.textAlign = 'center';
    leftH1.innerText = items[0].title;
    let leftImage = document.createElement('img');
    leftImage.src = items[0].url;
    leftImage.style.width = '100%';
    leftImage.style.height = '80%';
    leftImage.style.borderRadius = '20px';
    leftDiv.appendChild(leftH1);
    leftDiv.appendChild(leftImage);
    leftH1.parentNode.classList = 'image-preview';


    let rightDiv = document.createElement('div');
    rightDiv.style.display = 'inline-block';
    rightDiv.style.width = '25%';
    rightDiv.style.float = 'right';
    let filter = document.createElement('h3');
    let input = document.createElement('input');
    let image = document.createElement('img');
    image.style.borderRadius = '20px';
    let listItems = document.createElement('ul');
    listItems.classList = 'image-container';
    listItems.type = 'none';
    filter.style.textAlign = 'center';
    filter.innerText = 'Filter';
    input.style.marginLeft = '150px';
    rightDiv.appendChild(filter);
    rightDiv.appendChild(input);
    rightDiv.appendChild(listItems);
    let li = document.createElement('li');
    for (let i = 0, len = items.length; i < len; i += 1) {
        let currentItem = items[i];
        let currentLi = li.cloneNode(true);
        currentLi.style.textAlign = 'center';
        currentLi.style.fontWeight = 'bold';
        currentLi.innerText = currentItem.title;
        let currentImg = image.cloneNode(true);
        currentImg.src = currentItem.url;
        currentImg.style.width = '95%';
        currentLi.appendChild(currentImg);


        listItems.appendChild(currentLi);
    }

    listItems.addEventListener('mouseover', function (ev) {
        let target = ev.target;
        if (target.tagName === 'IMG') {
            target.parentNode.style.cursor = 'pointer';
            target.parentNode.style.background = 'grey';
        }
    }, false)
    listItems.addEventListener('mouseout', function (ev) {
        let target = ev.target;
        if (target.tagName === 'IMG') {
            target.parentNode.style.background = '';
        }
    }, false)

    listItems.addEventListener('click', function (ev) {
        let target = ev.target;
        if (target.tagName === 'IMG') {
            let name = (target.previousSibling);
            let div = document.getElementsByClassName('image-preview');
            div[0].childNodes[0].innerText = name.nodeValue;
            div[0].childNodes[1].src = target.currentSrc;
        }
    }, false)

    input.addEventListener('keyup', function () {
        let allLi = document.querySelectorAll('li');
        let input = document.getElementsByTagName('input')[0];
        let inputValue = input.value;

        for (let i = 0, len = allLi.length; i < len; i += 1) {
            let word = allLi[i].innerText.toLowerCase();
            let value = inputValue.toLowerCase();
            let index = word.indexOf(value);

            if(word.includes(value)){
                allLi[i].style.display = 'initial';
            }
            else{
                allLi[i].style.display = 'none';
            }
        }
    }, false)


    fragment.appendChild(leftDiv);
    fragment.appendChild(rightDiv);
    root.appendChild(fragment);


}