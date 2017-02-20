function solve(input) {

    var nk = input[0].split(' ').map(Number),
        arr = input[1].split(' ').map(Number),
        result;

    var n = nk[0];
    var k = nk[1];


    var neighbourLeft;
    var neighbourRight;
    var num;
    var arrTransformed = arr;
    for (var i = 0; i < k; i += 1) {
        arr = arrTransformed;
        //console.log(arr);
        arrTransformed=new Array(n);
        for (var j = 0; j < n; j += 1) {
            num = arr[j];
            //console.log(j);

            if (j === 0) {
                neighbourLeft = arr[n - 1];
                neighbourRight = arr[1];
            }
            else if (j === n - 1) {
                neighbourLeft = arr[n - 2];
                neighbourRight = arr[0];
            }
            else {
                neighbourLeft = arr[j - 1];
                neighbourRight = arr[j + 1];
            }
            //console.log(neighbourLeft+" "+neighbourRight);
            var transformedNum = numCheck(num, neighbourLeft, neighbourRight);
            //console.log(transformedNum);

            arrTransformed[j]=(transformedNum);
            //console.log(arrTransformed[j]);
        }


    }

    var total = 0;

    for (var obj in arrTransformed) {
total+=arrTransformed[obj];
    }

    console.log(total);
    function numCheck(num, n1, n2) {
        if (num === 0) {
            return abs(n1,n2);
        }
        else if (num === 1) {
            return sum(n1,n2);
        }
        else if (num % 2 === 0) {
            return max(n1,n2);
        }
        else if (num % 2 !== 0) {
            return min(n1,n2);
        }
    }


    function abs(n1, n2) {
        return Math.abs(n1 - n2);
    }

    function max(n1, n2) {
        return n1 >= n2 ? n1 : n2;
    }

    function sum(n1, n2) {
        return n1 + n2;
    }

    function min(n1, n2) {
        return n1 <= n2 ? n1 : n2;
    }
}

solve([
    '5 1',
    '9 0 2 4 1'
])

solve([
    '10 3',
    '1 9 1 9 1 9 1 9 1 9'

])

solve([
    '10 10',
    '0 1 2 3 4 5 6 7 8 9'

])