create procedure Ventas.listarNotas
	@Folio int = 0,
	@Fecha date = null,
	@IdEstatus int = 0
as
begin
	if (@Folio = 0) set @Folio = null

	if (@IdEstatus = 0) set @IdEstatus = null

	select	N.Fecha, N.FechaEnvio, N.Folio, N.Guia, N.IdCliente, N.IdEstatus, N.IdPaqueteria, N.IdTipo,
			N.MontoMXN, N.MontoUSD, N.SaldoMXN, N.SaldoUSD
	from	Ventas.Notas N (nolock)
	where	N.Folio = ISNULL(@Folio, N.Folio) and N.Fecha = ISNULL(@Fecha, N.Fecha)
			and N.IdEstatus = ISNULL(@IdEstatus, N.IdEstatus)
end;
go

create procedure Ventas.listarDetalle
	@Id int = 0,
	@IdNota int = 0,
	@IdProducto int = 0
as
begin
	if (@Id = 0)
	begin
		set @Id = null
	end
	if (@IdNota = 0)
	begin
		set @IdNota = null
	end
	if (@IdProducto = 0)
	begin
		set @IdProducto = null
	end

	select	D.Cantidad, D.Id, D.IdNota, D.IdProducto, D.PrecioMXN, D.PrecioUSD
	from	Ventas.Detalle D (nolock)
	where	D.Id = isnull(@Id, D.Id) and D.IdNota = isnull(@IdNota, D.IdNota)
			and D.IdProducto = ISNULL(@IdProducto, D.IdProducto)
end;
go

create procedure Ventas.listarComentarios
	@Id int = 0,
	@IdNota int = 0
as
begin
	if (@Id = 0) set @Id = null

	if (@IdNota = 0) set @IdNota = null

	select	NC.Id, NC.IdNota, NC.Comentario, NC.Fecha
	from	Ventas.NotasComentarios NC (nolock)
	where	NC.Id = isnull(@Id, NC.Id) and NC.IdNota = ISNULL(@IdNota, NC.IdNota)
end;
go

create procedure Ventas.listarTickets
	@Id int = 0,
	@IdNota int = 0
as
begin
	if (@Id = 0) set @Id = null

	if (@IdNota = 0) set @IdNota = null

	select	NT.Id, NT.IdNota,  NT.Fecha
	from	Ventas.NotasTickets NT (nolock)
	where	NT.Id = isnull(@Id, NT.Id) and NT.IdNota = ISNULL(@IdNota, NT.IdNota)
end;
go

create procedure Ventas.guardarNota
	@Folio int,
	@Fecha date = null,
	@IdTipo int,
	@IdEstatus int,
	@IdPaqueteria int,
	@IdCliente uniqueidentifier,
	@Guia varchar(50),
	@FechaEnvio date = null,
	@MontoMXN decimal(10,2),
	@MontoUSD decimal(10,2),
	@SaldoMXN decimal(10,2),
	@SaldoUSD decimal(10,2)
as
begin
	declare @identity int

	if exists (select 1 from Ventas.Notas N (nolock) where Folio = @Folio)
	begin
		update Ventas.Notas
		set Fecha = @Fecha, IdTipo = @IdTipo, IdEstatus = @IdEstatus, IdPaqueteria = @IdPaqueteria,
		IdCliente = @IdCliente, Guia = @Guia, FechaEnvio = @FechaEnvio, MontoMXN = @MontoMXN, MontoUSD = @MontoUSD,
		SaldoMXN = @SaldoMXN, SaldoUSD = @SaldoUSD
		where Folio = @Folio
		set @identity = @Folio
	end
	else
	begin
		insert into Ventas.Notas(	Fecha, IdTipo, IdEstatus, IdPaqueteria, IdCliente, Guia, FechaEnvio, MontoMXN,
									MontoUSD, SaldoMXN, SaldoUSD)
		values (@Fecha, @IdTipo, @IdEstatus, @IdPaqueteria, @IdCliente, @Guia, @FechaEnvio, @MontoMXN,
				@MontoUSD, @SaldoMXN, @SaldoUSD)
		select @identity = SCOPE_IDENTITY()
	end
	select	@identity Folio, @Fecha Fecha, @IdTipo IdTipo, @IdEstatus IdEstatus, @IdPaqueteria IdPaqueteria, @IdCliente IdCliente,
			@Guia Guia, @FechaEnvio FechaEnvio, @MontoMXN MontoMXN, @MontoUSD MontoUSD, @SaldoMXN SaldoMXN, @SaldoUSD SaldoUSD
