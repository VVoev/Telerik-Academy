
1.IdGenerator

function* getId() {
		let id = 0;

		while(true) {
			id += 1;
			yield id;
		}
	}

	const idGenerator = getId();
	
2.Add
add(...items){

            if(Array.isArray(items[0])){
                items = items[0];
            }

            if(items.length === 0 ){
                throw 'At least one items must be specifiec';
            }

            items.forEach(item=>{
                if(typeof item !== 'object'){
                    throw 'Item is not an object';
                }
                validateNumberBigger(item.id,0);
                validateLengthRange(item.name,2,40);
            })

            this._items.push(...items);
			return this;
            //items.forEach(item => this._items.push(item));
        }
		
3.Find By Args
find(args){

            function findById(id) {
                if(typeof id !== 'number'){
                    throw 'Provided parameter should be a number'
                }
                return this._items.filter(item=>item.id === id) || null;
            }

            function findByOptions(options) {

                return this._items.filter(item=>{
                    return(
                        (!options.hasOwnProperty('name') || item.name === options.name) &&
                        (!options.hasOwnProperty('id') || item.id === options.id)
                    )
                })
            }

            if(typeof args === 'object'){
                return findByOptions.call(this,args);
            }
            return findById.call(this,args);

        }
		
4.Search(pattern)

search(pattern){
            validateNonEmpty(pattern);
            return this._items.filter(item=>{
                return(
                    item.description.indexOf(pattern)>=0 ||
                    item.name.indexOf(pattern)>=0
                )
            })
        }		
		
5. Get specific value from a collection sorted and without dublications
getGenres() {
			return this._items
				.map(book => book.genre.toLowerCase())
				.sort()
				.filter((genre, index, genres) => genre !== genres[index - 1]);
		}
		getGenres(){
            var uniqSet = new Set();
            this._items.forEach(book=>{
                uniqSet.add(book.genre.toLowerCase())
            })
            return Array.from(uniqSet);
			
6.GetTop

getTop(count){
            if(typeof count !== 'number' || count<1){
                throw 'Invalid count';
            }
           var sorted = this.items.sort((a,b)=>a.rating>b.rating);
            var novi =sorted.map(x=>{
                return{
                    name:x.name,
                    id:x.id
                }
            })
            return novi.slice(0,count)
        }
		
7.SumTotal
showCost(){
            return this.products.reduce((a,b)=>a+b.price,0);
        }

8.GetInfo
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
				
				
9.Pagirane
listPlaylists(page, size){

			function SortingFunction(firstParameter, secondParameter) {
				return function (first, second) {
					if (first[firstParameter] < second[firstParameter]) {
						return -1;
					}
					else if (first[firstParameter] > second[firstParameter]) {
						return 1;
					}

					if (first[secondParameter] < second[secondParameter]) {
						return -1;
					}
					else if (first[secondParameter] > second[secondParameter]) {
						return 1;
					}
					else {
						return 0;
					}
				}
			}

			return this._playlist.slice()
				.sort(SortingFunction('name','id'))
				.slice(page*size,size);
		}
		
		
		