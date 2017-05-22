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

<<<<<<< HEAD
<<<<<<< HEAD
//receive: ajax(event, ui) {
//    alert("Your Twitter account has not been authenticated. Click here to register: https://localhost:44358/OAuth"); 
=======
>>>>>>> 609bf53d872c63294d95ef5ddd8dfaf8fa98366e
=======

//receive: ajax(event, ui) {
//    alert("Your Twitter account has not been authenticated. Click here to register: https://localhost:44358/OAuth"); 


>>>>>>> 45f660dd5f73c917a3a5004e40738789754c809e
