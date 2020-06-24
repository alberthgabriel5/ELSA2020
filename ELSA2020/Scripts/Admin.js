function Registrarse() {
    var parametros = {
        'nombre': $("#nombre").val(),
        'apellidos': $("#apellidos").val(),
        'nombreUsuario': $("#usuario").val(),
        'contrasenna': $("#contrasenna").val()
    };
    if (parametros.nombre === "" || parametros.apellidos === "" || parametros.nombreUsuario === "" || parametros.contrasenna === "") {
        $("#mensaje").html("Datos incompletos");
    } else {
        $.ajax(
            {
                url: "/Admin/RegistrarNuevoUsuario",
                type: "POST",
                data: parametros,
                beforeSend: function () {
                    $("#mensaje").html("Procesando, \n\ espere por favor...");
                },
                success: function (data) {
                    if (data != '') {
                        $("#mensaje").html("Nombre de usuario no disponible");
                    } else {
                        alert("Usuario Regitrado correctamente");
                        $("#nombre").val("");
                        $("#apellidos").val("");
                        $("#usuario").val("");
                        $("#contrasenna").val("");
                        $("#mensaje").html("");
                    }
                }
            }
        );
    }
}