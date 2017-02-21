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
			this._name = name;
			this._playLists = [];
		}

		get name(){
			return this._name;
		}

		addPlaylist(playlist){
			if(playlist.id === undefined){
				throw 'Not a valid playlist'
			}
			this._playLists.push(playlist);
			return this;
		}

		getPlaylistById(id){
			return this._playLists.filter(x=>x.id===id) || null;
		}


		removePlaylist(args){

			function removeById(id) {
				if(typeof id !== 'number'){
					throw 'You should provide number';
				}
				var index = this._playLists.filter(x=>x.id ===id) || null;
				if(index<0){
					throw ('Such id does not exist');
				}
				this._playLists.splice(index,1);
				return this;
			}

			function removeByOptions(options) {
				var exist  = this._playLists.filter(item=>item.name === options.name);

				if(exist<0){
					throw 'Such PlayList does not exist'
				};
				var number = exist[0].id;
				return removeById.call(this,number);

			}

			if(typeof args === 'object'){
				return removeByOptions.call(this,args);
			}
			return removeById.call(this,args);

		}

		listPlaylists(page, size){

		}

		contains(playable, playlist){
			if(playlist._playables.includes(playable)){
				return true;
			}
			return false;
		}

		search(pattern){

		}


	}

	class PlayList{

		constructor(name){
			this._name = name;
			this._id = idGenerator.next().value;
			this._playables = [];
		}

		get id(){
			return this._id;
		}

		get name (){
			return this._name;
		}

		add(playable){

			this._playables.push(playable);
			return this;
		}

		getPlayableById(id){

		}

		//TODO check because there are 2 methods
		removePlayable(id){

		}

		listPlayables(page, size){

		}

	}

	class Playable{

		constructor(title,author){
			this._title = title
			this._author = author;
			this._id = idGenerator.next().value;
		}

		play(){

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

//module.exports = solve;

var result = solve();
var player = result.getPlayer('VladoPlayer');
var playlist = result.getPlaylist('PlayList with hits');
var playlist2 = result.getPlaylist('Playlist with C++ Exams');
var playable1 = result.getPlayable('Hits 2017','Rihana');
var playable2 = result.getPlayable('Hits 2016','Madonna');
var playable3 = result.getPlayable('Hits 2015','Ceca');
var playable4 = result.getPlayable('Hits 2014','Vasko Pederasa');
playlist.add(playable1).add(playable2).add(playable3).add(playable4);
player.addPlaylist(playlist).addPlaylist(playlist2);
console.log(playlist);
console.log(player.getPlaylistById(3))
console.log(player);
//TODO Check Later Is Not Working Correctly
//player.removePlaylist({name:"Playlist with C++ Exams"});
console.log(player.contains(playable1,playlist))



