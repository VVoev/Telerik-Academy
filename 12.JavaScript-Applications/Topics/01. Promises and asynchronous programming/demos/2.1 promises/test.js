function loadMovies() {
    let url = "http://www.omdbapi.com/?t=" +
        $("#username").val();
    console.log('x')
    $.get(url)
        .then(displayMovie)
        .catch(displayError);


    function displayMovie(movie) {
        let infoMovie = movie;
        let ratingButton = $(`<button>Check Rating</button>`);
        console.log(infoMovie);
        let ul = $('<ul>Movie Details</ul>');

        ul.css('fontsize','30px');
        ul.append(`<li>Actors:${infoMovie.Actors}</li>`);
        ul.append(`<li>Awards:${infoMovie.Awards}</li>`);
        ul.append(`<li>Year:${infoMovie.Year}</li>`);
        ul.append(`<li>Movie Lenght:${infoMovie.Runtime}</li>`);
        ul.append(`<li>Movie Plot:${infoMovie.Plot}</li>`);
        ul.append(ratingButton);

        ratingButton.click(function () {
            let ul = $('<ul>Rating Details</ul>');
            for(let i of movie.Ratings){
                ul.append(`<li>Source:${i.Source}<br>Rating:${i.Value}</li>`);
            }
            $('body').append(ul);
        })


        $('body').append(ul);

    }

    function displayError() {
        alert('Cannot find such movie');
    }



}
function cleanValue() {
    let input = $('#username');
    input.val('');
}

function clean() {
    location.reload(true);
}