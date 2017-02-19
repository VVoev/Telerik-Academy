function solve() {

	const getId = (function () {
		let counter = 0 ;
		return function () {
			counter +=1;
			return counter;
		}
	})();

	const Validator = {
		isStringEmpty : function (param,field) {
			if(param.length===0 || typeof param !== 'string'){
				throw `${field} should be a string`
			}
		},
		isStringInRange: function (min,max,x,field) {
			if(typeof x !=='string' || x.length<min || x.length>max){
				throw `${field} should be between ${min} and ${max} symbols long and should be string`
			}
		},
        isISBNValid : function (x) {
            let regex = /^([0-9]{10}|[0-9]{13})$/;
            if(!x.match(regex) || typeof x !== 'string'){
                throw 'Invalid ISBN';
            }
        },
        isValidDuration:function (x) {
            if(typeof x !== 'number' || x<1){
                throw 'Invalid Duration';
            }
        },
        isValidRating:function (x) {
            if(typeof x !== 'number' || x<1 || x>5){
                throw 'Invalid Rating';
            }
        },
        isNumberBigger(x,min){
            if( x<min){
                throw 'Not a valid Number';
            }
        },
	}

	class Item{
		constructor(description,name){
			this._id = getId();
			this.description = description;
			this.name = name;
		}

		get description(){
			return this._description;
		}
		set description(value){
			Validator.isStringEmpty(value,'description')
			this._description = value;
		}

		get name(){
			return this._name;
		}
		set name(value){
			Validator.isStringInRange(2,40,value,'name')
			this._name = value;
		}

        get id(){
            return this._id;
        }
	}

	class Book extends Item{
		constructor(name, isbn, genre, description){
            super(description,name);
            this.isbn = isbn;
            this.genre = genre;
        }

        get isbn(){
            return this._isbn;
        }
        set isbn(value){
            Validator.isISBNValid(value);
            this._isbn = value;
        }

        get genre(){
            return this._genre;
        }
        set genre(value){
            Validator.isStringInRange(2,20,value,'genre');
            this._genre = value;
        }
	}

	class  Media extends Item{

        constructor(name,rating,duration,description){
            super(description,name);

            this.rating = rating;
            this.duration = duration;
        }

        get rating(){
            return this._rating;
        }
        set rating(value){
            Validator.isValidRating(value);
            this._rating = value;
        }

        get duration(){
            return this._duration;
        }
        set duration(value){
            Validator.isValidDuration(value);
            this._duration = value;
        }

	}

	class  Catalog{
        constructor(name){
            this.name = name;
            this._id = getId();
            this._items = [];
        }

        get name(){
            return this._name;
        }
        set name(value){
            Validator.isStringInRange(2,40,value,'name');
            this._name = value;
        }

        add(...items){
            if(Array.isArray(items[0])){
                items = items[0];
            }
            if(items.length === 0){
                throw 'You should have at least one item'
            }

            items.forEach(function (item) {
                if(typeof item !== 'object'){
                    throw 'Item is not an object';
                }
                Validator.isNumberBigger(item.id,0);
                Validator.isStringInRange(2,40,item.name,'name');
                //Validator.isStringEmpty(item.description,'description');
            });


            this._items.push(...items);
        }

        find(arg){
            
            function findById(id) {
                if(typeof id !== 'number'){
                    throw 'Invalid ID';
                }
                return this._items.find(item=>item.id===id || null);
            }
            function findByOptions(options) {
                return this._items.filter(item => {
                    return (
                       (!options.hasOwnProperty('name') || item.name === options.name)
                    && (!options.hasOwnProperty('id') || item.id === options.id));
                });
            }

            if(typeof arg ==='object'){
                return findByOptions.call(this,arg);
            }
            return findById.call(this,arg);

        }

        search(pattern) {
            Validator.isStringEmpty(pattern,'pattern');

            /*Mine Variant
            let found = [];
            this._items.forEach(function (x) {
                if(x.name.indexOf(pattern)>0){
                    found.push(x);
                }
                if(x.description.indexOf(pattern)>0){
                    found.push(x);
                }
            })
            return found;
            */
            return this._items.filter(item =>
                item.name.indexOf(pattern)>=0
             || item.description.indexOf(pattern)>=0);
        }



	}

	class BookCatalog extends Catalog{

        constructor(name){
            super(name);
        }

        add(...books){
            if(Array.isArray(books[0])){
                books = books[0];
            }
            books.forEach(function (book) {
                if(typeof book !=='object'){
                    throw 'Item is not an object';
                }
                Validator.isISBNValid(book.isbn);
                Validator.isStringInRange(2,20,book.genre,'book');
            })

            return super.add(books);
        }
        getGenres(){
            /*
            var uniqGenres = [];
            this._items.forEach(function (book) {
                if(!uniqGenres.includes(book.genre)){
                    uniqGenres.push(book.genre.toLowerCase());
                }
            })
            return uniqGenres
            */
            return this._items.map(book =>book.genre.toLowerCase())
                .sort()
                .filter((genre, index, genres) => genre !== genres[index - 1]);
        }

        find(options){
            if(typeof options === 'object'){
                const books = super.find(options);
                if(options.hasOwnProperty('genre')){
                    return books.filter(book=>book.genre===options.genre);
                }
                return books;
            }
            return super.find(options);
        }

	}

	class MediaCatalog extends Catalog{

        constructor(name){
            super(name);
        }

        add(...medias){
            if(Array.isArray(medias[0])){
                medias = medias[0];
            }

            medias.forEach(media=>{
                if(typeof media !== 'object'){
                    throw 'Item is not an object';
                }
                Validator.isValidDuration(media.duration);
                Validator.isValidRating(media.rating);
            })
            return super.add(medias);
        }

        getTop(count){
            if(typeof count !== 'number' || count<1){
                throw 'Invalid count';
            }

            return this._items
                .slice()
                .sort((x,y)=>y.rating-x.rating)
                .slice(0,count)
                .map(x=>{
                    return{
                        name:x.name,
                        id:x.id
                    }
                })
        }

        getSortedByDuration(){
            return this._items
                .slice()
                .sort((x,y)=>{
                    if(x.duration === y.duration){
                        return x.id-y.id;
                    }
                    return y.duration - x.duration;
                });
        }

        find(options){
            if(typeof options === 'object'){
                const medias = super.find(options);
                if(options.hasOwnProperty('rating')){
                    return medias.filter(media=>media.rating===options.rating)
                }
                return medias;
            }

            return super.find(options);
        }

	}


	return {
		getBook: function (name, isbn, genre, description) {
			return new Book(name,isbn,genre,description);
		},
		getMedia: function (name, rating, duration, description) {
			return new Media(name,rating,duration,description);
		},
		getBookCatalog: function (name) {
			return new BookCatalog(name)
		},
		getMediaCatalog: function (name) {
			return new MediaCatalog(name);
		},
		//TODO TEST DATA FROM HERE
		getItem : function (description,name) {
			return new Item(description,name);
		},
        getCatalog : function (name) {
            return new Catalog(name);
        }
	};
}

