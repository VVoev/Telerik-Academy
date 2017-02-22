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
    
    function* getId() {
        let id = 0;

        while(true) {
            id += 1;
            yield id;
        }
    }

    const idGenerator = getId();

    const Validator = {
        validateString(str, name) {
            if(typeof str !== 'string') {
                throw Error(`${name} is not a string`);
            }
        },
        validateLength2_20(str, name) {
            if(str.length < 2 || str.length > 20) {
                throw Error(`${name} must be between between 2 and 20 symbols long!`);
            }
        },
        validateOnlyLatin(str, name) {
            if(str.match(/[^a-zA-Z ]/)) {
                throw Error(`${name} can contain only latin symbols!`);
            }
        },

        validatePositiveInteger(num, name) {
            if(typeof num !== 'number' || !(num > 0) || num !== (num | 0)) {
                throw Error(`${name} must be a positive integer number!`);
            }
        },
        validatePositiveBelow(num, name, upperBound) {
            if(typeof num !== 'number' || !(num >= 0 && num <= upperBound)) {
                throw Error(`${name} must be a positive number below ${upperBound}!`)
            }
        },

        validateAlignment(alignment, name) {
            if(alignment !== 'good' && alignment !== 'neutral' && alignment !== 'evil') {
                throw Error(`${name} must be good, neutral or evil!`);
            }
        }
    };

    class Spell {
        constructor(name, manaCost, effect) {
            this.name = name;
            this.manaCost = manaCost;
            this.effect = effect;
        }

        get name() {
            return this._name;
        }
        set name(name) {
            Validator.validateString(name, 'Name');
            Validator.validateLength2_20(name, 'Name');
            Validator.validateOnlyLatin(name, 'Name');

            this._name = name;
        }

        get manaCost() {
            return this._manaCost;
        }
        set manaCost(manaCost) {
            Validator.validatePositiveInteger(manaCost, 'Mana');

            this._manaCost = manaCost;
        }
    }

    class Unit {
        constructor(name, alignment) {
            this.name = name;
            this.alignment = alignment;
        }

        get name() {
            return this._name;
        }
        set name(name) {
            Validator.validateString(name, 'Name');
            Validator.validateLength2_20(name, 'Name');
            Validator.validateOnlyLatin(name, 'Name');

            this._name = name;
        }

        get alignment() {
            return this._alignment;
        }
        set alignment(alignment) {
            Validator.validateAlignment(alignment, 'Alignment');

            this._alignment = alignment;
        }
    }

    class ArmyUnit extends Unit {
        constructor(name, alignment, damage, health, count, speed) {
            super(name, alignment);

            this._id = idGenerator.next().value;
            this.damage = damage;
            this.health = health;
            this.count = count;
            this.speed = speed;
        }

        get id() {
            return this._id;
        }

        get damage() {
            return this._damage;
        }

        set damage(damage) {
            Validator.validatePositiveBelow(damage, 'Damage', 100);

            this._damage = damage;
        }

        get health() {
            return this._health;
        }

        set health(health) {
            Validator.validatePositiveBelow(health, 'Health', 100);

            this._health = health;
        }

        get count() {
            return this._count;
        }

        set count(count) {
            Validator.validatePositiveInteger(count, 'Count');

            this._count = count;
        }

        get speed() {
            return this._speed;
        }

        set speed(speed) {
            Validator.validatePositiveBelow(speed, 'Speed', 100);
            this._speed = speed;
        }
    }


    class Commander extends Unit{

        constructor(name, alignment, mana){
            super(name,alignment)
            this.mana = mana;
            this._spellbook = [];
            this._army = [];
        }

        get mana(){
            return this._mana;
        }
        set mana(value){
            Validator.validatePositiveInteger(value,'mana');
            this._mana = value;
        }

    }

    class Battlemanager{

        constructor(){
            this._comanders = [];
            this._armyunits = [];
        }

        get comanders(){
            return this._comanders;
        }

        get armyunits(){
            return this._armyunits;
        }

        getCommander(name, alignment, mana) {
            return new Commander(name, alignment, mana);
        }

        getArmyUnit(options) {
            return new ArmyUnit(options.name, options.alignment, options.damage, options.health, options.count, options.speed);
        }

        getSpell(name, manaCost, effect) {
            return new Spell(name, manaCost, effect);
        }

        addCommanders(...commanders){
            if(Array.isArray(commanders)){
                commanders = commanders[0];
            }
            this._comanders.push(...commanders);
            return this;
        }

        addArmyUnitTo(commanderName, armyUnit){
            let commander = this._comanders.find(x=>x.name === commanderName);
            if(commander === 'undefined'){
                throw'There is no such commander';
            }
            commander._army.push(armyUnit);
            return this;
        }

        addSpellsTo(commanderName, ...spells){
            let commander = this._comanders.find(x=>x.name === commanderName);
            if(commander === 'undefined'){
                throw'There is no such commander';
            }
            commander._spellbook.push(...spells);
            return this;
        }

        findCommanders(query){
            let find =  this._comanders.filter(x=>x.name === query.name || x.alignment === query.alignment)
            let names = find.map(x=>{
                return {
                    name:x.name,
                    alignment:x.alignment
                }
            })
            return names;
            //return this._commanders
            //    .filter(commander => Object.keys(query).every(prop => query[prop] === commander[prop]))//
        }

        findArmyUnitById(id){
            var unit;
             this._comanders.forEach(x=>{
                 x._army.find(y=>{
                     if(y.id === id){
                         unit = x._army[id-1];
                     }
                 })
             })
            return unit;
        }

        findArmyUnits(query) {
            return this._army_units
                .filter(unit => Object.keys(query).every(prop => query[prop] === unit[prop]));
        }

        battle(attacker, defender) {
            // still not clear what to do here
            let totalDamage = attacker.damage * attacker.count;
            let totalHealth = defender.health * defender.count;
            totalHealth -= totalDamage;
            defender.count = Math.ceil(totalHealth / defender.health);

            if (defender.count < 0) {
                defender.count = 0;
            }
        }
    }

    return  new Battlemanager;
}


var result = solve();
var comander1 = result.getCommander('Vlado','evil',150);
var comander2 = result.getCommander('Spas','evil',200);
var comander3 = result.getCommander('Kiro','neutral',40);
var armyUnit1 = result.getArmyUnit({
    name: 'Bear',
    alignment: 'evil',
    damage: 60,
    health: 25,
    speed: 50,
    count: 10
})
var armyUnit2 = result.getArmyUnit({
    name: 'Archer',
    alignment: 'good',
    damage: 25,
    health: 5,
    speed: 80,
    count: 2
})
var armyUnit3 = result.getArmyUnit({
    name: 'Elite Barbarians',
    alignment: 'good',
    damage: 42,
    health: 15,
    speed: 99,
    count: 2
})

var spell1 = result.getSpell('LightingBolt',50,"Lighting from the sky");
var spell2 = result.getSpell('FireBall',100,"Inferno Hell");
result._comanders.push(comander1);
result._comanders.push(comander2);
result._comanders.push(comander3);


result.addArmyUnitTo('Vlado',armyUnit1);
result.addArmyUnitTo('Vlado',armyUnit2);
result.addArmyUnitTo('Vlado',armyUnit3);

result.addSpellsTo('Vlado',spell1).addSpellsTo('Vlado',spell2);
//console.log(result.findCommanders({ name: 'Skumriq'}));
//console.log(result.findCommanders({ alignment: 'evil' }))
console.log(result.findArmyUnitById(1));