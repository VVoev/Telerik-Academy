function solve(args) {

    var numObj = +args[0];
    var object = {};
    args = args.slice(1);
    for (var i = 0; i < numObj; i += 1) {
        var line = args[i].split('-').filter(function(a) {return a});
        object[line[0]]=line[1].split(';').map(function(a){if(Number(a)) {return Number(a)}else{return a}} );
    }

    args = args.slice(numObj);
    args = args.slice(1);
    //console.log(args);
    //console.log(object);
    var str = args.join('\n');
    //console.log(str);
    var regex = new RegExp('\<nk-template name="(.+?(?="))">((.|\n)+?(?=<\/nk))<\/nk-template>','g');
    var match = regex.exec(str);

    var templates = {};
    var str1 = str;

    while(match!==null){

        templates[match[1]]=match[2].substring(1,match[2].length-1);
        str1 = str1.replace(match[0],'');
        //console.log(match[0]);
        match = regex.exec(str);
    }
    str = str1.trim();


    var regexIf = new RegExp('\<nk-if condition="(.+(?="))">((.|\n)+?(?=<\/nk))<\/nk-if>','g');
    var matchIf = regexIf.exec(str);

    str1=str;
    while(matchIf!==null){
        //console.log(matchIf[1]);
        //console.log(object[matchIf[1]]);
        if(object[matchIf[1]]=='true'){
            str1 = str1.replace(matchIf[0],matchIf[2].trim());
        }
        else{
            str1 = str1.replace(matchIf[0]+'\n','');
        }

        //console.log(match[0]);
        matchIf = regexIf.exec(str);
    }
    str = str1.trim();

    var arrStr = str.split('\n');
    //console.log(arrStr);

    var regexTempl = new RegExp('<nk-template render="(.+?(?="))" \/>','g');
    var regexModel = new RegExp('({{)?<nk-model>(.+?(?=<))<\/nk-model>(}})?');
    var match1;
    var matchModel;
    for (var obj in arrStr) {
        //console.log(arrStr[obj]);
        match1 = regexTempl.exec(arrStr[obj]);
        matchModel = regexModel.exec(arrStr[obj]);
        if(matchModel){
            //console.log(arrStr[obj]);
            //console.log(matchModel);
            if(!matchModel[1]&&!matchModel[3]) {
                arrStr[obj] = arrStr[obj].replace(matchModel[0], object[matchModel[2]]);
            }
            else{
                arrStr[obj] = arrStr[obj].replace(matchModel[1], '').replace(matchModel[3],'');
            }
        }
        if(match1){
            //console.log(match1[0]);
            arrStr[obj]=arrStr[obj].replace(match1[0],templates[match1[1]]);
        }


    }
    console.log(arrStr.join("\n"));
    //console.log(str);
    //console.log(templates);



    //console.log(match);


}

solve([
    '6',
    'title-Telerik Academy',
    'showSubtitle-true',
    'subTitle-Free training',
    'showMarks-false',
    'marks-3;4;5;6',
    'students-Ivan;Gosho;Pesho',
    '42',
    '<nk-template name="menu">',
    '<ul id="menu">',
    '<li>Home</li>',
    '<li>About us</li>',
    '</ul>',
    '</nk-template>',
    '<nk-template name="footer">',
    '<footer>',
    'Copyright Telerik Academy 2014',
    '</footer>',
    '</nk-template>',
    '<!DOCTYPE html>',
    '<html>',
    '<head>',
    '<title>Telerik Academy</title>',
    '</head>',
    '<body>',
    '<nk-template render="menu" />',
    '',
    '<h1><nk-model>title</nk-model></h1>',
    '<nk-if condition="showSubtitle">',
    '<h2><nk-model>subTitle</nk-model></h2>',
    '<div>{{<nk-model>subTitle</nk-model>}} ;)</div>',
    '</nk-if>',
    '<ul>',
    '<nk-repeat for="student in students">',
    '<li>',
    '<nk-model>student</nk-model>',
    '</li>',
    '<li>Multiline <nk-model>title</nk-model></li>',
    '</nk-repeat>',
    '</ul>',
    '<nk-if condition="showMarks">',
    '<div>',
    '<nk-model>marks</nk-model>',
    '</div>',
    '</nk-if>',
'<nk-template render="footer" />',
'</body>',
'</html>'
])