//module.exports = solve;
var test = solve();
var item = test.getItem('Very nice book for cats','Djingal Book');
var item1 = test.getItem('Very nice book for dogs','Sharo Book');
//var invalid = test.getItem(1,'sa');//description should be string
//var invalid1 = test.getItem('','sa');/description cannot be emptry
//var invalid1 = test.getItem('1',111);//name should be string
//var invalid1 = test.getItem('vas','s');//nam should be between 2 and 40 symbols
console.log(item);
console.log(item1);

var book = test.getBook('Book About C++','1234567890','IT','Become a Developer');
var book1 = test.getBook('Book About JavaScript','1234567890123','Cooking','Become a  JS Developer');
var book2 = test.getBook('Book About Java','1234567890123','Java','Become a  Java Developer');
console.log(book);
console.log(book1);
//var invalid = test.getBook('some','123456789','IT',"some");//Invalid ISBN
//var invalid = test.getBook('some','12345678901234','IT',"some");//Invalid ISBN
//var invalid = test.getBook('xx','1234567890123','I','sasa')//Genre should be between 2 and 20 symbols
var media = test.getMedia('someName',5,1,'someDescription');
console.log(media);

var catalog = test.getCatalog('Catalog');
var item = [{name: 'Samsung Galaxy S2', id: 2,description:"newest Technology"}, {name: 'Peralnya Hubava', id: 3,description:"qka e"}, {name: 'Samsung Galaxy S2', id: 4,description:"old phone"}];
catalog.add(item)
console.log(catalog)
catalog.find({name: 'Samsung Galaxy S2'});
catalog.find({id: 2, name: 'Samsung Galaxy S2'});
console.log(catalog.find(2));
console.log(catalog.search('Technology'));

var bookCatalog = test.getBookCatalog('Book Catalog');
bookCatalog.add(book);
bookCatalog.add(book1)
bookCatalog.add(book2);
console.log(bookCatalog.getGenres())
console.log(bookCatalog.find(5))
console.log(bookCatalog.find({name:'Book About C++'}))
var media1 = test.getMedia('someName',3,120,'media1 description');
var mediaCatalog = test.getMediaCatalog("Media Catalog");
mediaCatalog.add(media1);
mediaCatalog.add(media);
console.log(mediaCatalog)
console.log(mediaCatalog.getTop(1))

console.log(mediaCatalog.getSortedByDuration())
console.log(mediaCatalog.find({name:'someName'}))






