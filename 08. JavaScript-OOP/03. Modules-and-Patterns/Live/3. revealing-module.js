var people = (function () {
    var people = ['Poko','Loko'];
    _render();
    
    function _render() {//private function
        console.log(people);
    }
    
    function addPerson(name) {
        people.push(name);
        _render();
    }

    function removePerson(i) {
        people.splice(i,1);
        _render();
    }

    return{
        addPerson:addPerson,
        deletePerson:removePerson
    };
})();

people.addPerson('Jako');
people.deletePerson(2);
people.deletePerson(0);
people.deletePerson(0);

