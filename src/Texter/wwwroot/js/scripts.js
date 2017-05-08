$(function () {
    $("#add-contact").submit(function (potato) {
        potato.preventDefault();

        $.ajax({
            url: 'Contact/Create',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                console.log(result);
            }
        });
    });
});