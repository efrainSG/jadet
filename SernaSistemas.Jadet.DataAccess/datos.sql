-- Datos iniciales
insert into Administracion.TipoCatalogo (Nombre)
values ('Tipo de nota'),('Paquetería'),('Categoría');

insert into Administracion.TipoEstatus (Nombre)
values ('Estatus de usuario'), ('Estatus de nota'), ('Estatus de Producto');

insert into Seguridad.Rol (Nombre)
values ('Administrador'), ('Cliente');

select * from Administracion.TipoCatalogo;
select * from Administracion.TipoEstatus;
select * from Seguridad.Rol;

-- Datos de ejemplo
exec Administracion.guardarCatalogo @Nombre='Centros', @IdTipoCatalogo = 3
go
insert into Administracion.Catalogo (Nombre, IdTipoCatalogo)
values	('Listones', 3),
		('Pinzas', 3),
		('Botones', 3),
		('DHL', 2),
		('Fedex', 2),
		('Mexpost', 2),
		('Sepomex', 2),
		('Estafeta', 2),
		('Preventa', 1),
		('En vivo', 1),
		('Existencias', 1),
		('VIP', 1);
go

