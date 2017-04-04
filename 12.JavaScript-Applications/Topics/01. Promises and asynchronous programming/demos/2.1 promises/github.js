function loadCommits() {
    $("#commits").empty();
    let url = "https://api.github.com/repos/" +
        $("#username").val() + "/" +
        $("#repo").val() + "/commits";
    $.get(url)
        .then(displayCommits)
        .catch(displayError);


    function displayCommits(commits){

        let infoAuthor = commits[0].committer;
        let id = infoAuthor.id;
        let name = infoAuthor.login;
        let text = `Author details: </br> ${name} with id ${id}`;
        $("body").append(`<h1>${text}</h1>`);
        for (let commit of commits)
            $("#commits").append($("<li>").text(
                commit.commit.author.name + ": " +
                commit.commit.message
            ));
    }

    function displayError(err){
        $("#commits").append($("<li>").text("Error: " +
            err.status + ' (' + err.statusText + ')'));
    }
}
