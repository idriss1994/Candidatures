// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// $(document).ready(function() {

//     $(".btn-delete").click = () => {
        
//     }
// });

let buttonsDelete = document.querySelectorAll('.btn-delete');
let btnClose = document.querySelector('.btn-no');

buttonsDelete.forEach(btn => btn.addEventListener("click", () => {
    document.querySelector('#pop').classList.add('open');
}));

btnClose.addEventListener("click", () => {
    document.querySelector('#pop').classList.remove('open');
});