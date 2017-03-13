function printMessage(text) {
    $("#messages-list").append('<li>' + text + '</li>');
}
let special= $('.special').first();
printMessage(`I am your special ${special.css('color','red').text()}`);
printMessage(`parent id :${special.parent().attr('id')}`);
printMessage(`div id is :${special.parents("div").attr("id")}`)
printMessage(`special item: ${special.parents("#wrapper").attr('id')}`)
printMessage(`item kids count : ${$("#items-list").children().length}`)