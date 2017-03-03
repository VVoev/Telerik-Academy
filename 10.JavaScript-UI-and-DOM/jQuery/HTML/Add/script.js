$(document).ready(function () {
    $('#addCar').click(function () {
        var input = $('input').val();
        $('ol').append(`<li>${input}</li>`);
    })
    $('#addCar2').click(function () {
        var input = $('input').val();
        $('ol').prepend(`<li>${input}</li>`);
    })
    $('#addMulti').click(function () {
        appendText();
    })
    $('#insertFront').click(function () {
        $('#first').before("<img src=cola.jpg>")
    })
    $('#insertAfter').click(function () {
        $('#first').after("<img src=ice.jpg>")
    })

})
function appendText() {
        var input = $('input').val();
        var txt1 = `<p>${input} with HTML</p>`            // Create text with HTML
        var txt2 = $("<p></p>").text(input +" Jquery");  // Create text with jQuery
        var txt3 = document.createElement("p");
        txt3.innerHTML = input+" DOM";               // Create text with DOM
        $("body").append(txt1, txt2, txt3);     // Append new elements
}

