function Matrix(x) {
    var number = Number(x[0]);

    for(var i = 1 ;i <= number;i++){
        var str = '';
        for(var j = i ;j < number+i;j++){
            str+=j+' ';
        }
        console.log(str);
    }
    
}
Matrix(['4']);
