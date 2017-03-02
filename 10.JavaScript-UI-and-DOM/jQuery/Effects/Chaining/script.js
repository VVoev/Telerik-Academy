$(document).ready(function () {
    $('button').click(function () {
        $('img').slideUp(2000,function () {
            $('img').css('width','400px').
            slideDown(2000).
            css('height','400px')
        })
    })
})