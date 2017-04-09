import React, { Component } from 'react';
import './NavigationBar.css';

export default class NavigationBar extends Component {
    render() {
        return (
            <div className="navigation-bar">
                <a href="#">Home</a>
                <a href="#">Login</a>
                <a href="#">Register</a>

            </div>
        );
    }
}
