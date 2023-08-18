
var campos = [];
$(document).ready(function () {
    getlistapnp();

    $("#SaveData").click(function () {
        campos.length = 0;
        if ($("#id1").val() == "") { campos.push("Nombre completo:"); }
        if ($("#id2").val() == "") { campos.push("Usuario:"); }
        if ($("#id3").val() == "") { campos.push("Password:"); }
        if ($("#id4").val() == -1) { campos.push("Perfil de usuario:"); }
        if ($("#id5").val() == -1) { campos.push("Area o departamento:"); }
       // if ($("#id6").val() == "") { campos.push("Módulos:"); }
        if ($("#id7").val() == "0") { campos.push("Estado:"); }

        var strCampos = "";
        if (campos.length > 0) {
            for (var indice in campos) {
                strCampos += campos[indice] + "\n";
            }

            swal({
                title: "Ingrese datos en los Campos Obligatorios:",
                text: strCampos
            });
        }
        else { save_(); }
    });

    $("#ViewPopupFrm").click(function () {
        $("#id1").val("");
        $("#id2").val("");
        $("#id3").val("");
        $("#id4").val("-1").trigger("chosen:updated.chosen");
        $("#id5").val("-1").trigger("chosen:updated.chosen");
        $("#id6").val("-1").trigger("chosen:updated.chosen");
        $("#id7").val("0").trigger("chosen:updated.chosen");
        $("#id8").val("");
        $("#idFileclose").click();
    });
});

function clickView(x) {
    $('#idImagen').html("<img src=" + x + " width='100%' />");
    $("#ViewPopupImg").click();
}

function clickViewVideo(x, y) {
    $('#idImagen').html("<video width='750' poster='" + y + "' controls><source src='" + x + "' type='video/mp4'></video>");
    $("#ViewPopupImg").click();
}

function getlistapnp() {
    $.ajax({
        type: 'POST',
        url: "GetUsuariosPNP",
        dataType: 'json',
        data: {},
        success: function (evt) {
            $("#lista1").html(evt.ListaHtmlview[0]);
            $('.dataTables-example').DataTable({
                pageLength: parseFloat($('#page_').val()),
                dom: '<"html5buttons"B>lTfgitp',
                buttons: [],
                "bLengthChange": false
            });
            $("#lista2").html(evt.ListaHtmlview[1]);
            $("#id4").empty();
            $('#id4').get(0).options[0] = new Option("--Seleccionar--", "-1");
            $.each(evt.ListaPnpPerfil, function (i, item) {
                $('#id4').get(0).options[$('#id4').get(0).options.length] = new Option(item.Perfilname, item.Perfilcode);
            });
            $("#id5").empty();
            $('#id5').get(0).options[0] = new Option("--Seleccionar--", "-1");
            $.each(evt.ListaPnpArea, function (i, item) {
                $('#id5').get(0).options[$('#id5').get(0).options.length] = new Option(item.Areaname, item.Areacode);
            });
            $('.chosen-select').chosen({ width: "100%" });

            $("#id5").chosen().change(function () {
                GetModulosxPerfil($("#id5").val());
            });
        },
        error: function (err) { alert("Error al cargar"); }
    });
}

function GetModulosxPerfil(x) {
    $.ajax({
        type: 'POST',
        url: "GetModulosxPerfil",
        dataType: 'json',
        data: { id: x },
        success: function (evt) {
            $("#id6").empty();
            $('#id6').get(0).options.length = 0;
            $.each(evt.ListaPnpModulo, function (i, item) {
                $('#id6').get(0).options[$('#id6').get(0).options.length] = new Option(item.Modnombre, item.Modcodi);
            });
            $('#id6').trigger("chosen:updated.chosen");
        },
        error: function (err) { alert("Error al cargar"); }
    });
}

function edit_(x) {
    $.ajax({
        type: 'POST',
        url: "ConsultaUsuarioPNP",
        dataType: 'json',
        data: { id: x },
        success: function (evt) {
            if (evt.Count > 0) {
                $("#editPopup").click();
                $('#id1').val(evt.PnpUser.Username);
                $('#id2').val(evt.PnpUser.Userlogin);
                $('#id3').val(evt.PnpUser.Userpass);
                $('#id4').val(evt.PnpUser.Userperfil).trigger("chosen:updated.chosen");
                $('#id5').val(evt.PnpUser.Areacode).trigger("chosen:updated.chosen");
                $("#id6").empty();
                $('#id6').get(0).options.length = 0;
                $.each(evt.ListaPnpModulo, function (i, item) {
                    $('#id6').get(0).options[$('#id6').get(0).options.length] = new Option(item.Modnombre, item.Modcodi);
                });
                $('#id6').trigger("chosen:updated.chosen");
                $.each(evt.ListaPnpUserprofile, function (i, e) {
                    $("#id6 option[value='" + e.Modcodi + "']").prop("selected", true).trigger("chosen:updated.chosen");
                });
                $('#id7').val(evt.PnpUser.Userstate).trigger("chosen:updated.chosen");
                $('#id8').val(evt.PnpUser.Usercode);
            }
            else { alert("Ha ocurrido un error."); }
        },
        error: function (err) { alert("Error al cargar"); }
    });
}

function delete_(x) { 
    swal({
        title: "Eliminar Registro?",
        text: "Esta seguro de eliminar registro?",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Eliminar!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            type: 'POST',
            url: "DeleteUsuarioPNP",
            dataType: 'json',
            data: { id: x },
            success: function (evt) {
                if (evt.Count > 0) { swal("Eliminado!", "Registro eliminado Exitosamente!.", "success"); getlistapnp(); }
                else { swal("Error!", "Ha ocurrido un error", "error"); }
            },
            error: function (err) { swal("Error!", "Error al cargar", "error"); }
        });
    });   
}

function save_() {
    var modulos = "";
    var options_ = $("#id6 option:selected").attr("selected", "selected");
    for (var i = 0; i < options_.length; i++) {
        modulos += options_[i].value + ",";
    }
    modulos = modulos.substring(0, modulos.length - 1);

    swal({
        title: "Guardar Registro?",
        text: "La información se guardara temporalmente hasta su respectiva validación!",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, Guardar!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            type: 'POST',
            url: "SaveUsuario",
            dataType: 'json',
            data: {
                name: $('#id1').val(),
                usu: $('#id2').val(),
                pass: $('#id3').val(),
                perfil: $('#id4').val(),
                area: $('#id5').val(),
                modulo: modulos,
                estado: $('#id7').val(),
                id: $('#id8').val()
            },
            success: function (evt) {
                swal("Guardado!", "Registro guardado Exitosamente!.", "success");
                getlistapnp();
                $("#idClose").click();
            },
            error: function (err) { swal("Error", "Error al guardar!:)", "error"); }
        });
    });

}