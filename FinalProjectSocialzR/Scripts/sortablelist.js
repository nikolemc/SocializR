$(function () {
    $(".sortable_list").sortable({
        connectWith: ".connectedSortable",
        //need to use receive command to look only at right hand list. Update looks at both
        receive: function (event, ui) {
            alert("dropped on = " + this.id); // Where the item is dropped
            alert("sender = " + ui.sender[0].id); // Where it came from
            alert("item = " + ui.item[0].innerHTML); //Which item (or ui.item[0].id)
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

            }

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

$(".list-group-item").mousedown(function () {
    $(".sortable_list").height($(".sortable_list").height());
}).mouseup(function () {
    $(".sortable_list").height('auto');
});





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