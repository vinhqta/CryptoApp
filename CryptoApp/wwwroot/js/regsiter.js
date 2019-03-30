$(document).ready(function () {
    $("#register_form").submit(function (e) {
        registerUser();
        e.preventDefault();
    });
});

function registerUser() {
    var url = "https://localhost:44335/api/user";
    var email = $('#email').val();
    var password = $('#password').val();
    var json = {
        "Email": email,
        "Password": password,
        "Coin": []
    }
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(json),
        contentType: "application/json",
        success: function (response) {
            document.location.href = 'https://localhost:44335/';
            console.log(response);
        }
    });
}



