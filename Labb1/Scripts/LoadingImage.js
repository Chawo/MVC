$(document).ready(function () {
    $('#button-upload').click(function () {
        $('#spinner').show();
    }).bind("ajaxStop", function () {
        $(this).hide();
    }).bind("ajaxError", function () {
        $(this).hide();
    });
});