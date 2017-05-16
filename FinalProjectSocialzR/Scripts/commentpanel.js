
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

