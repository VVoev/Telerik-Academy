let sammyApp = Sammy('#root', function () {
    let content = $('#content');

    //this => sammy.application
    this.get('#/login', function () {
        templates.get('login')
            .then(function (template) {
                //template -> handlebars.compile(tempalteString)
                content.html(template());

                $('#btn-login').on('click', function () {
                    let user = {
                        name: $('#tb-username').val(),
                        password: $('#tb-password').val()
                    }

                })

                $('#btn-register').on('click', function () {

                })
            });
    })

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