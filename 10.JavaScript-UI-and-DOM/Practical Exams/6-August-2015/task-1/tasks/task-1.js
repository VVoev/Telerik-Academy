function solve() {
    return function (selector, isCaseSensitive) {
        let root = document.querySelector(selector);
        let newLine = document.createElement('br');
        let inputForAddText = document.createElement('p');
        let addButton = document.createElement('button');
        addButton.className = '.items-control .result-controls .button';
        addButton.innerText = "Add";
        inputForAddText.innerText = "Enter Text";
        let inputForAdd = document.createElement('input');
        inputForAddText.appendChild(inputForAdd);
        inputForAddText.appendChild(newLine);
        inputForAddText.appendChild(addButton);


        let inputForSearchText = document.createElement('p');
        inputForSearchText.innerText = "Search";
        let inputForSearch = document.createElement('input');

        inputForSearchText.appendChild(inputForSearch);

        let names = ["These are Justice League", "Batman", "Superman", "Wonder Woman", "The Flash", "Green Lantern"]

        let ul = document.createElement('ul');
        let div = document.createElement('div');
        let close = document.createElement('button');
        ul.className = 'list-items';
        let list = document.createElement('li');
        for (let i = 0; i < 6; i += 1) {
            let li = list.cloneNode(true);
            let divContainer = div.cloneNode(true);
            let closeButton = close.cloneNode(true);
            divContainer.className = 'container';
            divContainer.style.display = 'block';
            li.className = 'item';
            closeButton.className = 'delete-item';
            closeButton.innerText = "X";
            li.innerText = names[i];
            divContainer.appendChild(li);
            divContainer.appendChild(closeButton);


            ul.appendChild(divContainer);
        }


        root.appendChild(inputForAddText);
        root.appendChild(inputForSearchText);
        root.appendChild(ul);

        addButton.addEventListener('click', function (ev) {
            let inputValue = inputForAdd.value;
            if (inputValue.length < 3) {
                inputForAdd.value = '';
                return;
            }

            let li = list.cloneNode(true);
            let divContainer = div.cloneNode(true);
            li.innerText = inputValue;
            divContainer.className = 'container';
            divContainer.style.display = 'block';
            li.className = 'item';

            let closeButton = close.cloneNode(true);
            closeButton.className = 'delete-item';
            closeButton.innerText = "X";

            divContainer.appendChild(li);
            divContainer.appendChild(closeButton);
            ul.appendChild(divContainer);
            inputForAdd.value = "";
        })

        let closedButtons = document.getElementsByClassName('delete-item');
        for (let i = 0; i < closedButtons.length; i += 1) {
            closedButtons[i].addEventListener('click', function (ev) {
                let target = ev.target;
                let div = target.parentNode;
                ul.removeChild(div);
            })
        }

        inputForSearchText.addEventListener('keyup', function (ev) {
            let lis = ul.getElementsByClassName('item');
            for (let i = 0, len = lis.length; i < len; i += 1) {
                let searchWord = inputForSearch.value;
                if (lis[i].innerText.indexOf(searchWord) >= 0) {
                    let parent = lis[i].parentNode;
                    parent.style.display = 'initial';
                }
                else {
                    let parent = lis[i].parentNode;
                    parent.style.display = 'none';
                }
            }
        }, false)


    };
}

//module.exports = solve;