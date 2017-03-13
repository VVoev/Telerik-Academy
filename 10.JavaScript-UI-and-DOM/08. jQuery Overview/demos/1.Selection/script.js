function print(text) {
    $('#message-list').append("<li>Message: <strong>"+text+"</strong></li>");
}
let items = $("ul li");
print(items.length)
print($('.widget').text())