import React, { Component } from 'react';

export default class Players extends Component {
    render() {
        // let playerRows = this.props.books.map(player =>
        //     <tr key={player._id}>
        //         <td>{player.title}</td>
        //         <td>{player.author}</td>
        //         <td>{player.description}</td>
        //         {this.getActions(player, this.props.userId)}
        //     </tr>
        // );

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
                    {/*{playerRows}*/}
                    </tbody>
                </table>
            </div>
        );
    }


}
