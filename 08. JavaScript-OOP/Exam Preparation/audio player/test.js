function solve() {
    var module = (function () {
        var playlist,
            playable,
            audio,
            video,
            validator,
            CONSTANTS = {
                        TEXT_MIN_LEN:3,
                        TEXT_MAX_LEN:25,
                        IMDB_MIN_RAT:1,
                        IMDB_MAX_RAT:5

            }

        //Validator
        validator={
                    validateIfUndefined:function (val,name) {
                        name = name || "Value";
                        if(val === undefined){
                            throw new Error(`${name} cannot be undefined`)
                        }
                    },

                    validateString:function (val,name) {
                        name = name || 'Value';
                        this.validateIfUndefined(val,name)
                        if(typeof val!=="string"){
                            throw new Error(`${name} must be a string`);
                        }

                        if(val.length<CONSTANTS.TEXT_MIN_LEN || val.length>CONSTANTS.TEXT_MAX_LEN){
                            throw new Error(`${name} must be between ${CONSTANTS.TEXT_MIN_LEN} and ${CONSTANTS.TEXT_MAX_LEN} symbols`)
                        }

                    },

                    validatePositiveNumber:function (val,name) {
                        this.validateIfUndefined(val,name);
                        this.validateIfNumber(val,name);

                        if(val<=0){
                            throw new Error(name + "must be a positive number")
                        }

                    },
            
                    validateIfNumber:function (val,name) {
                        name = name || 'Value';
                        if(typeof val !=='number'){
                            throw new Error `${name} is not a number`
                        }
                    },
            
                    validateImdbRating:function (val) {
                        this.validateIfUndefined(val,"IMDB Rating");
                        this.validateIfNumber(val,'IMDB Rating');

                        if(val<CONSTANTS.IMDB_MIN_RAT || CONSTANTS.IMDB_MAX_RAT<val){
                            throw new Error(`IMDB Rating must be between ${CONSTANTS.IMDB_MIN_RAT} and ${CONSTANTS.IMDB_MAX_RAT}`)
                        }
                        
                    }
        };


        //Module Playable
         playable = (function () {
            var currentPlayableId=0;
            var playable = Object.create({});

            //Constructor playable
            Object.defineProperty(playable,'init',{
                value:function (title,author) {
                    this.title=title;
                    this.author=author;
                    this._id = ++currentPlayableId;
                    return this;
                }
            });

            //Properties
            Object.defineProperty(playable,'id',{
               get:function () {
                   return this._id;
               }
            });

            Object.defineProperty(playable,'title', {
                get:function () {
                    return this._title;
                },
                set:function (val) {
                    validator.validateString(val,"Playable Title");
                    this._title = val;

                }
            });

            Object.defineProperty(playable,'author', {
                get:function () {
                    return this._author;
                },
                set:function (val) {
                    validator.validateString(val,"Playable Author");
                    this._author = val;
                }
            });

             //Method
            Object.defineProperty(playable,'play',{
                 value:function () {
                     return `${this._id}. ${this.title} - ${this.author}`
                 }
             });

            return playable;
        }());

        //Module Audio
        audio = (function (parent){
            var audio = Object.create(parent);

            //Constructor inherit from base CTOR
            Object.defineProperty(audio,'init',{
                value:function (title,author,lenght) {
                    //using ctor from base class
                    parent.init.call(this,title,author);
                    this.lenght = lenght;
                    return this;
                }
            });

            //Properties
            Object.defineProperty(audio,'lenght',{
                get:function () {
                    return this._lenght;
                },
                set:function (val) {
                    validator.validatePositiveNumber(val, "Audio Lenght");
                    this._lenght = val;
                }
            });

            //Methods
            Object.defineProperty(audio,'play',{
                value : function () {
                    return parent.play.call(this) + " - " + this.lenght;
                }
            })

            return audio;
        }(playable));
        
        //Module Video
        video = (function (parent){
            var video = Object.create(parent);

            //Ctor
            Object.defineProperty(video,'init',{
                value:function (title,author,imdbRating) {
                    parent.init.call(this,title,author);
                    this.imdbRating = imdbRating;
                    return this;
                }
            });

            //Properties
            Object.defineProperty(video,'imdbRating', {
                get:function () {
                    return this._imdbRating;
                },
                set:function (val) {
                    validator.validateImdbRating(val);
                    this._imdbRating = val;
                }
            });

            //Method
            Object.defineProperty(video,'play',{
                value:function () {
                    return parent.play.call(this) + ' - ' +this.imdbRating;
                }
            })

            return video;
        }(playable));




        //TODO IMPLEMENT FUNCTIONS
        return {
            getPlayer: function (name) {
                return Object.create(player).init(name);
            },
            getPlaylist: function (name) {
                return Object.create(playlist).init(name);
            },
            getAudio: function (title, author, length) {
                return Object.create(audio).init(title, author, length);
            },
            getVideo: function (title, author, imdbRating) {
                return Object.create(video).init(title, author, imdbRating);
            }
        };
    }());

    return module;
}
function makeFreeLines() {
    console.log("----------------------------------------------");
}
var module = solve();

//Test Data
for( var i = 1; i<=10; i++){
    var currentAudio = module.getAudio("Audio"+i,"Author"+i,i);
    console.log(currentAudio.play())
}
makeFreeLines()
for (var i = 1; i<=10;i++){
    var currentVideo = module.getVideo("Title"+i,"Authir"+i,3.5+(0.+i/10));
    console.log(currentVideo.play())
}
makeFreeLines()