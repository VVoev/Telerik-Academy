import React, {Component} from 'react';
import './App.css';
import ReactDOM from 'react-dom';
import $ from 'jquery';

import NavigationBar from './Components/NavigationBar';
import Footer from './Components/Footer';

import Home from './Views/Home';
import Login from './Views/Login';
import Register from './Views/Register';
import Books from './Views/Books';
import CreateBook from './Views/CreateBook';
import Logout from './Views/Logout'


export default class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            username: null,
            userId: null
        }
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
        $(document).ajaxError(
            this.handleAjaxError.bind(this));

        //Load State
        this.state = {
            username: sessionStorage.getItem('username'),
            userId: sessionStorage.getItem('userId')
        };

        this.showHomeView();
    }

    handleAjaxError(event, response) {
        let errorMsg = JSON.stringify(response);
        if (response.readyState === 0)
            errorMsg = "Cannot connect due to network error.";
        if (response.responseJSON &&
            response.responseJSON.description)
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


    render() {
        return (
            <div className="App">
                <header>
                    <NavigationBar
                        username={this.state.username}
                        homeClicked={this.showHomeView.bind(this)}
                        loginClicked={this.showLoginView.bind(this)}
                        registerClicked={this.showRegisterView.bind(this)}
                        booksClicked={this.showBooksView.bind(this)}
                        createBookClicked={this.showCreateBookView.bind(this)}
                        logoutClicked={this.showLogoutView.bind(this)}
                    />
                    <div id="errorBox">Error</div>
                    <div id="infoBox">Info</div>
                    <div id="loadingBox">Loading</div>
                </header>
                <div id="main">
                </div>
                <Footer/>
            </div>
        );
    }

    showHomeView() {
        this.showView(<Home />)
    }

    showLoginView() {
        this.showView(<Login />)
    }

    showRegisterView() {
        this.showView(<Register />)
    }

    showBooksView(){
        this.showView(<Books />)
    }

    showCreateBookView(){
        this.showView(<CreateBook />)
    }

    showLogoutView(){
        this.showView(<Logout />)
    }

    showView(reactComponent) {
        ReactDOM.render(
            reactComponent,
            document.getElementById('main')
        );
        $('#errorBox').hide();
    }
}


