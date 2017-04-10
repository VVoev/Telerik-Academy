import React, { Component } from 'react';
import './NavigationBar.css';

export default class NavigationBar extends Component {
    render() {
        let username = this.props.username;
        if (username == null) {
            // No user logged in
            return (
                <nav className="navigation-bar">
                    <a href="#" onClick={this.props.homeClicked}>Home</a>
                    <a href="#" onClick={this.props.loginClicked}>Login</a>
                    <a href="#" onClick={this.props.registerClicked}>Register</a>
                </nav>
            );
        } else {
            // User logged in
            return (
                <nav className="navigation-bar">
                    <a href="#" onClick={this.props.homeClicked}>Home</a>
                    <a href="#" onClick={this.props.playersClicked}>List All Players</a>
                    <a href="#" onClick={this.props.createPlayerClicked}>Create Player</a>
                    <a href="#" onClick={this.props.logoutClicked}>Logout</a>
                    <span id="loggedInUser">
                        Welcome, {username}!
                    </span>
                </nav>
            );
        }
    }
}
