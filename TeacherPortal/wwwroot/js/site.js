// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function Changed()
{
   

    if ($('#courseSelection option:selected').val() != 0) {
        var selected = $('#courseSelection option:selected').val();
        var decription = $('#courseSelection option:selected').text();

        alert('You Selected : ' + selected + '-' + ' ' + decription);
    }
    else
        alert('you must select a course');
}
