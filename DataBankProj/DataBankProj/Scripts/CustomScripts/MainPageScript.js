$(document).ready(function () {

    var x = document.getElementById('EditEntityForm');
    x.style.visibility = 'hidden';
    function EditButtonClick() {
        var x = document.getElementById('EditEntityForm');
        x.style.visibility = 'visible';
    }

    $.ajax({
        url: 'api/DataApi',
        type: 'GET',
        contentType: 'application/json',
        data: JSON,
        success: function (data) {
            var row = document.getElementById("titleRow");
            var listProp = Object.getOwnPropertyNames(data[0]);

            var items;
            listProp.forEach(function (item, i, a) {

                var x = row.insertCell(i);
                x.innerHTML = item;
                items = i;
                alert(Object.getOwnPropertyDescriptor(data[0], item).set);

            });

            items++;
            var x = row.insertCell(items);
            x.innerHTML = "Edit";
            items++;
            x = row.insertCell(items);
            x.innerHTML = "Delete";

            var table = document.getElementById("mainTable");

            data.forEach(function (item, index, a) {
                var row1 = table.insertRow(index + 1);

                //// Insert new cells (<td> elements) at the 1st and 2nd position of the "new" <tr> element:
                listProp.forEach(function (propItem, i, a) {
                    var cell1 = row1.insertCell(i);
                    cell1.innerHTML = data[index][propItem];
                    items = i;
                });
                items++;
                x = row1.insertCell(items);
                x.innerHTML = "<button onclick='EditButtonClick()'>Edit</button>";
                items++;
                x = row1.insertCell(items);
                x.innerHTML = "<button>Delete</button>";
            });
        }
    });
});