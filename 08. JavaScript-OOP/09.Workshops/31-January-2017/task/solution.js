function solve() {
    function getProduct(productType, name, price) {

        return {
            productType:productType,
            name:name,
            price:price
        }
    }

    function getShoppingCart() {

        const products = [];

        function add(product) {
            products.push(product);
            return this;
        };

        function remove(product) {
            var index = products.findIndex(p => p.name===product.name &&
                                                p.productType ===product.productType &&
                                                p.price === product.price);
            if(index<0){
                throw`${product.name} is not found`;
            }
            else{
                products.splice(index,1);
            }
            return this;
        };

        function showCost() {
            // let price = 0 ;
            // for(let product of products){
            //     price += product.price;
            // }
            // return price;
            let cost = products.reduce((cost,product)=>cost+ product.price,0);
            return cost;
        }

        function showProductTypes() {
            let uniqueProducts = [];
            // for (const p of products){
            //     if(uniqueProducts.indexOf(p.productType)<0){
            //         uniqueProducts.push(p.productType);
            //     }
            // }

            // products.forEach(function (p) {
            //     if(uniqueProducts.indexOf(p.productType)<0){
            //         uniqueProducts.push(p.productType);
            //     }
            // })

            //return uniqueProducts.sort();

            // return products.map(p=>p.productType)
            //     .sort()
            //     .filter((p,i,ps)=> i===0 || p!==ps[i-1]);

            const uniqTypesObj = {};
            products.forEach(p => uniqTypesObj[p.productType]=true);
            return Object.keys(uniqTypesObj).sort();

        }

        function getInfo() {
            /*
            const uniqNames = products.map(p=>p.name)
              .sort()
              .filter((p,i,ps)=> i===0 || p!==ps[i-1])
                .map(name =>{
                    const withThisName = products.filter(p=>p.name===name);
                    return{
                        name:name,
                        quantity:withThisName.length,
                        totalPrice:withThisName.reduce((cost,product)=>cost+product.price,0)
                    }
                })
                */

            const groupedByName = {};
            products.forEach(p =>{
                if(groupedByName.hasOwnProperty(p.name)){
                    groupedByName[p.name].quantity += 1;
                    groupedByName[p.name].totalPrice += p.price;
                }
                else{
                   groupedByName[p.name] ={
                       name : p.name,
                       quantity : 1,
                       totalPrice : p.price
                   }
                }
            })
            const groups = Object.keys(groupedByName)
                .sort()
                .map(n=>{
                    return{
                        name:n,
                        quantity:groupedByName[n].quantity,
                        quantity:groupedByName[n].totalPrice
                    }
                })

            return {
                products:groups,
                totalPrice: showCost()
            }
        }


        return{
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

const result = solve();
const cart = result.getShoppingCart();
cart.add(result.getProduct("Chips", "Pringles", 4))
    .add(result.getProduct("Alkoxol","Jack Daniels",45.50))
    .add(result.getProduct("Alkoxol","Jack Daniels",45.50))
    .add(result.getProduct("Alkoxol","Jack Daniels",45.50))
    .add(result.getProduct("Alkoxol","Jack Daniels",45.50))
    .add(result.getProduct("EnergyDrinks","Red Bull",10.20));

cart.remove(result.getProduct("Chips", "Pringles", 4));
//cart.remove(result.getProduct("Sweets", "Lind", 4));

console.log(cart.products)
console.log(cart.showCost());
console.log(cart.showProductTypes());
console.log(cart.getInfo())
