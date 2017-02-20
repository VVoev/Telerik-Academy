//Problem 1
console.log('Problem 1 Results\n-------------------------------');
String.prototype.format = function(options){
var str = this;
    for (var key in options) {
        var reg = new RegExp('#{'+key+'}','g');
        str = str.replace(reg,options[key])

    }
    return str;

};

var options = {name1: 'John', name2:'Batman'};
var str= 'Hello, there! Are you #{name1}? I am #{name2}!'.format(options);
console.log(str);


var options1 = {name: 'John', age: 13};
var str1 = ('My name is #{name} and I am #{age}-years-old').format(options1);
console.log(str1);


//Problem 2
console.log('\nProblem 2 Results\n-------------------------------');

String.prototype.bind = function (object) {
    var regexBind = new RegExp('data-bind-(.+?(?==))="(.+?(?="))"', 'g');
    var match = regexBind.exec(this);
    var arr = [];
    var content = '';
    var isContentBindingExist = false;
    while (match != null) {
        if (match[1] === 'content') {
            content = object[match[2]];
            isContentBindingExist = true;
        }
        else {
            arr.push(match[1] + '="' + object[match[2]] + '"');
        }
        match = regexBind.exec(this);
    }
    var replace = arr.length>0?', ':'';
    var bindStr = this;
    var existingContent = bindStr.match(/>(.*(?=<))</);
    replace += arr.join(", ") + '>' + (isContentBindingExist?content:existingContent[1]) + '<';

    bindStr = bindStr.replace(/>.*(?=<)</, replace);
    return bindStr;
}


var bindStr1 = '<div data-bind-content="name"></div>';
bindStr1 = bindStr1.bind({name: 'Steven'});
console.log(bindStr1);

var bindStr2 = '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></а>'
bindStr2=bindStr2.bind({name: 'Elena', link: 'http://telerikacademy.com'});
console.log(bindStr2);
