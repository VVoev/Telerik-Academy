let sammyApp = Sammy('#root', function () {
    let content = $('#content');

    //this => sammy.application

    this.get('#/quit', function () {
        templates.get('quit')
            .then(function (template) {
                //template -> handlebars.compile(tempalteString)
                content.html(template());
            });
    })

    this.get('#/items', function () {
        templates.get('items')
            .then(function (template) {
                //template -> handlebars.compile(tempalteString)
                content.html(template());
            });
    })


});

$(function () {
    sammyApp.run('#/')
})