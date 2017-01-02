function Exchange(numbers) {
    var first = Number(numbers[0]),
        second = Number(numbers[1]);
    first>second ? console.log(second+' '+first) : console.log(first+' '+second);
}
Exchange(['5', '10']);
Exchange(['15', '20']);

