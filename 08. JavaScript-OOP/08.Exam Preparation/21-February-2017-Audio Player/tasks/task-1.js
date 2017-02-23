function solve() {

	function* getId() {
		let id = 0;

		while(true) {
			id += 1;
			yield id;
		}
	}

	const idGenerator = getId();

	class Player{

		constructor(name){
			this.name = name;
			this._playlist = [];
			this._id = idGenerator.next().value;
		}

		get name(){
			return this._name;
		}
		set name(value){
			this._name = value;
		}

		get id(){
			return this._id;
		}

		addPlaylist(playlistToAdd){
			if(playlistToAdd.id === undefined){
				throw 'Invalid playlist'
			}
			this._playlist.push(playlistToAdd);
			return this;
		}

		getPlaylistById(id){
			let founded =  this._playlist.find(x=>x.id === id)
			if(founded === undefined){
				return null;
			}
			return founded;
		}

		removePlaylist(args){

			function findById(id) {
				if(typeof id !== 'number'){
					throw 'Provided parameter should be a number'
				}
				let index =  this._playlist.indexOf(item=>item.id === id);
				let number = index.id;
				this._playlist.splice(number,1);
			}

			function findByOptions(options) {

				let index = this._playlist.indexOf(item=>{
					return(
						(!options.hasOwnProperty('name') || item.name === options.name) &&
						(!options.hasOwnProperty('id') || item.id === options.id)
					)
				})
				this._playlist.splice(index,1);
			}
			if(typeof args === 'object'){
				return findByOptions.call(this,args);
			}
			return findById.call(this,args);

		}

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

		contains(playable, playlist){
			let found = false;
			let id = playable._id;
			let idList = playlist._id;
			this._playlist.forEach(x=>{
				if(x._id === idList){
					for(let i of x._playables){
						if(i._id === id){
							found =  true;
						}
					}
				}
			})
			return found;
		}

		search(pattern){
			let container = [];
			this._playlist.forEach(x=>{
				x._playables.forEach(y=>{
					if(y.title.includes(pattern)){
						container.push(x);
					}
				})
			})
			let indexes = container.map(x=>{
					return {
						name:x.name,
						id:x.id
					}
			})
			return indexes;
		}


	}

	class PlayList{

		constructor(name){
			this.name = name;
			this._id = idGenerator.next().value;
			this._playables = [];
		}

		get id(){
			return this._id;
		}

		addPlayable(playable){
			this._playables.push(playable);
			return this;
		}

		getPlayableById(id){

		}

		removePlayable(id){

		}

		removePlayable(playable){

		}

		listPlayables(page, size){

		}
	}

	class Playable{
		constructor(title,author){
			this._id = idGenerator.next().value;
			this.title = title;
			this.author = author;
		}

		play(){
			return `${this._id}. ${this.title} - ${this.author}`
		}
	}

	const module = {
		getPlayer: function (name){
			return new Player(name);
		},
		getPlaylist: function(name){
			return new PlayList(name);
		},
		getAudio: function(title, author, length){
			//returns a new audio instance with the provided title, author and length
		},
		getVideo: function(title, author, imdbRating){
			//returns a new video instance with the provided title, author and imdbRating
		},
		getPlayable:function (title,author) {
			return new Playable(title,author);
		}
	};

	return module;
}

var result = solve();
var player = result.getPlayer('Vlado');
var firstList = result.getPlaylist("Hits 2017");
var secondList = result.getPlaylist("Hits 2015");
var thirdList = result.getPlaylist("Retro 1990");
var fourthList = result.getPlaylist("Beatles 1965");
var firstPlayable = result.getPlayable("Izdislav","Fiki");
var secondPlayable = result.getPlayable("Frozen","Madona");
var thirdPlayable = result.getPlayable("Danza Kuduro","Don Omar");
var fourthPlayable = result.getPlayable("Ice QUeen","Azis");
var fivePlayable = result.getPlayable("Ice ICe Ice","Anonymonuys")
firstList.addPlayable(firstPlayable).addPlayable(secondPlayable).addPlayable(thirdPlayable).addPlayable(fourthPlayable);
secondList.addPlayable(fivePlayable);

player.addPlaylist(firstList).addPlaylist(secondList).addPlaylist(thirdList).addPlaylist(fourthList);
//console.log(player.getPlaylistById(2));
console.log(player.search("Ice"))
