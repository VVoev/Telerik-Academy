function solve(obj) {
    let clone  = cloneObject(obj);
    let secondClone = Object.assign({}, obj);
    console.log(clone);
    console.log(secondClone)

    function cloneObject(obj) {
        var clone = {};
        for(var i in obj) {
            if(typeof(obj[i])=="object" && obj[i] != null)
                clone[i] = cloneObject(obj[i]);
            else
                clone[i] = obj[i];
        }
        return clone;
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


