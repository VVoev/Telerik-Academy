$(document).ready(function(){
    $("#fadeOut").click(function(){
        $("#div1").fadeIn();
        $("#div2").fadeIn("slow");
        $("#div3").fadeIn(3000);
    });

    $("#fadeIn").click(function(){
        $("#div1").fadeOut();
        $("#div2").fadeOut("slow");
        $("#div3").fadeOut(1300);
    });
        var maybe = false;
    $("#toggle").click(function(){
        maybe = !maybe;
        if(maybe){
            $("#div1").toggle();
            $("#div2").toggle("slow");
            $("#div3").toggle(1300);
            $("#div1").css('background-color','red')
            $("#div2").css('background-color','#fffa06')
            $("#div3").css('background-color','#24ff44')
        }
        else{
            $("#div1").toggle(400);
            $("#div2").toggle("slow");
            $("#div3").toggle(1300);
            $("#div1").css('background-color','#68FAFF')
            $("#div2").css('background-color','#FF54E1')
            $("#div3").css('background-color','#CB8DFF')
        }


    });
});
