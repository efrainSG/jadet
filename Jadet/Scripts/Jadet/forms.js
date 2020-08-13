//-- PRODUCTO ---------------------------------------------------------------------------

const modalProducto =
    '<form action="/Administrador/guardarProducto" method="post" id="frmProducto" enctype="multipart/form-data">' +
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
    '    <div class="col-sm-2">Estátus</div>' +
    '    <div class="col-sm-10">' +
    '      <select id="selIdEstatus" name="IdEstatus" class="form-control"></select>' +
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
    '      <div class="col-sm-10">' +
    '        <input type="file" id="ImgArchivo" name="ImgArchivo" class="form-control" />' +
    '      </div>' +
    '    </div>' +
    '  </div>' +
    '</form>';

const modalEliminarProducto =
    '<form action="/Administrador/eliminarProducto" method="post" id="frmProducto">' +
    '  <input type="hidden" id="txtId" value="" name="Id" />' +
    '  <div class= "row" > ' +
    '    <div class="col-sm-12">' +
    '      <dl id="txtContenido" class="dl-jadet">' +
    '      </dl>' +
    '    </div > ' +
    '  </div>' +
    '</form>';

//-- CLIENTE ----------------------------------------------------------------------------

const modalCliente =
    '<form action="/Administrador/guardarCliente" method="post" id="frmCliente">' +
    '  <input type="hidden" id="txtId" value="" name="IdCliente" />' +
    '  <input type="hidden" id="txtIdRol" value="" name="IdRol" />' +
    '  <div class= "row" > ' +
    '    <div class="col-sm-3">Usuario: </div>' +
    '    <div class="col-sm-3"><input type="text" class="form-control" id="txtUsuario" name="usuario" /></div>' +
    '    <div class="col-sm-3">Contraseña: </div>' +
    '    <div class="col-sm-3"><input type="password" class="form-control" id="txtPasswd" name="Password" /></div>' +
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
    '</form>';

const modalEliminarCliente =
    '<form action="/Administrador/eliminarCliente" method="post" id="frmCliente">' +
    '  <input type="hidden" id="txtId" value="" name="Id" />' +
    '  <div class= "row" > ' +
    '    <div class="col-sm-12" id="txtContenido"></div>' +
    '  </div>' +
    '</form>';

//-- CATÁLOGO ---------------------------------------------------------------------------

const modalCatalogo =
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
    '</form>';

const modalEliminarCatalogo =
    '<form action="/Administrador/eliminarCatalogo" method="post" id="frmCatalogo">' +
    '  <input type="hidden" id="txtId" value="" name="Id" />' +
    '  <div class= "row" > ' +
    '    <div class="col-sm-12" id="txtContenido"></div>' +
    '  </div>' +
    '</form>';

//-- ESTÁTUS ----------------------------------------------------------------------------

const modalEstatus =
    '<form action="/Administrador/guardarEstatus" method="post" id="frmEstatus">' +
    '  <div class= "row" > ' +
    '    <div class="col-sm-3">Id: </div>' +
    '    <div class="col-sm-9"><input type="text" class="form-control" id="txtId" name="Id" readonly="readonly" /></div>' +
    '  </div>' +
    '  <div class= "row" > ' +
    '    <div class="col-sm-3">Nombre: </div>' +
    '    <div class="col-sm-9"><input type="text" class="form-control" id="txtNombre" name="Nombre" /></div>' +
    '  </div>' +
    '  <div class= "row" > ' +
    '    <div class="col-sm-3">Tipo de catáloo: </div>' +
    '    <div class="col-sm-9"><select class="form-control" id="selIdTipoCatalogo" name="IdTipoCatalogo" name="IdTipoCatalogo" /></select></div>' +
    '  </div>' +
    '</form>';

const modalEliminarEstatus =
    '<form action="/Administrador/eliminarEstatus" method="post" id="frmEstatus">' +
    '  <input type="hidden" id="txtId" value="" name="Id" />' +
    '  <div class= "row" > ' +
    '    <div class="col-sm-12" id="txtContenido"></div>' +
    '  </div>' +
    '</form>';

    //-- NOTA -------------------------------------------------------------------------------



    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------