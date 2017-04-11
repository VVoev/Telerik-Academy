import React, { Component } from 'react';

export default class CreatePlayer extends Component {
    render() {
        return (
            <form className="create-player-form" onSubmit={this.submitForm.bind(this)}>
                <h1>Add new Player</h1>
                <label>
                    <div>Name:</div>
                    <input type="text" name="title" required
                           ref={e => this.nameField = e}/>
                </label>
                <label>
                    <div>Blade:</div>
                    <input type="text" name="author" required
                           ref={e => this.bladeField = e}/>
                </label>
                <label>
                    <div>Rubbers:</div>
                    <input type="text" name="author" required
                           ref={e => this.rubbersField = e}/>
                </label>
                <label>
                    <div>Rating:</div>
                    <input type="text" name="author" required
                           ref={e => this.ratingField = e}/>
                </label>
                <div>
                    <input type="submit" value="Create"/>
                </div>
           </form>
        );
    }

    submitForm(event){
        event.preventDefault();
        this.props.onsubmit(
            this.nameField.value,
            this.bladeField.value,
            this.rubbersField.value,
            this.ratingField.value
        )
    }
}