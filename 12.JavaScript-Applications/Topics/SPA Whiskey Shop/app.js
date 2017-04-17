let sammyApp = Sammy('#root', function () {
    let content = $('#content');

    const kinveyBaseUrl = "https://baas.kinvey.com/";
    const kinveyAppKey = "kid_BkZElJp6x";
    const kinveyAppSecret = "f28b29d97c554c13ac9e3e9341b1b809";
    const kinveyAppAuthHeaders = {
        'Authorization': "Basic " +
        btoa(kinveyAppKey + ":" + kinveyAppSecret),
    };

    function changeView(view) {
        templates.get(view)
            .then(function (template) {
                //template -> handlebars.compile(tempalteString)
                content.html(template());
            })
    }

    function userIsNowLogged() {
        $('#linkLogin').hide();
        $('#linkRegister').hide();
    }

    //default view whenever you open the App
    changeView('home');

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
                        sessionStorage.setItem("authToken", user._kmd.authtoken);
                        $('#loggedInUser').text(`Welcome, ${user.username}`);
                        showInfo("Loggin Success");
                        changeView('home');
                        userIsNowLogged();
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
                    userIsNowLogged();
                    showInfo("Register Success");
                    changeView('home');
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
        $.ajax({
            method: "GET",
            url: kinveyBaseUrl + "appdata/" + kinveyAppKey + "/WhiskeyShop",
            headers: getKinveyUserAuthHeaders(),
            success: loadWhiskey,
            error: handleAjaxError
        });
        function loadWhiskey(items) {
            templates.fillItems('buy', items)
                .then(function (template) {
                    content.html(tem);
                })
        }
    })

    this.get('#/Sell', function () {
        let token = sessionStorage.getItem('authToken');
        if (token !== null) {
            changeView('sell');
        }
        else {
            showInfo('You need to be login/register in order to sell');
            changeView('login');
        }
    })

    $('#content').on('click', function (ev) {
        if(ev.target.id === "btn-sell"){
            let data = {};
            data.Brand = $('#tb-brand').val();
            data.Name = $('#tb-name').val();
            data.YearsOld = $('#tb-years').val();
            data.Price = $('#tb-price').val();

            $.ajax({
                method: "POST",
                url: kinveyBaseUrl + "appdata/" + kinveyAppKey + "/WhiskeyShop",
                headers: getKinveyUserAuthHeaders(),
                data: data,
                success: createNewWhiskey,
                error: handleAjaxError
            });

            function createNewWhiskey() {
                showInfo("Whiskey Created");
            }
        }
    })

});




function showInfo(message) {
    $('#infoBox').text(message);
    $('#infoBox').show();
    setTimeout(function () {
        $('#infoBox').fadeOut();
    }, 3000);
}

$('#linkLogout').on('click', function () {
    sessionStorage.clear();
    showInfo("Logout succesfully you are now redirecting to Home")
})

function handleAjaxError(error) {
    console.log(error)
}

function getKinveyUserAuthHeaders() {
    return {
        'Authorization': "Kinvey " +
        sessionStorage.getItem('authToken'),
    };
}

$(function () {
    sammyApp.run('#/')
})