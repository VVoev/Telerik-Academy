$(document).ready(function(){
    $("#hideAll").click(function(){
        $("p").hide(2000);
    });
    $("#showAll").click(function(){
        $("p").show(1500);
    });
    $("#hide").click(function () {
        var p = document.querySelectorAll('p');
        for(let i of p){
            $(i).hide(1000);
            break;
        }

    })
    $("#show").click(function () {
        $("#hide").show();
    })
    
    $("#changeColor").click(function () {
        $("div").hide(300);
        $("div").css("background-color","red")
        $("div").show(1500);

    })
});
