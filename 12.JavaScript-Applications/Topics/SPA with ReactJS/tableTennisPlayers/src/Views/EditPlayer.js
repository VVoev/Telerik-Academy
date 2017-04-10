import React, { Component } from 'react';

export default class EditPlayer extends Component {
    render() {
        return (
            <form className="edit-player-form" onSubmit={this.submitForm.bind(this)}>
                <h1>Edit Player</h1>
                <label>
                    <div>Name:</div>
                    <input type="text" name="title" required
                           defaultValue={this.props.name}
                           ref={e => this.nameField = e} />
                </label>
                <label>
                    <div>Blade:</div>
                    <input type="text" name="author" required
                           defaultValue={this.props.blade}
                           ref={e => this.bladeField = e} />
                </label>
                <label>
                    <div>Rubbers:</div>
                    <textarea name="description" rows="10"
                              defaultValue={this.props.rubbers}
                              ref={e => this.rubbersField = e} />
                </label>
                <label>
                    <div>Rating:</div>
                    <input type="text" name="title" required
                           defaultValue={this.props.rating}
                           ref={e => this.ratingField = e} />
                </label>
                <div>
                    <input type="submit" value="Edit" />
                </div>
            </form>
        );
    }

    submitForm(event) {
        event.preventDefault();
        this.props.onsubmit(
            this.props.playerId,
            this.nameField.value,
            this.bladeField.value,
            this.rubbersField.value,
            this.ratingField.value
        );
    }
}
