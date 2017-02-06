/* Task Description */
/*
 * Create a module for a Telerik Academy course
 * The course has a title and presentations
 * Each presentation also has a title
 * There is a homework for each presentation
 * There is a set of students listed for the course
 * Each student has firstname, lastname and an ID
 * IDs must be unique integer numbers which are at least 1
 * Each student can submit a homework for each presentation in the course
 * Create method init
 * Accepts a string - course title
 * Accepts an array of strings - presentation titles
 * Throws if there is an invalid title
 * Titles do not start or end with spaces
 * Titles do not have consecutive spaces
 * Titles have at least one character
 * Throws if there are no presentations
 * Create method addStudent which lists a student for the course
 * Accepts a string in the format 'Firstname Lastname'
 * Throws if any of the names are not valid
 * Names start with an upper case letter
 * All other symbols in the name (if any) are lowercase letters
 * Generates a unique student ID and returns it
 * Create method getAllStudents that returns an array of students in the format:
 * {firstname: 'string', lastname: 'string', id: StudentID}
 * Create method submitHomework
 * Accepts studentID and homeworkID
 * homeworkID 1 is for the first presentation
 * homeworkID 2 is for the second one
 * ...
 * Throws if any of the IDs are invalid
 * Create method pushExamResults
 * Accepts an array of items in the format {StudentID: ..., Score: ...}
 * StudentIDs which are not listed get 0 points
 * Throw if there is an invalid StudentID
 * Throw if same StudentID is given more than once ( he tried to cheat (: )
 * Throw if Score is not a number
 * Create method getTopStudents which returns an array of the top 10 performing students
 * Array must be sorted from best to worst
 * If there are less than 10, return them all
 * The final score that is used to calculate the top performing students is done as follows:
 * 75% of the exam result
 * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
 */

function solve() {

	var Course = (function () {

		//validation functions
		function isValidTitle(title) {
			if(title!=='string' ||
			   title.match(/\s{2,}/)||
			   title.match(/^\s+[^\s]{1}.*$/) ||
			   title.match(/^[^\s]{1}.*\s+$/) ||
			   title===' ')
			{
				throw new Error('Invalid Title')
			}
		}

		function isValidPresentations(presentation) {
			if(!Array.isArray(presentation)|| presentation.length===0){
				throw new Error('It is not a Array');
			}
			for (var obj in presentation){
				isValidTitle(presentation[obj])
			}
		};

		function isValidStudentName(name) {
			if(typeof (name) !=='string'){
				throw new Error('Invalid Student name')
			}
			let details = name.split(/[ ]/);
			let firstName = details[0];
			let lastName = details[1];
			let len = details.length;
			let regex = /^[A-Z]{1}[a-z]*$/;
			if(!firstName.match(regex)||
			   !lastName.match(regex)||
		        len!==2)
			{
				throw new Error('Invalid Name')
			}
			return details;


		}

		function isValidID(ID,students) {
			if(isNaN(ID)){
				throw new Error('Invalid ID')
			}
			ID=Number(ID);
			if(ID<0 || ID>students.length){
				throw new Error('Not Valid ID')
			}

		}

		function isValidScore(score) {
			if(isNaN(score)){
				throw new Error('Score must be a number');
			}
			score = Number(score);

			if(!score){
				throw new Error('Score does not exist');
			}
		}

		function isStudentIDDublicated(arr) {
			var uniqueArr = arr.filter(function (item,pos) {
				return arr.indexOf(item==pos)
			});
			if(arr.length!==uniqueArr.length){
				throw new Error('Student with the same ID has been added twice or more');
			}

		}

		var Course = {
			init: function(title, presentations) {
				this.title = title;
				this.presentations = presentations;
				this.students = [];
				this.id=0;
				return this;
			},
			addStudent: function(name) {
				var details = isValidStudentName(name);
				console.log(this.students)
				this.students.push({
					firstname:details[0],
					lastname:details[1],
					id:++this.id
				})


			},

			getAllStudents: function() {
				return this.students.map(function (student) {
					return{
						firstname:student.firstname,
						lastname:student.lastname,
						id:student.id
					}
				}).slice()
			},

			submitHomework: function(studentID, homeworkID) {
				isValidID(studentID,this.students);
				isValidID(homeworkID,this.students);
			},

			pushExamResults: function(results) {
				if(!Array.isArray(results)){
					throw new Error('Result are not array');
				}
				var arr = [] ;
				for(var obj in results) {
					isValidID(results[obj].StudentID, this.students);
					isValidScore(results[obj].score)
					arr.push(results[obj].StudentID)
				}
				isStudentIDDublicated(arr);
			},

			getTopStudents: function() {
			}
		};


		return Course;

	}());
	//Course.init('test',['test test']);
	//Course.addStudent('Don Kihot');
	//Course.addStudent('Ivan Magare');
	//Course.addStudent('Mariq Otvarachkata');
	//Course.submitHomework(1,3)
	//console.log(Course.getAllStudents());
	//Course.pushExamResults([{StudentID: 1, score: 4}, {StudentID: 2, score: 5},
	//	                    {StudentID: 1, score: 6}]);
//
}
solve();


