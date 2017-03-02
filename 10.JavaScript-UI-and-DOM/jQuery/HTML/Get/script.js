$(document).ready(function(){
    $("#btn1").click(function(){

        var input = $('div').text();
        $('#result').append(input);
    });
    $("#btn2").click(function(){
        var input = $('div').html();
        console.log(input)
        $('#result').append(input);
    });
    $("#btn2").click(function(){
        var input =  $("#test").val();
        console.log(input)
        $('#result').append(input);
    });
    $("#btn3").click(function(){
        $('#result').append($('#telerik').attr("href"));
    });

});