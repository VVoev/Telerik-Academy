function solve() {


    giveId = (function () {
        let counter = 0;
        return function () {
            counter+=1;
            return counter;
        }
    })()

    class Player{

        constructor(name){
            this.name = name;
            this._id = giveId();
            this._playlist = [];
        }

        get id(){
            return this._id;
        }

        get name(){
            return this._name;
        }
        set name(value){
            this._name = value;
        }
        
        /*
        addPlaylist(playlistToAdd)

        Adds a playlist to the player
        playlistToAdd must be a PlayList instance
        Otherwise, throw an error
        Enables chaining

        getPlaylistById(id)

        Finds and returns a playlist from the playlists in this player instance
        Returns null, if a playlist with the provided id is not contained in the player

        removePlaylist(id)

        Removes a playlists from this player instance, and the playlist must have an id equal to the provided id
        Enables chaining
        Throws an error, if a playlist with the provided id is not contained in the player
        */



        addPlaylist(playlistToAdd){
            this._playlist.push(playlistToAdd);
            return this;
        }

        getPlaylistById(id){
            var cp = this._playlist.filter(x=>x._id===id);
            if(cp.length === 0){
                return null;
            }
            return cp;
        }

        removePlaylist(id){
            var index = this._playlist.findIndex(x=>x._id===id);
            if(index<0){
                throw `Such ${id} does not exist`;
            }
            this._playlist.splice(index,1);
            return this;
        }




        listPlaylists(page, size){
             return this._playlist
                .slice()
                .splice(page * size, size);
        }

        contains(playable, playlist){

        }

        search(pattern){
            for(let i of this._playlist){
               var indexAuthor = i._playables.findIndex(x=>x.author===pattern);
                if(indexAuthor>=0){
                    return i._playables[indexAuthor];
                }
                var indexTitle = i._playables.findIndex(x=>x.title===pattern);
                if(indexTitle>=0){
                    return i._playables[indexTitle];
                }
                return 'Doesnt Exist';
            }
        }
    }

    class Playlist{

        constructor(name){
            this.name = name;
            this._id = giveId();
            this._playables = [];
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

        addPlayable(playable){
            this._playables.push(playable);
            return this;
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
            this._title = title;
            this._author = author;
            this._id = giveId();
        }
        get title(){
            return this._title;
        }
        get author(){
            return this._author;
        }
        get id(){
            return this._id;
        }

        play(){
            return `${this.id}. ${this.title} - ${this.author}`
        }
    }



    var module = {
        getPlayer: function (name){
            return new Player(name);
        },
        getPlaylist: function(name){
            return new Playlist(name);
        },
        getAudio: function(title, author, length){
            //returns a new audio instance with the provided title, author and length
        },
        getVideo: function(title, author, imdbRating){
            //returns a new video instance with the provided title, author and imdbRating
        },
        getPlayable: function (title,author){
            return new Playable(title,author);
        },
    };

    return module;
}

var module = solve();

var player = module.getPlayer('Ivan');
var playlist1 = module.getPlaylist("First PlayList");
var playlist2 = module.getPlaylist("Second PlayList");
var playlist3 = module.getPlaylist("Third PlayList");
var playable = module.getPlayable("Hits of 2017","Rihanna")
var playable2 = module.getPlayable("Hits of 2016","Riki Martin");
var playable3 = module.getPlayable("Hits of 2015","Ceca");
player.addPlaylist(playlist1).addPlaylist(playlist2).addPlaylist(playlist3);
player.removePlaylist(4);
playlist1.addPlayable(playable).addPlayable(playable2).addPlayable(playable3);
console.log(player.search("Hits of 2017"));



