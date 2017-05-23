let runPlaylistSearch = (playlistNumber) => {
    $.ajax({
        url: 'PlaylistChoice?id=' + playlistNumber , //controller to ping to get data from datbase (GET for saved social media controller)

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

//Angel trying to use JSON
//$.ajax({
//    url: '/api/Playlists?id=' + playlistNumber, //controller to ping to get data from datbase (GET for saved social media controller)
//    dataType: "JSON",
//    type: "GET",
//    success: function (data) {
//        $.each(data, function (index, element) {
//            $('ui-state-highlight').append($('<div>', {
//                image: element.ImageURL
//            }));
//        });
//    }


//});
