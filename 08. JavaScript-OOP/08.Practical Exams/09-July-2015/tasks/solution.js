function solve() {

    function* getId() {
        let id = 0;

        while(true) {
            id += 1;
            yield id;
        }
    }
    const idGenerator = getId();

    function validateNonEmpty(str) {
        if(typeof str !== 'string' || str === '') {
            throw 'Str is not valid';
        }
    }
    function validateLengthRange(str, min, max) {
        if(typeof str !== 'string') {
            throw 'Str is not valid';
        }
        validateNumberRange(str.length, min, max);
    }
    function validateIsbn(isbn) {
        if(typeof isbn !== 'string' || !isbn.match(/^([0-9]{10}|[0-9]{13})$/)) {
            throw 'Isbn is not valid';
        }
    }
    function validateNumberRange(n, min, max) {
        if(typeof n !== 'number' || n < min || n > max) {
            throw 'Not a valid number';
        }
    }
    function validateNumberBigger(n, min) {
        if(typeof n !== 'number' || n <= min) {
            throw 'Not a valid number';
        }
    }

    class Item{

        constructor(description,name){
        this._id = idGenerator.next().value;
        this.description = description;
        this.name = name;
        }

        get description(){
            return this._description;
        }
        set description(value){
            validateNonEmpty(value);
            this._description = value;
        }

        get name(){
            return this._name;
        }
        set name(value){
            validateLengthRange(value,2,40);
            this._name = value;
        }

        get id(){
            return this._id;
        }

    }

    class Book extends Item{
        constructor(name,isbn,genre,description){
            super(description,name);
            this.isbn = isbn;
            this.genre = genre;
        }

        get isbn(){
            return this._isbn;
        }
        set isbn(value){
            validateIsbn(value);
            this._isbn = value;
        }

        get genre(){
            return this._genre;
        }
        set genre(value){
            validateLengthRange(value,2,20);
            this._genre = value;
        }

    }

    class Media extends Item{

        constructor(name,rating,duration,description){
        super(description,name);
        this.rating = rating;
        this.duration = duration;
        }

        get rating(){
            return this._rating;
        }
        set rating(value){
            validateNumberRange(value,1,5);
            this._rating = value;
        }

        get duration(){
            return this._duration;
        }
        set duration(value){
            validateNumberBigger(value,0);
            this._duration = value;
        }

    }

    class Catalog{

        constructor(name){
            this.name = name;
            this._id = idGenerator.next().value;
            this._items = [];
        }
        get id(){
            return this._id;
        }
        
        get items(){
            return this._items;
        }

        get name(){
            return this._name;
        }
        set name(value){
            this._name = value;
        }

        add(...items){
            if(Array.isArray(items[0])){
                items = items[0];
            }

            if(items.length === 0){
                throw 'There is no Items to be added';
            }

            items.forEach(item=>{
                if(typeof item !== 'object'){
                    throw 'Item Should be a object';
                }
                validateNonEmpty(item.description);
                validateLengthRange(item.name,2,40);
                validateNumberBigger(item.id,0);
            })

            this._items.push(...items);
            return this;
        }

        find(args){

            function findById(id) {
                if(typeof id !== 'number'){
                    throw 'You should provide number';
                }
                return this._items.filter(x=>x.id ===id) || null;
            }

            function findByOptions(options) {
                return this._items.filter(item=>{
                    return(
                        (!options.hasOwnProperty('name') || item.name === options.name) &&
                        (!options.hasOwnProperty('id')   ||   item.id === options.id)
                    )
                })

            }

            if(typeof args === 'object'){
                return findByOptions.call(this,args);
            }
            return findById.call(this,args);
        }

        search(pattern){
            if(typeof pattern !== 'string'){
                throw 'Invalid Search'
            }
            if(pattern.length<1){
                throw 'Search should be at least 1 char';
            }

                return this._items.filter(item=>{
                return(
                    item.name.indexOf(pattern)>=0 ||
                    item.description.indexOf(pattern)>=0);
            });
        }
    }

    class BookCatalog{

    }

    class MediaCatalog{

    }

    return {
        getBook: function (name, isbn, genre, description) {
            return new Book(name,isbn,genre,description)
        },
        getMedia: function (name, rating, duration, description) {
            return new Media(name,rating,duration,description);
        },
        getBookCatalog: function (name) {
            return new BookCatalog(name);
        },
        getMediaCatalog: function (name) {
            return new MediaCatalog(name);
        },
        //TEST DATA SHOULD BE DELETED
        getItem : function (description,name) {
            return new Item(description,name);
        },
        getCatalog : function (name) {
            return new Catalog(name);
        }
    };
}

//module.exports = solve();
var result = solve();
var item1 = result.getItem('For Woman','Gilette');
var item2 = result.getItem('Drink and Enjoy','Jack');
var item3 = result.getItem('Give you wings','RedBull');
var item4 = result.getItem('Not for kids','Durex');
var item5 = result.getItem('Cuttest Pets','Scotish Cat')
var book = result.getBook("Book Name",'1234567890',"Book Genre","Book Description");
var media = result.getMedia("Media name",3.5,300,"Media Description");
var catalog = result.getCatalog("Just Catalog");
console.log(book);
console.log(media);
catalog.add(item1).add(item2).add(item3).add(item4).add(item5);
console.log(catalog.find(5))
console.log(catalog.find({name:"Durex"}));
console.log(catalog.search('Xalva'));
