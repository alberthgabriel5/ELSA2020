$(document).ready(function () {
    validaFecha();
    cargaTipoHabitacion();

});

function prueba() {
    var fechaCorta = $("#fechaEntrada").val();
    var fechaLarga = $("#fechaSalida").val();
    var inicioReservacion = $("#fechaEntrada").datepicker('getDate');
    var finalReservacion = $("#fechaSalida").datepicker('getDate');

    if (!inicioReservacion || !finalReservacion)
        return;
    var days = 0;
    if (inicioReservacion && finalReservacion) {
        days = Math.floor((finalReservacion.getTime() - inicioReservacion.getTime()) / 86400000); // ms per day
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