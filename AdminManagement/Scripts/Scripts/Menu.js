//DropDownListFor nesnelerine değer girmek.
$(document).ready(function () {
    DropDown();
    //KonumTipi nesnesinin change olayında
    $("#KonumTipi").change(function () {
        DropDown();
    });


});

function DropDown()
{
    if (($("#KonumTipi").val()) == "ANAMENU") {
        //KonumID nesnesinin option değerleri kaldırılıyor.
        $('#KonumID').find('option').remove().end().append('<option value=""></option>').val('');
        //Yeni Option değerleri giriliyor.
        $('#KonumID').append($('<option>', {
            value: 0,
            text: "ANAMENU"
        }));
    }
    else if (($("#KonumTipi").val()) == "ALTMENU") {

        $.post("/Menu/Konum", { deger: "ANAMENU" }, function (data) {

            //KonumID nesnesinin option değerleri kaldırılıyor.
            $('#KonumID').find('option').remove().end().append('<option value=""></option>').val('');
            //Yeni Option değerleri giriliyor.
            $.each(data, function (i, eleman) {
                $('#KonumID').append($('<option>', {
                    value: eleman.ID,
                    text: eleman.Adi
                }));
            });

        });
    }


    else if (($("#KonumTipi").val()) == "SONMENU") {
        $.post("/Menu/Konum", { deger: "ALTMENU" }, function (data, status) {
            //KonumID nesnesinin option değerleri kaldırılıyor.
            $('#KonumID').find('option').remove().end().append('<option value=""></option>').val('');
            //Yeni Option değerleri giriliyor.        
            $.each(data, function (i, eleman) {
                $('#KonumID').append($('<option>', {
                    value: eleman.ID,
                    text: eleman.Adi
                }));
            });
        });
    }
}
