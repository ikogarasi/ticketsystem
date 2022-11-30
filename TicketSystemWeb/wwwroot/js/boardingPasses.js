var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').dataTable({
        stateSave: true,
        "bDestroy": true,
        "ajax": {
            "url": "/Admin/BoardingPasses/GetAll"
        },
        "columns": [
            { "data": "userModel.fullName"},
            { "data": "userModel.email"},
            { "data": "passengerFirstName"},
            { "data": "passengerSecondName"},
            { "data": "genderString"},
            { "data": "birthDate"},
            { "data": "route.name"},
            { "data": "seatString"},
            /*{
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a class="btn btn-primary mx-2" href="/admin/routes/upsert?id=${data}">Edit</a>
                            <a class="btn btn-danger mx-2" id="btnDelete" data-id="${data}" data-bs-target="#deleteModal" data-bs-toggle="modal">Delete</a>
                        </div>`
                },
                "width": "15%"
            }*/
        ]
    });
}