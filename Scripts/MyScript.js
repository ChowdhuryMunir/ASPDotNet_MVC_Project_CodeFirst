var AllowanceCategories = []

function LoadCategory(element) {
    if (AllowanceCategories.length == 0) {
        $.ajax({
            type: "GET",
            url: '/Default/getAllowanceCategories',
            success: function (data) {
                AllowanceCategories = data;
                renderCategory(element);
            }
        })
    }
    else {
        renderCategory(element);
    }
}

function renderCategory(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));

    $.each(AllowanceCategories, function (i, val) {
        $ele.append($('<option/>').val(val.AllowanceCategoryId).text(val.AllowanceCategoryName));
    });
}

function LoadProduct(categoryDD) {
    $.ajax({
        type: "GET",
        url: '/Default/getAllowance',
        data: { 'AllowanceCategoryId': $(categoryDD).val() },
        success: function (data) {
            renderProduct($(categoryDD).parents('.mycontainer').find('select.allowanceName'), data);
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function renderProduct(element, data) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));

    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.AllowanceTypeId).text(val.AllowanceName));
    });
}

$(document).ready(function () {
    LoadCategory($('#allowanceCategory'));

    $("#add").click(function () {
        var isAllvalid = true;

        if ($('#allowanceCategory').val() == "0") {
            isAllvalid = false;
            $('#allowanceCategory').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#allowanceCategory').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#allowanceName').val() == "0") {
            isAllvalid = false;
            $('#allowanceName').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#allowanceName').siblings('span.error').css('visibility', 'hidden');
        }

        if (!$('#amount').val().trim() != "" && (parseInt($('#amount').val()) || 0)) {
            isAllValid = false;
            $('#amount').siblings('span.error').css('visibility', 'visible');
        } else {
            $('#amount').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllvalid) {
            var $newRow = $('#mainrow').clone().removeAttr('id');
            $('.pc', $newRow).val($('#allowanceCategory').val());
            $('.allowanceName', $newRow).val($('#allowanceName').val());
            $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');
            $('#allowanceCategory, #allowanceName, #amount, #add', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();

            $('#allowanceDetailsItems').append($newRow);
            $('#allowanceCategory, #allowanceName').val('0');
            $('#amount').val('');
            $("#allowanceItemError").empty();
        }
    });

    $('#allowanceDetailsItems').on('click', '.remove', function () {
        $(this).parents('tr').remove();
    });

    $('#submit').click(function () {
        var isAllValid = true;
        $('#allowanceItemError').text('');
        var list = []
        var errorItemCount = 0;

        $('#allowanceDetailsItems tbody tr').each(function (index, ele) {
            if ($('select.allowanceName', this).val() == "0" || (parseInt($('.amount', this).val()) || 0) == 0 || isNaN($('.amount', this).val())) {
                errorItemCount++;
                $(this).addClass('error');
            }
            else {
                var allowanceItem = {
                    AllowanceTypeId: $('select.allowanceName', this).val(),
                    Amount: parseInt($('.amount', this).val())
                };
                console.log($('select.allowanceName', this).val())
                console.log($('.amount', this).val())

                list.push(allowanceItem);
            }
        });

        /*console.log("Hello")*/
        if (errorItemCount > 0) {
            $('#allowanceItemError').text(errorItemCount + " Invalid entry in allowance item list!!!");
            isAllValid = false;
        }

        if (list.length == 0) {
            $('#allowanceItemError').text(" At least one entry is required to save employee allowance information!!!");
            isAllValid = false;
        }

        if ($('#employeeName').val().trim() == '') {
            $('#employeeName').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        } else {
            $('#employeeName').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#payDate').val().trim() == '') {
            $('#payDate').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        } else {
            $('#payDate').siblings('span.error').css('visibility', 'hidden');
        }

        console.log(list)

        if (isAllValid) {
            var data = {
                EmployeeName: $('#employeeName').val(),
                Address: $('#address').val(),
                PhoneNo: $('#phoneNo').val(),
                Image: $('#imageupload').val().trim(),
                PaymentDate: $('#payDate').val().trim(),
                //Terms: $('#bool').is('.checked'),
                Details: list
            };

            $(this).val('Saving Info....');
            console.log(data)


            $.ajax({
                type: "POST",
                url: '/Default/Save',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        alert("Employee Allowance Information Saved Successfully!!!");
                        list = [];
                        $('#employeeName, #address, #phoneNo, #imageupload, #payDate, #bool').val('');
                        $('#allowanceDetailsItems').empty();
                        
                    }
                    else {
                        alert('Error Saving Information');
                    }
                    $('#submit').val('Save Information');
                },
                error: function (error) {
                    console.log(error);
                    $('#submit').val('Save Information');
                }
            });
        }
    });
});

LoadCategory($('#allowanceCategory'));