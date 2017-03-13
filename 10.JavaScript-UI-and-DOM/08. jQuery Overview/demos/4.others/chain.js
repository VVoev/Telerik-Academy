function onSuccessButtonClick(ev) {
    var color = ['red','blue','green','pink','violet'];
    var number = Math.floor(Math.random(0,color.length)*color.length);
    var randomColor = color[number];
    $('#success-list').append(
        $('<li />')
            .addClass('success-item')
            .html('success')
            .css('color',randomColor)
            .css('font-size','23px'))

}
$('<button />')
    .addClass('btn-success')
    .html('Click for success!')
    .on('click', onSuccessButtonClick)
    .appendTo(document.body);