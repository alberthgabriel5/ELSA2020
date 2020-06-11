function actualizarHome(imagenNombre) {
    var descripcion = $("#descripcion").val();
    var selectFile = ($('#imagen'))[0].files[0];
    var dataString = new FormData();

    if (!selectFile) {
        dataString.append("imagen", selectFile);
        dataString.append("imagenNombre", imagenNombre);
        dataString.append("estado", "No");
        dataString.append("descripcion", descripcion);
        dataString.append("id", 1);
    } else {
        dataString.append("imagen", selectFile);
        dataString.append("imagenNombre", "");
        dataString.append("estado", "Si");
        dataString.append("descripcion", descripcion);
    }

    $.ajax(
        {
            url: "/Admin/actualizarHomePaginna",
            type: "POST",
            contentType: false,
            data: dataString,
            processData: false,
            beforeSend: function () {
                $("#mensaje").html("Procesando, \n\ espere por favor...");
            },
            success: function (data) {
                $.confirm({
                    title: 'Informacion',
                    content: 'Actualizacion Exitosa',
                    type: 'green',
                    typeAnimated: true,
                    buttons: {
                        confirm: {
                            text: 'Aceptar',
                            btnClass: 'btn-green',
                            action: function () {
                                window.location.href = "/Admin/Index";
                            }
                        }
                    }

                });
            }
        }
    );


}

function cancelarActualizarHome(descripcion, imagenNombre) {
    var descripcionCambiada = $("#descripcion").val();
    var selectFile = ($('#imagen'))[0].files[0];
    var dataString = new FormData();
    if (descripcion == descripcionCambiada && !selectFile) {
            window.location.href = "/Admin/Index";
    } else {
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
                        $('#descripcion').val('');
                        $('#imagen').val('');
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

}
