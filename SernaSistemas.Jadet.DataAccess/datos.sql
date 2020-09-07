-- limpieza inicial de datos


delete from Ventas.Detalle;

delete from Ventas.NotasComentarios;

delete from Ventas.NotasTickets;

delete from Ventas.Notas;

delete from Seguridad.Usuario;

delete from Seguridad.Rol;

delete from Ventas.Producto;

delete from Administracion.Catalogo;

delete from Administracion.TipoCatalogo;

delete from Administracion.Estatus;

delete from Administracion.TipoEstatus;


-- Datos iniciales
set identity_insert Administracion.TipoCatalogo on
insert	into Administracion.TipoCatalogo (Id, Nombre)
values	(1, 'Tipo de nota'),
		(2, 'Paquetería'),
		(3, 'Categoría');
set identity_insert Administracion.TipoCatalogo off

set identity_insert Administracion.TipoEstatus on
insert	into Administracion.TipoEstatus (Id, Nombre)
values	(1, 'Estatus de usuario'),
		(2, 'Estatus de Producto'),
		(3, 'Estatus de nota');
set identity_insert Administracion.TipoEstatus off

set identity_insert Administracion.Estatus on
insert	into Administracion.Estatus(Id, Nombre, IdTipoEstatus)
values	(1,  'Usuario Activo', 1),
		(2,  'Usuario Inactivo', 1),
		(3,  'Usuario Bloqueado', 1),
		(4,  'Producto descontinuado', 2),
		(5,  'Producto vigente', 2),
		(6,  'Nota sin procesar', 3),
		(7,  'Nota pagada', 3),
		(8,  'Nota empaquetada', 3),
		(9,  'Nota enviada', 3),
		(10, 'Nota entregada', 3),
		(11, 'Nota cancelada', 3);
set identity_insert Administracion.Estatus off

set identity_insert Seguridad.Rol on
insert	into Seguridad.Rol (Id, Nombre)
values	(1, 'Administrador'),
		(2, 'Cliente');
set identity_insert Seguridad.Rol off

set identity_insert Administracion.Catalogo on
insert	into Administracion.Catalogo (Id, Nombre, IdTipoCatalogo)
values	(1,  'Preventa', 1),
		(2,  'VIP', 1),
		(3,  'En vivo (live)', 1),
		(4,  'Existencias', 1),
		(5,  'Venta exprés', 1),

		(6,  'DHL', 2),
		(7,  'DHL zona extendida', 2),
		(8,  'Sepomex (correos)', 2),
		(9,  'Mexpost', 2),
		
		(10, 'Listones', 3),
		(11, 'Centros', 3),
		(12, 'Pistolas', 3),
		(13, 'Silicones', 3),
		(14, 'Pinzas', 3),
		(15, 'Botones', 3);
set identity_insert Administracion.Catalogo off
go

-- Datos de ejemplo
insert	into Seguridad.Usuario(	Id, Nombre, Direccion, Telefono, Foto, Usuario, Passwd, IdRol,
								ZonaPaqueteria, IdEstatus )
values	(	newid(), 'Administrador 1', 'Dirección 1', '1234567890', null, 'admin', cast('' as varbinary),
			1, null, 1),
		(	newid(), 'Cliente 1', 'Dirección 2', '1234567890', null, 'user1', cast('' as varbinary),
			2, null, 1),
		(	newid(), 'Cliente 2', 'Dirección 3', '1234567890', null, 'user2', cast('' as varbinary),
			2, null, 1);

select * from Administracion.TipoCatalogo;
select * from Administracion.TipoEstatus;
select * from Administracion.Catalogo;
select * from Administracion.Estatus;
select * from Seguridad.Rol;
select * from Seguridad.Usuario;