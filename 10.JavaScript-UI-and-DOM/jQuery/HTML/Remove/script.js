$(document).ready(function () {
    $('#removeTop').click(function () {
        $('ol li').first().remove()
    })
    $('#removeBottom').click(function () {
        $('ol li').last().remove()
    })
})