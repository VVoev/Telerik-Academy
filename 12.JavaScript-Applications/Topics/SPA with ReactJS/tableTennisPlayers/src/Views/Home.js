import React, {Component} from 'react';

export default class Home extends Component {
    render() {
        let loged = document.getElementById('loggedInUser');
        return (
            <div className="home-view">
                <h1>Home</h1>
                { loged === null ?
                    <p>Welcome to my table-tennis site.</p> :
                    <p>{loged.innerText}.</p>
                }
            </div>
        );
    }
}