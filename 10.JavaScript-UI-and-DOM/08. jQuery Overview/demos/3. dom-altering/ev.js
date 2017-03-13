function printMessage(text) {
    $('#messages-list').append('<li>Message: <strong>' + text + '</strong></li>');
}
function onButtonClick() {
    $('.current').removeClass('current');
    $(this).addClass('current');
}
function onInputChange() {
    let msg = `input  value changed to ${$(this).val()}`
    printMessage(msg);
}
function onOptimizedClick() {
    let msg = $(this).text()+" clicked";
    printMessage(msg);
}

$(document).ready(function () {
    $('#tb-text').on('change',onInputChange);
    $('ul.buttons-group').on('click','a',onOptimizedClick);
    
})