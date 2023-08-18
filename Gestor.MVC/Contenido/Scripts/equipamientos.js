var campos = [];
var listaclientes_;
var listaEstados_;

$(function () {

    getlista();
    $("#saveVenta").click(function () {
        campos.length = 0;

        if ($("#fr_monto").val() == "") { campos.push("Ingrese un nuevo monto"); }

        var strCampos = "";
        if (campos.length > 0) {
            for (var indice in campos) {
                strCampos += campos[indice] + "\n";
            }

            swal({
                title: "Datos bligatorios",
                text: strCampos
            });
        }
        else { saveVenta_(); }
    });
    jQuery('#fr_monto').keyup(function () { this.value = this.value.replace(/[^0-9\.]/g, ''); });
    jQuery('#fr_porcentaje').keyup(function () { this.value = this.value.replace(/[^0-9\.]/g, ''); });
});
function add_() {
    $('#fr_id').val(0);
    $('#fr_equipamiento').val("");
    LoadSelector();
    $("#popupFrm").click();
}
function edit_(a, b, c) {
    $('#fr_id').val(a);
    $('#fr_equipamiento').val(b);
    $('#fr_estado').val(c).trigger("chosen:updated.chosen");
    $("#popupFrm").click();
}
function getlista() {
    $.ajax({
        type: 'POST',
        url: "GetListaEquipamientos",
        dataType: 'json',
        //data: { pagina : $("#fr_page").val() },
        success: function (evt) {
            DesignTabla(evt);
        },
        error: function (err) { swal("Error!", "Error al cargar", "error"); }
    });
}
function saveVenta_() {
    swal({
        title: "Vender articulo?",
        text: "El prestamo elegido se convertira en una Venta por garantia!",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Cancelar",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, Guardar!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            type: 'POST',
            url: "ModificarPrestamo",
            dataType: 'json',
            data: { id: $('#fr_id').val(), monto: $('#fr_monto').val(), tipo: 3, pagina: $("#fr_page").val(), evento: 1, motivo: '' },
            success: function (evt) {
                if (evt.Count > 0) {
                    swal("Guardado!", "Registro procesado..!", "success");
                    $("#idClose").click();
                    DesignTabla(evt);
                } else {
                    swal("Aviso!", "Error al registrar!.", "warning");
                }
            },
            error: function (err) { swal("Error", "Error al guardar!", "error"); }
        });
    });
}
function DesignTabla(evt_) {
    listaEstados_ = evt_.ListaEstados;
    $("#lista1").html(evt_.Htmlview);
    LoadSelector();
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
function LoadSelector() {
    $("#fr_estado").empty();
    $('#fr_estado').get(0).options[0] = new Option("--Seleccionar--", "-1");

    if (listaEstados_.length > 0) {
        $.each(listaEstados_, function (y, ito) {
            $("#fr_estado").get(0).options[$("#fr_estado").get(0).options.length] = new Option(ito.EstadoDes, ito.IdEstado);
        });
    }
    $('#fr_estado').trigger("chosen:updated");
}