$(document).ready(function () {
    jQuery.noConflict();

    var actualizaFila = function (boton, corte, data) {
        boton.fadeOut('slow').fadeIn('fast');
        console.log(data);
        _id = boton.attr("id").substring(corte);
        $("#Cantidad" + _id).text(data.Cantidad);
        $("#btnplusitem" + _id).attr("cantidad", data.Cantidad);
        $("#btnminusitem" + _id).attr("cantidad", data.Cantidad);
        $("#MontoMXN" + _id).text((data.Cantidad * data.PrecioMXN).toFixed(2));
        $("#MontoUSD" + _id).text((data.Cantidad * data.PrecioUSD).toFixed(2));
        if (data.Cantidad <= 1) {
            $("#btnminusitem" + _id).attr("habilitado", "no");
            $("#btnminusitem" + _id).removeClass("btn-warning-jadet").addClass("btn-secondary");
        } else {
            $("#btnminusitem" + _id).attr("habilitado", "si");
            $("#btnminusitem" + _id).removeClass("btn-secondary").addClass("btn-warning-jadet");
        }
    };
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
    };

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
            if ($this.attr("habilitado") === "si") {
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
                    actualizaFila($this, 12, data.data);
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
                actualizaFila($this, 11, data.data);
            });
        });
    $('[id^="btnremoveitem"]').off()
        .on("click", function () {
            $this = $(this);
            var _frm = $('<form method="post">')
                .append($('<input type="hidden" name="Id">')
                    .val($this.attr("id").substring(12)))
                .append($('<input type="hidden" name="IdProducto">')
                    .val($this.attr("productoid")))
                .append($('<input type="hidden" name="IdTipo">')
                    .val($this.attr("tipo")))
                .append($('<input type="hidden" name="Cantidad">')
                    .val(0));
            $.post(
                "/Cliente/quitarProducto",
                _frm.serialize()
            ).done(function (data) {
                $("#fila" + $this.attr("id").substring(13)).fadeOut('fast');
                console.log(data);
            });
        });

    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
});