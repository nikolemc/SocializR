function runPlaylistSearch(that, playlistNumber) {
    $("#currentPlaylist").val(playlistNumber);
    $.ajax({
        url: '/PlaylistSelection/GetPlaylist?id=' + playlistNumber , //controller to ping to get data from datbase (GET for saved social media controller)
        dataType: "html",
        type: "GET",
        success: (partial) => {
            UpdateRightUpper(null, playlistNumber);
            $("#playlistSearchDisplayFront").html(partial); // make a new PLaylist search results partial
            initList();
            UpdateNameLeft(playlistNumber);
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

let UpdateNameLeft = (id) => {
    $.ajax({
        url: '/PlaylistSelection/RefreshUpper2?id=' + id, //controller to ping to get data from datbase (GET for saved social media controller)
        dataType: "html",
        type: "GET",
        success: (data) => {
            $("#playlistDisplayName2").html(data); // make a new PLaylist search results partial
            console.log('works');
        },
        error: (data) => {
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
    let rssurl = "https://socializrmedia.azurewebsites.net/MediaExport?id=" + _playListId;
    $("#rssdownloadmodaltextbox").val(rssurl);
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
            UpdateUpper();
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
            UpdateUpper();
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

function AddPlaylist() {
    let text = $("#addplaylisttext").val();

    let playlistName = text;

    $.ajax({
        url: '/PlaylistSelection/AddPlaylist?playlistName=' + playlistName,
        dataType: "html",
        type: "POST",
        success: (partial) => {
            UpdateUpper();
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

function UpdateUpper() {
    $.ajax({
        url: '/PlaylistSelection/RefreshUpperNoId', //controller to ping to get data from datbase (GET for saved social media controller)
        dataType: "html",
        type: "GET",
        success: (partial) => {
            $("#playlistSearchDisplayFrontUpper").html(partial); // make a new PLaylist search results partial
            console.log('works');
        },
        error: (data) => {
            console.log("oops", data)
        },
        complete: (data) => {
            console.log("done", data);
        }

    });
}


function UpdateRightUpper(that, playlistNumber) {
    $("#currentPlaylist").val(playlistNumber);
    $.ajax({
        url: '/PlaylistSelection/RefreshUpper?id=' + playlistNumber, //controller to ping to get data from datbase (GET for saved social media controller)
        dataType: "html",
        type: "GET",
        success: (partial) => {
            $("#playlistSearchDisplayFrontUpper").html(partial); // make a new PLaylist search results partial
            console.log('works');
        },
        error: (data) => {            
            console.log("oops", data)
        },
        complete: (data) => {
            console.log("done", data);
        }

    });
}
