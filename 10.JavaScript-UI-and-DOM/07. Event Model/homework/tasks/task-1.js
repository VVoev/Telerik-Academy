/* globals $ */

/* 

Create a function that takes an id or DOM element and:
  

*/

function solve(){
  return function (selector) {

    if(typeof selector !== 'string' && selector.nodeType!==1){
        throw {
          name:"Invalid Argument",
          message:"Invalid Argument Error"
        }
    }

    function getDomElement(selector) {
      var element;
      if (selector.nodeType === 1 && selector.id) {
        element = selector;
        if (!document.body.contains(element)) {
          throw {
            name: 'InvalidDomElement',
            message: 'InvalidDomElement'
          }
        }
      }
      else {
        element = document.getElementById(selector);
        if (element == undefined) {
          throw {
            name: 'InvalidDomElement',
            message: 'InvalidDomElement'
          }
        }
      }

      return element;
    }

    



  };
};

//module.exports = solve;