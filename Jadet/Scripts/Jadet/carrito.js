$(document).ready(function () {
    jQuery.noConflict();

    var cargarDiccionarios = function () {
        $.get(
            "/Administrador/obtenerDiccionario"
            , { IdTipo: 3 }
            , function (data) {
                for (i = 0; i < data.length; i++) {
                    categorias.push(data[i]);
                }
            }
        );
        $.get(
            "/Administrador/obtenerDiccionario"
            , { IdTipo: 2 }
            , function (data) {
                for (i = 0; i < data.length; i++) {
                    zonas.push(data[i]);
                }
            }
        );
        $.get(
            "/Administrador/obtenerTiposCatalogos"
            , { IdTipo: 0 }
            , function (data) {
                for (i = 0; i < data.length; i++) {
                    tiposcatalogos.push(data[i]);
                }
            }
        );
        $.get(
            "/Administrador/obtenerEstatus"
            , { IdTipo: 0 }
            , function (data) {
                for (i = 0; i < data.length; i++) {
                    estatus.push(data[i]);
                }
            }
        );
        $.get(
            "/Administrador/obtenerTipoEstatus"
            , { IdTipo: 0 }
            , function (data) {
                for (i = 0; i < data.length; i++) {
                    tipoestatus.push(data[i]);
                }
            }
        );
        $.get(
            "/Administrador/obtenerDiccionario"
            , { IdTipo: 1 }
            , function (data) {
                for (i = 0; i < data.length; i++) {
                    tiposnotas.push(data[i]);
                }
            }
        );
    }

    var llenarSelect = function ($select, listado, filtro) {
        var opcion = "";
        if (filtro == undefined) {
            for (i = 0; i < listado.length; i++) {
                opcion = '<option value="' + listado[i].id + '">' + listado[i].nombre + '</option>';
                $select.append(opcion);
            }
        } else {
            for (i = 0; i < listado.length; i++) {
                if (listado[i].Tipo == filtro) {
                    opcion = '<option value="' + listado[i].id + '">' + listado[i].nombre + '</option>';
                    $select.append(opcion);
                }

            }
        }
    };

    cargarDiccionarios();
    //-- CARRITO ----------------------------------------------------------------------------
    $('[id^="btnagregarCarrito"]').off()
        .on("click", function () {
            $this = $(this);
            var _frm = $('<form method="post">')
                .append($('<input type="hidden" name="IdProducto">')
                    .val($this.attr("id").substring(17)))
                .append($('<input type="hidden" name="IdTipo">')
                    .val($this.attr("data-content")))
                .append($('<input type="hidden" name="Cantidad">')
                    .val(1));
            $.post(
                "/Cliente/agregarProducto",
                _frm.serialize()
            ).done(function (data) {
                $this.fadeOut('slow').fadeIn('fast');
                console.log(data);
            });
        });
    $('[id^="btnminusitem"]').off()
        .on("click", function () {
            $this = $(this);
            debugger;
            if ($this.prop('disabled') === undefined) {
                var _frm = $('<form method="post">')
                    .append($('<input type="hidden" name="Id">')
                        .val($this.attr("id").substring(12)))
                    .append($('<input type="hidden" name="IdProducto">')
                        .val($this.attr("productoid")))
                    .append($('<input type="hidden" name="IdTipo">')
                        .val($this.attr("tipo")))
                    .append($('<input type="hidden" name="Cantidad">')
                        .val(parseInt($this.attr("cantidad")) - 1));
                $.post(
                    "/Cliente/agregarProducto",
                    _frm.serialize()
                ).done(function (data) {
                    $this.fadeOut('slow').fadeIn('fast');
                    console.log(data);
                    $("#Cantidad" + $this.attr("id").substring(12)).text(data.data.Cantidad);
                    $this.attr("cantidad", data.data.Cantidad);
                    $("#btnminusitem" + $this.attr("id").substring(12)).attr("cantidad", data.data.Cantidad);
                });
            }
        });
    $('[id^="btnplusitem"]').off()
        .on("click", function () {
            $this = $(this);
            var _frm = $('<form method="post">')
                .append($('<input type="hidden" name="Id">')
                    .val($this.attr("id").substring(11)))
                .append($('<input type="hidden" name="IdProducto">')
                    .val($this.attr("productoid")))
                .append($('<input type="hidden" name="IdTipo">')
                    .val($this.attr("tipo")))
                .append($('<input type="hidden" name="Cantidad">')
                    .val(parseInt($this.attr("cantidad")) + 1));
            $.post(
                "/Cliente/agregarProducto",
                _frm.serialize()
            ).done(function (data) {
                $this.fadeOut('slow').fadeIn('fast');
                console.log(data);
                $("#Cantidad" + $this.attr("id").substring(11)).text(data.data.Cantidad);
                $this.attr("cantidad", data.data.Cantidad);
                $("#btnminusitem" + $this.attr("id").substring(11)).attr("cantidad", data.data.Cantidad);
            });
        });
    $('[id^="btnremoveitem"]').off()
        .on("click", function () {
            $this = $(this);
            //var _frm = $('<form method="post">')
            //    .append($('<input type="hidden" name="IdProducto">')
            //        .val($this.attr("id").substring(17)))
            //    .append($('<input type="hidden" name="IdTipo">')
            //        .val($this.attr("data-content")))
            //    .append($('<input type="hidden" name="Cantidad">')
            //        .val(1));
            //$.post(
            //    "/Cliente/agregarProducto",
            //    _frm.serialize()
            //).done(function (data) {
            //    $this.fadeOut('slow').fadeIn('fast');
            //    console.log(data);
            //});
        });

    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
});