end;
go

create procedure Ventas.guardarDetalle
	@Id int,
	@IdNota int,
	@IdProducto int,
	@Cantidad int,
	@PrecioMXN decimal(10,2),
	@PrecioUSD decimal(10,2)
as
begin
	declare @identity int

	if exists (select 1 from Ventas.Detalle D (nolock) where Id = @Id)
	begin
		update Ventas.Detalle
		set IdNota = @IdNota, IdProducto = @IdProducto, Cantidad = @Cantidad, PrecioMXN = @PrecioMXN, PrecioUSD = @PrecioUSD
		where Id = @Id
		set @identity = @Id
	end
	else
	begin
		insert into Ventas.Detalle(IdNota, IdProducto, Cantidad, PrecioMXN, PrecioUSD)
		values (@IdNota, @IdProducto, @Cantidad, @PrecioMXN, @PrecioUSD)
		select @identity = SCOPE_IDENTITY()
	end
	select	@identity Id, @IdNota IdNota, @IdProducto IdProducto, @Cantidad Cantidad, @PrecioMXN PrecioMXN,
			@PrecioUSD PrecioUSD
end;
go

create procedure Ventas.guardarComentario
	@Id int,
	@IdNota int,
	@Comentario text,
	@Fecha date
as
begin
	declare @identity int

	if exists (select 1 from Ventas.NotasComentarios NC (nolock) where Id = @Id)
	begin
		update Ventas.NotasComentarios
		set IdNota = @IdNota, Comentario = @Comentario, Fecha = @Fecha
		where Id = @Id
		set @identity = @Id
	end
	else
	begin
		insert into Ventas.NotasComentarios(IdNota, Comentario, Fecha)
		values (@IdNota, @Comentario, @Fecha)
		select @identity = SCOPE_IDENTITY()
	end
	select	@identity Id, @IdNota IdNota, @Comentario Comentario, @Fecha Fecha
end;
go

--create procedure Ventas.guardarTicket
--as
--begin
--	declare @identity int

--	if exists (select 1 from Ventas.Detalle D (nolock) where Id = @Id)
--	begin
--		update Ventas.Detalle
--		set IdNota = @IdNota, IdProducto = @IdProducto, Cantidad = @Cantidad, PrecioMXN = @PrecioMXN, PrecioUSD = @PrecioUSD
--		where Id = @Id
--		set @identity = @Id
--	end
--	else
--	begin
--		insert into Ventas.Detalle(IdNota, IdProducto, Cantidad, PrecioMXN, PrecioUSD)
--		values (@IdNota, @IdProducto, @Cantidad, @PrecioMXN, @PrecioUSD)
--		select @identity = SCOPE_IDENTITY()
--	end
--	select	@identity Id, @IdNota IdNota, @IdProducto IdProducto, @Cantidad Cantidad, @PrecioMXN PrecioMXN,
--			@PrecioUSD PrecioUSD
--end;
--go

--create procedure Ventas.borrarNota
--as
--begin
--end;
--go

--create procedure Ventas.borrarDetalle
--as
--begin
--end;
--go

--create procedure Ventas.borrarTicket
--as
--begin
--end;
--go

--create procedure Ventas.borrarComentario
--as
--begin
--end;
--go

