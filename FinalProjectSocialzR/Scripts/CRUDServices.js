function SaveBlacklistEdit(that, blacklistId) {
    let str = "#BlacklistedWord-" + blacklistId;
    let text = $(str).val();

    $.ajax({
        url: '/Blacklists/EditBlacklistWord?id=' + blacklistId + "&text=" + text,
        dataType: "html",
        type: "POST",
        success: (partial) => {
            $("#EditBlacklistTarget").html(partial);
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
            $("#EditBlacklistTarget").html(partial);
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
    let text = $("#blacklistWordInput").val();

    $.ajax({
        url: '/Blacklists/AddNewBlacklistedWord?text=' + text,
        dataType: "html",
        type: "POST",
        success: (partial) => {
            $("#EditBlacklistTarget").html(partial);
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

function runBlacklistWordSearch() {
    let searchTerm = $("#searchBlacklistWord").val();

    $.ajax({
        url: '/Blacklists/BlacklistCatelogCheck?searchTerm=' + searchTerm,
        dataType: "html",
        type: "GET",
        success: (data) => {
            alert(data);
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