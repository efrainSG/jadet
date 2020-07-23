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
    }

    cargarDiccionarios();

    //construye el modal, carga datos y despliega botón de guardado de producto.
    // #btnGuardar
    $('[id^="btneditarProducto"]').off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Editar producto");
            $bodyModal.empty();
            $bodyModal.append(
                '<form action="/Administrador/guardarProducto" method="post" id="frmProducto">' +
                '  <input type="hidden" id="txtId" value="" name="Id" />' +
                '  <div class= "row" > ' +

                '    <div class="col-sm-2">SKU</div >' +
                '    <div class= "col-sm-4">' +
                '      <input type = "text" id = "txtsku" class= "form-control" name="Sku" />' +
                '    </div>' +

                '    <div class= "col-sm-2">Categoría</div>' +
                '    <div class= "col-sm-4">' +
                '      <select id = "selIdCategoria" name="IdCategoria" class= "form-control"></select>' +
                '    </div>' +

                '  </div>' +

                '  <div class= "row">' +

                '    <div class= "col-sm-2">Producto</div>' +
                '    <div class="col-sm-10">' +
                '      <input type="text" id="txtproducto" name="Nombre" class="form-control" />' +
                '    </div>' +

                '  </div>' +

                '  <div class="row">' +

                '    <div class="col-sm-2">Descripción</div>' +
                '    <div class="col-sm-10">' +
                '      <textarea id="Descripcion" name="Descripcion" rows="4" cols="50" class="form-control"></textarea>' +
                '    </div>' +

                '  </div>' +

                '  <div class="row">' +

                '    <div class="col-sm-2">Precio MXN.</div>' +
                '    <div class="col-sm-4">' +
                '      <input type="text" id="txtPrecioMXN" name="PrecioMXN" class="form-control" />' +
                '    </div>' +

                '    <div class="col-sm-3">Precio USD.</div>' +
                '    <div class="col-sm-3">' +
                '      <input type="text" id="txtprecioUSD" name="PrecioUSD" class="form-control" />' +
                '    </div>' +

                '  </div>' +

                '  <div class="row">' +

                '    <div class="col-sm-2">Aplica existencias</div>' +
                '    <div class="col-sm-4">' +
                '      <input type="radio" id="rdoexistencias1" name="AplicaExistencias" class="form-check-input" value="true">' +
                '      <label class="form-check-label" for="rdoexistencias1">&nbsp;Sí&nbsp;&nbsp;</label>' +
                '      <input type="radio" id="rdoexistencias2" name="AplicaExistencias" class="form-check-input" value="false">' +
                '      <label class="form-check-label" for="rdoexistencias2">&nbsp;No&nbsp;&nbsp;</label>' +
                '    </div>' +
                '    <div class="col-sm-2">Existencias</div>' +
                '    <div class="col-sm-4">' +
                '      <input type="text" id="txtExistencias" name="Existencias" class="form-control" />' +
                '    </div > ' +

                '  </div>' +

                '  <div class="row">' +

                '    <div class="col-sm-2">Foto</div>' +
                '      <div class="col-sm-8">' +
                '        <input type="text" id="txtruta" class="form-control" />' +
                '      </div>' +

                '      <div class="col-sm-2">' +
                '        <a href="#" class="btn btn-sm btn-success">Cargar</a>' +
                '      </div>' +

                '    </div>' +

                '  </div>' +

                '</form>');

            var $categoria = $("#selIdCategoria");
            var opcion = "";
            for (i = 0; i < categorias.length; i++) {
                opcion = '<option value="' + categorias[i].id + '" ';
                if ($($componentes[9]).text() == categorias[i].nombre)
                    opcion += 'selected="selected"';
                opcion += '>' + categorias[i].nombre + '</option> ';
                $categoria.append(opcion);

            }

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
            $("#btnEliminar, #btnEliminarCliente, #btnEliminarCatalogo, #btnGuardarCliente, #btnGuardarCatalogo").hide();
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
            $bodyModal.append(
                '<form action="/Administrador/eliminarProducto" method="post" id="frmProducto">' +
                '  <input type="hidden" id="txtId" value="" name="Id" />' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-12" id="txtContenido"></div>' +
                '  </div>' +
                '</form>');

            $("#txtContenido")
                .append('<span>Id: ' + $($componentes[0]).text() + '</span><br />')
                .append('<span>SKU: ' + $($componentes[1]).text() + '</span><br />')
                .append('<span>Nombre: ' + $($componentes[2]).text() + '</span><br />')
                .append('<span>Descripción: ' + $($componentes[4]).text() + '</span><br />')
                .append('<span>Precio MXN: ' + $($componentes[5]).text() + '</span><br />')
                .append('<span>Precio USD: ' + $($componentes[6]).text() + '</span><br />')
                .append('<span>Existencias: ' + $($componentes[7]).text() + '</span><br />')
                .append('<span>Aplica existencias: ' + $($componentes[8]).text() + '</span><br />');

            $("#btnEliminar").show();
            $("#btnGuardar, #btnEliminarCliente, #btnEliminarCatalogo, #btnGuardarCliente, #btnGuardarCatalogo").hide();
            $("#myModal").modal("show");
        });

    //construye el modal y despliega botón de guardado de producto nuevo.
    // #btnGuardar
    $("#btnnuevoProducto").off()
        .on("click", function (e) {
            $this = $(this);
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Registrar producto");
            $bodyModal.empty();
            $bodyModal.append(
                '<form action="/Administrador/guardarProducto" method="post" id="frmProducto">' +
                '  <input type="hidden" id="txtId" value="" name="Id" />' +
                '  <div class= "row" > ' +

                '    <div class="col-sm-2">SKU</div >' +
                '    <div class= "col-sm-4">' +
                '      <input type = "text" id = "txtsku" class= "form-control" name="Sku" />' +
                '    </div>' +

                '    <div class= "col-sm-2">Categoría</div>' +
                '    <div class= "col-sm-4">' +
                '      <select id = "selIdCategoria" name="IdCategoria" class= "form-control"></select>' +
                '    </div>' +

                '  </div>' +

                '  <div class= "row">' +

                '    <div class= "col-sm-2">Producto</div>' +
                '    <div class="col-sm-10">' +
                '      <input type="text" id="txtproducto" name="Nombre" class="form-control" />' +
                '    </div>' +

                '  </div>' +

                '  <div class="row">' +

                '    <div class="col-sm-2">Descripción</div>' +
                '    <div class="col-sm-10">' +
                '      <textarea id="Descripcion" name="Descripcion" rows="4" cols="50" class="form-control"></textarea>' +
                '    </div>' +

                '  </div>' +

                '  <div class="row">' +

                '    <div class="col-sm-2">Precio MXN.</div>' +
                '    <div class="col-sm-4">' +
                '      <input type="text" id="txtPrecioMXN" name="PrecioMXN" class="form-control" />' +
                '    </div>' +

                '    <div class="col-sm-3">Precio USD.</div>' +
                '    <div class="col-sm-3">' +
                '      <input type="text" id="txtprecioUSD" name="PrecioUSD" class="form-control" />' +
                '    </div>' +

                '  </div>' +

                '  <div class="row">' +

                '    <div class="col-sm-2">Aplica existencias</div>' +
                '    <div class="col-sm-4">' +
                '      <input type="radio" id="rdoexistencias1" name="AplicaExistencias" class="form-check-input" value="1">' +
                '      <label class="form-check-label" for="rdoexistencias1">&nbsp;Sí&nbsp;&nbsp;</label>' +
                '      <input type="radio" id="rdoexistencias2" name="AplicaExistencias" class="form-check-input" value="0">' +
                '      <label class="form-check-label" for="rdoexistencias2">&nbsp;No&nbsp;&nbsp;</label>' +
                '    </div>' +
                '    <div class="col-sm-2">Existencias</div>' +
                '    <div class="col-sm-4">' +
                '      <input type="text" id="txtExistencias" name="Existencias" class="form-control" />' +
                '    </div > ' +

                '  </div>' +

                '  <div class="row">' +

                '    <div class="col-sm-2">Foto</div>' +
                '      <div class="col-sm-8">' +
                '        <input type="text" id="txtruta" class="form-control" />' +
                '      </div>' +

                '      <div class="col-sm-2">' +
                '        <a href="#" class="btn btn-sm btn-success">Cargar</a>' +
                '      </div>' +

                '    </div>' +

                '  </div>' +

                '</form>');

            var $categoria = $("#selIdCategoria");
            var opcion = "";
            for (i = 0; i < categorias.length; i++) {
                opcion = '<option value="' + categorias[i].id + '">' + categorias[i].nombre + '</option> ';
                $categoria.append(opcion);
            }
            $("#btnEliminar, #btnEliminarCliente, #btnEliminarCatalogo, #btnGuardarCliente, #btnGuardarCatalogo").hide();
            $("#btnGuardar").show();

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
            $bodyModal.append(
                '<form action="/Administrador/guardarCliente" method="post" id="frmCliente">' +
                '  <input type="hidden" id="txtId" value="" name="IdCliente" />' +
                '  <input type="hidden" id="txtIdRol" value="" name="IdRol" />' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Usuario: </div>' +
                '    <div class="col-sm-9"><input type="text" class="form-control" id="txtUsuario" name="usuario" /></div>' +
                '  </div>' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Nombre: </div>' +
                '    <div class="col-sm-9"><input type="text" class="form-control" id="txtNombre" name="Nombre" /></div>' +
                '  </div>' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Dirección: </div>' +
                '    <div class="col-sm-9"><input type="text" class="form-control" id="txtDirección" name="Direccion" /></div>' +
                '  </div>' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Teléfono: </div>' +
                '    <div class="col-sm-9"><input type="text" class="form-control" id="txtTelefono" name="Telefono" /></div>' +
                '  </div>' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Zona de paquetería: </div>' +
                '    <div class="col-sm-9"><select class="form-control" id="selZonaPaqueteria" name="ZonaPaqueteria"></select></div>' +
                '  </div>' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Estátus: </div>' +
                '    <div class="col-sm-9"><select class="form-control" id="selIdEstatus" name="IdEstatus"></select></div>' +
                '  </div>' +
                '</form>');
            var $estatus = $("#selIdEstatus");
            var opcion = "";
            for (i = 0; i < estatus.length; i++) {
                opcion = '<option value="' + estatus[i].id + '">' + estatus[i].nombre + '</option> ';
                $estatus.append(opcion);
            }
            var $zonas = $("#selZonaPaqueteria");
            opcion = "";
            for (i = 0; i < zonas.length; i++) {
                opcion = '<option value="' + zonas[i].id + '">' + zonas[i].nombre + '</option> ';
                $zonas.append(opcion);
            }

            $("#txtUsuario").val($($componentes[0]).text());
            $("#txtNombre").val($($componentes[1]).text());
            $("#txtDirección").val($($componentes[2]).text());
            $("#txtTelefono").val($($componentes[3]).text());
            $("#txtZonaPaqueteria").val($($componentes[4]).text());
            $("#txtEstatus").val($($componentes[5]).text());
            $("#txtId").val($this.attr('data-content'));
            $("#txtIdRol").val(2);
            $("#btnEliminar, #btnGuardar, #btnGuardarCatalogo, #btnEliminarCliente, #btnEliminarCatalogo").hide();
            $("#btnGuardarCliente").show();
            $("#myModal").modal("show");
        });

    //construye el modal y despliega botón de guardado de cliente nuevo.
    // #btnGuardarCliente
    $("#btnagregarCliente").off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Agregar cliente");
            $bodyModal.empty();
            $bodyModal.append(
                '<form action="/Administrador/guardarCliente" method="post" id="frmCliente">' +
                '  <input type="hidden" id="txtId" value="" name="IdCliente" />' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Usuario: </div>' +
                '    <div class="col-sm-9"><input type="text" class="form-control" id="txtUsuario" /></div>' +
                '  </div>' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Nombre: </div>' +
                '    <div class="col-sm-9"><input type="text" class="form-control" id="txtNombre" /></div>' +
                '  </div>' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Dirección: </div>' +
                '    <div class="col-sm-9"><input type="text" class="form-control" id="txtDirección" /></div>' +
                '  </div>' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Teléfono: </div>' +
                '    <div class="col-sm-9"><input type="text" class="form-control" id="txtTelefono" /></div>' +
                '  </div>' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Zona de paquetería: </div>' +
                '    <div class="col-sm-9"><input type="text" class="form-control" id="txtZonaPaqueteria" /></div>' +
                '  </div>' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Estátus: </div>' +
                '    <div class="col-sm-9"><input type="text" class="form-control" id="txtEstatus" /></div>' +
                '  </div>' +
                '</form>');

            $("#btnEliminar, #btnGuardar, #btnGuardarCatalogo, #btnEliminarCliente, #btnEliminarCatalogo").hide();
            $("#btnGuardarCliente").show();
            $("#myModal").modal("show");
        });

    //construye el modal, carga datos y despliega botón de guardado de catálogo.
    $('[id^="btneditarCatalogo"]').off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Editar catálogo");
            $bodyModal.empty();
            $bodyModal.append(
                '<form action="/Administrador/guardarCatalogo" method="post" id="frmCatalogo">' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Id: </div>' +
                '    <div class="col-sm-9"><input type="text" class="form-control" name="Id" id="txtId" readonly="readonly" /></div>' +
                '  </div>' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Nombre: </div>' +
                '    <div class="col-sm-9"><input type="text" class="form-control" name="Nombre" id="txtNombre" /></div>' +
                '  </div>' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Tipo de catálogo: </div>' +
                '    <div class="col-sm-9"><select class="form-control" id="selIdTipoCatalogo" name="IdTipoCatalogo" /></select>' +
                '  </div>' +
                '</form>');

            $("#txtId").val($($componentes[0]).text());
            $("#txtNombre").val($($componentes[1]).text());
            var $categoria = $("#selIdTipoCatalogo");
            var opcion = "";
            for (i = 0; i < tiposcatalogos.length; i++) {
                opcion = '<option value="' + tiposcatalogos[i].id + '" ';
                if ($this.prop("data-content") == tiposcatalogos[i].id)
                    opcion += 'selected="selected"';
                opcion += '>' + tiposcatalogos[i].nombre + '</option> ';
                $categoria.append(opcion);

            }

            $("#btnEliminar, #btnGuardar, #btnGuardarCliente, #btnEliminarCliente, #btnEliminarCatalogo").hide();
            $("#btnGuardarCatalogo").show();
            $("#myModal").modal("show");
        });

    $('[id^="btneditarEstatus"]').off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Editar catálogo");
            $bodyModal.empty();
            $bodyModal.append(
                '<form action="/Administrador/guardarEstatus" method="post" id="frmEstatus">' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Id: </div>' +
                '    <div class="col-sm-9"><input type="text" class="form-control" id="txtId" readonly="readonly" /></div>' +
                '  </div>' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Nombre: </div>' +
                '    <div class="col-sm-9"><input type="text" class="form-control" id="txtNombre" /></div>' +
                '  </div>' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-3">Tipo de catáloo: </div>' +
                '    <div class="col-sm-9"><select class="form-control" id="selIdTipoCatalogo" name="IdTipoCatalogo" /></select></div>' +
                '  </div>' +
                '</form>');

            $("#txtId").val($($componentes[0]).text());
            $("#txtNombre").val($($componentes[1]).text());
            var $categoria = $("#selIdTipoCatalogo");
            var opcion = "";
            for (i = 0; i < tiposcatalogos.length; i++) {
                opcion = '<option value="' + tiposcatalogos[i].id + '" ';
                if ($this.prop("data-content") == tiposcatalogos[i].id)
                    opcion += 'selected="selected"';
                opcion += '>' + tiposcatalogos[i].nombre + '</option> ';
                $categoria.append(opcion);

            }

            $("#btnEliminar, #btnGuardar, #btnGuardarCliente, #btnEliminarCliente, #btnEliminarCatalogo").hide();
            $("#btnGuardarCatalogo").show();
            $("#myModal").modal("show");
        });

   //realiza el guardado de los datos de producto mediante POST.
    $("#btnGuardar").off()
        .on("click", function () {
            $.post(
                "/Administrador/guardarProducto",
                $("#frmProducto").serialize())
                .done(function (data) {
                    console.log(data);
                    if (data.respuesta.ErrorNumero == 0)
                        location.reload();
                    else
                        alert(data.respuesta.ErrorMensaje);
                });
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


    $('[id^="btneliminarCliente"]').off()
        .on("click", function (e) {
            $this = $(this);
            var $componentes = $this.parent().siblings();
            var $bodyModal = $("#divModalBody");
            $("#modalHdr").text("Eliminar cliente");
            $bodyModal.empty();
            $bodyModal.append(
                '<form action="/Administrador/guardarProducto" method="post" id="frmProducto">' +
                '  <input type="hidden" id="txtId" value="" name="Id" />' +
                '  <div class= "row" > ' +
                '    <div class="col-sm-12" id="txtContenido"></div>' +
                '  </div>' +
                '</form>');

            $("#txtContenido")
                .append('<span>USuario: ' + $($componentes[0]).text() + '</span><br />')
                .append('<span>Nombre: ' + $($componentes[1]).text() + '</span><br />')
                .append('<span>Dirección: ' + $($componentes[2]).text() + '</span><br />')
                .append('<span>Teléfono: ' + $($componentes[3]).text() + '</span><br />')
                .append('<span>Zona de paquetería: ' + $($componentes[4]).text() + '</span><br />')
                .append('<span>Estátus: ' + $($componentes[5]).text() + '</span><br />')

            $("#btnGuardarCliente, #btnGuardar, #btnGuardarCatalogo, #btnEliminarCliente, #btnEliminarCatalogo").hide();
            $("#btnEliminar").show();
            $("#myModal").modal("show");
        });

});