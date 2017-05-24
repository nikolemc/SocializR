let runPlaylistSearch = (playlistNumber) => {
    $.ajax({
        url: '/PlaylistSelection/GetPlaylist?id=' + playlistNumber , //controller to ping to get data from datbase (GET for saved social media controller)

        dataType: "html",
        type: "GET",
        success: (partial) => {
            $("#playlistSearchDisplayFront").html(partial); // make a new PLaylist search results partial
            console.log('works');
        },
        error: (data) => {
            alert("You have successfully selected a playlist");
            console.log("oops", data)
        },
        complete: (data) => {
            console.log("done", data);
        }

    });
}


