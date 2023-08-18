var controlador = siteRoot + 'administracion/';

function descargar_(nameArch, areanomb, opt) {
    $.ajax({
        type: 'POST',
        url: controlador + 'GetArchivo',
        data: {
            nameArch: nameArch,
            areanomb: areanomb,
            opt: opt
        },
        dataType: 'json',
        success: function (result) {

            if (result == 1) {// existe archivo
                window.location = controlador + "Exportar?fi=" + nameArch + "&n=" + areanomb + "&opt=" + opt;
            }
            if (result == -1) { // No existe archivo

                swal({
                    title: "Error en archivo!!",
                    text: "el archivo que intenta abrir no existe o esta dañado."
                });

            }
        },
        error: function () {
            mostrarError();
        }
    });
}