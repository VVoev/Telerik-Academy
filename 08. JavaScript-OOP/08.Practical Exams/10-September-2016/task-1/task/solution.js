function solve(){

    class Product{

        constructor(productType,name,price){
            this.productType = productType;
            this.name = name;
            this.price = price;
        }


    }

    class ShoppingCart {

        constructor(){
            this.products = [];
        }

        add(product){
            this.products.push(product);
            return this;
        }

        remove(product){
           console.log(this.products[4])
           let index = this.products.findIndex(p=>p.name === product.name &&
                                      p.productType === product.productType &&
                                      p.price === product.price)
            if(index<0){
                throw('Such product does not exist');
            }
            this.products.splice(index,1)
            return this;
        }

        showCost(){
            return this.products.reduce((a,b)=>a+b.price,0)

        }

        showProductTypes(){
            var uniqueProducts = [];
            this.products.forEach(function (product) {
                if(!uniqueProducts.includes(product.productType)){
                    uniqueProducts.push(product.productType);
                }
            })
            return uniqueProducts.sort();
            //uniqueProducts.sort((a,b)=>a.localeCompare(b));
        }

        getInfo(){

            const groupedByname = {};

            this.products.forEach(p=>{
                if(groupedByname.hasOwnProperty(p.name)){
                    groupedByname[p.name].quantity +=1;
                    groupedByname[p.name].totalPrice +=p.price;
                }
                else{
                    groupedByname[p.name] = {
                        name:p.name,
                        quantity:1,
                        totalPrice:p.price
                    }
                }
            });

            const groups = Object.keys(groupedByname).sort().map(x=>{
                return {
                    name:x,
                    quantity:groupedByname[x].quantity,
                    totalPrice:groupedByname[x].totalPrice
                }
            })




            return {
                products:groups,
                totalPrice:this.showCost()
            }
        }





    }

    return {
        Product, ShoppingCart
    };
}
//module.exports = solve;
let {Product, ShoppingCart} = solve();

let cart = new ShoppingCart();

let pr1 = new Product("Alkoxol", "Jack Daniels", 28.20);
let pr2 = new Product("Sweets", "Lind", 3.20);
let pr3 = new Product("Cigari", "Marlboro", 6.20);
let pr4 = new Product("Gyms", "Orbit", 1.20);
let pr5 = new Product("Drinks", "Stela", 2.20);
let pr6 = new Product("Drinks", "Red Bull", 3.50);
let pr7 = new Product("Food", "Chio Chips", 1.80);
cart.add(pr2).add(pr2).add(pr2).add(pr5).add(pr1).add(pr4);
cart.remove(pr4);
console.log(cart.showCost())
console.log(cart.showProductTypes())
console.log(cart.getInfo())
