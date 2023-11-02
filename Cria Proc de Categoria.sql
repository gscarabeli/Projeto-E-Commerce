create procedure spInsert_Categorias
(
 @id int,
 @descricao varchar(max)
)
as
begin
 insert into Categorias(id, descricao) values (@id, @descricao)
end
GO

create procedure spUpdate_Categorias
(
 @id int,
 @descricao varchar(max)
)
as
begin
 update Categorias set descricao = @descricao where id = @id
end
GO