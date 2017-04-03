(function () {
    function *fibonachi() {
        let fn1 = 1, fn2 = 1, current, reset;
        while (true) {
            current = fn2;
            fn2 = fn1;
            fn1 = fn1 + current;
            reset = yield  current;

            if (reset) {
                fn1 = 1;
                fn2 = 1;
            }
        }
    }

    let sequence = fibonachi();
    console.log(sequence.next().value);
    console.log(sequence.next().value);
    console.log(sequence.next().value);
    console.log(sequence.next().value);
    console.log(sequence.next().value);
    console.log(sequence.next().value);
    console.log(sequence.next().value);
    console.log(sequence.next().value);
    console.log(sequence.next().value);
    console.log(sequence.next().value);
    console.log(sequence.next(true).value);
    console.log(sequence.next().value);
    console.log(sequence.next().value);
    console.log(sequence.next().value);

}())