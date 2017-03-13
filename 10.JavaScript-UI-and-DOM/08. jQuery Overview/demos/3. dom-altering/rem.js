
const count = 64;
let list = $('#items-list');
for(let i = 0; i<count; i+=1){
    list.append('<li>'+i+'</li>')
}

$('#delete-even').on('click',function () {
    list.find('li:even').remove();
});

$('#fade-button').on('click', function () {
    list.fadeOut(3000);
    list.fadeIn(3000);
});
$('#animate-button').on('click', function () {
    list.animate({
        height:"toggle"
    },4000,function () {
    })
});