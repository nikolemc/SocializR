$(document).ready(() => {
    console.log("loaded")
    $(".time").each(function () {
        console.log("formatid", this)
        let _formattedDate = moment($(this).html()).format("ddd MMMM YYYY, h:mm:ss a");
        //let _formattedDate = moment($(this).html()).startOf("minute").fromNow();
        $(this).html(_formattedDate);
    });
    
});




