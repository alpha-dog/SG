//this is the javascript file for my vendig machine
"use strict";
$(document).ready(function () {

    loadSnacks();

});
function loadSnacks(){
    
    
    var columnCount = 1;
    var newRow = true;
    var rowCount = 1;

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function(snackArray){
            $.each(snackArray, function(index, snack){
                var num = index;
                var name = snack.name;
                var price = snack.price;
                var quantity = snack.quantity;
                

                            //make it even more dynamic and add an id for button that uses the index to number it
                    //    var newSnack = '<div class="panel panel-default" id="snack"> <button> <div class="panel-heading">';
                      var  newSnack = '';
                      var newSnackRow = '';
                           if(newRow)
                           {
                               newSnackRow += '<div class="row first-row text-center row' + rowCount + '">\
            <div class="col-md-3 col-sm-4 col-xs-6 bottom-gutter column1"><div class="panel panel-default span4"  id="snack"></div></div>\
            <div class="col-md-3 col-sm-4 col-xs-6 bottom-gutter column2"><div class="panel panel-default span4"  id="snack"></div></div>\
            <div class="col-md-3 col-sm-4 col-xs-6 bottom-gutter column3"><div class="panel panel-default span4"  id="snack"></div></div></div>'
            $('.container').append(newSnackRow);
            
                           }
                           var snackStuff = $('.row' + rowCount + ' .column' + columnCount + ' #snack');
                           newSnack += '<button> <div class="panel-heading"> <h4>' + name + '</h4>'; 
                           newSnack += '</div> <div class="panel-body pheat-body">';
                           newSnack += '<h4>' + price + '</h4>'; 
                           newSnack += '</div> <div class="panel-footer">';
                           newSnack += '<h4>' + quantity + '</h4>'; 
                           newSnack += '</div> </button> </div>';

                
                //  var newSnack = '<h4>' + name + index + '<h4>';

                snackStuff.append(newSnack);
                if(columnCount >= 3)
                {
                    newRow = true;
                    rowCount++;
                    columnCount = 0;
                }
                else
                {
                    newRow = false;
                }
                columnCount++;
                
            });

        },
        error: function(){
            $('#errorMessages')
                .append($('<li>').attr({class: 'list-group-item list-group-danger'})
                .text('Error calling web service. Please try again later.'));

        }
    })
}
// function loadContacts(){
//     clearContactTable();
//     var contentRows = $('#contentRows')

//     $.ajax({
//         type: 'GET',
//         url: 'http://localhost:8080/contacts',
//         success: function(contactArray) {
//             $.each(contactArray, function(index, contact) {
//                 var name = contact.firstName + ' ' + contact.lastName;
//                 var company = contact.company;
//                 var contactId = contact.contactId;

//                 var row = '<tr>';
//                     row += '<td>' + name + '</td>';
//                     row += '<td>' + company + '</td>';
//                     row += '<td><a onclick="showEditForm(' + contactId + ')">Edit</a></td>';
//                     row += '<td><a onclick="deleteContact(' + contactId + ')">Delete</a></td>';
//                     row += '</tr>';

//                 contentRows.append(row);
//             });
//         },
//         error: function(){
//             $('#errorMessages')
//                 .append($('<li>').attr({class: 'list-group-item list-group-danger'})
//                 .text('Error calling web service. Please try again later.'));
//         }
//     });
// }
