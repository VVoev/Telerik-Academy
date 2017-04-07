function startApp() {

    const kinveyBaseUrl = "https://baas.kinvey.com/";
    const kinveyAppKey = "kid_Hy6bk5m6l";
    const kinveyAppSecret = "b0c665b064fd49d8ba0220311adab351";
    const kinveyAppAuthHeaders = {
        'Authorization': "Basic " +
        btoa(kinveyAppKey + ":" + kinveyAppSecret),
    };


    sessionStorage.clear(); // Clear user auth data

    showHideMenuLinks();

    showView('viewHome');

    // Bind the navigation menu links
    $("#linkHome").click(showHomeView);

    $("#formLogin").submit(loginUser);

    $("form").submit(function (e) {
        e.preventDefault()
    });

    // Bind the info / error boxes: hide on click
    $("#infoBox, #errorBox").click(function () {
        $(this).fadeOut();
    });

    // Attach AJAX "loading" event listener
    $(document).on({
        ajaxStart: function () {
            $("#loadingBox").show()
        },
        ajaxStop: function () {
            $("#loadingBox").hide()
        }
    });


    // Bind the form submit buttons
    $("#buttonLoginUser").click(loginUser);
    $("#buttonRegisterUser").click(registerUser);
    $("#buttonCreateBook").click(createBook);
    $("#buttonEditBook").click(editBook);


    // Bind the navigation menu links
    $("#linkHome").click(showHomeView);
    $("#linkLogin").click(showLoginView);
    $("#linkRegister").click(showRegisterView);
    $("#linkListBooks").click(listBooks);
    $("#linkCreateBook").click(showCreateBookView);
    $("#linkLogout").click(logoutUser);

    function registerUser() {
        let userData = {
            username: $('#formRegister input[name=username]').val(),
            password: $('#formRegister input[name=passwd]').val()
        };
        console.log(userData);
        $.ajax({
            method: "POST",
            url: kinveyBaseUrl + "user/" + kinveyAppKey + "/",
            headers: kinveyAppAuthHeaders,
            data: userData,
            success: registerSuccess,
            error: handleAjaxError
        })

    }

    function saveAuthInSession(userInfo) {
        let b = userInfo;
        let userAuth = userInfo._kmd.authtoken;
        sessionStorage.setItem('authToken', userAuth);
        let userId = userInfo._id;
        //TODO might lead to a problem cause we are keeping name instead of id
        sessionStorage.setItem('userName', userInfo.username);
        $('#loggedInUser').text(`Welcome, ${userInfo.username}`);
    }

    function showInfo(message) {
        $('#infoBox').text(message);
        $('#infoBox').show();
        setTimeout(function () {
            $('#infoBox').fadeOut();
        }, 3000);
    }

    function showError(errorMsg) {
        $('#errorBox').text("Error: " + errorMsg);
        $('#errorBox').show();
    }

    function registerSuccess(userInfo) {
        saveAuthInSession(userInfo);
        showHideMenuLinks();
        listBooks();
        showInfo(`${userInfo.username} succesfully registered`);
    }

    function handleAjaxError(response) {
        let errorMsg = JSON.stringify(response);
        if (response.readyState === 0)
            errorMsg = "Cannot connect due to network error.";
        if (response.responseJSON &&
            response.responseJSON.description)
            errorMsg = response.responseJSON.description;
        showError(errorMsg);
    }

    function createBook() {

    }

    function editBook() {

    }

    function showLoginView() {
        showView('viewLogin');
        $('#formLogin').trigger('reset');
    }

    function showRegisterView() {
        showView('viewRegister');
        $('#formRegister').trigger('reset');
    }

    function listBooks() {

    }

    function showCreateBookView() {
        $('#formCreateBook').trigger('reset');
        showView('viewCreateBook');
    }

    function logoutUser() {
        let check = loginUser();
        console.log(check)
        sessionStorage.clear();
        $('#loggedInUser').text('');
        showView('viewHome');
        showInfo('Logout Success');
        showHideMenuLinks();
    }

    function showHideMenuLinks() {

        $('#menu a').hide();
        //If we are logged
        if (sessionStorage.getItem('authToken')) {
            $('#linkHome').show();
            $('#linkListBooks').show();
            $('#linkCreateBook').show();
            $('#linkLogout').show();
        }
        //If we are not logged
        else {
            $('#linkHome').show();
            $('#linkLogin').show();
            $('#linkLogout').show();
            $('#linkRegister').show();
        }
    }

    function showView(viewName) {
        // Hide all views and show the selected view only
        $('main > section').hide();
        $('#' + viewName).show();

    }

    function showHomeView() {
        showView('viewHome');
        $('#formLogin').trigger('reset');
    }

    function loginUser() {
        let userData = {
            username: $('#formLogin input[name=username]').val(),
            password: $('#formLogin input[name=passwd]').val()
        };
        $.ajax({
            method: "POST",
            url: kinveyBaseUrl + "user/" + kinveyAppKey + "/login",
            headers: kinveyAppAuthHeaders,
            data: userData,
            success: loginSuccess,
            error: handleAjaxError

        })

        function loginSuccess(userInfo) {
            saveAuthInSession(userInfo);
            showHideMenuLinks();
            listBooks();
            showInfo('Login successful.');
        }

    }

    function listBooks() {
        $('#books').empty();
        showView('viewBooks');
        $.ajax({
            method: "GET",
            url: kinveyBaseUrl + "appdata/" + kinveyAppKey + "/bookStore",
            headers: getKinveyUserAuthHeaders(),
            success: loadBooksSuccess,
            error: handleAjaxError
        });

        function loadBooksSuccess(books) {
            showInfo('Books loaded.');
            if (books.length == 0) {
                $('#books').text('No books in the library.');
            }
            else {
                let table = $(`
                <table>
                    <tr>
                        <th>Title</th>
                        <th>Author</th>
                        <th>Description</th>
                        <th>Actions</th>
                    </tr>
                </table>`);
                console.log(books);

                for(let book of books){
                    let tr = $('<tr>');
                    tr.append(
                        $('<td>').text(book.title),
                        $('<td>').text(book.author),
                        $('<td>').text(book.information),
                        $('<td>').append($('<a href="#">[Delete]</a>')).append($('<a href="#">[Edit]</a>')),
                        $('</tr>')
                    );
                    table.append(tr);
                }


                $('#books').append(table);
                

            }

            //TODO implement handlebars

            // (function solve() {
            //         var template = '<div class="event-calendar">' +
            //             '<h2 class="header">Appointments for <span class="month">{{month}}</span> <span class="year">{{year}}</span></h2>' +
            //             '{{#days}}' +
            //             '<div class="col-date">' +
            //             '<div class="date">{{day}}</div>' +
            //             '<div class="events">' +
            //             '{{#each events}}' +
            //             '{{#if title}}' +
            //             '<div class="event {{importance}}" title="duration: {{duration}}">' +
            //             '<div class="title">{{title}}</div>' +
            //             '<span class="time">at: {{time}}</span>' +
            //             '</div>' +
            //             '{{else}}' +
            //             '<div class="event {{importance}}">' +
            //             '<div class="title">Free slot</div>' +
            //             '</div>' +
            //             '{{/if}}' +
            //             '{{/each}}' +
            //             '</div>' +
            //             '</div>' +
            //             '{{/days}}' +
            //             '</div>';
            //        let books =  document.getElementById('books');
            //     books.innerText = template;
            //
            // }())

        }


        function getKinveyUserAuthHeaders() {
            return {
                'Authorization': "Kinvey " +
                sessionStorage.getItem('authToken'),
            };
        }

    }

}
