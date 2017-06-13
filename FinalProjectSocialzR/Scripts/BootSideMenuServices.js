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

////allows search to happen by pressing enter
//document.getElementById("twitterSearch")
//    .addEventListener("keyup", function (event) {
//        event.preventDefault();
//        if (event.keyCode == 13) {
//            document.getElementById("SearchButton").click();
//        }
//    });


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

    ////allows search to happen by pressing enter after entering location
    //document.getElementById("Location")
    //    .addEventListener("keyup", function (event) {
    //        event.preventDefault();
    //        if (event.keyCode == 13) {
    //            document.getElementById("SearchButton").click();
    //        }
    //    });
}

//receive: ajax(event, ui) {
//    alert("Your Twitter account has not been authenticated. Click here to register: https://localhost:44358/OAuth"); 



