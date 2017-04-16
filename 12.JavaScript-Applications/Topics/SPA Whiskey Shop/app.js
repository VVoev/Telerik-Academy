let sammyApp = Sammy('#root', function () {
    let content = $('#content');

    const kinveyBaseUrl = "https://baas.kinvey.com/";
    const kinveyAppKey = "kid_BkZElJp6x";
    const kinveyAppSecret = "f28b29d97c554c13ac9e3e9341b1b809";
    const kinveyAppAuthHeaders = {
        'Authorization': "Basic " +
        btoa(kinveyAppKey + ":" + kinveyAppSecret),
    };



    //this => sammy.application
    this.get('#/Login', function () {
        templates.get('login')
            .then(function (template) {
                //template -> handlebars.compile(tempalteString)
                content.html(template());
            }).then(function () {
            $("#btn-login").on('click', function () {
                let user = {
                    username: $('#tb-username').val(),
                    password: $('#tb-password').val(),
                }
                    $.ajax({
                        method: "POST",
                        url: kinveyBaseUrl + "user/" + kinveyAppKey + "/login",
                        headers: kinveyAppAuthHeaders,
                        data: user,
                        success: loginSuccess,
                        error: handleAjaxError
                    })
            })

            function loginSuccess(user) {
                templates.get('home')
                    .then(function (template) {
                        content.html(template());
                        sessionStorage.setItem("authToken",user._kmd.authtoken);
                        $('#loggedInUser').text(`Welcome, ${user.username}`)
                    });
            }


        })
    })

    this.get('#/Register', function () {
        templates.get('register')
            .then(function (template) {
                //template -> handlebars.compile(tempalteString)
                content.html(template());
            }).then(function () {
            $("#btn-register").on('click', function () {
                let user = {
                    username: $('#tb-username').val(),
                    password: $('#tb-password').val(),
                }
                $.ajax({
                    method: "POST",
                    url: kinveyBaseUrl + "user/" + kinveyAppKey + "/",
                    headers: kinveyAppAuthHeaders,
                    data: user,
                    success: registerSuccess,
                    error: handleAjaxError
                })

                function registerSuccess() {
                    alert("Succesfully Registered")
                }


            })
        });
    })

    this.get('#/Home', function () {
        templates.get('home')
            .then(function (template) {
                //template -> handlebars.compile(tempalteString)
                content.html(template());
            });
    })

    this.get('#/Buy', function () {
        templates.get('buy')
            .then(function (template) {
                //template -> handlebars.compile(tempalteString)
                content.html(template());
            });
    })


});

function handleAjaxError(error) {
    console.log(error)
}

$(function () {
    sammyApp.run('#/')
})