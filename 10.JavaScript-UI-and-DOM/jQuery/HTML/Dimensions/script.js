$(document).ready(function(){
    $("#dimensions").click(function(){
        var txt = "";
        txt += "Width of div: " + $("#div1").width() + "</br>";
        txt += "Height of div: " + $("#div1").height()+ "</br>";
        txt += "Inner width of div: " + $("#div1").innerWidth() + "</br>";
        txt += "Inner height of div: " + $("#div1").innerHeight()+ "</br>";;
        txt += "Outer width: " + $("#div1").outerWidth() + "</br>";
        txt += "Outer height: " + $("#div1").outerHeight()+ "</br>";;
        $("#div1").html(txt);
    });
    $("#resize").click(function () {
        $("#div2").width(500).height(500);
    })
});