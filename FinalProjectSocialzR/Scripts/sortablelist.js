var initList = () => {
    $(".sortable_list").sortable({
        connectWith: ".connectedSortable",    

        receive: function (event, ui) {

            let _playListId = $(".selected-playlist").attr("data-id");
            var item = {

                //source: ui.item[0].Source,
                ImageUrl: $(ui.item[0]).find("img").attr("src"),
                ScreenName: $(ui.item[0]).find(".screen-name").html().trim(),
                Text: $(ui.item[0]).find(".text-body").html().trim(),
                OriginalText: $(ui.item[0]).find(".text-body").html().trim(),
                //OriginalText:ui.item[0].OriginalText,
                PostTimeStamp: $(ui.item[0]).find(".time-stamp").html().trim(),
                MediaImage: $(ui.item[0]).find(".photo-link").attr("value"),
                //UserName:ui.item[0].UserName,
                //IsRetweeted:ui.item[0].IsRetweeted,
                //Language:ui.item[0].Language,
                Media: $(ui.item[0]).find(".media-link").attr("value"),
                //AddedToPlaylistTimeStamp:ui.item[0].AddedToPlaylistTimeStamp,
                //UserId:ui.item[0].UserId, 

                PlaylistId: _playListId
            };
 

            console.log(item); //Which item (or ui.item[0].id)
            // POST to server using $.post or $.ajax
            $.ajax({
                type: "POST",
                url: 'api/SavedSocialMessages',
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(item)
            });
            

        }

    }).disableSelection();
}

$(function () {
    initList();
});


//$(".playlistFooter").draggable({
//    disabled: true
//});
//$("#btn btn-primary btn-sm btn-block").draggable({
//    disabled: true
//});


function moveButton(counterId) {
    let div = "#leftSideSearch-" + counterId;
    //let elem = $(div).html();
    $(div).detach().appendTo("#playlistSearchDisplayFront");
    let _playListId = $(".selected-playlist").attr("data-id");
    var item = {
        ImageUrl: $(div).find ,

        //ImageUrl: $(div).find("img").attr("src"),
        //source: ui.item[0].Source,
        ImageUrl: $(div).find("img").attr("src"),
        ScreenName: $(div).find(".screen-name").html().trim(),
        Text: $(div).find(".text-body").html().trim(),
        OriginalText: $(div).find(".text-body").html().trim(),
        //OriginalText:ui.item[0].OriginalText,
        PostTimeStamp: $(div).find(".time-stamp").html().trim(),
        MediaImage: $(div).find(".photo-link").attr("value"),
        //UserName:ui.item[0].UserName,
        //IsRetweeted:ui.item[0].IsRetweeted,
        //Language:ui.item[0].Language,
        Media: $(div).find(".media-link").attr("value"),
        //AddedToPlaylistTimeStamp:ui.item[0].AddedToPlaylistTimeStamp,
        //UserId:ui.item[0].UserId, 

        PlaylistId: _playListId
    };

    //$("#item").load("runPlaylistSearch" + PlaylistId + "&list=" + $(this).attr('id')); 

    console.log(item); //Which item (or ui.item[0].id)
    // POST to server using $.post or $.ajax
    $.ajax({
        type: "POST",
        url: 'api/SavedSocialMessages',
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(item)
    });
}

//saved this in nunber 2
function moveButton2(elem) {
    if ($(elem).parent().attr("id") == "nonSelected") {
        $(elem).detach().appendTo('#selected');
    }
    else {
        $(elem).detach().appendTo('#nonSelected');
    }
}