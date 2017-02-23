function solve() {

	const Validator = {

		validateString(str, name) {
			if(typeof str !== 'string') {
				throw Error
			}
		},
		validatePositiveInteger(num, name) {
			if (typeof num !== 'number' || !(num > 0) ) {
				throw Error();
			}
		},
		validateRating(num,name){
			if(typeof num !== 'number' || num<1 || num>10){
				throw Error();
			}
		},
		validateName(num,name){
			let regex = (/^[A-Z0-9a-z ]*$/)
			if(!num.match(regex)){
				throw Error();
			}
			if(num.length<1 || num.length>24){
				throw Error();
			}
		},
		validateIfNumber(x,name){
			if(typeof x !== 'number'){
				throw Error();
			}
		}

	}

	class App{

		constructor(name,description,version,rating){
			this.name = name;
			this.description = description;
			this.version = version;
			this.rating = rating;
		}

		get name(){
			return this._name;
		}
		set name(value){
			Validator.validateName(value,'name');
			this._name = value;
		}

		get description(){
			return this._description;
		}
		set description(value){
			Validator.validateString(value,'description');
			this._description = value;
		}

		get version(){
			return this._version;
		}
		set version(value){
			Validator.validatePositiveInteger(value,'version')
			this._version = value;
		}

		get rating(){
			return this._rating;
		}
		set rating(value){
			Validator.validateRating(value,'rating');
			this._rating = value;
		}

		release(args){

			function changeByNumber(number) {
				if(typeof number !== 'number'){
					throw Error();
				}
				if(this.version>number){
					throw Error();
				}
				this.version = number;
			}

			function changeByOptions(options) {
				let input = options.map(x=>{
					return{
						version:x.version,
						description:x.description,
						rating:x.rating
					}
				})
				let newVersion = input[0].version;
				let newDescription = input[0].description;
				let newRating = input[0].rating;
				if(newVersion === undefined){
					throw Error();
				}
				Validator.validateIfNumber(newVersion,'version');
				if(newVersion<this.version){
					throw Error();
				}
				this.version = newVersion;
				if(newDescription !== undefined){
					Validator.validateString(newDescription,'new description');
					this.description = newDescription;
				}
				if(newRating !== undefined){
					Validator.validateRating(newRating,'new rating');
					this.rating = newRating;
				}
			}

			if(typeof args === 'object'){
				return changeByOptions.call(this,args);
			}
			return changeByNumber.call(this,args);
		}
	}

	class Store extends App{

		constructor(name,description,version,rating){
			super(name,description,version,rating);
			this._apps = [];
		}

		get apps(){
			return this._apps;
		}

		release(args){
			return super.release(args);
		}

		uploadApp(app) {


			if (typeof app !== 'object') {
				throw Error();
			}
			let index = this._apps.filter(x=>x.name === app.name);

			if(index.length === 0){
				this._apps.push(app);
			}
			else{
				this._apps.forEach(x=>{
					if(x.name === app.name){
						x.version = app.version;
						x.description = app.description;
						x.rating = app.rating;
					}
				})
			}

			return this;
		}

		takedownApp(name){
			if(typeof name !== 'string'){
				throw Error();
			}
			let index = 0;
			let found = false;
			this._apps.forEach(x=>{
				if(x.name === name){
					this._apps.splice(index,1);
					found = true;
				}
				index+=1;
			})
			if(!found){
				throw Error();
			}
			return this;
		}

		search(pattern){
			if(typeof pattern !== 'string'){
				throw Error();
			}
			return this._apps.filter(item=>{
				return(
					//item.description.indexOf(pattern)>=0 ||
					item.name.toLowerCase().indexOf(pattern.toLowerCase())>=0
				)
			}).sort((a,b)=>a.name.localeCompare(b.name)).slice();
		}

		listMostRecentApps(count){
			var mostRecent = [];

			if(count === undefined){
				 count = 10;
			}
			let reversed = this._apps.reverse();

			for(let i = 0; i < count; i+=1){
				if(reversed[i] !== undefined){
					mostRecent.push(reversed[i]);
				}
			}

			return mostRecent

		}

		listMostPopularApps(count){
			var mostPopular = [];

			if(count === undefined){
				count = 10;
			}
			return this._apps.sort((x,y)=>x.rating<y.rating).slice(0,count);

		}
	}

	class Device{

		constructor(hostname,apps){
			this.hostname = hostname;
			this.apps = apps;
		}

		get hostname(){
			return this._hostname;
		}
		set hostname(value){
			if(typeof value !== 'string' || value.length<1 || value.length>32){
				throw Error();
			}
			this._hostname = value;
		}

		get apps(){
			return this._apps;
		}
		set apps(value){
			if(typeof value !== "object" || value === undefined){
				throw Error();
			}
			this._apps = value;
		}


		search(pattern) {
			if(typeof  pattern !== 'string' || pattern.length === 0){
				throw Error();
			}

				return this._apps._apps.filter(app=> {
					return (
						app.name.indexOf(pattern) >= 0
					)
				}).sort((a,b)=>a.name.localeCompare(b.name)).slice();
			}


		install(name){
				console.log(this._apps)
				let found = this._apps._apps.find(x=>x.name === name);
				if(found === undefined){
					throw Error();
				}
				this._apps.push(found);
				return this;
		}
		uninstall(name){
			let index = 0;
			let found = false;
			this._apps._apps.forEach(x=>{
				if(x.name === name){
					this._apps._apps.splice(index,1);
					found = true;
				}
				index++;
			})
			if(!found){
				throw Error();
			}
			return this;
		}

		listInstalled(){
			return this._apps._apps.sort((a,b)=>a.name.localeCompare(b.name)).slice();
		}

		update(){

			return this;
		}
	}

	return {
		createApp(name, description, version, rating) {
			return new App(name,description,version,rating)
		},
		createStore(name, description, version, rating) {
			return new Store(name,description,version,rating)
		},
		createDevice(hostname, apps) {
			return new Device(hostname,apps)
		}
	};
}

// Submit the code above this line in bgcoder.com
module.exports = solve;
//let result = solve();
//let app1 = result.createApp('Shazam',"Best app for identifuyigs a song",1,5);
//let app3 = result.createApp('Counter Strike',"Best Shooter Game",3,8);
//let app4 = result.createApp('ICook','Learn to cook while coding',4,7);
//let app2 = result.createApp('Shazam',"Improved Version",2,5);
//let app5 = result.createApp('Free Taxi','StartUp',1,5);
//let tesapp = result.createApp('Test app','Test Description',10,10);
//let version = [{version:5}];
//app4.release(version);
////console.log(app)
//
//let store = result.createStore("Itunes Store","Best Apps Are Here",1,9);
//let store2= result.createStore('test','some',1,5);
//store2.uploadApp(tesapp);
//store.uploadApp(app1).uploadApp(app3).uploadApp(app4).uploadApp(app5);
//store.uploadApp(app2);
////store.takedownApp('Test app');
////console.log(store)
////console.log(store.search('C'));
////console.log(store.listMostRecentApps())
////console.log(store.listMostPopularApps())
//let device = result.createDevice('some device',store);
////console.log(device.search('C'))
//device.uninstall('Free Taxi');
////console.log(device);
//console.log(device.listInstalled())



