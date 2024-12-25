(function ($) {
    "use strict";
    var currentUrl = window.location.host;
    $('.column100').on('mouseout', function () {
        var table1 = $(this).parent().parent().parent();
        var table2 = $(this).parent().parent();
        var verTable = $(table1).data('vertable') + "";
        var column = $(this).data('column') + "";
        $(table2).find("." + column).removeClass('hov-column-' + verTable);
    });

    $('input[type=checkbox]').change(function () {
        if ($('input[type=checkbox]:checked').length >= 1) {
            $('input[type=checkbox]:not(:checked)').attr('disabled', "disabled");
        } else {
            $('input[type=checkbox]:disabled').removeAttr('disabled');
        }
    });

    $('#button_').click(function () {
        var userId = $('input[type=checkbox]:checked').attr('id') || 'Оберіть співробітника!';
        if (isNaN(userId)) {
            alert("Співробітника не обрано!\nЩоб вибрати натисніть на чек бокс поряд із потрбним співробітником");
        } else {
            $.ajax({
                url: '/Staff/DeleteStaff',
                type: 'POST',
                data: {
                    Id: userId
                },
                success: function () {
                    document.getElementById("tr_" + userId).remove();
                    $('input[type=checkbox]:disabled').removeAttr('disabled');
                }
            });
        }   
    });

    $('#buttonEdit_').click(function () {
        var userId = $('input[type=checkbox]:checked').attr('id') || 'Оберіть співробітника!';
        if (isNaN(userId)) {
            alert("Співробітника не обрано!\nЩоб вибрати натисніть на чек бокс поряд із потрбним співробітником");
        } else {
            $('input[type=checkbox]:disabled').removeAttr('disabled');
            window.location.replace("https://" + currentUrl + "/Staff/EditStaff/" + userId);
        }
    });

    $('#SaveEditStaff').click(function () {
        var IdUser = $('form').attr('id');
        var FirstName = $('#FirstName').prop('value');
        var LastName = $('#LastName').prop('value');
        var City = $('#City').prop('value');
        var ZipCode = $('#ZipCode').prop('value');
        var State = $('#State').prop('value');
        var Streets = $('#Streets').prop('value');
        var PhoneNumber = $('#PhoneNumber').prop('value');
        var Day = $('#Day').prop('value');
        var Mount = $('#Mount').prop('value');
        var Year = $('#Year').prop('value');
        var PassportCode = $('#PassportCode').prop('value');
        var TaxpayerCode = $('#TaxpayerCode').prop('value');
        var Department = $('#Department').prop('value');
        var RoleInDepartment = $('#RoleInDepartment').prop('value');
        $.ajax({
            url: '/Staff/SaveEditStaff',
            type: 'POST',
            data: {
                Id: IdUser,
                FirstName: FirstName,
                LastName: LastName,
                City: City,
                ZipCode: ZipCode,
                State: State,
                Streets: Streets,
                PhoneNumber: PhoneNumber,
                Day: Day,
                Mount: Mount,
                Year: Year,
                PassportCode: PassportCode,
                TaxpayerCode: TaxpayerCode,
                Department: Department,
                RoleInDepartment: RoleInDepartment
            },
            success: function () {
                window.location.replace("https://" + currentUrl + "/Staff");
            },
            error: function () {
                window.location.replace("https://" + currentUrl + "/Staff");
            }
        });
    });

    $('.view').click(function () {
        var modal = document.getElementById("myModal");
        // get <span>, becouse close modal window
        var span = document.getElementsByClassName("close")[0];
        modal.style.display = "block";
        // click <span> (x), user to close modal window
        span.onclick = function () {
            modal.style.display = "none";
        }
    });
})(jQuery);