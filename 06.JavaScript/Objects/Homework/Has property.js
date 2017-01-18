function  solve(obj) {
    let hasProp = hasProperty(obj,'firstname');
    let hasPayCheck = hasProperty(obj,'zaplata');
    console.log(hasProp);
    console.log(hasPayCheck);



    function  hasProperty(object,parameter) {
        return object.hasOwnProperty(parameter);
    }
}

let PetarDetails =
{
    firstname:"Petar",
    lastname:"Petrov",
    age:31,
    male:true
};
solve(PetarDetails);
