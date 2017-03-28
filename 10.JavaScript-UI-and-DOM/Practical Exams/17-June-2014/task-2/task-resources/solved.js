/* globals $ */
$.fn.gallery = function (columnsPerRow) {

    columnsPerRow = columnsPerRow || 4;

    let $gallery = $(this);
    let $imageContainer = $gallery.find('.image-container');
    let $galleryList = $gallery.children('.gallery-list');
    let $selected = $gallery.find('.selected');

    let $currentImage = $selected.find('#current-image');
    let $nextImage = $selected.find('#next-image');
    let $prevImage = $selected.find('#previous-image');

    $gallery.addClass('gallery');
    $selected.hide();

    $imageContainer.each(function (index, elem) {
        if (index % columnsPerRow === 0) {
            $(elem).addClass('clearfix');
        }
    });
    
    $galleryList.on('click','img',function () {
        let $this = $(this);
        let imgSrc = $this.attr('src');
        let index = $this.data('info');
        $('</div>').addClass('disabled-background').appendTo($gallery);
        $galleryList.addClass('blurred')
        $currentImage.attr('src',imgSrc);
        $selected.show();
    })

    $currentImage.on('click',function () {
        $selected.hide();
        $galleryList.removeClass('blurred')
    })









    function validateIfNumberInRange(elem) {
        if(elem>$imageContainer.length){
            elem=1;
            return elem;
        }
        if(elem<1){
            elem = $imageContainer.length;
            return elem;
        }
        return elem;
    }
};