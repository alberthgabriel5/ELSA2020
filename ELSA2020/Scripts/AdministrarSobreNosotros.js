$(document).ready(function () {
    //cargaTexto();
    $('#btnGuardarSobreNosotros').attr("disabled", false);
    $('#btnCancelarSobreNosotros').attr("disabled", false);
});

function cargaTexto() {
    $.ajax({
        url: "/Admin/CargaPaginaSobreNosotros",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#textoSobreNosotros').val(result.valorTexto);
        },

        error: function (errorMessage) {
            alert(errorMessage.responseText);
        }
    });
}


function desecharCambios() {
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
                    $('#textAreaNuevaDescripcion').val('');
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

function cambiarTextoSobreNosotros(id) {
    
    var parametros = {
        'texto': $('#textAreaNuevaDescripcion').val(),
        'id': id
    }



    $.ajax({
        type: "POST",
        url: "/Admin/ActualizaTextoPaginaSobreNosotros",
        data: parametros,
        success: function (data) {
            $('#textAreaNuevaDescripcion').val('');
            $('#btnGuardarSobreNosotros').attr("disabled", true);
            $('#btnCancelarSobreNosotros').attr("disabled", true);
            setTimeout(function () {
                $('#msjExito').html('Cambio Realizado');
                $('#msjExito').fadeIn(2500);
            }, 1000);
            setTimeout(function () {
                $('#msjExito').fadeOut(2500);
                
            }, 1000);
            setTimeout(function () {
                window.location.href = "/Admin/Index";
            }, 4000);
            $("#msjExito").val('');
            

        }
    });
}