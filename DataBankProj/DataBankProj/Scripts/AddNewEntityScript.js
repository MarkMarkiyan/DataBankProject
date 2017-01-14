$(document).ready(function () {

    $("#saveButton").click(function () {
        $.post("/api/DataApi/DeleteData",
     {
         name: "Donald Duck",
         city: "Duckburg"
     },
     function (data, status) {
         window.location.href = "Home/Index";
     });
    });

});