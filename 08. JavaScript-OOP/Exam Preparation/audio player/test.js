function solve() {
    var module = (function () {
        var playable,
            audio,
            validator,
            CONSTANTS = {
                        TEXT_MIN_LEN:3,
                        TEXT_MAX_LEN:25
            }

        //Validator
        validator={
                    validateString:function (val,name) {
                        name = name || 'Value';
                        if(val===undefined){
                            throw new Error(`${name} cannot be undefined`);
                        }

                        if(typeof val!=="string"){
                            throw new Error(`${name} must be a string`);
                        }

                        if(val.length<CONSTANTS.TEXT_MIN_LEN || val.length>CONSTANTS.TEXT_MAX_LEN){
                            throw new Error(`${name} must be between ${CONSTANTS.TEXT_MIN_LEN} and ${CONSTANTS.TEXT_MAX_LEN} symbols`)
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
        
}