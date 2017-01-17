$(document).ready(function () {

    var currentDataType = "User";

    $("#CreateNewEntityBtn").click(function () {
        window.location.href = "Home/AddNewEntity?type=" + currentDataType;
    });

    function getDataList() {
        FillDataTable();
    };

    document.getElementById('DataTypesDropDown').onchange = function (dropDown) {
        var selectedValue = dropDown.currentTarget.value;
        currentDataType = selectedValue;
        getDataList();
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
                    table.innerHTML = "<table id=\"mainTable\" class=\"table table-striped\"><tr id=\"titleRow\"></tr></table>";

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
                        var dataRow = table.insertRow(index + 1);

                        listProp.forEach(function (propItem, i, a) {
                            var dataCell = dataRow.insertCell(i);
                            dataCell.innerHTML = data[index][propItem];
                            items = i;
                        });
                        items++;
                        x = dataRow.insertCell(items);

                        var editBtn = document.createElement('button');
                        editBtn.innerHTML = "Edit";
                        editBtn.className = "class=\"btn .btn-success\"";
                        editBtn.onclick = function () {
                            window.location.href = "Home/Edit?Id=" +item.Id + "&Type=" + currentDataType;
                        };
                        x.append(editBtn);

                        items++;
                        x = dataRow.insertCell(items);
                        var deleteBtn = document.createElement('button');
                        deleteBtn.innerHTML = "Delete";
                        deleteBtn.className = "class=\"btn .btn-success\"";
                        deleteBtn.onclick = function () {
                            $.ajax({
                                url: 'api/DataApi/DeleteData?type=' + currentDataType + '&id=' + data[index]['Id'],
                                type: 'POST',
                                contentType: 'application/json',
                                data: JSON,
                                success: function() {
                                    table.deleteRow(index + 1);
                                }
                            });
                        };
                        x.append(deleteBtn);;
                    });
                }
            }
        });
    }

    FillDataTable();
});