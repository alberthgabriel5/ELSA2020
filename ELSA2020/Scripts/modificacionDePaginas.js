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
                if (typeof (data.Value) != "undefined") {
                    alert(data.Message);
                } else {
                    alert("Error no identificado");
                }
            }
        }
    );


}