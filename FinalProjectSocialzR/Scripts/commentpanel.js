
$('.upbutton').on('click', function () {
    var hook = $(this).closest('.list-group-item').prev('.list-group-item');
    if (hook.length) {
        var elementToMove = $(this).closest('.list-group-item').detach();
        hook.before(elementToMove);
    }
});
$('.downbutton').on('click', function () {
    var hook = $(this).closest('.list-group-item').next('.list-group-item');
    if (hook.length) {
        var elementToMove = $(this).closest('.list-group-item').detach();
        hook.after(elementToMove);
    }
});




//$('TransfertoSearch').on('click', function () {
//    $('.destination').appendTo('.source');
//});

//$('TransferAcross').on('click', function () {
//    $('.source').appendTo('.destination');
//});

$(function () {

    $('#ui-state-highlight destination').on('dblclick', '.list-group-item', function () {
        $(this).appendTo('#ui-state-highlight source');
    });

    $('#ui-state-highlight source').on('dblclick', '.list-group-item', function () {
        $(this).appendTo('#ui-state-highlight destination');
    });

});


