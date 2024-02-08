/// 
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let table = new DataTable('.table', {
    language: {
        url: '/js/ar_localization.json',
    },
    "lengthMenu": [5,10, 25, 50, 75, 100],
    "pageLength": 5,
});