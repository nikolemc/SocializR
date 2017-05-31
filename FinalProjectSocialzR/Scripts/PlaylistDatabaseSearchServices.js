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
        url: '/SavedSocialMessagesCRUD/Delete?id=' + messageId + "&playListId=" + _playListId,
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
    let str = "#exampleInputEmail-" + messageId;
    let text = $(str).val();

    let MessageToEdit = {
        id: messageId,
        playListId: _playListId,
        newText: text,
    }    

    $.ajax({
        url: '/SavedSocialMessagesCRUD/EditMessage',       
        data: JSON.stringify(MessageToEdit),
        dataType: "html",
        type: "PUT",
        contentType: "application/json",
        success: (partial) => {
            runPlaylistSearch(null, _playListId);
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

function setRSSUrl() {
    let _playListId = $(".selected-playlist").attr("data-id");
    let rssurl = "http://localhost:61066/MediaExport?id=" + _playListId;
    $("#rssdownloadmodal").val(rssurl);
}

function EditPlaylist(that, playlistId) {
    
    let str = "#playlistname-" + playlistId
    let text = $(str).val();

    let ToEdit = {
        id: playlistId,
        newPlaylistName: text,
    }

    $.ajax({
        url: '/PlaylistSelection/EditPlaylist',       
        data: JSON.stringify(ToEdit),
        dataType: "html",
        type: "PUT",
        contentType: "application/json",
        success: (partial) => {
            $("#myPlaylistContainer").html(partial);
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

function DeletePlaylist(that, playlistId) {
    

    $.ajax({
        url: '/PlaylistSelection/Delete/?id=' + playlistId,
        dataType: "html",
        type: "DELETE",
        success: (partial) => {
            $("#myPlaylistContainer").html(partial);
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









