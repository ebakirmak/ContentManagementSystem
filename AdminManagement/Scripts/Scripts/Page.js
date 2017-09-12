$(document).ready(function () {
    
    $('#MenuID').find('option').remove().end().append('<option value=""></option>').val('');
    $.post("/Page/MenuList", "", function (menuler) {
        $.each(menuler, function (i, eleman) {
            $('#MenuID').append($('<option>', {
                value: eleman.ID,
                text: eleman.Adi
            }));
         
        });
    });
});

