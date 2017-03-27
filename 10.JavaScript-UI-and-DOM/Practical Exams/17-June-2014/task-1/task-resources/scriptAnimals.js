function createImagesPreviewer(selector, items) {

    function setPropertiesToRightElements(elem) {
        elem.style.marginLeft = '50%';
    }

    let root = document.querySelector(selector);
    let df = document.createDocumentFragment();

    let divRight = document.createElement('div');
    let leftButton = document.createElement('button');
    let newLine = document.createElement('br');
    leftButton.innerText = 'AutoPlay';
    let list = document.createElement('li');
    let image = document.createElement('img');
    let divLeft = document.createElement('div');
    let inputRight = document.createElement('input');
    let anchor = document.createElement('a');
    let h3 = document.createElement('h1');
    let p = document.createElement('p');
    let imageLeft = document.createElement('img');
    let ulAnimals = document.createElement('ul');
    ulAnimals.className = "Animals";
    ulAnimals.style.listStyleType = 'none';
    ulAnimals.style.display = 'absolute';

    imageLeft.src = items[0].url;


    leftButton.style.width = '200px';
    leftButton.style.height = '30px';
    leftButton.style.backgroundColor = 'purple';
    leftButton.style.color = 'yellow';
    leftButton.style.marginLeft = '50%';


    divLeft.style.width = '50%';
    divLeft.style.height = '100%';
    divRight.style.width = '50%';
    divRight.style.height = '100%';
    imageLeft.style.textAlign = 'center';
    imageLeft.style.width = '80%';
    imageLeft.style.height = '50%';

    setPropertiesToRightElements(p);
    setPropertiesToRightElements(inputRight);

    h3.innerText = items[0].title;
    p.innerText = "Filter";

    divLeft.style.float = 'left';
    divRight.style.float = 'right';
    h3.style.textAlign = 'center';
    divLeft.appendChild(h3);
    divLeft.appendChild(imageLeft);
    divLeft.appendChild(newLine);
    divLeft.appendChild(leftButton);


    let len = items.length;
    for (i = 0; i < len; i += 1) {
        let item = items[i];
        let li = list.cloneNode(true);
        let a = anchor.cloneNode(true);
        setPropertiesToRightElements(li);
        let imageRight = image.cloneNode(true);
        imageRight.style.width = '30%';
        imageRight.style.height = '20%';
        a.innerText = item.title;
        //li.style.textAlign = 'justify';
        a.style.width = '95%';
        a.style.fontWeight = 'bold';
        a.style.display = 'inline-block';


        li.value = i;
        li.style.width = image.width + 100;
        imageRight.src = item.url;
        imageRight.style.margin = '5px';
        imageRight.value = i;
        li.appendChild(a);
        li.appendChild(imageRight);
        ulAnimals.appendChild(li);
    }

    ulAnimals.addEventListener('mouseover', function (ev) {
        let target = ev.target;
        if (target.tagName === 'IMG') {
            let parent = target.parentNode;
            parent.style.cursor = 'pointer';
            parent.style.backgroundColor = 'grey';

        }
    }, false)

    ulAnimals.addEventListener('mouseout', function (ev) {
        let target = ev.target;
        if (target.tagName === 'IMG') {
            let parent = target.parentNode;
            parent.style.cursor = '';
            parent.style.backgroundColor = '';

        }
    }, false)

    ulAnimals.addEventListener('click', function (ev) {
        let target = ev.target;
        if (target.tagName === 'IMG') {
            imageLeft.src = target.src;
            h3.innerText = target.previousElementSibling.innerText;
        }
    }, false)

    inputRight.addEventListener('keyup', function (ev) {
        let value = inputRight.value.toLowerCase();
        let listOfAnimals = document.getElementsByClassName('Animals')[0].childNodes;
        for (let i = 0, len = listOfAnimals.length; i < len; i += 1) {
            let currentAnimal = listOfAnimals[i].innerText.toLowerCase();
            if (currentAnimal.indexOf(value) >= 0) {
                listOfAnimals[i].style.display = '';
            }
            else {
                listOfAnimals[i].style.display = 'none';
            }
        }
    })

    leftButton.addEventListener('click', function (ev) {
        var time = 1;
        let listOfAnimals = document.getElementsByClassName('Animals')[0].childNodes;

        var interval = setInterval(function() {
            if (time <= listOfAnimals.length) {
                let currentAnimalName = listOfAnimals[time].innerText;
                let currentAnimalUrl = listOfAnimals[time].children[1].src;
                changeNameAndPicture(currentAnimalName,currentAnimalUrl,h3,imageLeft);
                time++;
            }
            else {
                clearInterval(interval);
            }
        }, 2500);

    }, false)

    function changeNameAndPicture(text,image,h3,imageLeft){



        h3.innerText = text;
        imageLeft.src = image;

    }


    divRight.appendChild(p);
    divRight.appendChild(inputRight);
    divRight.appendChild(ulAnimals);
    df.appendChild(divLeft);
    df.appendChild(divRight);


    root.appendChild(df);
}



