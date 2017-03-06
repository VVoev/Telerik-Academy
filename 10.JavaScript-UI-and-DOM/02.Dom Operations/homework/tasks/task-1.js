/*

 Create a function that takes an id or DOM element and an array of contents

 * if an id is provided, select the element
 * Add divs to the element
 * Each div's content must be one of the items from the contents array
 * The function must remove all previous content from the DOM element provided
 * Throws if:
 * The provided first parameter is neither string or existing DOM element
 * The provided id does not select anything (there is no element that has such an id)
 * Any of the function params is missing
 * Any of the function params is not as described
 * Any of the contents is neight `string` or `number`
 * In that case, the content of the element **must not be** changed
 */

module.exports = function () {
  'use strict';
  return function (element, contents) {

    if (typeof element !== 'string' && element.nodeType !== 1) {
      throw new Error();
    }


    if (typeof element === 'string') {
      if (!document.getElementById(element)) {
        throw new Error();
      }
    }

    if (element === undefined || contents === undefined) {
      throw new Error();
    }

    if (contents === null) {
      throw new Error();
    }

    if (!Array.isArray(contents)) {
      throw new Error();
    }


    contents.forEach(function (item) {
      if (typeof item !== 'string' && isNaN(item)) {
        throw new Error();
      }

      if (typeof item === 'object') {
        throw new Error();
      }
    });

    var el;

    if (typeof element === 'string') {
      el = document.getElementById(element);
    } else {
      el = document.getElementById(element.id);
    }

    while (el.firstChild) {
      el.removeChild(el.firstChild);
    }

    contents.forEach(function (item) {
      var div = document.createElement('div');
      div.innerHTML = item;
      el.appendChild(div);
    });

  };
};