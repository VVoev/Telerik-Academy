 function Album()  {

        let bgCounter = 0;
        var backgrounds = [
            "djingo.jpg",
        ];
        function changeBackground() {
            bgCounter = (bgCounter + 1) % backgrounds.length;
            $('body').css('background', '#000 url(' + backgrounds[bgCounter] + ') no-repeat');
            setTimeout(changeBackground, 3000);
        }
     return{
         photos:changeBackground()
     }


}

 $(document).ready(function () {


     $('#change').click(function () {
         $('#1').text('Java Script');
         $(".2").text('C#');
         $('input').val('Qko Techno');
         $('body').css('background', 'url("480.jpg") no-repeat');
     })
     $('#photos').click(function () {
        let result = Album();
     })
 })


