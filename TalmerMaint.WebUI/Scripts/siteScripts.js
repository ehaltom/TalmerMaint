$(document).ready(function () {
    $('form').find('input[type=text],textarea,select').filter(':visible:first').focus();
});