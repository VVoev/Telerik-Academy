class PlayerView {
    constructor() {

    }

    getPlayer(data) {

    }

    getPlayers(data) {
        data.forEach(
            function (entity) {
                let playerDiv = $('<div class="player"></div>')
                playerDiv.append(`<div>${entity.name}</div>`);
                playerDiv.append(`<div>${entity.rubbers}</div>`);
                playerDiv.append(`<div>${entity.rating}</div>`);
                $('#wrapper').append(playerDiv);
            }
        )
    }
}