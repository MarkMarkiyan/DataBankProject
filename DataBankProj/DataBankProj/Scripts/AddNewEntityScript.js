$(document).ready(function () {

    $("#saveButton").click(function () {
        window.location.href = "Home/AddNewEntity?type=" + currentDataType;
    });

});