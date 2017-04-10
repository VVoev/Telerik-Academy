import React, { Component } from 'react';

export default class DeletePlayer extends Component {
    render() {
        return (
            <form className="delete-player-form" onSubmit={this.submitForm.bind(this)}>
                    <h1>Confirm Delete Player</h1>
                <label>
                    <div>Name:</div>
                    <input type="text" name="title" disabled
                           defaultValue={this.props.name}
                           ref={e => this.nameField = e} />
                </label>
                <label>
                    <div>Blade:</div>
                    <input type="text" name="author" disabled
                           defaultValue={this.props.blade} />
                </label>
                <label>
                    <div>Rubbers:</div>
                    <input type="text" name="author" disabled
                           defaultValue={this.props.rubbers} />
                </label>
                <label>
                    <div>Rating:</div>
                    <input type="text" name="author" disabled
                           defaultValue={this.props.rating} />
                </label>
                <div>
                    <input type="submit" value="Delete" />
                </div>
            </form>
        );
    }

    submitForm(event) {
        event.preventDefault();
        this.props.onsubmit(this.props.playerId);
    }
}
