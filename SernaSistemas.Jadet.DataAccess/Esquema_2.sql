create procedure Administracion.guardarEstatus
	@Id int = 0,
	@Nombre varchar(50),
	@IdTipoEstatus int
as
begin
	declare @identity int

	if exists (select 1 from Administracion.Estatus (nolock) where Id = @Id)
	begin
		update Administracion.Estatus
		set Nombre = @Nombre, IdTipoEstatus = @IdTipoEstatus
		where Id = @Id
		set @identity = @Id
	end
	else
	begin
		insert into Administracion.Estatus(Nombre, IdTipoEstatus)
		values (@Nombre, @IdTipoEstatus)
		select @identity = SCOPE_IDENTITY()
	end

	select @identity Id, @Nombre Nombre, @IdTipoEstatus IdTipoEstatus
end;
go

create procedure Administracion.listarEstatus
	@IdTipoEstatus int,
	@IdEstatus int = NULL
as
begin
	if (@IdTipoEstatus = 0)
	begin
		set @IdTipoEstatus = null
	end
	if (@IdEstatus = 0)
	begin
		set @IdEstatus = null
	end

	select	E.Id, E.Nombre, E.IdTipoEstatus
	from	Administracion.Estatus E (nolock)
	where	E.IdTipoEstatus = isnull(@IdTipoEstatus, E.IdTipoEstatus)
			and E.Id = ISNULL(@IdEstatus, E.Id)
end;
go

create procedure Administracion.borrarEstatus
	@Id int
as
begin
	declare @ErrNo int = 0,
			@ErrMsg varchar(max) = ''

	begin try
		delete from Administracion.Estatus
		where Id = @Id
	end try
	begin catch
		select @ErrNo = Error_number(), @ErrMsg = Error_Message()
	end catch
	select @ErrNo ErrorNumero, @ErrMsg Mensaje
end;
go

create procedure Administracion.listarTipoCatalogo
	@Id int = null
as
begin
	if @Id = 0
	begin
		set @Id = null
	end
	select	Id, Nombre
	from	Administracion.TipoCatalogo TC (nolock)
	where	TC.Id = isnull(@Id, TC.Id)
end;
go

create procedure Administracion.listarTipoEstatus
	@Id int = null
as
begin
	if @Id = 0
	begin
		set @Id = null
	end
	select	Id, Nombre
	from	Administracion.TipoEstatus TE (nolock)
	where	TE.Id = isnull(@Id, TE.Id)
end;
go

create procedure Administracion.guardarCatalogo
	@Id int = 0,
	@Nombre varchar(100),
	@IdTipoCatalogo int
as
begin
	declare @identity int

	if exists (select 1 from Administracion.Catalogo (nolock) where Id = @Id)
	begin
		update Administracion.Catalogo
		set Nombre = @Nombre, IdTipoCatalogo = @IdTipoCatalogo
		where Id = @Id
		set @identity = @Id
	end
	else
	begin
		insert into Administracion.Catalogo(Nombre, IdTipoCatalogo)
		values (@Nombre, @IdTipoCatalogo)
		select @identity = SCOPE_IDENTITY()
	end

	select @identity Id, @Nombre Nombre, @IdTipoCatalogo IdTipoCatalogo
end;
go

create procedure Administracion.borrarCatalogo
	@Id int
as
begin
	declare @ErrNo int = 0,
			@ErrMsg varchar(max) = ''

	begin try
		delete from Administracion.Catalogo
		where Id = @Id
	end try
	begin catch
		select @ErrNo = Error_number(), @ErrMsg = Error_Message()
	end catch
	select @ErrNo ErrorNumero, @ErrMsg Mensaje
end;
go

create procedure Administracion.listarCatalogo
	@IdTipoCatalogo int,
	@IdCatalogo int = null
as
begin
	if @IdTipoCatalogo = 0
	begin
		set @IdTipoCatalogo = null
	end
	if @IdCatalogo = 0
	begin
		set @IdCatalogo = null
	end
	select	C.Id, C.Nombre, C.IdTipoCatalogo
	from	Administracion.Catalogo C (nolock)
	where	C.IdTipoCatalogo = isnull(@IdTipoCatalogo, C.IdTipoCatalogo)
			and C.Id = isnull(@IdCatalogo, C.Id)
end;
go

create procedure Seguridad.listarRol
	@Id int = null
as
begin
	if @Id = 0
	begin
		set @Id = null
	end
	select	Id, Nombre
	from	Seguridad.Rol R (nolock)
	where	R.Id = isnull(@Id, R.Id)
end;
go

create procedure Seguridad.guardarUsuario
	@Id uniqueidentifier,
	@Nombre varchar(200),
	@Direccion varchar(200),
	@Telefono varchar(20),
	@Foto varbinary(max),
	@Usuario varchar(50),
	@Passwd varbinary(max),
	@IdRol int,
	@ZonaPaqueteria int,
	@IdEstatus int
