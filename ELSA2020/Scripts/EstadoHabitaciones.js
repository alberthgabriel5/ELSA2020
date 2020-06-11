$(document).ready(function () {
    //listarEstadoHabitaciones();
    otro();

});

function otro() {
    var nueva = '';
$.ajax({
    url: "/Admin/listarEstadoHabitaciones",
    type: "GET",
    contentType: "application/json;charset=utf-8",
    dataType: "json",
    success: function (result) {

        dataSet = new Array();
        var html = '';
        $.each(result, function (key, item) {
            if (item.estado == '0') {
                nueva = 'disponible';
            }
            else if (item.estado == '1') {
                nueva = 'ocupado';
            } else if (item.estado == '2') {
                nueva = 'Quien sabe';
            }
            data = [

                item.numero,
                item.tipo,
                nueva,

            ];

            dataSet.push(data);
        });

        $('#tableEstHab').DataTable({
            "searching": true,
            data: dataSet,
            "bDestroy": true,
            dom: 'Bfrtip',
            buttons: [
                {
                    extend: 'excelHtml5',
                    text: '<i class="fa fa-file-excel-o"></i>',
                    titleAttr: 'Exportar a Excel',
                    className: 'btn btn-success',
                    title: 'Estado del Hotel Colibrí Hoy',

                },
                {
                    extend: 'pdfHtml5',
                    text: '<i class="fa fa-file-pdf-o"></i>',
                    titleAttr: 'Exportar a PDF',
                    className: 'btn btn-danger',
                    title: 'Estado del Hotel Colibrí Hoy',
                },
                {
                    extend: 'print',
                    text: '<i class="fa fa-print"></i>',
                    titleAttr: 'Imprimir',
                    className: 'btn btn-warning',
                    title: 'Estado del Hotel Colibrí Hoy',
                },

            ],
            language: {
                "decimal": "",
                "emptyTable": "No hay información",
                "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Mostrar _MENU_ Entradas",
                "loadingRecords": "Cargando...",
                "processing": "Procesando...",
                "search": "Buscar:",
                "zeroRecords": "Sin resultados encontrados",
                "paginate": {
                    "first": "Primero",
                    "last": "Ultimo",
                    "next": "Siguiente",
                    "previous": "Anterior"
                }
            },

        });

    },
    error: function (errorMessage) {
        alert(errorMessage.responseText);
    }
});
}

function listarEstadoHabitaciones() {
    $.ajax({
        url: "/Admin/listarEstadoHabitaciones",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            dataSet = new Array();
            var html = '';
            $.each(result, function (key, item) {

                data = [

                    item.numero,
                    item.tipo,
                    item.estado,

                ];

                dataSet.push(data);
            });

            $('#tableEstHab').DataTable({
                "searching": true,
                data: dataSet,
                "bDestroy": true,
                dom: 'Bfrtip',
                buttons: [
                    {
                        extend: 'excelHtml5',
                        text: '<i class="fa fa-file-excel-o"></i>',
                        titleAttr: 'Exportar a Excel',
                        className: 'btn btn-success',
                        title: 'Disponibilidad de las Habitaciones Hotel Colibrí',
                        messageTop: 'Durante las fechas de: ' + fechaCortaIinicio + ' al ' + fechaCortaFin

                    },
                    {
                        extend: 'pdfHtml5',
                        text: '<i class="fa fa-file-pdf-o"></i>',
                        titleAttr: 'Exportar a PDF',
                        className: 'btn btn-danger',
                        title: 'Disponibilidad de las Habitaciones Hotel Colibrí',
                        messageTop: 'Durante las fechas de: ' + fechaCortaIinicio + ' al ' + fechaCortaFin
                    },
                    {
                        extend: 'print',
                        text: '<i class="fa fa-print"></i>',
                        titleAttr: 'Imprimir',
                        className: 'btn btn-warning',
                        title: 'Disponibilidad de las Habitaciones Hotel Colibrí',
                        messageTop: 'Durante las fechas de: ' + fechaCortaIinicio + ' al ' + fechaCortaFin
                    },

                ],
                language: {
                    "decimal": "",
                    "emptyTable": "No hay información",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                    "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                    "infoPostFix": "",
                    "thousands": ",",
                    "lengthMenu": "Mostrar _MENU_ Entradas",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "Buscar:",
                    "zeroRecords": "Sin resultados encontrados",
                    "paginate": {
                        "first": "Primero",
                        "last": "Ultimo",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                },

            });

        },
        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}