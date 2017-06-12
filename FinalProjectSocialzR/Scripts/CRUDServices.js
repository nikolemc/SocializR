function EditBlacklist(that, playlistId) {

    let str = "#playlistname-" + playlistId
    let text = $(str).val();

    let ToEdit = {
        id: playlistId,
        newPlaylistName: text,
    }

    $.ajax({
        url: '/Blacklists/EditPlaylist',
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

function DeleteBlacklist(that, badWordId) {
    $.ajax({
        url: '/Blacklists/DeleteWord/' + badWordId,
        dataType: "html",
        type: "DELETE",
        success: (partial) => {
            $("#refresher123").html(partial);
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

function AddBlacklist() {
    let text = $("#addblacklisttext").val();

    let playlistName = text;

    $.ajax({
        url: '/Blacklists/AddPlaylist?playlistName=' + playlistName,
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