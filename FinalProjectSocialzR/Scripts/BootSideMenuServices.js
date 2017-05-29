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
    let vid = false;
    let photo = false;
    if ($("#mediafilter").val() == "mustcontainvideo") {
        vid = true;
    }
    if ($("#mediafilter").val() == "mustcontainphoto") {
        photo = true;
    }

    
    let searchParam = {
        searchKeyWord: $("#twitterSearch").val(),
        Language: $("#language").val(),
        ZipCode: $("#Location").val(),
        Latitude: $("#Latitude").val(),
        Longitude: $("#Longitude").val(),
        Radius: $("#Radius").val(),
        MustContainVideo: vid,
        //MustContainPhoto: $("#mediafilter").val() == "mustcontainvideo",
        IncludeRetweet: $('#IncludeRetweets').is(":checked") ?true :false,
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



