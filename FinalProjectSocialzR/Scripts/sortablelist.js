var initList = () => {
    $(".sortable_list").sortable({
        connectWith: ".connectedSortable",

        //need to use receive command to look only at right hand list. Update looks at both
        //beforeStop: function (event, ui) {
        //    console.log("Before beforestop");
        //},
        //activate: function (event, ui) {
        //    console.log("Before activate");
        //},
        //change: function (event, ui) {
        //    console.log("Before change");
        //},
        //create: function (event, ui) {
        //    console.log("Before create");
        //},
        //deactivate: function (event, ui) {
        //    console.log("Before deactivate");
        //},
        //out: function (event, ui) {
        //    console.log("Before out");
        //},
        //over: function (event, ui) {
        //    console.log("Before over");
        //},
        //remove: function (event, ui) {
        //    console.log("Before remove");
        //},
        //sort: function (event, ui) {
        //    console.log("Before sort");
        //},
        //start: function (event, ui) {
        //    console.log("Before start");
        //    ui.item[0].Text = "blah blah";
        //},
        //stop: function (event, ui) {
        //    console.log("Before stop");
        //},
        //update: function (event, ui) {
        //    console.log("Before update");
        //    ui.item[0].Media = "blah blah";
        //},


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


///modal stuff

//$(function () {
//    // there's the gallery and the transfer
//    var $twitterSearchDisplayFront = $("#twitterSearchDisplayFront"),
//        $playlistSearchDisplayFront = $("#playlistSearchDisplayFront"),

//    // let the gallery items be draggable
//        $("div", $twitterSearchDisplayFront).draggable({
//        cancel: "a.ui-icon", // clicking an icon won't initiate dragging
//        revert: "invalid", // when not dropped, the item will revert back to its initial position
//        containment: "document",
//        helper: "clone",
//        cursor: "move"
//    });

//    // let the transfer be droppable, accepting the gallery items
//    $playlistSearchDisplayFront.droppable({
//        accept: "#twitterSearchDisplayFront > div",
//        activeClass: "ui-state-highlight",
//        drop: function (event, ui) {
//            deleteImage(ui.draggable);
//        }
//    });

//    // let the gallery be droppable as well, accepting items from the transfer
//    $twitterSearchDisplayFront.droppable({
//        accept: "#playlistSearchDisplayFront div",
//        activeClass: "custom-state-active",
//        drop: function (event, ui) {
//            recycleImage(ui.draggable);
//        }
//    });
    
//    // function for generating info of icon/s in drop box
//    $('button.generate').click(function () {
//        var content = $('div div h5', $playlistSearchDisplayFront).map(function (i, v) {
//            return $(this).text();
//        }).get();
//        $gen_dialog.find('.diag-content').html(content.join(', ')).end().dialog('open');
//    });
//    //function for resetting the icons back to original positions
//    $('button.reset').click(function () {
//        $('div div', $playlistSearchDisplayFront).each(function () {
//            recycleImage($(this));
//        });
//    });

//    toggleButtons();

//    // image deletion function
//    var recycle_icon = "<a href='link/to/recycle/script/when/we/have/js/off' title='Transfer this icon back' class='ui-icon ui-icon-transfer-e-w'>Transfer this icon back</a>";
//    function deleteImage($item) {
//        $item.fadeOut(function () {
//            var $list = $("div", $playlistSearchDisplayFront).length ?
//                $("div", $playlistSearchDisplayFront) :
//                $("<div class='twitterSearchDisplayFront ui-helper-reset'/>").appendTo($playlistSearchDisplayFront);

//            $item.find("a.ui-icon-transferthick-e-w").remove();
//            $item.append(recycle_icon).appendTo($list).fadeIn(function () {
//                $item
//                    .animate({ width: "48px" })
//                    .find("img")
//                    .animate({ height: "36px" }, function () {
//                        toggleButtons();
//                    });
//            });
//        });
//    }

//    // image recycle function
//    var transfer_icon = "<a href='link/to/transfer/script/when/we/have/js/off' title='Transfer Across' class='ui-icon ui-icon-transferthick-e-w'>Transfer Across</a>";
//    function recycleImage($item) {
//        $item.fadeOut(function () {
//            $item
//                .find("a.ui-icon-transfer-e-w")
//                .remove()
//                .end()
//                .css("width", "96px")
//                .append(transfer_icon)
//                .find("img")
//                .css("height", "72px")
//                .end()
//                .appendTo($twitterSearchDisplayFront)
//                .fadeIn(function () {
//                    toggleButtons();
//                });
//        });
//    }
//    // display buttons when icon transferred across     
//    function toggleButtons() {
//        $('div.col3 button').toggle($('> div > div', $playlistSearchDisplayFront).length > 0);
//    }
    
//    // resolve the icons behavior with event delegation
//    $("div.twitterSearchDisplayFront > div").click(function (event) {
//        var $item = $(this),
//            $target = $(event.target);

//        if ($target.is("a.ui-icon-transferthick-e-w")) {
//            deleteImage($item);
//        } else if ($target.is("a.ui-icon-transfer-e-w")) {
//            recycleImage($item);
//        }

//        return false;
//    });
//});

