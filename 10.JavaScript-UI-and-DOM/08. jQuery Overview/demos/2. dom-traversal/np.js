function printMessage(text) {
    $("#messages-list").append('<li>Message: ' + text + '</li>');
}
let specialItem = $(".special");
printMessage(`${specialItem.text()} with value ${specialItem.val()}`);
printMessage(`I am the previous ${specialItem.prev().text()}`);
printMessage(`I am the next ${specialItem.next().text()}`);
printMessage(`I am the sibling ${specialItem.nextSibling===undefined ? "Not Existing":`${specialItem.nextSibling()}`}`)

