$(document).ready(function () {

    var currentDataType = "User";

    $("#CreateNewEntityBtn").click(function () {
        window.location.href = "Home/AddNewEntity?type=" + currentDataType;
    });

    function getDataList(type) {
        FillDataTable();
    };

    document.getElementById('DataTypesDropDown').onchange = function (dropDown) {
        var selectedValue = dropDown.currentTarget.value;
        currentDataType = selectedValue;
        getDataList(selectedValue);
    };

    function FillDataTable() {
        $.ajax({
            url: 'api/DataApi/GetDataByType?type=' + currentDataType,
            type: 'GET',
            contentType: 'application/json',
            data: JSON,
            success: function (data) {
                if (data != null) {
                    var table = document.getElementById("mainTable");
                    table.innerHTML = "<table id=\"mainTable\" class=\"table table-striped\"><tr id=\"titleRow\"></tr></table";

                    var row = document.getElementById("titleRow");
                    var listProp = Object.getOwnPropertyNames(data[0]);

                    var items;
                    listProp.forEach(function (item, propertyIndex, a) {
                        var x = row.insertCell(propertyIndex);
                        x.innerHTML = item;
                        items = propertyIndex;
                    });

                    items++;
                    var x = row.insertCell(items);
                    x.innerHTML = "Edit";
                    items++;
                    x = row.insertCell(items);
                    x.innerHTML = "Delete";

                    data.forEach(function (item, index, a) {
                        var row1 = table.insertRow(index + 1);

                        listProp.forEach(function (propItem, i, a) {
                            var cell1 = row1.insertCell(i);
                            cell1.innerHTML = data[index][propItem];
                            items = i;
                        });
                        items++;
                        x = row1.insertCell(items);

                        var editBtn = document.createElement('button');
                        editBtn.innerHTML = "Edit";
                        editBtn.onclick = function () {
                            window.location.href = "Home/Edit?Id=2&Type=" + currentDataType;
                        };
                        x.append(editBtn);
                        items++;
                        x = row1.insertCell(items);
                        x.innerHTML = "<button>Delete</button>";
                    });
                }
            }
        });
    }
});