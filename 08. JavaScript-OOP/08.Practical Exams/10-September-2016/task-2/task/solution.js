function solve() {
    'use strict';

    const ERROR_MESSAGES = {
        INVALID_NAME_TYPE: 'Name must be string!',
        INVALID_NAME_LENGTH: 'Name must be between between 2 and 20 symbols long!',
        INVALID_NAME_SYMBOLS: 'Name can contain only latin symbols and whitespaces!',
        INVALID_MANA: 'Mana must be a positive integer number!',
        INVALID_EFFECT: 'Effect must be a function with 1 parameter!',
        INVALID_DAMAGE: 'Damage must be a positive number that is at most 100!',
        INVALID_HEALTH: 'Health must be a positive number that is at most 200!',
        INVALID_SPEED: 'Speed must be a positive number that is at most 100!',
        INVALID_COUNT: 'Count must be a positive integer number!',
        INVALID_SPELL_OBJECT: 'Passed objects must be Spell-like objects!',
        NOT_ENOUGH_MANA: 'Not enough mana!',
        TARGET_NOT_FOUND: 'Target not found!',
        INVALID_BATTLE_PARTICIPANT: 'Battle participants must be ArmyUnit-like!'
    };

    const nextId = (function () {
        let counter = 0 ;
        return function () {
            counter+=1;
            return counter;
        }
    })();

    const Validator = {
        isString: function (x) {
            if (typeof x !== 'string') {
                throw  Error(ERROR_MESSAGES.INVALID_NAME_TYPE);
            }
        },
        isLengthInRange2_20: function (x) {
            if (x.length < 2 || x.length > 20) {
                throw  Error(ERROR_MESSAGES.INVALID_NAME_LENGTH);
            }
        },
        isConsistedOfValidSymbols: function (x) {
            if (x.match(/[^a-zA-Z ]/)) {
                new Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
            }
        },
        isValidMana: function (x) {
            if (typeof x !== 'number' || x <= 0) {
                new Error(ERROR_MESSAGES.INVALID_MANA);
            }
        },
        isValidEffect: function (x) {
            if (typeof x !== 'function' || x.length !== 1) {
                throw  Error(ERROR_MESSAGES.INVALID_EFFECT);
            }
        },
        validateAlignment: (function () {
            const validAlignment = ['good','neutral','evil'];
            return function (x) {
                if(validAlignment.indexOf(x) < 0){
                    throw Error('Alignment must be good, neutral or evil!');
                }
            }
        })(),
        isValidDamage : function (x) {
            if(typeof x !== 'number'
                   || x < 0
                   || x > 100){
                throw Error(ERROR_MESSAGES.INVALID_DAMAGE);
            }
        },
        isValidHealth : function (x) {
            if(typeof x !== 'number'
                || x < 0
                || x > 200){
                throw Error(ERROR_MESSAGES.INVALID_HEALTH);
            }
        },
        isValidCount: function (x) {
            if(typeof x !=='number' || x<0){
                throw Error(ERROR_MESSAGES.INVALID_COUNT);
            }

        },
        isValidSpeed: function (x) {
            if(typeof x !=='number' || x<0 || x>100){
                throw Error(ERROR_MESSAGES.INVALID_SPEED);
            }

        },


    }

    class Spell{
        constructor(name,manaCost,effect){
            this.name = name;
            this.manaCost = manaCost;
            this.effect = effect;
        }

        get name(){
            return this._name;
        }
        set name(value){
            Validator.isString(value);
            Validator.isLengthInRange2_20(value);
            Validator.isConsistedOfValidSymbols(value);
            this._name = value;
        }

        get manaCost(){
            return this._manaCost;
        }
        set manaCost(value){
            Validator.isValidMana(value);
            this._manaCost = value;
        }

        get effect(){
            return this._effect;
        }
        set effect(value){
            Validator.isValidEffect(value);
            this._effect = value;
        }
    }

    class Unit{
        constructor(name,alignment){
            this.name = name;
            this.alignment = alignment;
        }

        get name(){
            return this._name;
        }
        set name(value){
            Validator.isString(value);
            Validator.isLengthInRange2_20(value);
            Validator.isConsistedOfValidSymbols(value);
            this._name = value;
        }

        get alignment(){
            return this._alignment;
        }
        set alignment(value){
            Validator.validateAlignment(value);
            this._alignment = value;
        }
    }

    class ArmyUnit extends Unit{
        constructor(name,alignment,damage,health,count,speed){
            super(name,alignment);
            this._id = nextId();
            this.damage = damage;
            this.health = health;
            this.count = count;
            this.speed = speed;
        }
        get damage(){
            return this._damage;
        }
        set damage(value){
            Validator.isValidDamage(value);
            this._damage = value;
        }

        get health(){
            return this._health;
        }
        set health(value){
            Validator.isValidHealth(value);
            this._health = value;
        }

        get count(){
            return this._count;
        }
        set count(value){
            Validator.isValidCount(value);
            this._count = value;
        }

        get speed(){
            return this._speed;
        }
        set speed(value){
            Validator.isValidSpeed(value);
            this._speed = value;
        }

        get id(){
            return this._id;
        }

    }

    class Commander extends Unit{

        constructor(name,alignment,mana){
            super(name,alignment);
            this.mana = mana;
            this.spellbook = [];
            this.army = [];
        }

        get mana(){
            return this._mana;
        }
        set mana(value){
            Validator.isValidMana(value);
            this._mana = value;
        }

    }

    const battleManagagerData = {
        commanders : [],
    };
    
    Array.prototype.filterByProperty = function(query,propName) {
        if(!query.hasOwnProperty(propName)){
            return this;
        }
        const value = query[propName];
        return this.filter(x => x[propName]=== value);
    };


    const battlemanager = {
        getCommander: function(name, alignment, mana){
            return new Commander(name,alignment,mana);
        },

        getArmyUnit: function(options){

            // ES6
            // const {name,alignment,damage,health,count,speed} = options;
            return new ArmyUnit(options.name,options.alignment,options.damage,options.health,options.count,options.speed);

        },

        getSpell: function(name, manaCost, effect){
            return new Spell(name,manaCost,effect)
        },

        addCommanders: function(...commanders){
            battleManagagerData.commanders.push(...commanders);
            return this;
        },

        addArmyUnitTo: function(commanderName, armyUnit)    {
                battleManagagerData.commanders.find(c => c.name === commanderName).army.push(armyUnit);
            return this;
        },

        addSpellsTo: function(commanderName, ...spell){
            battleManagagerData.commanders.find(c => c.name === commanderName).spellbook.push(...spell);
            return this;

        },

        findCommanders: function(query){
            battleManagagerData.commanders.
                slice().
                filterByProperty(query,'name').
                filterByProperty(query,'alignment').
                sort((x,y)=>x.name.localeCompare(y.name));

        },

        findArmyUnitById: function(id){
            let unit;
           for (let c of battleManagagerData.commanders){
               const res = c.army.find(u => u.id);
               if(typeof res!== 'undefined'){
                   unit = res;
                   break;
               }

           }
        },

        findArmyUnits: function(query){

        },

        spellCast: function(casterName, spellName, targetUnitId){

        },

        battle: function(attacker, defender){

        }

    };

    return battlemanager;
}

module.exports = solve();
