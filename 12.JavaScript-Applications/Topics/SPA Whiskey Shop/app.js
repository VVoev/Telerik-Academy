let sammyApp = Sammy('#root', function () {
    let content = $('#content');

    //this => sammy.application
    this.get('#/Login', function () {
        templates.get('login')
            .then(function (template) {
                //template -> handlebars.compile(tempalteString)
                content.html(template());
            });
    })

    this.get('#/Register', function () {
        templates.get('register')
            .then(function (template) {
                //template -> handlebars.compile(tempalteString)
                content.html(template());
            });
    })

    this.get('#/Home', function () {
        templates.get('home')
            .then(function (template) {
                //template -> handlebars.compile(tempalteString)
                content.html(template());
            });
    })


});

$(function () {
    sammyApp.run('#/')
})