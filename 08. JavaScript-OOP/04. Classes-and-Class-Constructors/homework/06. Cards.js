(function () {
    let Suits = {
        CLUBS: "\u2663",
        DIAMONDS: "\u2666",
        HEARTS: "\u2665",
        SPADES: "\u2660",
    };
    let face = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }

        get face() {
            return this._face
        }
        set face(value) {
            if(!isFaceValid(value)){
                throw new Error (`Invalid card face ${value}`)
            }
            this._face=value;
        }

        get suit(){return this._suit};
        set suit(value){
            isSuitValid(value);
            this._suit=value;}


        toString(){
            return `${this.face}${this.suit}`
        }
    }

    function isFaceValid(card) {
        for(let i of face){
            if(i===card){
                return true;
            }
        }
        return false;

    }
    function isSuitValid(card) {
            let k = Object.keys(Suits).map(b=>Suits[b]);
         if(!k.includes(card)){
             throw new Error('Invalid Card');
         }
    }

    //return {
    //    Face:this.face,
    //    Suits:this.suit
    //}

    let card = new Card("Q",Suits.DIAMONDS);//Q♦
    //card = new Card("1",Suits.DIAMONDS);//Error
    //card = new Card("A",Suits.Pesho);//Error
    //card = new Card("A",'hearts');//Error
    console.log('' + card);




}());









