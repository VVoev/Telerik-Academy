function  solve(args) {
    let elementhToBeRemoved = args[0];
    args.shift();

    for(let i of args){
        if(i!=elementhToBeRemoved){
            console.log(i)
        }
    }

}
arr1 = [ '1', '2', '3', '2', '1', '2', '3', '2' ];
arr2 = [
    '_h/_',
    '^54F#',
    'V',
    '^54F#',
    'Z285',
    'kv?tc`',
    '^54F#',
    '_h/_',
    'Z285',
    '_h/_',
    'kv?tc`',
    'Z285',
    '^54F#',
    'Z285',
    'Z285',
    '_h/_',
    '^54F#',
    'kv?tc`',
    'kv?tc`',
    'Z285'
];
arr3= ['Vlado',"Ivan","Kiro","Petko","Vlado"];
solve(arr1);
solve(arr2);
solve(arr3);
