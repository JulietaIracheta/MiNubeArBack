EXEC sp_rename 'evento.descripcion', 'title'

EXEC sp_rename 'evento.fecha', 'start'

alter table evento add url varchar(100)

