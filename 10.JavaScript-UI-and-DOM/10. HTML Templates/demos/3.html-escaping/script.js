/* globals Handlebars, document */
'use strict';
var templateHtml;
var tempalte;

var obj = {
    htmlString:'<h1>Hello how are you</h1>',
    escapedHtmlString:new Handlebars.SafeString('<h1>I am fine</h1>')
};
templateHtml = document.getElementById('template').innerHTML;
tempalte = Handlebars.compile(templateHtml);
document.getElementById('root').innerHTML = tempalte(obj);
