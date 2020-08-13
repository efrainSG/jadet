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
    }

    var llenarSelect = function ($select, listado) {
        var opcion = "";
        for (i = 0; i < listado.length; i++) {
            opcion = '<option value="' + listado[i].id + '">' + listado[i].nombre + '</option>';
            $select.append(opcion);
        }
    };

    cargarDiccionarios();

    //-- PRODUCTO ---------------------------------------------------------------------------

    //construye el modal y despliega botón de guardado de producto nuevo.
    // #btnGuardar
    $("#btnnuevoProducto").off()
        .on("click", function (e) {
            $this = $(this);
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Registrar producto");
            $bodyModal.empty();
            $bodyModal.append(modalProducto);

            var $categoria = $("#selIdCategoria");
            var $estatus = $("#selIdEstatus");
            var $estatusProd = $.grep(estatus, function (o) { return o.Tipo == 2; });

            llenarSelect($categoria, categorias);
            llenarSelect($estatus, $estatusProd);

            $(botones).hide();
            $("#btnGuardar").show();

            $("#myModal").modal("show");

        });

    //construye el modal, carga datos y despliega botón de guardado de producto.
    // #btnGuardar
    $('[id^="btneditarProducto"]').off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Editar producto");
            $bodyModal.empty();
            $bodyModal.append(modalProducto);

            var $categoria = $("#selIdCategoria");
            var $estatus = $("#selIdEstatus");
            var $estatusProd = $.grep(estatus, function (o) { return o.Tipo == 2; });

            llenarSelect($categoria, categorias);
            llenarSelect($estatus, $estatusProd);

            $("#txtId").val($($componentes[0]).text());
            $("#txtsku").val($($componentes[1]).text());
            $("#txtproducto").val($($componentes[2]).text());
            $("#Descripcion").text($($componentes[4]).text());
            $("#txtPrecioMXN").val($($componentes[5]).text());
            $("#txtprecioUSD").val($($componentes[6]).text());
            $("#txtExistencias").val($($componentes[7]).text());
            if ($($componentes[8]).text().trim() == "Sí") {
                $("#rdoexistencias1").prop("checked", true);
            } else {
                $("#rdoexistencias2").prop("checked", true);
            }
            $(botones).hide();
            $("#btnGuardar").show();

            $("#myModal").modal("show");
        });

    //construye el modal, carga datos y despliega botón de eliminación de producto.
    // #btnEliminar
    $('[id^="btneliminarProducto"]').off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Eliminar producto");
            $bodyModal.empty();
            $bodyModal.append(modalEliminarProducto);

            $("#txtContenido")
                .append('<dt class="dt-jadet">Id:</dt><dd class="jadet" id="ddId">' + $($componentes[0]).text() + '</dd>')
                .append('<dt class="dt-jadet">SKU:</dt><dd class="jadet">' + $($componentes[1]).text() + '</dd>')
                .append('<dt class="dt-jadet">Nombre:</dt><dd class="jadet">' + $($componentes[2]).text() + '</dd>')
                .append('<dt class="dt-jadet">Descripción:</dt><dd class="jadet">' + $($componentes[4]).text() + '</dd>')
                .append('<dt class="dt-jadet">Precio MXN:</dt><dd class="jadet">' + $($componentes[5]).text() + '</dd>')
                .append('<dt class="dt-jadet">Precio USD:</dt><dd class="jadet">' + $($componentes[6]).text() + '</dd>')
                .append('<dt class="dt-jadet">Existencias:</dt><dd class="jadet">' + $($componentes[7]).text() + '</dd>')
                .append('<dt class="dt-jadet">Aplica existencias:</dt><dd class="jadet">' + $($componentes[8]).text() + '</dd>');

            $(botones).hide();
            $("#btnEliminar").show();
            $("#myModal").modal("show");
        });

    //realiza el guardado de los datos de producto mediante POST.
    $("#btnGuardar").off()
        .on("click", function () {
            var formData = new FormData($("#frmProducto")[0]);
            var archivoLoad = $("#ImgArchivo").get(0);
            var archivo = archivoLoad.files;

            formData.append("imgArch", archivo);
            $.post({
                url: '/Administrador/guardarProducto',
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

    $("#btnEliminar").off()
        .on("click", function () {
            debugger;
            $.post({
                url: '/Administrador/eliminarProducto',
                data: {"id": $("#ddId").text() },
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
    //-- CLIENTE ----------------------------------------------------------------------------

    //construye el modal y despliega botón de guardado de cliente nuevo.
    // #btnGuardarCliente
    $("#btnagregarCliente").off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Agregar cliente");
            $bodyModal.empty();
            $bodyModal.append(modalCliente);

            var $estatus = $("#selIdEstatus");
            var $zonas = $("#selZonaPaqueteria");

            llenarSelect($estatus, estatus);
            llenarSelect($zonas, zonas);

            $(botones).hide();
            $("#btnGuardarCliente").show();
            $("#myModal").modal("show");
        });

    // #btnGuardarCliente
    $('[id^="btneditarCliente"]').off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Editar cliente");
            $bodyModal.empty();
            $bodyModal.append(modalCliente);

            var $estatus = $("#selIdEstatus");
            var $zonas = $("#selZonaPaqueteria");

            llenarSelect($estatus, estatus);
            llenarSelect($zonas, zonas);

            $("#txtUsuario").val($($componentes[0]).text());
            $("#txtNombre").val($($componentes[1]).text());
            $("#txtDirección").val($($componentes[2]).text());
            $("#txtTelefono").val($($componentes[3]).text());
            $("#txtZonaPaqueteria").val($($componentes[4]).text());
            $("#txtEstatus").val($($componentes[5]).text());
            $("#txtId").val($this.attr('data-content'));
            $("#txtIdRol").val(2);

            $(botones).hide();
            $("#btnGuardarCliente").show();
            $("#myModal").modal("show");
        });

    // #btnEliminarCliente
    $('[id^="btneliminarCliente"]').off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Eliminar cliente");
            $bodyModal.empty();
            $bodyModal.append(modalEliminarCliente);

            $("#txtContenido")
                .append('<dt class="dt-jadet">Usuario:</dt><dd class="jadet">' + $($componentes[0]).text() + '</dd>')
                .append('<dt class="dt-jadet">Nombre:</dt><dd class="jadet">' + $($componentes[1]).text() + '</dd>')
                .append('<dt class="dt-jadet">Dirección:</dt><dd class="jadet">' + $($componentes[2]).text() + '</dd>')
                .append('<dt class="dt-jadet">Teléfono:</dt><dd class="jadet">' + $($componentes[3]).text() + '</dd>')
                .append('<dt class="dt-jadet">Zona de paquetería:</dt><dd class="jadet">' + $($componentes[4]).text() + '</dd>')
                .append('<dt class="dt-jadet">Estátus:</dt><dd class="jadet">' + $($componentes[5]).text() + '</dd>')

            $(botones).hide();
            $("#btnEliminarCliente").show();
            $("#myModal").modal("show");
        });

    $("#btnGuardarCliente").off()
        .on("click", function () {
            $.post(
                "/Administrador/guardarCliente",
                $("#frmCliente").serialize())
                .done(function (data) {
                    console.log(data);
                    if (data.respuesta.ErrorNumero == 0)
                        location.reload();
                    else
                        alert(data.respuesta.ErrorMensaje);
                });
        });

    $("#btnEliminarCliente").off()
        .on("click", function () { });
    //-- CATÁLOGO ---------------------------------------------------------------------------

    // #btnGuardarCatalogo
    $('[id^="btnagregarCatalogo"]').off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Agregar al catálogo");
            $bodyModal.empty();
            $bodyModal.append(modalCatalogo);

            var $categoria = $("#selIdTipoCatalogo");
            llenarSelect($categoria, tiposcatalogos);

            $(botones).hide();
            $("#btnGuardarCatalogo").show();
            $("#myModal").modal("show");
        });

    //construye el modal, carga datos y despliega botón de guardado de catálogo.
    // #btnGuardarCatalogo
    $('[id^="btneditarCatalogo"]').off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Editar catálogo");
            $bodyModal.empty();
            $bodyModal.append(modalCatalogo);

            $("#txtId").val($($componentes[0]).text());
            $("#txtNombre").val($($componentes[1]).text());

            var $categoria = $("#selIdTipoCatalogo");
            llenarSelect($categoria, tiposcatalogos);

            $(botones).hide();
            $("#btnGuardarCatalogo").show();
            $("#myModal").modal("show");
        });

    // #btnEliminarCatalogo
    $('[id^="btneliminarCatalogo"]').off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Eliminar cliente");
            $bodyModal.empty();
            $bodyModal.append(modalEliminarCatalogo);

            $("#txtContenido")
                .append('<dt class="dt-jadet">Id:</dt><dd class="jadet">' + $($componentes[0]).text() + '</dd>')
                .append('<dt class="dt-jadet">Nombre:</dt><dd class="jadet">' + $($componentes[1]).text() + '</dd>');

            $(botones).hide();
            $("#btnEliminarCatalogo").show();
            $("#myModal").modal("show");
        });

    $("#btnGuardarCatalogo").off()
        .on("click", function () {
            $.post(
                "/Administrador/guardarCatalogo",
                $("#frmCatalogo").serialize())
                .done(function (data) {
                    console.log(data);
                    if (data.respuesta.ErrorNumero == 0)
                        location.reload();
                    else
                        alert(data.respuesta.ErrorMensaje);
                });
        });

    $("#btnEliminarCatalogo").off()
        .on("click", function () { });
    //-- ESTÁTUS ----------------------------------------------------------------------------

    // #btnGuardarEstatus
    $('[id^="btnagregarEstatus"]').off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Agregar al catálogo");
            $bodyModal.empty();
            $bodyModal.append(modalEstatus);

            var $categoria = $("#selIdTipoCatalogo");
            llenarSelect($categoria, tipoestatus);

            $(botones).hide();
            $("#btnGuardarEstatus").show();
            $("#myModal").modal("show");
        });

    // #btnGuardarEstatus
    $('[id^="btneditarEstatus"]').off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Editar catálogo");
            $bodyModal.empty();
            $bodyModal.append(modalEstatus);

            $("#txtId").val($($componentes[0]).text());
            $("#txtNombre").val($($componentes[1]).text());
            var $categoria = $("#selIdTipoCatalogo");
            llenarSelect($categoria, tipoestatus);

            $(botones).hide();
            $("#btnGuardarEstatus").show();
            $("#myModal").modal("show");
        });

    // #btnEliminarEstatus
    $('[id^="btneliminarEstatus"]').off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Eliminar cliente");
            $bodyModal.empty();
            $bodyModal.append(modalEliminarEstatus);

            $("#txtContenido")
                .append('<dt class="dt-jadet">Id:</dt><dd class="jadet">' + $($componentes[0]).text() + '</dd>')
                .append('<dt class="dt-jadet">Nombre:</dt><dd class="jadet">' + $($componentes[1]).text() + '</dd>');

            $(botones).hide();
            $("#btnEliminarEstatus").show();
            $("#myModal").modal("show");
        });

    $("#btnGuardarEstatus").off()
        .on("click", function (e) {
            $.post(
                "/Administrador/guardarEstatus",
                $("#frmEstatus").serialize())
                .done(function (data) {
                    console.log(data);
                    if (data.respuesta.ErrorNumero == 0)
                        location.reload();
                    else
                        alert(data.respuesta.ErrorMensaje);
                });
        });

    $("#btnEliminarEstatus").off()
        .on("click", function () { });
    //-- NOTA -------------------------------------------------------------------------------



    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
});