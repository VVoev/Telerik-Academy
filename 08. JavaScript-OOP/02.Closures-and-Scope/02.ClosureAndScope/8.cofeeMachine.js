var cofeeMachine = function () {

    var orders,
        lastId,
        self;

    function makeCofee(order) {
        if(!lastId){
            lastId=0;
        }

        if(!orders){
            orders=[];
        }

        order.orderID = ++lastId;
        orders.push(order);
        return self;

    }

    function findByID(id) {
        if(id>lastId){
            throw "there is no such order";
        }
        for(let i of orders){
            if(i.orderID==id){
                return i;
            }
        }
        return null;
    }
    //Todo to be added
    function addMilk() {

    }

    function addSugar() {

    }

    function getTodayOrders() {
        var cloned = [];
        cloned[orders.length-1]="CofeeShop";
        for (let i of orders){
            cloned.push(i);
        }
        return cloned;
    }

    self={
        make:makeCofee,
        getAll:getTodayOrders,
        giveId:findByID
    };

    return self;
}();
var cofeeTypes = ["Late","Makiato","Hot Chocolate"];

cofeeMachine.make({
    type:cofeeTypes[0],
});
cofeeMachine.make({
    type:cofeeTypes[1],
});
cofeeMachine.make({
    type:cofeeTypes[2]
});
console.log("-------------------")

console.log(cofeeMachine.getAll())

console.log(cofeeMachine.giveId(3));
console.log(cofeeMachine.giveId(1));




