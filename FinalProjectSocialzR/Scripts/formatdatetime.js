$(document).ready(() => {
    console.log("loaded")
    $(".time").each(function () {
        console.log("formatid", this)
        let _formattedDate = moment($(this).html()).format("h:mm a");
        $(this).html(_formattedDate);
    });

    $(".date").each(function () {
        console.log("formatid", this)
        let _formattedDay = moment($(this).html()).format("DD");
        $(this).html(_formattedDay);
    });
});