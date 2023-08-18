var campos = [];
$(function () {
    getmenupnp();
    $('.dataTables-example').DataTable({
        pageLength: 25,
        dom: '<"html5buttons"B>lTfgitp',
        buttons: [
            { extend: 'copy' },
            { extend: 'csv' },
            { extend: 'excel', title: 'ExampleFile' },
            { extend: 'pdf', title: 'ExampleFile' },

            {
                extend: 'print',
                customize: function (win) {
                    $(win.document.body).addClass('white-bg');
                    $(win.document.body).css('font-size', '10px');

                    $(win.document.body).find('table')
                        .addClass('compact')
                        .css('font-size', 'inherit');
                }
            }
        ]

    });


    $("#SaveData").click(function () {
        campos.length = 0;
        if ($("#idNombre").val() == "") { campos.push("Nombre menú:"); }
        if ($("#idDescripcion").val() == "") { campos.push("Descripción menú:"); }
        if ($("#idUrl").val() == "") { campos.push("Url menú:"); }
        if ($("#idEsatdo").val() == "0") { campos.push("Estado:"); }

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
        else {
            save_();
        }
    });

    $("#ViewPopupFrm").click(function () {
        $("#idNombre").val("");
        $("#idDescripcion").val("");
        $("#idUrl").val("");
        $("#idFileclose").click();
        $("#idEsatdo").val("0").trigger("chosen:updated.chosen");
    });
});

function getmenupnp() {
    $.ajax({
        type: 'POST',
        url: "GetMenuPortal",
        dataType: 'json',
        data: { id: -1 },
        success: function (evt) {
            $("#lista1").html(evt);
            $('.dataTables-example').DataTable({
                pageLength: parseFloat($('#page_').val()),
                dom: '<"html5buttons"B>lTfgitp',
                buttons: [],
                "bLengthChange": false
            });
            $('.chosen-select').chosen({ width: "100%" });
        },
        error: function (err) { swal("Error!", "Error al cargar", "error"); }
    });
}

function edit_(x, y) {
    $.ajax({
        type: 'POST',
        url: "ConsultaMenuPortal",
        dataType: 'json',
        data: { id: x, idDet: y },
        success: function (evt) {
            if (evt.Count > 0) {
                $('#idNombre').val(evt.PnpMenu.Menutitle);
                $('#idDescripcion').val(evt.PnpMenu.Menudesc);
                $('#idUrl').val(evt.PnpMenu.Menuurl);
                $('#idEsatdo').val(evt.PnpMenu.Registroestado).trigger("chosen:updated.chosen");
                $('#idMenucodi').val(evt.PnpMenu.Menucodi);
                $('#idPadrecodi').val(evt.PnpMenu.Padrecodi);
                $('#idDetregcodi').val(evt.PnpMenu.Detregcodi);
                $("#editPopup").click();
            }
            else { swal("Error!", "Ha ocurrido un error", "error"); }
        },
        error: function (err) { swal("Error!", "Error al cargar", "error"); }
    });
}

function delete_(x, y) {
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
            url: "DeleteMenuPortal",
            dataType: 'json',
            data: { id: x, idDet: y },
            success: function (evt) {
                if (evt.Count == 1) { swal("Eliminado!", "Registro eliminado Exitosamente!.", "success"); getmenupnp(); }
                else {
                    if (evt.Count == -2) {
                        swal("Proceso Cancelado", "El Menu a eliminar tiene Sub-Menu", "error");
                    }
                    else { swal("Error!", "Ha ocurrido un error", "error"); }
                }
            },
            error: function (err) { swal("Error!", "Error al cargar", "error"); }
        });
    });
}

function save_() {

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
            url: "SaveMenuPortal",
            dataType: 'json',
            data: {
                menutitle: $('#idNombre').val(),
                menudesc: $('#idDescripcion').val(),
                menuestado: $('#idEsatdo').val(),
                menucodi: $('#idMenucodi').val(),
                padrecodi: $('#idPadrecodi').val(),
                menuurl: $('#idUrl').val(),
                detregcodi: $('#idDetregcodi').val()
            },
            success: function (evt) {
                swal("Guardado!", "Registro guardado Exitosamente!.", "success");
                getmenupnp();
                $("#idClose").click();
            },
            error: function (err) {
                swal("Error", "Error al guardar!:)", "error");
            }
        });


    });
}

function go_(x) {
    $.ajax({
        type: 'POST',
        url: "SetVarible",
        dataType: 'json',
        data: { id: x },
        success: function (evt) {
            if (evt > 0) { window.location = "SubMenu"; }
        },
        error: function (err) { swal("Error!", "Error al cargar", "error"); }
    });
}

function sendVal_(x) {
    $.ajax({
        type: 'POST',
        url: "ProcesarVal",
        dataType: 'json',
        data: { idDet: x },
        success: function (evt) {
            getmenupnp();
        },
        error: function (err) { swal("Error!", "Error al cargar", "error"); }
    });
}