// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.getElementById('registrationForm').addEventListener('submit', function (event) {
    //阻止表單默認行為
    event.preventDefault();

    const username = document.getElementById('username').value;
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;

    document.getElementById('resultUsername').textContent = username;
    document.getElementById('resultEmail').textContent = email;
    document.getElementById('resultPassword').textContent = password;
    //在同一頁呈現不跳頁
    document.getElementById('resultContainer').style.display = 'block';
});