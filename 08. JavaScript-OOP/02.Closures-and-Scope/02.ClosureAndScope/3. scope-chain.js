function outer() {
    var x = 'OUTER';
    var y = "it is not funny"

    function inner() {
        var x = 'INNER';
        return x;
    }
    function innerY() {
        var y = "it is funny";
        return y;
    }

    inner();
    innerY();
    return {
        x: x,
        f: inner,
        y:y,
        z:innerY
    };
}

console.log(outer().x);
console.log(outer().y)
console.log(outer().f());
console.log(outer().z())

