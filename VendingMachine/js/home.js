//this is the javascript file for my vendig machine
"use strict";
$(document).ready(function () {

    loadSnacks();

});
function loadSnacks(){
    
    var snackStuff = $('#snack')
    

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function(snackArray){
            $.each(snackArray, function(index, snack){
                var num = index;
                var name = snack.name;
                var price = snack.price;
                var quantity = snack.quantity;

                    //    var newSnack = '<div class="panel panel-default" id="snack"> <button> <div class="panel-heading">';
                    //        newSnack += '<h4>' + name + '</h4>'; 
                    //        newSnack += '</div> <div class="panel-body pheat-body">';
                    //        newSnack += '<h4>' + price + '</h4>'; 
                    //        newSnack += '</div> <div class="panel-footer">';
                    //        newSnack += '<h4>' + quantity + '</h4>'; 
                    //        newSnack += '</div> </button> </div>';
                
                
                 var newSnack = '<h4>' + name + index + '<h4>';

                snackStuff.append(newSnack);
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
