//this is the javascript file for my vendig machine
"use strict";
$(document).ready(function () {

    loadSnacks();

});

function loadSnacks(){
    var snackNum = 1;

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function(contactArray) {
            $.each(contactArray, function(index, items) {
                
                var contentRows = $('#snack' + snackNum)
               
                var name = items.name;
                var price = items.price;
                var quantity = items.quantity;
                

                var snackLoader = ' <button>\
                                        <div class="panel-heading">\
                                            '+ name +'\
                                        </div>\
                                        <div class="panel-body pheat-body">\
                                            '+ price +'\
                                        </div>\
                                        <div class="panel-footer">\
                                            '+ quantity +'\
                                        </div>\
                                    </button>';
                  snackNum++;                  
                

                contentRows.append(snackLoader);
            });
        },
        error: function(){
            $('#errorMessages')
                .append($('<li>').attr({class: 'list-group-item list-group-danger'})
                .text('Error calling web service. Please try again later.'));
        }
    });
}
