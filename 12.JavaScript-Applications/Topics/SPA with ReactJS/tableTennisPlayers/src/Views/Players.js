import React, { Component } from 'react';

export default class Players extends Component {
    render() {
        let playerRows = this.props.players.map(player =>
            <tr key={player._id}>
                <td>{player.name}</td>
                <td>{player.rating}</td>
                <td>{player.blade}</td>
                <td>{player.rubbers}</td>
                {/*{this.getActions(book, this.props.userId)}*/}
            </tr>
        );
        debugger;

        return (
            <div className="players-view">
                <h1>Table Tennis Players</h1>
                <table className="players-table">
                    <thead>
                    <tr>
                        <th>Name</th>
                        <th>Rating</th>
                        <th>Blade</th>
                        <th>Rubbers</th>
                    </tr>
                    </thead>
                    <tbody>
                    {playerRows}
                    </tbody>
                </table>
            </div>
        );
    }


}
