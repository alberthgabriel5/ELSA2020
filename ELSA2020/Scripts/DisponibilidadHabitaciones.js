$(document).ready(function () {
    validaFecha();
    cargaTipoHabitacion();
    $('#table').hide();
});

function disponibilidadHabitacion() {
    var fechaCortaIinicio = $("#fechaEntrada").val();
    var fechaCortaFin = $("#fechaSalida").val();
    var tipoHabitacion = $("#tipoHabitacion option:selected").val();
    $('#table').show();
    var inicioReservacion = $("#fechaEntrada").datepicker('getDate');
    var finalReservacion = $("#fechaSalida").datepicker('getDate');
   

    if (!inicioReservacion || !finalReservacion)
        return;
    var days = 0;
    if (inicioReservacion && finalReservacion) {
        days = Math.floor((finalReservacion.getTime() - inicioReservacion.getTime()) / 86400000); // ms per day
    }

    if (tipoHabitacion != '-1') {
        $.ajax({
            url: "/Admin/ListaDisponibilidadHabitaciones",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            data: {
                'fechaCortaIinicio': fechaCortaIinicio,
                'fechaCortaFin': fechaCortaFin,
                'dias': days,
                'tipoHab': tipoHabitacion
            },
            success: function (result) {
                
                dataSet = new Array();
                var html = '';
                $.each(result, function (key, item) {

                    data = [
                        
                        item.numero,
                        item.nombre,
                        item.precioColones,

                    ];

                    dataSet.push(data);
                });

                $('#table').DataTable({
                    "searching": true,
                    data: dataSet,
                    "bDestroy": true,
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
                    }
                });
               
            },

            error: function (errorMessage) {
                alert(errorMessage.responseText);
            }
        });
    } else {
        alert("Debe elegir un tipo de Habitacion");
    }


}

function cargaTipoHabitacion() {

    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "/Admin/ListaNombreHabitaciones",
            data: "{}",
            success: function (data) {
                var s = '<option value="-1">Tipo de Habitacion</option>';
                s += '<option value="0">Todas</option>';
                for (var i = 0; i < data.length; i++) {
                    s += '<option value="' + data[i].id + '">' + data[i].nombre + '</option>';
                }
                $("#tipoHabitacion").html(s);
            }
        });
    });
}


function validaFecha(){

    var getDate = function (input) {
        return new Date(input.date.valueOf());
    }

    $('#fechaEntrada, #fechaSalida').datepicker({
        format: "yyyy/mm/dd",
        language: 'es'
    });

    $('#fechaEntrada').datepicker({
        startDate: '+5d',
        endDate: '+35d',
    }).on('changeDate',
        function (selected) {
            $('#fechaSalida').datepicker('setStartDate', getDate(selected));
        });

    $('#fechaSalida').datepicker({
        startDate: '+6d',
        endDate: '+36d',
    }).on('changeDate',
        function (selected) {
            $('#fechaEntrada').datepicker('setEndDate', getDate(selected));
        });

};