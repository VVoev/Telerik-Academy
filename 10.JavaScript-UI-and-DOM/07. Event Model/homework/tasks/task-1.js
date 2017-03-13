/* globals $ */

/* 

 Create a function that takes an id or DOM element and:


 */

function solve(){
  return function (selector) {

    function checkIfSelectorIsValid(selector) {
      if(typeof  selector === 'string'){
        selector = document.getElementById(selector);
        if(selector === null){
         throw 'Invalid'
        }
        return selector;
      }
      else{
        throw 'Invalid'
      }
    }

    function findContentSiblingIfAny(target){
      var currentSibling = target.nextElementSibling;

      if(currentSibling === null || currentSibling === undefined || currentSibling.className === buttonsC){
        return null;
      }
      else if (currentSibling.classname === contentC){
        return currentSibling;
      }

      findContentSiblingIfAny(currentSibling);
    }

    function changeState(event) {
      var targetButton = event.target;
      var targetButtonSibling = findContentSiblingIfAny(targetButton);

      if(targetButtonSibling !== null){
        if(targetButton.style.display ==''){
          targetButton.style.display = 'none';
          targetButton.innerHTML = 'show';
        }
        else{
          targetButtonSibling.style.display ='';
          targetButtonSibling.innerHTML = 'hide';
        }

      }
    }

    const buttonsC = 'button';
    const contentC = 'content';

    selector =  checkIfSelectorIsValid(selector);
    var buttonClass = selector.getElementsByClassName(buttonsC);
    var contentClass = selector.getElementsByClassName(contentC);

    var buttons = [].slice.apply(buttonClass);
    buttons.forEach(b=>{
      b.textContent = "hide";
      b.addEventListener('click',changeState);
    })
  };
};

//module.exports = solve;

// function solve() {
//  return function(selector) {
//  if (typeof selector === 'string') {
//  selector = document.getElementById(selector);
//  if (selector == null) {
//  throw Error('selector not found');
//  }
//  } else if (!(selector instanceof HTMLElement)) {
//  throw Error('invalid selector');
//  }
//
//  var buttons = document.getElementsByClassName('button');
//  var contents = document.getElementsByClassName('content');
//
//  for (var i = 0; i < buttons.length; i += 1) {
//  buttons[i].textContent = 'hide';
//  buttons[i].addEventListener('click', changeVisibility);
//  }
//  };
//
//  function changeVisibility(event) {
//  var targetButton = event.target;
//
//  var targetButtonSibling = findSibling(targetButton);
//  //if we found the correct sibling
//  if (targetButtonSibling != null) {
//  if (targetButtonSibling.style.display == '') {
//  targetButtonSibling.style.display = 'none';
//  targetButton.innerHTML = 'show';
//  } else {
//  targetButtonSibling.style.display = '';
//  targetButton.innerHTML = 'hide';
//  }
//  }
//  }
//  function findSibling(targetEl) {
//
//  var currentSibling = targetEl.nextElementSibling;
//
//  if (currentSibling == null ||
//  currentSibling == undefined ||
//  currentSibling.className == 'button') {
//  return null;
//  } else if (currentSibling.className == 'content') {
//  return currentSibling;
//  }
//
//  finSibling(currentSibling);
//  }
//  }