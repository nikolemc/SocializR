$(function () {
    $(".sortable_list").sortable({
        connectWith: ".connectedSortable",
        //need to use receive command to look only at right hand list. Update looks at both
        beforeStop: function (event, ui) {
            console.log("Before beforestop");
        },
        activate: function (event, ui) {
            console.log("Before activate");
        },
        change: function (event, ui) {
            console.log("Before change");
        },
        create: function (event, ui) {
            console.log("Before create");
        },
        deactivate: function (event, ui) {
            console.log("Before deactivate");
        },
        out: function (event, ui) {
            console.log("Before out");
        },
        over: function (event, ui) {
            console.log("Before over");
        },
        remove: function (event, ui) {
            console.log("Before remove");
        },
        sort: function (event, ui) {
            console.log("Before sort");
        },
        start: function (event, ui) {
            console.log("Before start");
            ui.item[0].Text = "blah blah";
        },
        stop: function (event, ui) {
            console.log("Before stop");
        },
        update: function (event, ui) {
            console.log("Before update");
            ui.item[0].Media = "blah blah";
        },

        receive: function (event, ui) {

            let _playListId = $(".selected-playlist").attr("data-id");
            var item = {


                //source: ui.item[0].Source,
                ImageUrl: $(ui.item[0]).find("img").attr("src"),
                ScreenName: $(ui.item[0]).find(".screen-name").html().trim(),
                Text: $(ui.item[0]).find(".comment-text").html().trim(),
                //OriginalText:ui.item[0].OriginalText,
                PostTimeStamp: $(ui.item[0]).find(".time-stamp").html().trim(),
                //PostContentUrl:ui.item[0].PostContentUrl,
                //UserName:ui.item[0].UserName,
                //IsRetweeted:ui.item[0].IsRetweeted,
                //Language:ui.item[0].Language,
                Media: $(ui.item[0]).find(".twit-vid").attr("href"),
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
    }).disableSelection();


});

////this is where I want to get my playlist ID for runPlaylistSearch
//function AddPlaylistId(Text, Value) {
//    // Create an playlist object

//    var pl = document.createElement("playlist");

//    // Add an Option object to Drop Down/List Box
//    document.getElementById("dropdown-menu").options.add(opt);
//    // Assign text and value to Option object
//    pl.text = Text;
//    pl.value = Value;
//    ui.item[0].PlaylistId,

//            };





        /*stop: function(event, ui) {
            var item_sortable_list_id = $(this).attr('id');
            console.log(ui);
            //alert($(ui.sender).attr('id'))
        },*/
        //receive: function (event, ui) {
        //    alert("dropped on = " + this.id); // Where the item is dropped
        //    alert("sender = " + ui.sender[0].id); // Where it came from
        //    alert("item = " + ui.item[0].innerHTML); //Which item (or ui.item[0].id)
        //}