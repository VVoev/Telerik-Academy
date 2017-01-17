function  reverse(input) {
    var x = input[0];
    var rev ='';
    for(var i = x.length-1; i>=0;i--){
        rev+=x[i];
    }
    console.log(rev);
}
reverse([ 'sample' ]);
