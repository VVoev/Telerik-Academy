class PlayerController {
    constructor(model, view) {
        this.model = model;
        this.view = view;
    }

    getPlayer(id) {
        this.model.getPlayer(id).then(
            function (success) {

            }
        ).catch(function (error) {
            console.log(error)
        })
    }

    getPlayers() {
        let self = this;
        this.model.getPlayers().then(
            function (successData) {
                self.view.getPlayers(successData)
            }
        ).catch(function (errorData) {
            console.log(errorData)
        })
    }

    createPlayer(data){
        this.model.postPlayer(data).then(
            function (successData) {
                console.log(successData)
            }
        ).catch(function (errorData) {
            console.log(errorData)
        })
    }


}