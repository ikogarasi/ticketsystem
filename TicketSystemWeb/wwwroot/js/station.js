var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').dataTable({
        stateSave: true,
        "bDestroy": true,
        "ajax": {
            "url": "/Admin/Stations/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <button class="btn btn-primary mx-2" id="btnEdit" data-id="${data}" data-bs-target="#upsertModal" data-bs-toggle="modal">Edit</button>
                            <button class="btn btn-danger mx-2" id="btnDelete" data-id="${data}" data-bs-target="#upsertModal" data-bs-toggle="modal">Delete</button>
                        </div>`
                },
                "width": "15%"
            }
        ]
    });
}

var popup = document.getElementById('upsertModal')

popup.addEventListener('show.bs.modal',
    function (event) {
        var button = event.relatedTarget
        if (button.textContent == "Create") {
            upsertModal.querySelector('#modalInput').readOnly = false;
            upsertModal.querySelector('#modalInput').value = "";
            upsertModal.querySelector('#modalLabel').textContent = 'Create';
            upsertModal.querySelector('#actionBtn').textContent = 'Create';
        }
        else if (button.textContent == "Edit") {
            upsertModal.querySelector('#modalInput').readOnly = false;
            upsertModal.querySelector('#modalLabel').textContent = 'Edit';
            upsertModal.querySelector('#actionBtn').textContent = 'Edit';
            $.ajax({
                type: "GET",
                url: "/admin/stations/getstation?",
                data: { "id": button.getAttribute("data-id") },
                success: function (response) {
                    if (response['success'] == true) {
                        upsertModal.querySelector('#modalInput').value = response['name'];
                    }
                }
            });
        }
        else {
            upsertModal.querySelector('#modalLabel').textContent = 'Delete';
            upsertModal.querySelector('#actionBtn').textContent = 'Delete';
            $.ajax({
                type: "GET",
                url: "/admin/stations/getstation?",
                data: { "id": button.getAttribute("data-id") },
                success: function (response) {
                    if (response['success'] == true) {
                        upsertModal.querySelector('#modalInput').value = response['name'];
                    }
                }
            });
            upsertModal.querySelector('#modalInput').readOnly = true;
        }
    });