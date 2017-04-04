let catalog = {};

let div = document.createElement('div');
div.id = 'Catalog';
let ul = document.createElement('ul');
div.innerHTML = "Catalog";

let furnitures = ['Table', 'Chair', 'Lamp', 'PC', 'Door'];

for (let i = 0; i < 5; i += 1) {
    let li = document.createElement('li');
    li.innerHTML = furnitures[i];
    let dis = i % 2 === 0;
    var x;
    if (dis) {

        x = ((x + 1) / 100) * 85 || 37;
    }
    else {
        x = (i + 1) * 23 * 1.5;
    }
    catalog[i] = {
        id: i,
        names: furnitures[i],
        discount: dis,
        price: x
    };
    ul.appendChild(li);

}

function giveMeCheapest(items) {
    let cheapestPrice = 9999;
    let x = [];
    for (var item in items) {
        if(items[item].price<cheapestPrice){
            cheapestPrice = items[item].price;
            x.push(items[item]);
        }
    }
    return x;
}
let promise = new Promise((resolve, reject)=> {
    resolve(giveMeCheapest(catalog));
    reject("Site is broken");
})


div.appendChild(ul);
document.body.appendChild(div);


promise
    .then(function (data) {
        let sale = document.getElementById('onsale');
        sale.style.color='blue';
        sale.innerHTML+=data[0].names.toLowerCase()+" "+data[0].price+" bgn";
    })
    .catch(function (error) {
        console.log(error)
    })

