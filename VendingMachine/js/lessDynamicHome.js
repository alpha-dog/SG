//this is the javascript file for my vendig machine
"use strict";

var total = 0;
var itemSelected = -1;

$(document).ready(function () {

    loadSnacks();
    $('#makePurchase').click(vendSnack);
    $('#getChange').click(changeReturn);
});

function loadSnacks() {
    var snackNum = 1;

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function (contactArray) {
            $.each(contactArray, function (index, items) {

                var contentRows = $('#snack' + snackNum);
                $('#snack' + snackNum).empty();

                var name = items.name;
                var price = items.price;
                var quantity = items.quantity;


                var snackLoader = ' <button value=' + snackNum + ' class="snackButton" data-id="' + snackNum + '">\
                                        <div class="panel-heading">\
                                            '+ snackNum + ' ' + name + '\
                                        </div>\
                                        <div class="panel-body pheat-body">\
                                            $'+ price + '\
                                        </div>\
                                        <div class="panel-footer">\
                                            Quantity Left: ' + quantity + '\
                                        </div>\
                                    </button>';
                snackNum++;


                contentRows.append(snackLoader);
            });
            $('.snackButton').click(function () {
                itemSelected = $(this).data("id");
                $('#snackSelection').val(itemSelected);
            });

        },
        error: function () {
            $('#message')
                .append($('<li>').attr({ class: 'list-group-item list-group-danger' })
                    .text('Error calling web service. Please try again later.'));
        }
    });
}
function vendSnack() {
    if (itemSelected != -1) {
        $.ajax({
            type: 'GET',
            ///money/{amount}/item/{id}
            url: 'http://localhost:8080/money/' + total + '/item/' + itemSelected + '',
            success: function (change, status) {
                $('#changeDisplay').val('Q:' + change.quarters + ' D:' + change.dimes + ' N:' + change.nickels + ' P:' + change.pennies);
                $('#snackMessage').val('enjoy your snack');
                //$('changeDisplay').val('q' + change.responseJSON.quarters, change.responseJSON.dimes. change.responseJSON.nickels, change.responseJSON.pennies)

                total = 0;
                $('#totalMoney').val(total);
            },
            error: function (xhr, status, error) {
                $('#snackMessage').val(xhr.responseJSON.message);
            }
        })
    }
    else{
        $('#snackMessage').text('please select a snack');
    }


}

function changeReturn (){
     
     loadSnacks();
     $('#changeDisplay').val('');
     $('#snackMessage').val('');
     $('#snackSelection').val('');
}
    


$('#addDollar').click(function () {
    total += 1;
    $('#totalMoney').val(total);
});

$('#addQuarter').click(function () {
    total += .25;
    $('#totalMoney').val(total);
});

$('#addDime').click(function () {
    total += .10;
    $('#totalMoney').val(total);
});

$('#addNickel').click(function () {
    total += .05;
    $('#totalMoney').val(total);
});

$('#snackButton1').click(function () {
    itemSelected = 1;
    $('#snackSelection').val(itemSelected);
});


