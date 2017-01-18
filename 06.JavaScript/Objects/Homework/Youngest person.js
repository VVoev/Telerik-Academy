function  solve(collection) {
    let youngsters = collection.sort(function (a,b) {
        return a.age>b.age;
    });
    for (let i of youngsters){
        console.log(`${i.firstname} ${i.lastname}`);
        break;
    }
}






let peopleFirst = [
    { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
    { firstname: 'Bay', lastname: 'Ivan', age: 81 },
    { firstname: 'John', lastname: 'Doe', age: 42 }
];
let peopleSecond = [
    { firstname: 'Penka', lastname: 'Hristova', age: 61 },
    { firstname: 'System', lastname: 'Failiure', age: 99 },
    { firstname: 'Malko', lastname: 'Kote', age: 18 }
];
solve(peopleFirst);
solve(peopleSecond);