import React, {Component} from 'react';

export default class Players extends Component {
    render() {
        let playerRows = this.props.players.map(player =>
            <tr key={player._id}>
                <td>{player.name}</td>
                <td>{player.rating}</td>
                <td>{player.blade}</td>
                <td>{player.rubbers}</td>
                {this.getActions(player, this.props.userId)}
            </tr>
        );


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
                        <th>Actions</th>
                    </tr>
                    </thead>
                    <tbody>
                    {playerRows}
                    </tbody>
                </table>
            </div>
        );
    }

    getActions(player, playerId) {
        if (player._acl.creator === playerId)
            return (
                <td>
                    <input type="button" value="Edit"
                           onClick={this.props.editPlayerClicked.bind(this, player._id)} />
                    &nbsp;
                    <input type="button" value="Delete"
                           onClick={this.props.deletePlayerClicked.bind(this, player._id)} />
                </td>
            );
        else
            return <td></td>;
    }
}
