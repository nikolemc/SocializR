$(function () {
    $(".sortable_list").sortable({
        connectWith: ".connectedSortable",
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
    }).disableSelection();


});