let runTwitterSearch = () => {
    $.ajax({
        url: '/Home/CustomSearch?searchTerm='+ $("#twitterSearch").val(),
        dataType: "html",
        type: "GET",
        success: (partial) => {
            $("#twitterSearchDisplayFront").html(partial);
            console.log('works');
        },
        error: (data) => {
            alert("Your Twitter account has not been authenticated");
            console.log("oops", data)
        },
        complete: (data) => {
            console.log("done", data);
        }

    });
}


let runTwitterSearchAdvance = () => {
    let searchParam = {
        searchKeyWord: $("#twitterSearch").val(),
        Language: $("#language").val(),
        ZipCode: $("#Location").val(),
        Latitude: $("#Latitude").val(),
        Longitude: $("#Longitude").val(),
        Radius: $("#Radius").val(),
        MustContainVideo: $("#mediafilter").val('Must Contain Video') || $("#mediafilter").val('Must Contain Video and Photo') ?true :false,
        MustContainPhoto: $("#mediafilter").val('Must Contain Photo') || $("#mediafilter").val('Must Contain Video and Photo') ?true :false,
        IncludeRetweet: $('#IncludeRetweets').val() ?true :false,
    };

    pass = JSON.stringify({
        'searchParam': searchParam,
    });
    
    $.ajax({
        url: '/Search/TwitterAdvancedSearch',
        contentType: "application/json",
        data: pass,
        dataType: "html",
        type: "POST",
        success: (partial) => {
            $("#twitterSearchDisplayFront").html(partial);
            console.log('works');
        },
        error: (data) => {
            alert("Your Twitter account has not been authenticated");
            console.log("oops", data)
        },
        complete: (data) => {
            console.log("done", data);
        }

    });
}



//receive: ajax(event, ui) {
//    alert("Your Twitter account has not been authenticated. Click here to register: https://localhost:44358/OAuth"); 



