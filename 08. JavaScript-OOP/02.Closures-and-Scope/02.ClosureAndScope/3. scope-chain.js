function outer() {
    var x = 'OUTER';
    var y = "it is not funny"

    function inner() {
        var x = 'INNER';
        var y = 'it is funny'
        return y;
    }
    inner();
    return {
        x: x,
        f: inner,
    };
}

console.log(outer().x);
console.log(outer().f());/**
 * Created by Vlado on 1/28/2017.
 */

