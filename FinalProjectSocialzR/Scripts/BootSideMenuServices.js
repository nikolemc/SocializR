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
            console.log("oops", data)
        },
        complete: (data) => {
            console.log("done", data);
        }

    });
}

receive: ajax(event, ui) {
    alert("Your Twitter account has not been authenticated. Click here to register: https://localhost:44358/OAuth"); 