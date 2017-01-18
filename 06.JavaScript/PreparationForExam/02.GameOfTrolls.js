function solve(args){
    "use strict"
    //get field dimensions
    let arr = args[0].split(' ').map(Number);
    let rows = arr[0];
    let cols = arr[1];

    let playerCords = args[1].split(/;\s/g);
    let troll1 = {
        row:playerCords[0],
        col:playerCords[1],
        trapped: false
    };
    let troll2 = {
        row:playerCords[2],
        col:playerCords[3],
        trapped: false
    };
    let princess = {
        row:playerCords[4],
        col:playerCords[5],
    };

    let traps = [];
    for(let i = 0; i<rows ; i+=1){
       let row = new Array(cols);
        row.fill(false);
        traps.push(row);
    }
    //remove first two rows
    args.shift();
    args.shift();
    
    
    args.forEach(function (command) {
        if(command ==='lay trap'){
            traps[princess.row][princess.col] = true;
        }
        else {
            let spl = command.split(' ');
            let unitToMove;
            if(spl[0][1] === 'L'){//princess is Moving
                unitToMove = princess;
            }
            else if(spl[0][1] === 'W'){
                unitToMove=troll1;
            }
            else if(spl[0][1] === 'N'){
                unitToMove=troll2;
            }
            else {
                //should never happen
            }

            if(spl[2]==='u' && unitToMove.row>0){
                unitToMove.row -= 1;
            }
            else if(spl[2]==='d' && unitToMove.row<rows-1){
                unitToMove.row += 1;
            }
            else if(spl[2]==='l' && unitToMove.col>0){
                unitToMove.col -= 1;
            }
            else if(spl[2]==='r' && unitToMove.col<cols-1){
                unitToMove.col += 1;
            }

            //check for trapping





            if(princess.row ===rows-1 && princess.col == cols-1){
                console.log(`Lsjtujzbo is saved! ${troll1.row} ${troll1.col} ${troll2.row} ${troll2.col}`)
            }

        }
    })





}
arr = [
    '5 5',
    '1 1;0 1;2 3',
    'mv Lsjtujzbo d',
    'lay trap',
    'mv Lsjtujzbo d',
    'mv Wboup r',
    'mv Wboup r',
    'mv Nbslbub d',
    'mv Nbslbub d',
    'mv Nbslbub d',
    'mv Nbslbub d',
    'mv Nbslbub d',
    'mv Wboup d',
    'mv Wboup d'
];
arr1 = [
    '7 7',
    '0 1;0 2;3 3',
    'mv Lsjtujzbo l',
    'lay trap',
    'mv Lsjtujzbo r',
    'lay trap',
    'mv Lsjtujzbo r',
    'lay trap',
    'mv Lsjtujzbo d',
    'mv Lsjtujzbo r',
    'mv Lsjtujzbo r',
    'mv Lsjtujzbo r',
    'mv Lsjtujzbo r',
    'mv Wboup d',
    'mv Wboup d',
    'mv Wboup l',
    'mv Wboup l',
    'mv Nbslbub r',
    'mv Nbslbub r',
    'mv Nbslbub r',
    'mv Nbslbub d',
    'mv Lsjtujzbo d',
    'mv Lsjtujzbo l',
    'mv Lsjtujzbo l',
    'mv Nbslbub l',
    'mv Nbslbub d',
    'mv Nbslbub d',
    'mv Wboup d',
    'mv Wboup d',
    'mv Wboup r',
    'mv Lsjtujzbo d',
    'mv Wboup d',
    'mv Wboup d',
    'mv Wboup r',
    'mv Lsjtujzbo r',
    'mv Lsjtujzbo r'
];
arr2 = [
    '8 8',
    '1 3;0 3;5 5',
    'mv Lsjtujzbo l',
    'mv Lsjtujzbo l',
    'lay trap',
    'mv Lsjtujzbo r',
    'lay trap',
    'mv Lsjtujzbo r',
    'lay trap',
    'mv Lsjtujzbo d',
    'lay trap',
    'mv Lsjtujzbo d',
    'lay trap',
    'mv Wboup r',
    'mv Wboup r',
    'mv Wboup d',
    'mv Wboup d',
    'mv Wboup d',
    'mv Wboup d',
    'mv Nbslbub d',
    'mv Nbslbub d',
    'mv Lsjtujzbo l',
    'mv Nbslbub d',
    'mv Nbslbub r',
    'mv Nbslbub r',
    'mv Nbslbub d',
    'mv Nbslbub d',
    'mv Nbslbub d'
];
solve(arr);
//solve(arr1);
//solve(arr2);
