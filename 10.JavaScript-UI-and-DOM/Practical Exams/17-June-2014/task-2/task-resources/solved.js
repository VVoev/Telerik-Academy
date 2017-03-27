/* globals $ */
$.fn.gallery = function (columnsPerRow) {

    var columnsPerRow = columnsPerRow || 4;
    let $this = $(this);
    let $imageContainer = $this.find('.image-container');

    $imageContainer.each(function (index, elem) {
        if (index % columnsPerRow === 0) {
            $(elem).addClass('clearfix');
        }
    })


    $this.addClass('gallery');
    $this.find('.selected').hide();


};