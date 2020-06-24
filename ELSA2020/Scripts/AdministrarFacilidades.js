$(document).ready(function () {
    //cargaTexto();
    //$('#btnGuardarSobreNosotros').attr("disabled", false);
    //$('#btnCancelarSobreNosotros').attr("disabled", false);
});


function obtenerFacilidad(id) {
    $('#exampleModal').modal('show');  
    $.ajax({
        url: "/Admin/CargaTextoPaginaFacilidades/" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#textAreaDescripcion').val(result.descripcionEsp);          
                   
            $('#exampleModalLabel').html('Actualizar Descripción');
        },

        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}

function actualizarFacilidad(id) {

    var parametros = {
        'texto': texto,
        'id': id
    }

    

    //$.ajax({
    //    type: "POST",
    //    url: "/Admin/ActualizaTextoPaginaSobreNosotros",
    //    data: parametros,
    //    success: function (data) {
    //        $('#textAreaNuevaDescripcion').val('');
    //        $('#btnGuardarSobreNosotros').attr("disabled", true);
    //        $('#btnCancelarSobreNosotros').attr("disabled", true);
    //        toastr.success("Actualizado");
    //        toastr.options = {
    //            "closeButton": false,
    //            "debug": false,
    //            "newestOnTop": false,
    //            "progressBar": false,
    //            "positionClass": "toast-top-right",
    //            "preventDuplicates": true,
    //            "onclick": null,
    //            "showDuration": "300",
    //            "hideDuration": "1000",
    //            "timeOut": "2000",
    //            "extendedTimeOut": "1000",
    //            "showEasing": "swing",
    //            "hideEasing": "linear",
    //            "showMethod": "fadeIn",
    //            "hideMethod": "fadeOut"
    //        }

    //        setTimeout(function () {
    //            window.location.href = "/Admin/Index";
    //        }, 2000);
    //    }
    //});
}


function cargaTexto() {
    $.ajax({
        url: "/Admin/CargaTextoPaginaFacilidades",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#textoFacilidades').val(result.descripcionEsp);
        },

        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}