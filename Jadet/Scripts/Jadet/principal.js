$(document).ready(function () {
    jQuery.noConflict();
    $('[id^="btneditar"]').off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            var $bodyModal = $("#divModalBody");

            $bodyModal.empty();
            $bodyModal.append(
                '<div class="row">' +
                '<div class="col-sm-2">SKU</div >' +
                '<div class= "col-sm-4">' +
                '<input type = "text" id = "txtsku" class= "form-control" />' +
                '</div>' +
                '<div class= "col-sm-2">Categoría</div>' +
                '<div class= "col-sm-4">' +
                '<select id = "txtsku" class= "form-control"></select>' +
                '</div>' +
                '</div>' +
                '<div class= "row">' +
                '<div class= "col-sm-2">Producto</div>' +
                '<div class="col-sm-10">' +
                '<input type="text" id="txtproducto" class="form-control" />' +
                '</div>' +
                '</div>' +
                '<div class="row">' +
                '<div class="col-sm-2">Descripción</div>' +
                '<div class="col-sm-2">' +
                '</div>' +
                '</div>' +
                '<div class="row">' +
                '<div class="col-sm-2">Precio MXN.</div>' +
                '<div class="col-sm-2">' +
                '<input type="text" id="txtPrecioMXN" class="form-control" />' +
                '</div>' +
                '<div class="col-sm-2">Precio USD.</div>' +
                '<div class="col-sm-2">' +
                '<input type="text" id="txtprecioUSD" class="form-control" />' +
                '</div>' +
                '<div class="col-sm-2">Existencias</div>' +
                '<div class="col-sm-2">' +
                '<input type="text" id="txtexistencias" class="form-control" />' +
                '</div>' +
                '</div>' +
                '<div class="row">' +
                '<div class="col-sm-2">Foto</div>' +
                '<div class="col-sm-8">' +
                '<input type="text" id="txtruta" class="form-control" />' +
                '</div>' +
                '<div class="col-sm-2">' +
                '<a href="#" class="btn btn-sm btn-success">Cargar</a>' +
                '</div>' +
                '</div>');
            $("#txtsku").val($($componentes[0]).text());
            $("#txtproducto").val($($componentes[2]).text());
            //$("#").val($($componentes[3]).text());
            $("#txtPrecioMXN").val($($componentes[4]).text());
            $("#txtprecioUSD").val($($componentes[5]).text());
            $("#txtexistencias").val($($componentes[6]).text());
            $("#txtruta").val($($componentes[6]).text());
            /*.append($('<div class="row">')
                .append($('<div class="col-sm-2">')
                    .append("SKU")
                    .append($('<input type="text" class="col-sm-10 form-control">').val($($componentes[0]).text()))
                    ))
            .append($('<input type="text" class="form-control">').val($($componentes[2]).text()))
            .append($('<input type="text" class="form-control">').val($($componentes[3]).text()))
            .append($('<input type="text" class="form-control">').val($($componentes[4]).text()))
            .append($('<input type="text" class="form-control">').val($($componentes[5]).text()))
            .append($('<input type="text" class="form-control">').val($($componentes[6]).text()));*/
            $("#myModal").modal("show");
        });
});