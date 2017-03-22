function solve() {
    return function (selector, initialSuggestions) {

        // <div class="autocomplete">
        //     <input class="tb-pattern" type="text" />
        //     <a href="#" class="btn-add">Add</a>
        //     <ul class="suggestions-list">
        //
        //     </ul>
        //     </div>

        let root = document.querySelector(selector);
        let df = document.createDocumentFragment();
        let li = document.createElement('li');
        let input = root.getElementsByClassName('tb-pattern')[0];
        let ul = root.getElementsByClassName('suggestions-list')[0];
        let addButton = root.getElementsByClassName('btn-add')[0];

        let len = initialSuggestions.length;

        for (let i = 0; i < len; i += 1) {
            let currentLi = li.cloneNode(true);
            currentLi.innerText = initialSuggestions[i];
            currentLi.classList = 'suggestions';
            currentLi.style.display = 'none';
            df.appendChild(currentLi);
        }
        ul.appendChild(df);

        input.addEventListener('input', function (ev) {
            let value = input.value.toLowerCase();
            let suggestions = ul.getElementsByClassName('suggestions');
            if (input.value === '') {
                for (let i = 0; i < suggestions.length; i += 1) {
                    suggestions[i].style.display = 'none';
                }
            }

            for (let i = 0; i < suggestions.length; i += 1) {
                let word = suggestions[i].innerText.toLowerCase();
                if (word.indexOf(value) >= 0 && input.value !== '') {
                    suggestions[i].style.display = 'block';
                }
                else {
                    suggestions[i].style.display = 'none';
                }
            }
        })

        ul.addEventListener('click', function (ev) {
            let target = ev.target;
            if (target.tagName !== 'LI') {
                return;
            }
            input.value = target.innerText;
            let suggestions = ul.getElementsByClassName('suggestions');
            for (let i = 0; i < suggestions.length; i += 1) {
                suggestions[i].style.display = 'none';
            }

        })

        addButton.addEventListener('click', function (ev) {
            let target = ev;
            let word = input.value;
            let suggestions = ul.getElementsByClassName('suggestions');
            for (let i = 0; i < suggestions.length; i += 1) {
                if (suggestions[i].innerText === word) {
                    suggestions[i].style.display = 'block';
                    suggestions[i].classList ='untouchable';
                }
            }
        }, false)


    };
}