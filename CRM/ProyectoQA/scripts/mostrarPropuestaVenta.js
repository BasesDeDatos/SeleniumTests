function propuestaVentaXContacto($idContactoPersona) {
    $("body").css("cursor", "progress");
    $.ajax({
        async: false,
        type: "POST",
        url: "ContactoPersona.aspx/propuestaVentaXContactoJS",
        data: '{idContactoPersona: ' + $idContactoPersona + ', accion: false}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: resultadoPropuesta,
        error: errores

    });
    $.ajax({
        async: false,
        type: "POST",
        url: "ContactoPersona.aspx/propuestaVentaXContactoJS",
        data: '{idContactoPersona: ' + $idContactoPersona + ', accion: true}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: resultadoVenta,
        complete: function () {
            mostrarModal()
        },
        error: errores

    });
    $("body").css("cursor", "default");


}
function resultadoPropuesta(msg) {
    //msg.d tiene el resultado devuelto por el método
    var contactoPropuesta = document.getElementById("contactoPropuesta");
    contactoPropuesta.innerHTML = msg.d;

}

function resultadoVenta(msg) {
    //msg.d tiene el resultado devuelto por el método
    var contactoPropuesta = document.getElementById("contactoVenta");
    contactoPropuesta.innerHTML = msg.d;


}

function errores(msg) {
    //msg.responseText tiene el mensaje de error enviado por el servidor
    alert('Error: ' + msg.d);
}
function mostrarModal() {
    $('#contactoPropuestaModal').modal('show');
}

