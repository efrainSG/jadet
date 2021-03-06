﻿
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
                categorias = new Array();
                for (i = 0; i < data.length; i++) {
                    categorias.push(data[i]);
                }
            }
        );
        $.get(
            "/Administrador/obtenerDiccionario"
            , { IdTipo: 2 }
            , function (data) {
                zonas = new Array();
                for (i = 0; i < data.length; i++) {
                    zonas.push(data[i]);
                }
            }
        );
        $.get(
            "/Administrador/obtenerTiposCatalogos"
            , { IdTipo: 0 }
            , function (data) {
                tiposcatalogos = new Array();
                for (i = 0; i < data.length; i++) {
                    tiposcatalogos.push(data[i]);
                }
            }
        );
        $.get(
            "/Administrador/obtenerEstatus"
            , { IdTipo: 0 }
            , function (data) {
                estatus = new Array();
                for (i = 0; i < data.length; i++) {
                    estatus.push(data[i]);
                }
            }
        );
        $.get(
            "/Administrador/obtenerTipoEstatus"
            , { IdTipo: 0 }
            , function (data) {
                tipoestatus = new Array();
                for (i = 0; i < data.length; i++) {
                    tipoestatus.push(data[i]);
                }
            }
        );
        $.get(
            "/Administrador/obtenerDiccionario"
            , { IdTipo: 1 }
            , function (data) {
                tiposnotas = new Array();
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
                    .val($this.attr("id").substring(13)))
                .append($('<input type="hidden" name="IdProducto">')
                    .val(0))
                .append($('<input type="hidden" name="IdTipo">')
                    .val(0))
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

    $('[id^="btnhacerPedido"]').off()
        .on("click", function () {
            $this = $(this);
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Generar pedido");
            $bodyModal.empty();
            $bodyModal.append(modalgeneraPedido);
            $.get(
                "/Cliente/JsonDetalleCarrito"
                , { idCarrito: $this.attr("id").substring(14) }
                , function (data) {
                    $("#txtContenido").append(
                        $('<dl>').append('<dt class="dt-jadet">Folio:</dt><dd class="jadet">' + data.Folio + '</dd>')
                            .append('<dt class="dt-jadet">Tipo:</dt><dd class="jadet">' + data.Tipo + '</dd>')
                            .append('<dt class="dt-jadet">Estatus:</dt><dd class="jadet">' + data.Estatus + '</dd>')
                            .append('<dt class="dt-jadet">Paquetería:</dt><dd class="jadet"><select id="IdPaqueteria" class="form-control" name="IdPaqueteria"></select></dd>')
                            .append('<dt class="dt-jadet">Total:</dt><dd class="jadet">$' + data.MontoMXN.toFixed(2) + ' (' + data.MontoUSD.toFixed(2) + ' USD)</dd>')
                    );
                    for (i = 0; i < zonas.length; i++) {
                        $("#IdPaqueteria").append('<option value="' + zonas[i].id + '">' + zonas[i].nombre + '</option>')
                    }
                    $("#IdPaqueteria").val(data.IdPaqueteria);
                    $("#txtId").val(data.Folio);
                    var tabla = $('<table class="table table-bordered table-active">');
                    tabla.append('<tr><th rowspan="2">Producto</th><th rowspan="2">Cantidad</th><th colspan="2">Precio</th><th colspan="2">Monto</th></tr>');
                    tabla.append('<tr><th>MXN</th><th>USD</th><th>MXN</th><th>USD</th></tr>');
                    for (i = 0; i < data.Items.length; i++) {
                        tabla
                            .append($('<tr>')
                                .append('<td>' + data.Items[i].Producto + '</td>')
                                .append('<td>' + data.Items[i].Cantidad + '</td>')
                                .append('<td>$ ' + data.Items[i].PrecioMXN.toFixed(2) + '</td>')
                                .append('<td>' + data.Items[i].PrecioUSD.toFixed(2) + '</td>')
                                .append('<td>$ ' + data.Items[i].MontoMXN.toFixed(2) + '</td>')
                                .append('<td>' + data.Items[i].MontoUSD.toFixed(2) + '</td>')
                            );
                    }
                    $("#txtContenido").append(tabla);
                }
            );
            $(botones).hide();
            $("#btnGuardar").show();
            $("#myModal").modal("show");
        });

    $("#btnGuardar").off()
        .on("click", function () {
            $("#frmCatalogo").submit();
            console.log($("#frmCatalogo").serialize());
            alert("Ok");
        });
    //-- COMENTARIOS ------------------------------------------------------------------------
    $("#btnnuevoComentario").off()
        .on("click", function () {
            $this = $(this);
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Generar pedido");
            $bodyModal.empty();
            $bodyModal.append(modalComentarioCliente);
            $("#txtId").val($this.attr("folio"));
            $(botones).hide();
            $("#btnGuardarComentario").show();
            $("#myModal").modal("show");
        });
    $("#btnGuardarComentario").off()
        .on("click", function () {
            $("#frmComentario").submit();
        });
    //-- TICKETS ----------------------------------------------------------------------------
    $("#btnnuevoTicket").off()
        .on("click", function () {
            $this = $(this);
            debugger;
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Agregar foto de ticket");
            $bodyModal.empty();
            $bodyModal.append(modalTicket);
            $(botones).hide();
            $("#txtId").val($this.attr("folio"));
            $("#btnGuardarTicket").show();
            $("#myModal").modal("show");
        });
    $("#btnGuardarTicket").off()
        .on("click", function () {
            var formData = new FormData($("#frmTicket")[0]);
            var archivoLoad = $("#ImgArchivo").get(0);
            var archivo = archivoLoad.files;
            formData.append("imgArch", archivo);
            $.post({
                url: '/Cliente/subirTicket',
                data: formData,
                dataType: 'json',
                contentType: false,
                processData: false
            })
                .done(function (data) {
                    console.log(data);
                    if (data.respuesta.ErrorNumero == 0)
                        location.reload();
                    else
                        alert(data.respuesta.ErrorMensaje);
                });
});
    //-- PERFIL -----------------------------------------------------------------------------
    $("#btnGuardarPerfil").off()
        .on("click", function () {
            $this = $(this);
            var $form = $($this.parent().parent().parent());
            $form.submit();
        });
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
});