var campos = [];
var listaSedes_;
var listaTipoComplejos_;
var listaEstados_;

$(function () {

    getlista();
    $("#idSave").click(function () {
        campos.length = 0;

        if ($("#fr_sede").val() == "") { campos.push("Ingrese un nombre"); }
        if ($("#fr_sede").val() == "-1") { campos.push("Ingrese una sede"); }
        if ($("#fr_tipocomplejo").val() == "-1") { campos.push("Ingrese un tipo"); }
        if ($("#fr_estado").val() == "-1") { campos.push("Ingrese un estado"); }

        var strCampos = "";
        if (campos.length > 0) {
            for (var indice in campos) {
                strCampos += campos[indice] + "\n";
            }

            swal({
                title: "Datos obligatorios",
                text: strCampos
            });
        }
        else { save_(); }
    });
});
function getlista() {
    $.ajax({
        type: 'POST',
        url: "GetListaComplejos",
        dataType: 'json',
        //data: { pagina : $("#fr_page").val() },
        success: function (evt) {
            DesignTabla(evt);
        },
        error: function (err) { swal("Error!", "Error al cargar", "error"); }
    });
}
function add_() {
    $('#fr_id').val(0);
    $('#fr_complejo').val("");
    LoadSelectorSedes();
    LoadSelectorTipoComplejos();
    LoadSelectorEstados();
    $("#popupFrm").click();
}
function edit_(a, b, c, d, e) {
    $('#fr_id').val(a);
    $('#fr_complejo').val(b);
    $('#fr_sede').val(c).trigger("chosen:updated.chosen");
    $('#fr_tipocomplejo').val(d).trigger("chosen:updated.chosen");
    $('#fr_estado').val(e).trigger("chosen:updated.chosen");
    $("#popupFrm").click();
}
function save_() {
    swal({
        title: "¿Desea guardar el registro?",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, Guardar!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            type: 'POST',
            url: "SaveComplejoDeportivo",
            dataType: 'json',
            data: { id: $('#fr_id').val(), complejo: $('#fr_complejo').val(), sede: $('#fr_sede').val(), tipo: $('#fr_tipocomplejo').val(), estado: $('#fr_estado').val() },
            success: function (evt) {
                if (evt.Count > 0) {
                    swal("Guardado!", "Registro procesado..!", "success");
                    $("#idClose").click();
                    DesignTabla(evt);
                } else {
                    swal("Aviso!", "Error al registrar!", "warning");
                }
            },
            error: function (err) { swal("Error", "Error al guardar!", "error"); }
        });
    });
}
function delete_(a) {
    swal({
        title: "¿Desea eliminar el registro?",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, Guardar!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            type: 'POST',
            url: "DeleteComplejoDeportivo",
            dataType: 'json',
            data: { id: a },
            success: function (evt) {
                if (evt.Count > 0) {
                    swal("Guardado!", "Registro eliminado..!", "success");
                    DesignTabla(evt);
                } else {
                    swal("Aviso!", "Error al eliminar!", "warning");
                }
            },
            error: function (err) { swal("Error", "Error de eliminacion!", "error"); }
        });
    });
}
function DesignTabla(evt_) {
    listaSedes_ = evt_.ListaSedes;
    listaTipoComplejos_ = evt_.ListaTipoComplejosDeportivos;
    listaEstados_ = evt_.ListaEstados;
    $("#lista1").html(evt_.Htmlview);
    LoadSelectorSedes();
    LoadSelectorTipoComplejos();
    LoadSelectorEstados();
    var table = $('.dataTables-example').DataTable({
        //pageLength: parseInt($('#page_').val()),
        //pageLength: 25,
        dom: '<"html5buttons"B>lTfgitp',
        scrollX: true,
        "bLengthChange": false,
        "ordering": false,
        "columnDefs": [
            { "width": "150px", "targets": 0 },
            { "width": "70px", "targets": 1 },
            { "width": "70px", "targets": 2 },
            { "width": "70px", "targets": 3 },
            { "width": "100px", "targets": 4 },
            { "width": "100px", "targets": 5 }
        ],
        "paging": false,
        "searching": false
    });
}
function LoadSelectorSedes() {
    $("#fr_sede").empty();
    $('#fr_sede').get(0).options[0] = new Option("--Seleccionar--", "-1");

    if (listaSedes_.length > 0) {
        $.each(listaSedes_, function (y, ito) {
            $("#fr_sede").get(0).options[$("#fr_sede").get(0).options.length] = new Option(ito.SedeDes, ito.IdSede);
        });
    }
    $('#fr_sede').trigger("chosen:updated");
}
function LoadSelectorTipoComplejos() {
    $("#fr_tipocomplejo").empty();
    $('#fr_tipocomplejo').get(0).options[0] = new Option("--Seleccionar--", "-1");

    if (listaTipoComplejos_.length > 0) {
        $.each(listaTipoComplejos_, function (y, ito) {
            $("#fr_tipocomplejo").get(0).options[$("#fr_tipocomplejo").get(0).options.length] = new Option(ito.TipoComplejoDeportivoDes, ito.IdTipoComplejoDeportivo);
        });
    }
    $('#fr_tipocomplejo').trigger("chosen:updated");
}
function LoadSelectorEstados() {
    $("#fr_estado").empty();
    $('#fr_estado').get(0).options[0] = new Option("--Seleccionar--", "-1");

    if (listaEstados_.length > 0) {
        $.each(listaEstados_, function (y, ito) {
            $("#fr_estado").get(0).options[$("#fr_estado").get(0).options.length] = new Option(ito.EstadoDes, ito.IdEstado);
        });
    }
    $('#fr_estado').trigger("chosen:updated");
}