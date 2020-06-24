function obtenerFacilidad(id) {
    $('#exampleModal').modal('show');  
    $('#idF').val(id); 
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

function desecharCambiosFacilidades() {
    $.confirm({
        title: 'Descartar Cambios',
        content: '¿Esta Seguro?',
        type: 'red',
        typeAnimated: true,
        buttons: {
            confirm: {
                text: 'Si',
                btnClass: 'btn-green',
                action: function () {
                    window.location.href = "/Admin/Index";
                }
            },
            close: {
                text: 'No',
                btnClass: 'btn-red',
                action: function () {
                }
            }
        }

    });

}

function actualizarFacilidad() {

    var parametros = {
        'texto': $('#textAreaDescripcion').val(),
        'id': $('#idF').val()
    }

    

    $.ajax({
        type: "POST",
        url: "/Admin/ActualizaTextoPaginaFacilidades",
        data: parametros,
        success: function (data) {
            toastr.success("Actualizado");
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "2000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }

            setTimeout(function () {
                window.location.href = "/Admin/Index";
            }, 2000);
        }
    });
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