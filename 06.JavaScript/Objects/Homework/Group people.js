function  solve(people) {
    console.log(groupBy(people, 'age'));

    function groupBy(people, groupByParam) {
        var grouped = {};
        for (i = 0; i < people.length; i += 1) {
            if (!grouped[people[i][groupByParam]]) {
                grouped[people[i][groupByParam]] = [];
            }
                grouped[people[i][groupByParam]].push(people[i]);
        }
        return grouped;
    }
}






var people = [
    { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
    { firstname: 'Bay', lastname: 'Ivan', age: 81 },
    { firstname: 'John', lastname: 'Doe', age: 42 },
    { firstname: 'Pesho', lastname: 'Pesho', age: 22 },
    { firstname: 'Asdf', lastname: 'Xyz', age: 81 },
    { firstname: 'Gosho', lastname: 'Gosho', age: 22 }
];
solve(people);
