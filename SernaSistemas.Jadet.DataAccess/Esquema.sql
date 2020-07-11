create schema Administracion;
go
create schema Ventas;
go
create schema Seguridad;
go

create table Seguridad.Rol(
	Id int identity primary key,
	Nombre varchar(100) not null
);

create table Administracion.TipoEstatus(
	Id int identity primary key,
	Nombre varchar(50) not null
);

create table Administracion.Estatus(
	Id int identity primary key,
	Nombre varchar(50) not null,
	IdTipoEstatus int not null,
	Constraint fk_tipoEstatus_Estatus foreign key (idTipoEstatus)
		references Administracion.TipoEstatus(Id)
		on update no action on delete no action
);

create table Seguridad.Usuario(
	Id uniqueidentifier primary key,
	Nombre varchar(200) not null,
	Direccion varchar(200) not null,
	Telefono varchar(20) not null,
	Foto varbinary(max) null,
	Usuario varchar(50) not null,
	Passwd varbinary(max) not null,
	IdRol int not null,
	ZonaPaqueteria int,
	IdEstatus int not null,
	Constraint fk_rol_usuario foreign key(IdRol) references Seguridad.Rol(Id)
		on update no action on delete no action,
	Constraint fk_Estatus_usuario foreign key(IdEstatus)
		references Administracion.Estatus(Id)
		on update no action on delete no action
);

create table Administracion.TipoCatalogo(
	Id int identity primary key,
	Nombre varchar(50) not null
);

create table Administracion.Catalogo(
	Id int identity primary key,
	Nombre varchar(100) not null,
	IdTipoCatalogo int not null,
	Constraint fk_TipoCatalogo_Catalogo foreign key(IdTipoCatalogo)
		references Administracion.TipoCatalogo(Id)
		on update no action on delete no action
);

create table Ventas.Producto(
	Id int identity primary key,
	sku varchar(20) not null,
	Nombre varchar(100) not null,
	Descripcion varchar(200) not null,
	PrecioMXN decimal(10,2) not null,
	PrecioUSD decimal(10,2) not null,
	Existencias int not null,
	AplicaExistancias bit not null,
	Foto varbinary(max),
	IdCatalogo int not null,
	Constraint fk_Catalogo_Producto foreign key(IdCatalogo)
		references Administracion.Catalogo(Id)
		on update no action on delete no action
);

create table Ventas.Notas(
	Folio int identity primary key,
	Fecha date not null,
	IdTipo int not null,
	IdEstatus int not null,
	IdPaqueteria int not null,
	IdCliente uniqueidentifier not null,
	Guia varchar(50),
	FechaEnvio date,
	MontoMXN decimal(10,2) not null,
	MontoUSD decimal(10,2) not null,
	SaldoMXN decimal(10,2) not null,
	SaldoUSD decimal(10,2) not null,
	Constraint fk_Catalogo_Notas_Tipo foreign key(IdTipo)
		references Administracion.Catalogo(Id)
		on update no action on delete no action,
	Constraint fk_Catalogo_Notas_Estatus foreign key(IdEstatus)
		references Administracion.Catalogo(Id)
		on update no action on delete no action,
	Constraint fk_Catalogo_Notas_Paqueteria foreign key(IdPaqueteria)
		references Administracion.Catalogo(Id)
		on update no action on delete no action,
	Constraint fk_Usuario_Notas foreign key(IdCliente)
		references Seguridad.Usuario(Id)
		on update no action on delete no action
);

create table Ventas.Detalle(
	Id int identity primary key,

);