as
begin
	if exists (select 1 from Seguridad.Usuario U (nolock) where U.Id = @Id)
	begin
		update Seguridad.Usuario
		set	Nombre = @Nombre,
			Direccion = @Direccion,
			Telefono = @Telefono,
			Foto = @Foto,
			Usuario = @Usuario,
			Passwd = @Passwd,
			IdRol = @IdRol,
			ZonaPaqueteria = @ZonaPaqueteria,
			IdEstatus = @IdEstatus
		where Id = @Id
	end;
	else
	begin
		insert into Seguridad.Usuario (	Id, Nombre, Direccion, Telefono, Foto, Usuario,
										Passwd, IdRol, ZonaPaqueteria, IdEstatus)
		values (@Id, @Nombre, @Direccion, @Telefono, @Foto, @Usuario,
				@Passwd, @IdRol, @ZonaPaqueteria, @IdEstatus)
	end;

	select	@Id Id, @Nombre Nombre, @Direccion Direccion, @Telefono Telefono, @Foto Foto,
			@Usuario Usuario, @Passwd Passwd, @IdRol IdRol,
			@ZonaPaqueteria ZonaPaqueteria, @IdEstatus IdEstatus
end;
go

create procedure Seguridad.listarUsuario
	@Id uniqueidentifier = null,
	@IdRol int = null
as
begin
	if @IdRol = 0
	begin
		set @IdRol = null
	end
	if @Id = '00000000-0000-0000-0000-000000000000'
	begin
		set @Id = null
	end
	select	U.Id, U.Direccion, U.Telefono, U.Foto, U.Usuario, U.Passwd,
			U.IdRol, U.ZonaPaqueteria, U.IdEstatus, R.Nombre Rol
	from	Seguridad.Usuario U (nolock)
	join	Seguridad.Rol R (nolock) on U.IdRol = R.Id
	where	U.Id = isnull(@Id, U.Id) and U.IdRol = isnull(@IdRol, U.IdRol)
end;
go

create procedure Seguridad.borrarUsuario
	@Id uniqueidentifier
as
begin
	declare @ErrNo int = 0,
			@ErrMsg varchar(max) = ''

	begin try
		delete from Seguridad.Usuario
		where Id = @Id
	end try
	begin catch
		select @ErrNo = Error_number(), @ErrMsg = Error_Message()
	end catch
	select @ErrNo ErrorNumero, @ErrMsg Mensaje
end;
go

create procedure Ventas.guardarProducto
	@Id int = 0,
	@sku varchar(20),
	@Nombre varchar(100),
	@Descripcion text,
	@PrecioMXN decimal(10,2),
	@PrecioUSD decimal(10,2),
	@Existencias int,
	@AplicaExistencias bit,
	@Foto varbinary(max),
	@IdCatalogo int
as
begin
	declare @identity int

	if exists (select 1 from Ventas.Producto P (nolock) where Id = @Id)
	begin
		update Ventas.Producto
		set sku = @sku, Nombre = @Nombre, Descripcion = @Descripcion,
			PrecioMXN = @PrecioMXN, PrecioUSD = @PrecioUSD, Existencias = @Existencias,
			AplicaExistencias = @AplicaExistencias, Foto = @Foto,
			IdCatalogo = @IdCatalogo
		where Id = @Id
		set @identity = @id
	end
	else
	begin
		insert into Ventas.Producto (	sku, Nombre, Descripcion, PrecioMXN, PrecioUSD,
										Existencias, AplicaExistencias, Foto,
										IdCatalogo)
		values (@sku, @Nombre, @Descripcion, @PrecioMXN, @PrecioUSD, @Existencias,
				@AplicaExistencias, @Foto, @IdCatalogo)
		select @identity = SCOPE_IDENTITY()
	end
	select	@identity Id, @sku Sku, @Nombre Nombre, @Descripcion Descripcion,
			@PrecioMXN PrecioMXN, @PrecioUSD PrecioUSD, @Existencias Existencias,
			@AplicaExistencias AplicaExistencias, @Foto Foto,
			@IdCatalogo IdCatalogo
end;
go

create procedure Ventas.listarProductos
	@Id int = null
as
begin
	if @Id = 0
	begin
		set @Id = null
	end
	select	P.Id, P.sku, P.Nombre, P.Descripcion, P.PrecioMXN, P.PrecioUSD,
			P.Existencias, P.APlicaExistencias, P.Foto, P.IdCatalogo,
			C.Nombre Categoria
	from	Ventas.Producto P (nolock)
	join	Administracion.Catalogo C (nolock) on P.IdCatalogo = C.Id
	where	P.Id = isnull(@Id, P.Id)
end;
go
