﻿function runPlaylistSearch(that, playlistNumber) {
    $("#currentPlaylist").val(playlistNumber);
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

function DeleteMessageInPlaylist(that, messageId) {    
    let _playListId = $(".selected-playlist").attr("data-id");
    $("#currentPlaylist").val(_playListId);
    $.ajax({
        url: '/SavedSocialMessagesCRUD/Delete?id=' + messageId + "&playListId=" + _playListId, //controller to ping to get data from datbase (GET for saved social media controller)

        dataType: "html",
        type: "GET",
        success: (partial) => {
            runPlaylistSearch(null, _playListId);
            //$("#playlistSearchDisplayFront").html(partial); // make a new PLaylist search results partial
            console.log('works');
        },
        error: (data) => {
            alert("NOPE");
            console.log("oops", data)
        },
        complete: (data) => {
            console.log("done", data);
        }
    });
}

function EditMessageInPlaylist(that, messageId) {
    let _playListId = $(".selected-playlist").attr("data-id");
    $("#currentPlaylist").val(_playListId);
    $.ajax({
        url: '/SavedSocialMessagesCRUD/Delete?id=' + messageId + "&playListId=" + _playListId, //controller to ping to get data from datbase (GET for saved social media controller)

        dataType: "html",
        type: "PUT",
        success: (partial) => {
            runPlaylistSearch(null, _playListId);
            //$("#playlistSearchDisplayFront").html(partial); // make a new PLaylist search results partial
            console.log('works');
        },
        error: (data) => {
            alert("NOPE");
            console.log("oops", data)
        },
        complete: (data) => {
            console.log("done", data);
        }
    });
}







