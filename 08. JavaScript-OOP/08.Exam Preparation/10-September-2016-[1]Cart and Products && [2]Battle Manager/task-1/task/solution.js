function solve(){
    class Product{
        constructor(productType,name,price){
            this._productType = productType;
            this._name = name;
            this._price = price;
        }
        get productType(){
            return this._productType;
        }
        get name(){
            return this._name;
        }
        get price(){
            return this._price;
        }
    }

    class ShoppingCart {
        constructor(){
            this._products = [];
        }

        get products(){
            return this._products;
        }

        add(product){
            this._products.push(product);
            return this;
        }

        remove(product){
            let index = this._products.findIndex(
                x=>x.name === product.name &&
                x.productType === product.productType &&
                x.price === product.price);
            if(index<0){
                throw 'There is no such product'
            }
            this.products.splice(index,1);

            return this;
        }

        showCost(){
            return this.products.reduce((a,b)=>a+b.price,0);
        }

        showProductTypes(){
            let uniq = this.products.map(x=>x.productType).sort().filter((p, i, ps) => i === 0 || p !== ps[i - 1]);
            return uniq;
        }

        getInfo(){

            let groupedProducts = {};
            this.products.forEach(p=>{
                if(groupedProducts.hasOwnProperty(p.name)){
                    groupedProducts[p.name].quantity +=1;
                    groupedProducts[p.name].totalPrice += p.price;
                }
                else{
                    groupedProducts[p.name] ={
                        //type:p.productType,
                        name:p.name,
                        quantity:1,
                        totalPrice:p.price
                    }
                }
            })

            const groups = Object.keys(groupedProducts)
                .sort()
                .map(x=>{
                    return{
                        name:[x],
                        quantity:groupedProducts[x].quantity,
                        totalPrice:groupedProducts[x].totalPrice,
                        //type:groupedProducts[x].type
                    }
                })


            return{
                products:groups,
                totalPrice:this.showCost()
            }
        }



    }

    return {
        Product:function (productType,name,price) {
            return new Product(productType,name,price);
        },
        ShoppingCart:function () {
            return new ShoppingCart();
        }
    };
}

let result = solve();
var pr1 = result.Product("Alkoxol","Jack Daniels",35);
var pr2 = result.Product("Drinks","Coca Cola",2.8);
var pr3 = result.Product("Chips","Pringles",5);
var pr4 = result.Product("Energy Drinks","Red Bull",3);
var pr5 = result.Product("Chocolate","Lind",3.3);
var cart =result.ShoppingCart();
cart.add(pr1).add(pr2).add(pr3).add(pr4).add(pr5).add(pr1);
//console.log(cart.showProductTypes());
//console.log(cart.getInfo().totalPrice)
console.log(cart.getInfo().products)


