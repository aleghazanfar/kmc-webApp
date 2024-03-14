var dataTable;
var DeptTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    debugger
    dataTable = $('#tblData').DataTable({
        "processing": true,
        "paging": true,
        "ajax": {
            "url": "/Reports/GetAll"
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "tittle", "width": "50%" },
            { "data": "directiveDate", "width": "20%" },
            { "data": "status", "width": "10%" },
            
        ],
       
    });
}



