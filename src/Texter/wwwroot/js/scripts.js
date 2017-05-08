$(function () {
    $("#add-contact").submit(function (potato) {
        potato.preventDefault();

        $.ajax({
            url: 'Contact/Create',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                ajaxGetAll();
            }
        });
    });

    var ajaxGetAll = function () {
        console.log("Inside getAll");
        $.ajax({
            url: 'Contact/GetAll',
            type: 'GET',
            dataType: 'json',
            success: function (result) {
                var htmlString = "";
                for (var i = 0; i < result.length; i++)
                {
                    htmlString += "<div class='contact'>" +
                        "<p>" + result[i].name + "</p>" +
                        "</div>"
                }

                $(".results").html(htmlString);
            }
        });
    }
});