function baaaaasiKoniaChuek(input) {
    var rows = parseInt(input[0]),
        cols = parseInt(input[1]);

    input = input.slice(2);

    var board = [];

    //Make the board
    for (var i = 0; i < rows; i += 1) {
        var line = input[i].split('').filter(function (a) {
            return a
        });
        board.push(line);
    }
    input = input.slice(rows);

    //Get number of tests
    var tests = parseInt(input[0]);
    input = input.slice(1);
    //console.log(board);

    var counter = 0;
    for (var j = 0; j < tests; j++) {

        var move = input[j];
        var startPosition = move.split(' ');
        var startRow = +startPosition[0][1];
        var startCol = +startPosition[0][0].toLowerCase().charCodeAt(0) - 97;


        var destRow = +startPosition[1][1];
        var destCol = +startPosition[1][0].toLowerCase().charCodeAt(0) - 97;

        var startCell = board[rows - startRow][startCol];
        var destCell = board[rows - destRow][destCol];
        //console.log(startCell);
        //console.log(startCell);

        if (startCell === '-') {
            console.log('no');
            continue;
        }
        else if (destCell != '-') {
            console.log('no');
            continue;

        }

        //Rookie
        else if (startCell === 'R') {

            if (destCell != '-') {
                console.log('no');
                continue;
            }
            else if (startRow != destRow && startCol != destCol) {
                console.log('no');
                continue;
            }
            else if (startRow === destRow) {

                if (startCol === destCol) {
                    console.log('no');
                    continue;
                }
                else {
                    //console.log('test');

                    var rMax = Math.max(startCol, destCol);
                    var rMin = Math.min(startCol, destCol);

                    var isBlockedR = false;
                    for (var r = rMin + 1; r < rMax; r += 1) {
                        //console.log(board[rows-startRow][r]);
                        if (board[rows - startRow][r] != '-') {
                            //console.log('no');
                            isBlockedR = true;
                            break;
                        }

                    }
                    if (isBlockedR) {
                        console.log('no');
                        continue;
                    }
                    console.log('yes');
                    continue;
                }
            }
            else if (startCol === destCol) {
                if (startRow === destRow) {
                    console.log('no');
                    continue;
                }
                else {
                    //console.log('test');

                    var rMax = Math.max(startRow, destRow);
                    var rMin = Math.min(startRow, destRow);

                    var isBlockedR = false;
                    for (var r = rMin + 1; r < rMax; r += 1) {

                        if (board[rows - r][startCol] != '-') {
                            //console.log('no');
                            isBlockedR = true;
                            break;
                        }

                    }
                    if (isBlockedR) {
                        console.log('no');
                        continue;
                    }
                    console.log('yes');
                    continue;
                }
            }

        }

        //Bishop
        else if (startCell === 'B') {
            //console.log('test');
            if (destCell != '-') {
                console.log('no');
                continue;
            }
            else if (startRow == destRow || startCol == destCol) {
                console.log('no');
                continue;
            }

            var diffRow = Math.abs(startRow - destRow);
            var diffCol = Math.abs(startCol - destCol);

            if (diffRow != diffCol) {
                console.log('no');
                continue;
            }
            else {
                var rMax = Math.max(startRow, destRow);
                var rMin = Math.min(startRow, destRow);

                var cMax = Math.max(startCol, destCol);
                var cMin = Math.min(startCol, destCol);
                var isBlocked = false;


                if (startRow < destRow) {
                    var col1 =startCol;
                    for (var q = startRow + 1; q <=destRow; q++) {
                        if (startCol < destCol) {
                                col1++;
                                    if (board[rows - q][col1] != '-') {
                                        isBlocked = true;
                                        break;
                                    }



                        }
                        else {
                            col1--;
                                    if (board[rows - q][col1] != '-') {
                                        isBlocked = true;
                                        break;
                                    }



                        }


                    }


                }

                else if (startRow > destRow) {
                    var col1 = startCol;
                    for (var q = startRow-1; q >= destRow; q--) {

                        if (startCol <= destCol) {

                                col1++;


                                    if (board[rows - q][col1] != '-') {

                                        isBlocked = true;
                                        break;
                                    }


                            }

                        else {
                            col1--;

                                    if (board[rows - q][col1] != '-') {
                                        isBlocked = true;
                                        break;
                                    }
                                }


                        }

                    }


                }


                if (isBlocked) {
                    console.log('no');
                    continue;
                }
                console.log('yes');
                continue;
            }




        //Queen
        else if (startCell === 'Q') {

            var diffRow = Math.abs(startRow - destRow);
            var diffCol = Math.abs(startCol - destCol);


            if (startRow != destRow && startCol != destCol) {

                if (diffRow != diffCol) {

                    console.log('no');
                    continue;
                }
                else {

                    var diffRow = Math.abs(startRow - destRow);
                    var diffCol = Math.abs(startCol - destCol);

                    if (diffRow != diffCol) {
                        console.log('no');
                        continue;
                    }
                    else {
                        var rMax = Math.max(startRow, destRow);
                        var rMin = Math.min(startRow, destRow);

                        var cMax = Math.max(startCol, destCol);
                        var cMin = Math.min(startCol, destCol);
                        var isBlocked = false;


                        if (startRow < destRow) {
                            var col1 =startCol;
                            for (var q = startRow + 1; q <=destRow; q++) {
                                if (startCol < destCol) {
                                    col1++;
                                    if (board[rows - q][col1] != '-') {
                                        isBlocked = true;
                                        break;
                                    }



                                }
                                else {
                                    col1--;
                                    if (board[rows - q][col1] != '-') {
                                        isBlocked = true;
                                        break;
                                    }



                                }


                            }


                        }

                        else if (startRow > destRow) {
                            var col1 = startCol;
                            for (var q = startRow-1; q >= destRow; q--) {

                                if (startCol <= destCol) {

                                    col1++;


                                    if (board[rows - q][col1] != '-') {

                                        isBlocked = true;
                                        break;
                                    }


                                }

                                else {
                                    col1--;

                                    if (board[rows - q][col1] != '-') {
                                        isBlocked = true;
                                        break;
                                    }
                                }


                            }

                        }


                    }


                    if (isBlocked) {
                        console.log('no');
                        continue;
                    }
                    console.log('yes');
                    continue;
                }
            }

            if (startRow === destRow) {

                if (startCol === destCol) {
                    console.log('no');
                    continue;
                }
                else {


                    var rMax = Math.max(startCol, destCol);
                    var rMin = Math.min(startCol, destCol);

                    var isBlockedR = false;
                    for (var r = rMin + 1; r < rMax; r += 1) {
                        //console.log(board[rows-startRow][r]);
                        if (board[rows - startRow][r] != '-') {
                            //console.log('no');
                            isBlockedR = true;
                            break;
                        }

                    }
                    if (isBlockedR) {
                        console.log('no');
                        continue;
                    }
                    console.log('yes');
                    continue;
                }
            }
            if (startCol === destCol) {
                //console.log('test');
                if (startRow === destRow) {
                    console.log('no');
                    continue;
                }
                else {
                    //console.log('test');

                    var rMax = Math.max(startRow, destRow);
                    var rMin = Math.min(startRow, destRow);

                    var isBlockedR = false;
                    for (var r = rMin + 1; r < rMax; r += 1) {

                        if (board[rows - r][startCol] != '-') {
                            //console.log('no');
                            isBlockedR = true;
                            break;
                        }

                    }
                    if (isBlockedR) {
                        console.log('no');
                        continue;
                    }
                    console.log('yes');
                    continue;
                }
            }


            //else{
            //    console.log('-');
            //}
            // Your solution here
            //console.log('yes'); // or console.log('no');
            //console.log(counter);
            //counter++;

        }
    }


}


//baaaaasiKoniaChuek([
//    '3',
//    '4',
//    '--R-',
//    'B--B',
//    'Q--Q',
//    '12',
//    'd1 b3',
//    'a1 a3',
//    'c3 b2',
//    'a1 c1',
//    'a1 b2',
//    'a1 c3',
//    'a2 b3',
//    'd2 c1',
//    'b1 b2',
//    'c3 b1',
//    'a2 a3',
//    'd1 d3'
//
//])


baaaaasiKoniaChuek([
    '5',
    '5',
    'Q---Q',
    '-----',
    '-B---',
    '--R--',
    'Q---Q',
    '10',
    'a1 a1',
    'a1 d4',
    'e1 b4',
    'a5 d2',
    'e5 b2',
    'b3 d5',
    'b3 a2',
    'b3 d1',
    'b3 a4',
    'c2 c5'

])