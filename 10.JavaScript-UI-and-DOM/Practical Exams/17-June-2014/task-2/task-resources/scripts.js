/* globals $ */
$.fn.gallery = function (columnsPerRow) {

    let columnPerRow = columnsPerRow || 4;
    let currentImage = $('#current-image');
    let previousImage = $('#previous-image');
    let nextImage = $('#next-image');


    let gallery = $('#gallery');
    gallery.addClass('gallery');


    let selected = gallery.children('.selected');
    selected.css('display', 'none');

    let imageContainer = $('.image-container');
    imageContainer.each(function (index, element) {
        if (index % columnPerRow === 0) {
            $(element).addClass('clearfix');
        }
    })

    let galleryList = $('.gallery-list');

    galleryList.on('click', 'img', function () {
        let $this = $(this);
        let number = parseInt($this.data('info'));
        galleryList.addClass('blurred');
        let div = $('<div>');
        div.addClass('disabled-background');
        gallery.append(div);
        let imageSrc = $this.attr('src');
        let prev = getPrevIndex(number);
        let next = getNextIndex(number);

        let prevImage = $('#previous-image');
        let prevSrc = prevImage.attr('src');
        let nextImage = $('#next-image');
        let nextSrc = nextImage.attr('src');
        prevImage.attr('src',prevSrc);
        nextImage.attr('src',nextSrc);


        currentImage = $('#current-image');
        currentImage.attr('src', imageSrc)
        selected.css('display', 'inline');
    })

    currentImage.on('click', function () {
        $('.selected').hide();
        galleryList.removeClass('blurred');
        $('.disabled-background').remove();
    })

    function getNextIndex(index) {
        index+=1;
        if(index>imageContainer.length){
            index = 1;
        }

        return index;
    }

    function getPrevIndex(index) {
        index-=1;
        if(index<=0){
            index = imageContainer.length;
        }
        return index;
    }


};