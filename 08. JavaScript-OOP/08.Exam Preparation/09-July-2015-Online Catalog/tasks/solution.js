function solve() {
    function* giveId() {
        var index = 0;
        while(true)
            yield ++index;
    }

    const idGenerator = giveId();

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
            
            this.description = description;
            this.name = name;
            this._id = idGenerator.next().value;
        }

        get name(){
            return this._name;
        }
        set name(value){
            validateLengthRange(value,2,40);
            this._name = value;
        }

        get description(){
            return this._description;
        }
        set description(value){
            validateNonEmpty(value);
            this._description = value;
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

        get name(){
            return this._name;
        }
        set name(value){
            validateLengthRange(value,2,40);
            this._name = value;
        }

        get items(){
            return this._items;
        }

        get id(){
            return this._id;
        }

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

        search(pattern){
            validateNonEmpty(pattern);
            return this._items.filter(item=>{
                return(
                    item.description.indexOf(pattern)>=0 ||
                    item.name.indexOf(pattern)>=0
                )
            })
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
            if(books.length === 0){
                throw 'There should be at least one book'
            }


            books.forEach(book=>{
                if(typeof book !== 'object'){
                    throw 'Item should be an object'
                }
                validateIsbn(book.isbn);
                validateLengthRange(book.genre,2,20);
            })

            return super.add(books);
            //return this
        }

        getGenres(){
            var uniqSet = new Set();
            this._items.forEach(book=>{
                uniqSet.add(book.genre.toLowerCase())
            })
            return Array.from(uniqSet);
        }

        find(args){
            if(typeof args === 'object'){
                const books = super.find(args);
                if(args.hasOwnProperty('genre')){
                    return books.filter(book=>book.genre === args.genre);
                }
                return books;
            }
         return super.find(args);
        }


    }

    class MediaCatalog extends Catalog{

        constructor(name){
            super(name);
        }

        add(...medias){
            if(Array.isArray(medias[0])) {
                medias = medias[0];
            }
            if(medias.length === 0){
                throw 'there should be at least one media'
            }
            
            medias.forEach(media=>{
                if(typeof media !== 'object'){
                    throw 'Media should be an object'
                }
                validateNumberBigger(media.duration,0);
                validateNumberRange(media.rating,1,5);
                
            });
            
            return super.add(medias);
            //return this
            
        }

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

        getSortedByDuration(){
            return this._items.slice().sort((a,b)=>{
                if(a.duration === b.duration){
                    return a.id>b.id;
                }
                return a.duration<b.duration;
            })
        }

        find(args){
            if(typeof args === 'object'){
                const medias = super.find(args);
                if(args.hasOwnProperty('rating')){
                    return medias.filter(media=>media.rating === args.rating);
                }
                return medias;
            }
            return super.find(args);
        }

    }




    return {
        getBook: function (name, isbn, genre, description) {
            return new Book(name,isbn,genre,description);
        },
        getMedia: function (name, rating, duration, description) {
            return new Media(name,rating,duration,description)
        },
        getBookCatalog: function (name) {
            return new BookCatalog(name);
        },
        getMediaCatalog: function (name) {
            return new MediaCatalog(name);
        },
        getItem:function (description,name) {
            return new Item(description,name);
        },
        getCatalog:function (name) {
            return new Catalog(name);
        }

    };
}

var result = solve();
var item = result.getItem("Best Phone","Iphone 7");
var item1 = result.getItem("Gaming Laptop","Asus Rog");
var item2 = result.getItem("Shoes for Runing","Mizuno");
var item3 = result.getItem("Table Tennis Equpment","Butterfly Blades")
var item4 = result.getItem("Table Tennis Equpment","Stiga Blades")
var item5 = result.getItem("Table Tennis Equpment","Tibhar Blades")
var book1 = result.getBook("Learn Programing C++",'1234567890',"IT","Book about C++");
var book2 = result.getBook("Learn JAVA",'1010101010',"JAVA PRograming","Book About JAva");
var book3 = result.getBook("Learn C#",'2020202020',"C# Programing","Book About C#");
var book4 = result.getBook("Learn JavaScript",'3030303030',"Js Programing","Book About Js");
var book5 = result.getBook("Learn JavaScript",'3040302010',"Js Programing","Book About Js 2nd Part");
var media1 = result.getMedia("Rihana",5,230,"Under my Umbrella");
var media2 = result.getMedia("Madona",4,300,"Frozen");
var media3 = result.getMedia("Riki Martin",3.2,150,"Da Vida Loka");
var media4 = result.getMedia("Azis",3.8,150,"Ice Queen");
var media5 = result.getMedia("Black Eeyed Peas",4.5,210,"Where`s The Love?");

var catalog = result.getCatalog("some Catalog");
var bookCatalog = result.getBookCatalog("Book Catalog");
catalog.add(item).add(item1).add(item2).add(item3).add(item4).add(item5);
bookCatalog.add(book1).add(book2).add(book3).add(book4).add(book5);
//console.log(bookCatalog.find({genre:"C# Programing"}));

var mediaCatalog = result.getMediaCatalog("Media Catalog");
mediaCatalog.add(media1).add(media2).add(media3).add(media4).add(media5);

console.log(mediaCatalog.find(13))


