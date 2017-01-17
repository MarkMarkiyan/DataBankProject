$(document).ready(function () {

    var dataModel = new Object;
    dataModel.Type = dataType.toString();

    $('#saveButton').bind("click", function () {
        var allInputs = $(":input");

        var data = new Object;

        allInputs.each(function (index, item) {
            if (item.localName === "input") {
                data[item.id.toString()] = item.value;
            }
        });
        dataModel.Data = data;

        $.ajax({
            type: 'POST',
            url: '/api/DataApi/SaveData',
            data: JSON.stringify(dataModel),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function () {
                alert("Changes saved");
            }
        });
    });
});