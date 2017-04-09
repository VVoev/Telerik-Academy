import React, {Component} from 'react';
import './App.css';
import ReactDOM from 'react-dom';
import $ from 'jquery';
import NavigationBar from './Components/NavigationBar';
import Footer from './Components/Footer';
import Home from './Views/Home';
import Login from './Views/Login';


export default class App extends Component {
    constructor(props){
        super(props);
        this.state = {
            username:sessionStorage.getItem('username'),
            userId:sessionStorage.getItem('userId')
        }
    }
    render() {
        return (
            <div className="App">
                <header>
                    <NavigationBar
                        username ={this.state.username}
                        homeClicked ={this.showHomeView.bind(this)}
                        loginClicked = {this.showLoginView.bind(this)}
                    />
                    <div id="errorBox">Error</div>
                    <div id="infoBox">Info</div>
                    <div id="loadingBox">Loading</div>
                </header>
                <div id="main">
                    <h1>Welcome to my App</h1>
                </div>
                <Footer/>
            </div>
        );
    }
    showHomeView(){
        this.showView(<Home />)
    }

    showLoginView(){
        this.showView(<Login />)
    }

    showView(reactComponent){
        ReactDOM.render(
            reactComponent,
            document.getElementById('main')
        );
    }
}


