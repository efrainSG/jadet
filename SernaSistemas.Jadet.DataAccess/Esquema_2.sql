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