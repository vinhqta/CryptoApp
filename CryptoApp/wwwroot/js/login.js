$(document).ready(function () {
    $("#login_form").click(function () {
        getCoinData();
    });
});

function handleLogin() {
    var login = $("login");
    var password = $("password");
    $.ajax({
        type: "GET",
        url: url,
        data: json,
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            addRowToCoinTable(response);
        }
    });
}