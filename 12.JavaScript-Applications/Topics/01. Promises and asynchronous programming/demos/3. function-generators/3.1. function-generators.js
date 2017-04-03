(function () {

    function *idMaker() {
        var ID = 0;

        while (true) {
            yield  ID += 1;
        }
    }

    var gen = idMaker();
    console.log(gen.next().value)
    console.log(gen.next().value)
}());