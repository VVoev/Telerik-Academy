import React, {Component} from 'react';
import './App.css';
import $ from 'jquery';
import NavigationBar from './Components/NavigationBar';
import Footer from './Components/Footer';

export default class App extends Component {
    render() {
        return (
            <div className="App">
                <header>
                    <NavigationBar/>
                    <div id="error-msg">Error</div>
                    <div id="info-msg">Info</div>
                    <div id="loading-msg">Loading</div>
                </header>
                <div id="main">Welcome to my App</div>
                <Footer/>
            </div>
        );
    }
}


