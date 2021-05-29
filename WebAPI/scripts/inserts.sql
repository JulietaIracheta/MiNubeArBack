insert into Personas (nombre,apellido,email,telefono)values('marcos','cabral','marcoscabral2506@gmail.com',111111);
insert into Usuarios(idPersona,usuario_nombre,password) values(1,'mcabral','1234');
insert into Roles (descripcion)values('estudiante');
insert into Roles (descripcion)values('docente');
insert into Roles (descripcion)values('tutor');
insert into Roles (descripcion)values('admin');
insert into Usuario_Rol (idUsuario,idRol) values(1,1);