$(document).ready(function () {
    $("#btnSubmit").click(function () {
        var urlGet = '/Person/GetPersonName/' + $("#txtPersonID").val();
        $.ajax({
            url: urlGet,
            type: "GET",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#txtPersonName").val(data);
            },
            error: function (e) {
                alert(e);
            }
        });
    });


    $("#btnAdd").click(function () {
        $.ajax({
            url: '/Person/AddPerson',
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function () {
                alert('Person added sucessfully');
            },
            error: function (e) {
                alert(e);
            }
        });
    });

    $("#btnDelete").click(function() {
        $.ajax({
            url: '/Person/DeletePerson',
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function () {
                alert('Person removed sucessfully');
            },
            error: function (e) {
                alert(e);
            }
        });
    });

    $("#btnUpdate").click(function () {
        $.ajax({
            url: '/Person/UpdatePerson',
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function () {
                alert('Person updated sucessfully');
            },
            error: function (e) {
                alert(e);
            }
        });
    });

});





