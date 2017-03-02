$(document).ready(function(){
    $("#1").click(function(){
        $("p").hide("slow", function(){
            alert("After P is hidden it is initiated");
        });
    });
    $("#2").click(function(){
        $("p").hide("slow");
        alert("Before the P is Hidden");
    });
});

