(function () {
    var btn = document.getElementById("btn-add-item");
    var list = document.getElementById("list");

    function formatTime(date) {


        function checkIfBiggerThanTen(dateParams) {
            var b = dateParams / 10 > 0 ?  ""+dateParams : "0"+dateParams;
            return b;
        }

        var hours,
            hoursString,
            minutes,
            minutesString,
            seconds,
            secondsString;

        if(!date){
            date = new Date();
        }

        hours = date.getHours();
        minutes = date.getMinutes();
        seconds = date.getSeconds();

        hoursString =  checkIfBiggerThanTen(hours);
        minutesString = checkIfBiggerThanTen(minutes);
        secondsString = checkIfBiggerThanTen(seconds);

        return `${hoursString}:${minutesString}:${secondsString}`
    }

    btn.addEventListener("click",function (x) {
        var time = formatTime();
        console.log(time);
        list.innerHTML += "<li class='list-item'>" + time + "</li>";
    })
})();
