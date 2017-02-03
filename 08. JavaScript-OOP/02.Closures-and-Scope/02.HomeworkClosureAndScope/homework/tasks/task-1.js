/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/
function solve() {
	var library = (function () {
		var books = [];
		var categories = [];


		function listBooks() {
			if (arguments.length > 0) {
				if (arguments[0]['category']) {
					if (categories[arguments[0]['category']])
						return categories[arguments[0]['category']].books.sort(function (a, b) {
							return a.ID - b.ID;
						});
					return [];
				}

				if (arguments[0]['author']) {
					if (categories[arguments[0]['author']])
						return categories[arguments[0]['author']].books.sort(function (a, b) {
							return a.ID - b.ID;
						});
					return [];
				}
			}

			return books;
		}

		function addBook(book) {
			book.ID = books.length + 1;
			//Checks
			isValidTitleAndCategory(book['category']);
			isValidTitleAndCategory(book['title']);
			isValidAuthor(book['author']);
			isValidISBN(book['isbn']);
			isArgumentAlreadyExist(book);

			if(categories.indexOf(book['category'])<0){
				categories[book['category']]={
					ID:1,
					books:[book]
				};
			}
			else{
				categories[book]['category']['ID'] = categories.length+1;
				categories[book['category']]['books'].push(book);
			}
			books.push(book);
			return book;
		}

		function listCategories() {
			var category = [];
			for(var cat in categories){
				category.push(cat);
			}
			return category;
		}

		//Custom Functions
		function isValidTitleAndCategory(args) {
			if(args.length<2 || args.length>100){
				throw "Args should be between 2 and 100 symbols"
			}
		}

		function isValidAuthor(args) {
			if(!args.length>0 && !args.trim()){
				throw 'Error';
			}
		}
		
		function isValidISBN(args) {
			var regex = /^\d{10}|\d{13}$/;
			if(!args.match(regex)){
				throw "Error";
			}
		}

		function isArgumentAlreadyExist(args) {
			for(var book in books){
				if(args['isbn'] == books[book]['isbn']){
					throw  "Error";
				}
				if(args['title'] == books[book]['title']){
					throw "Error";
				}
			}
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());

	return library;
}
module.exports = solve;