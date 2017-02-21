function solve() {



    function getProduct(productType, name, price) {

        return{
            productType : productType,
            name : name,
            price: price
        }
    }

    function getShoppingCart() {

        const products = [];

        function add(product) {
            products.push(product)
            return this;
        }

        function remove(product) {
            if(products.length ===0){
                throw ("You have no products");
            }
            let index = products.findIndex(x=>
            x.productType === product.productType &&
            x.name === product.name &&
            x.price === product.price);
            if(index<0){
                throw `Such product does not exist`;
            }
            products.splice(index,1);
            return this;
        }

        function showCost() {
            return products.reduce((a,b)=>a+b.price,0);
        }

        function showProductTypes() {
            var uniqTypes = new Map();
            for(let i of products){
                if(!uniqTypes.has(i.productType)){
                    uniqTypes.set(i.productType);
                }
            }
            var keys = [];
            for (let [ key, val ] of uniqTypes) {
                keys.push(key);
            }
            return keys.sort((a,b)=>a.localeCompare(b));
        }

        function getInfo(){

            const groupedByName = {};
            products.forEach(p=>{
                if(groupedByName.hasOwnProperty(p.name)){
                    groupedByName[p.name].totalPrice +=p.price;
                    groupedByName[p.name].quantity +=1;
                    groupedByName[p.name].price = p.price;
                }
                else{
                    groupedByName[p.name]={
                        name : p.name,
                        price : p.price,
                        quantity:1,
                        totalPrice:p.price
                    }
                }
            })
            const groups = Object.keys(groupedByName).sort().map(p=>{
                return{
                    name : p,
                    price : groupedByName[p].price,
                    quantity:groupedByName[p].quantity,
                    totalPrice : groupedByName[p].totalPrice
                }
            })
            return{
                products:groups,
                totalPrice:showCost()
            }
        }

        return {
            products: products,
            add: add,
            remove: remove,
            showCost: showCost,
            showProductTypes: showProductTypes,
            getInfo: getInfo
        };
    }

    return {
        getProduct: getProduct,
        getShoppingCart: getShoppingCart
    };
}

module.exports = solve();
//const result = solve();
//let cart = result.getShoppingCart()
//let pr1 = result.getProduct("Sweets", "Shokolad Milka", 2);
//let pr2 = result.getProduct("Alkoxol", "Teachers", 15.50);
//let pr3 = result.getProduct("Chips", "Pringles", 3.50);
//let pr4 = result.getProduct("Nuts", "Almonds ", 2.80);
//let pr5 = result.getProduct("Drinks", "Red Bull", 2);
//let pr6 = result.getProduct("Cigarettes", "Marboro White", 6.50);
//let pr7 = result.getProduct("Sweets", "Shokolad Milka", 2);
//cart.add(pr1).add(pr2).add(pr3).add(pr4).add(pr5).add(pr6).add(pr7).add(pr6);
//cart.remove(pr4).remove(pr6);//Remove almonds and Marlboro
//cart.add(pr4).add(pr6);
//console.log(cart.products);
//console.log(cart.showCost());
//console.log(cart.showProductTypes());
//console.log(cart.getInfo());

