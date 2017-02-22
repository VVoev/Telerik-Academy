
1.IdGenerator

function* giveId() {
        var index = 0;
        while(true)
            yield ++index;
    }
    const idGenerator = giveId();	
	this._id = idGenerator.next().value;
	
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
		
		