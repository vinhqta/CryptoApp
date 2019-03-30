$(document).ready(function () {
    $("#coin_btn").click(function () {
        getCoinData();
        $("#CoinText").val('');
    });
});

function getCoinData() {
    var coin = $("#CoinText").val();
    var json = { "name": coin }
    var url = "https://localhost:44335/coins/listing/coin";
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

function addRowToCoinTable(json) {
    var html = "<tr> <th scope='row'>";
    html += json.rank + "</th>";
    html += "<td>" + json.name + "</td>";
    html += "<td>" + json.price_usd + "</td>";
    html += "<td>" + json.percent_change_24h + "% </td>";
    html += "</tr>"
    $("table tbody").append(html);
}