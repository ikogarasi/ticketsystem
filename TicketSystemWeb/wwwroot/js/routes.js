var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').dataTable({
        stateSave: true,
        "bDestroy": true,
        "ajax": {
            "url": "/Admin/Routes/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "outgoingStation.name", "width": "15%" },
            { "data": "destinationStation.name", "width": "15%" },
            { "data": "distance", "width": "15%" },
            { "data": "duration", "width": "15%" },
            { "data": "price", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a class="btn btn-primary mx-2" href="/admin/routes/upsert?id=${data}">Edit</a>
                            <a class="btn btn-danger mx-2" id="btnDelete" data-id="${data}" data-bs-target="#deleteModal" data-bs-toggle="modal">Delete</a>
                        </div>`
                },
                "width": "15%"
            }
        ]
    });
}