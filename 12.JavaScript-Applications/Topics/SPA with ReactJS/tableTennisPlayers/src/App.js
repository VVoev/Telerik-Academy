import React, {Component} from 'react';
import ReactDOM from 'react-dom';
import './App.css';

import Footer from './Components/Footer';
import NavigationBar from './Components/NavigationBar';

import $ from 'jquery';
import KinveyRequester from './KinveyRequester';

import Home from './Views/Home';
import Login from './Views/Login';
import Register from './Views/Register';
import Players from './Views/Players';
import CreatePlayer from "./Views/CreatePlayer";
import EditPlayer from './Views/EditPlayer';
import DeletePlayer from './Views/DeletePlayer'


export default class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            username: sessionStorage.getItem("username"),
            userId: sessionStorage.getItem("userId")
        };
    }

    render() {
        return (
            <div className="App">
                <header>
                    <NavigationBar
                        username={this.state.username}
                        homeClicked={this.showHomeView.bind(this)}
                        loginClicked={this.showLoginView.bind(this)}
                        registerClicked={this.showRegisterView.bind(this)}
                        playersClicked={this.showPlayersView.bind(this)}
                        createPlayerClicked={this.showCreatePlayerView.bind(this)}
                        logoutClicked={this.logoutScreen.bind(this)}
                    />
                    <div id="loadingBox">Loading ...</div>
                    <div id="infoBox">Info</div>
                    <div id="errorBox">Error</div>
                </header>
                <main id="main"></main>
                <Footer />
            </div>
        );
    }

    componentDidMount() {
        // Attach global AJAX "loading" event handlers
        $(document).on({
            ajaxStart: function () {
                $("#loadingBox").show()
            },
            ajaxStop: function () {
                $("#loadingBox").hide()
            }
        });

        // Attach a global AJAX error handler
        $(document).ajaxError(this.handleAjaxError.bind(this));

        // Hide the info / error boxes when clicked
        $("#infoBox, #errorBox").click(function () {
            $(this).fadeOut();
        });

        // Initially load the "Home" view when the app starts
        this.showHomeView();
    }

    handleAjaxError(event, response) {
        let errorMsg = JSON.stringify(response);
        if (response.readyState === 0)
            errorMsg = "Cannot connect due to network error.";
        if (response.responseJSON && response.responseJSON.description)
            errorMsg = response.responseJSON.description;
        this.showError(errorMsg);
    }

    showInfo(message) {
        $('#infoBox').text(message).show();
        setTimeout(function () {
            $('#infoBox').fadeOut();
        }, 3000);
    }

    showError(errorMsg) {
        $('#errorBox').text("Error: " + errorMsg).show();
    }

    showView(reactViewComponent) {
        ReactDOM.render(reactViewComponent,
            document.getElementById('main'));
        $('#errorBox').hide();
    }

    showHomeView() {
        this.showView(<Home  />);
    }

    showLoginView() {
        this.showView(<Login onsubmit={this.login.bind(this)}/>);
    }

    login(username, password) {
        KinveyRequester.loginUser(username, password)
            .then(loginSuccess.bind(this))

        function loginSuccess(userInfo) {
            this.saveAuthInSession(userInfo);
            this.showInfo("Login successful.");
            this.showPlayersView();
        }
    }

    showRegisterView() {
        this.showView(<Register onsubmit={this.register.bind(this)}/>);
    }

    register(username, password) {
        KinveyRequester.registerUser(username, password)
            .then(registerSuccess.bind(this));

        function registerSuccess(userInfo) {
            this.saveAuthInSession(userInfo);
            this.showInfo("User registration successful.");
            this.showHomeView();
        }
    }

    showPlayersView() {
        KinveyRequester.findAllPlayers()
            .then(loadPlayersSuccess.bind(this));

        function loadPlayersSuccess(players) {
            this.showInfo("Players loaded.");
            this.showView(
                <Players
                    players={players}
                    userId={this.state.userId}
                    onEdit={this.loadPlayerForEdit.bind(this)}
                    onDelete={this.loadPlayerForDelete.bind(this)}
                />
            );
        }
    }

    loadPlayerForEdit(playerId) {
        alert(playerId);
    }

    loadPlayerForDelete(playerId) {
        alert(playerId);
    }

    showCreatePlayerView() {
        this.showView(<CreatePlayer onsubmit={this.createPlayer.bind(this)}/>);
    }


    createPlayer(name, blade, rubbers, rating) {
        KinveyRequester.createPlayer(name, blade, rubbers, rating)
            .then(createBookSuccess.bind(this));

        function createBookSuccess() {
            this.showPlayersView();
            this.showInfo("Player created.");
        }
    }

    logoutScreen() {
        sessionStorage.clear();
        this.setState({username: null, userId: null});
        this.showHomeView();
        this.showInfo('Logout successful.');
    }

    saveAuthInSession(userInfo) {
        sessionStorage.setItem('authToken', userInfo._kmd.authtoken);
        sessionStorage.setItem('userId', userInfo._id);
        sessionStorage.setItem('username', userInfo.username);

        // This will update the entire app UI (e.g. the navigation bar)
        this.setState({
            username: userInfo.username,
            userId: userInfo._id
        });
    }

}


