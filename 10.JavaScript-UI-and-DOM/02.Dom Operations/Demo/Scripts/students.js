(function () {
    var studentName = document.getElementById('student-name');
    var studentList = document.getElementById('student-list');


    var buttonAddStudent = document.getElementById('add-Student');
    var buttonAddRating = document.getElementById('rating');
    var buttonSortByRating = document.getElementById('sort-by-rating');

    buttonAddStudent.addEventListener('click',addStudentToList);
    buttonAddRating.addEventListener('click',addPlayersRating);
    buttonSortByRating.addEventListener('click',SortPlayersByRating);


    function addStudentToList(){
        var student = studentName.value;
        let li = document.createElement('li');
        li.innerHTML = student;
        studentList.appendChild(li);
        studentName.value = "";
    }

    function addPlayersRating() {
        var playersList = document.getElementById('student-list');
        var players = playersList.innerText.split("\n");
        playersList.innerHTML ="";
            players.forEach(x=>{
                let li = document.createElement('li');
                if(x.length<3){

                }else{
                    x += " :Rating "+generateRating();
                    li.innerHTML = x;
                    playersList.appendChild(li);
                }

       })
        function generateRating() {
            var random = Math.floor((Math.random() * 4000) + 1);
            return random;
        }
    }

    function SortPlayersByRating() {
        var playersList = document.getElementById('student-list');
        var allPlayers = [];
        var players = playersList.innerText.split("\n");
        for(let i of players){
            var regex = /[0-9]\d{0,}/
            var rating = i.match(regex);
            if(rating !== null){
                var details = rating.input.split(':');
                let name = details[0];
                let score = rating[0];
                allPlayers.push({
                    key:name,
                    rating:score
                })
            }
        }
        var sorted = allPlayers.sort((a,b)=>{
            return a.rating - b.rating;
        })

        playersList = document.getElementById('student-list');
        playersList.innerHTML ="";
        sorted.forEach(x=>{
            let li = document.createElement('li');
                li.innerHTML = `Name:${x.key}Rating: ${x.rating}`;
                playersList.appendChild(li);
            })
    }






})();
