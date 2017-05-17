let runTwitterSearch = () => {

    let searchCriteria = {
        searchTerm: $("#search").val()
    };

    $.ajax({
        url: '/Home/CustomSearch',
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(newMarble),
        type: "GET",
        success: (data) => {
            marbDisplay(data);
        },
        error: (data) => {
            console.log("oops", data)
        },
        complete: (data) => {
            console.log("done", data);
        }
    });
}



