$(document).ready(function () {
    $('form').find('input[type=text],textarea,select').filter(':visible:first').focus();


    $(document).on("submit", ".deleteConfirm", function() {
        
        var url = $(this).attr('action');
        $('#deleteConfirmModal #deleteConfirmed').attr('action', url);
        $('#deleteConfirmModal').modal('show');
        return false;
    });
});