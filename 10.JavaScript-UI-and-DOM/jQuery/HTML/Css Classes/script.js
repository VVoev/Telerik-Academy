$(document).ready(function () {
    $('#sortBMW').click(function () {
        $( "li:first-child, li:first-child+li").addClass("bmw");
        $( "li:first-child+li+li,li:first-child+li+li+li").addClass("mercedes");
        $( "li:last-child,li:nth-last-child(2)").addClass("audi")

    })

})
