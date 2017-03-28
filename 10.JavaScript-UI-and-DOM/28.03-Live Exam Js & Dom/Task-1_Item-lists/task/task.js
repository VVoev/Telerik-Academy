function solve() {

	return function (selector, defaultLeft, defaultRight) {

		var root = document.querySelector(selector);
		var leftInfo = defaultLeft;
		var rightInfo = defaultRight;

		var list = document.createElement('li');
		var image = document.createElement('img');

		var container = document.createElement('div');
		var leftDiv = document.createElement('div');
		var rightDiv = document.createElement('div');
		var leftDivSelect = document.createElement('div');
		var rightDivSelect = document.createElement('div');
		var leftInput = document.createElement('input');
		leftInput.setAttribute('checked', 'true');
		var leftLabel = document.createElement('label');
		var rightInput = document.createElement('input');
		var rightLabel = document.createElement('label');
		var leftOl = document.createElement('ol');
		var rightOl = document.createElement('ol');

		var inputForAdd = document.createElement('input');
		inputForAdd.style.width = '15%';
		var buttonForAdd = document.createElement('button');
		buttonForAdd.innerText = "Add";

		container.className = 'column-container';
		leftDiv.className = 'column';
		rightDiv.className = 'column';

		leftDivSelect.className = 'select';
		rightDivSelect.className = 'select';

		rightInput.setAttribute("type", "radio");
		leftInput.setAttribute("type", "radio");

		leftInput.setAttribute('id', 'leftColumn');

		rightInput.setAttribute('id', 'rightColumn');

		leftLabel.innerText = "Add Here";
		rightLabel.innerText = "Add Here";

		if (leftInfo !== undefined) {
			fillOl(leftOl, leftInfo);
		}
		if (rightInfo !== undefined) {
			fillOl(rightOl, rightInfo);
		}

		function fillOl(ol, info) {
			for (var i = 0, len = info.length; i < len; i += 1) {
				var li = list.cloneNode(true);
				var img = image.cloneNode(true);

				img.className = 'delete';
				img.src = 'imgs/Remove-icon.png';
				li.className = 'entry';
				if (info[i].length > 0) {
					li.innerHTML = info[i];
					li.appendChild(img);
					ol.appendChild(li);
				}
			}
		}

		var df = document.createDocumentFragment();
		container.appendChild(leftDiv);
		container.appendChild(rightDiv);
		leftDiv.appendChild(leftDivSelect);
		rightDiv.appendChild(rightDivSelect);
		leftDivSelect.appendChild(leftInput);
		leftDivSelect.appendChild(leftLabel);
		rightDivSelect.appendChild(rightInput);
		rightDivSelect.appendChild(rightLabel);
		leftDiv.appendChild(leftOl);
		rightDiv.appendChild(rightOl);

		df.appendChild(container);
		df.appendChild(inputForAdd);
		df.appendChild(buttonForAdd);
		root.appendChild(df);

		leftLabel.addEventListener('click', function (ev) {
			leftInput.checked = true;
			rightInput.checked = false;
		}, false);

		leftInput.addEventListener('click', function (ev) {
			leftInput.checked = true;
			rightInput.checked = false;
		}, false);

		rightInput.addEventListener('click', function (ev) {
			leftInput.checked = false;
			rightInput.checked = true;
		}, false);

		rightLabel.addEventListener('click', function (ev) {
			leftInput.checked = false;
			rightInput.checked = true;
		}, false);

		buttonForAdd.addEventListener('click', function (ev) {

			var inputValue = inputForAdd.value;
			if (inputValue.length === 0) {
				return;
			}
			var li = list.cloneNode(true);
			li.className = 'entry';
			var img = image.cloneNode(true);
			img.className = 'delete';
			img.src = 'imgs/Remove-icon.png';

			li.innerText = inputValue;
			li.appendChild(img);

			if (leftInput.checked === true) {
				leftOl.appendChild(li);
			}
			if (rightInput.checked === true) {
				rightOl.appendChild(li);
			}
			inputForAdd.value = '';
		}, false);

		container.addEventListener('click', function (ev) {
			var target = ev.target;
			if (target.tagName === 'IMG') {
				var targetLi = target.parentNode;
				inputForAdd.value = targetLi.innerText;
				targetLi.parentNode.removeChild(targetLi);
			}
		}, false);
	};
}

// SUBMIT THE CODE ABOVE THIS LINE

 if(typeof module !== 'undefined') {
	 module.exports = solve;
 }

