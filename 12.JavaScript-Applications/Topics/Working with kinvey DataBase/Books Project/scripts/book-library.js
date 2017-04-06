function startApp() {

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
    $("#infoBox, #errorBox").click(function() {
        $(this).fadeOut();
    });

    // Attach AJAX "loading" event listener
    $(document).on({
        ajaxStart: function() { $("#loadingBox").show() },
        ajaxStop: function() { $("#loadingBox").hide() }
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
        
    }
    
    function createBook() {
        
    }
    
    function editBook() {
        
    }

    function showLoginView() {

    }

    function showRegisterView() {

    }

    function listBooks() {

    }

    function showCreateBookView() {

    }

    function logoutUser() {

    }

    function showHideMenuLinks() {

        $('#menu a').hide();
        //If we are logged
        if(sessionStorage.getItem('authToken')){
            $('#linkHome').show();
            $('#linkListBooks').show();
            $('#linkCreateBook').show();
            $('#linkRegister').show();
        }
        //If we are not logged
        else{
            $('#linkHome').show();
            $('#linkLogin').show();
            $('#linkLogout').show();
            $('#linkRegister').show();
        }
    }

    function showView(viewName) {

    }

    function showHomeView() {
        showView('viewHome');
    }

    function loginUser() {

    }
}
