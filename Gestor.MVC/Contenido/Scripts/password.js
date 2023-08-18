var campos = [];
var listaclientes_;

$(function () {
    $("#save_").click(function () {
        campos.length = 0;

        if ($("#fr_pass1").val() == "") { campos.push("Ingrese la nueva contraseña"); }
        else {
            if ($("#fr_pass2").val() == "") { campos.push("Vuelva a repetir la nueva contraseña"); }
            if ($("#fr_pass1").val() != $("#fr_pass2").val()) { campos.push("Las contraseñas no coinciden"); }
        }

        var strCampos = "";
        if (campos.length > 0) {
            for (var indice in campos) {
                strCampos += campos[indice] + "\n";
            }

            swal({
                title: "Validacion",
                text: strCampos
            });
        }
        else { save_(); }
    });
});

function save_() {
    swal({
        title: "Desea cambiar su password?",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, Guardar!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            type: 'POST',
            url: "ModificarPassword",
            dataType: 'json',
            data: { pass: $('#fr_pass1').val() },
            success: function () {
                $("#fr_pass1").prop("readonly", false).val("");
                $("#fr_pass2").prop("readonly", false).val("");
                swal("Correcto!", "Proceso exitoso!.", "success");
            },
            error: function (err) { swal("Error", "Error al guardar!", "error"); }
        });
    });
}