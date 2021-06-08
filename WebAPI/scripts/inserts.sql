-- agrego url a evento y cambio nombres de campos
EXEC sp_rename 'evento.descripcion', 'title'
EXEC sp_rename 'evento.fecha', 'start'
alter table evento add url varchar(100)
alter table Materias add icon varchar(100)
alter table usuarios alter column password varchar(100);
alter table Contenidos add  video varchar(255);

insert into Roles (descripcion)values('Estudiante');
insert into Roles (descripcion)values('Docente');
insert into Roles (descripcion)values('Tutor');
insert into Roles (descripcion)values('Admin');

--estudiante
insert into Personas(nombre,apellido,email,telefono) values('Lorenzo','Acevedo','lacevedo@gmail.com',15003231);
INSERT [dbo].[Usuarios] ([idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion],
[fecha_eliminacion_logico]) 
VALUES ( 1, N'lacevedo@gmail.com', N'$2b$10$AVDyfmT22arGYxbNeoEGz./uSVIdlOTcH5Ezni5aST7LW/U2UP4v2',NULL, NULL, null)

--docente
insert into Personas(nombre,apellido,email,telefono) values('Carmen','Lopez','clopez@gmail.com',1145321787);
INSERT [dbo].[Usuarios] ([idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion],
[fecha_eliminacion_logico]) 
VALUES ( 2, N'clopez@gmail.com', N'$2b$10$AVDyfmT22arGYxbNeoEGz./uSVIdlOTcH5Ezni5aST7LW/U2UP4v2',NULL, NULL, null)
 
 --usuario rol
insert into Usuario_Rol (idUsuario,idRol) values(1,1),(2,2);

--instituciones
select * from Instituciones
insert into Instituciones(nombre,direccion,email) values('Mariano Moreno','Urquiza 343','marianomoreno@gmail.com');
insert into Instituciones(nombre,direccion,email) values('Escuela primaria 1','Sarmiento 11','escuelapri1@gmail.com');
insert into Instituciones(nombre,direccion,email) values('Escuela secundaria 1','Sarmiento 11','escuelasec1@gmail.com');

-- Materias
select * from Materias
INSERT INTO Materias (nombre,icon) VALUES
(N'Matemáticas',N'calculator'),
(N'Literatura',N'book'),
(N'Ciencias Naturales',N'leaf'),
(N'Ciencias Sociales',N'globe-americas'),
(N'Música',N'music'),
(N'Inglés',N'globe'),
(N'Juegos',N'chess-knight');

INSERT INTO minubeDB.dbo.Materia_Estudiante (idMateria,idUsuario) VALUES
(1,1),
(7,1),
(2,1),
(3,1);
 
-- Institucion por Materia
insert into Institucion_Materia (idInstitucion,idMateria) values(1,1),(1,2),(1,3),(1,4),(1,5);
insert into Institucion_Materia (idInstitucion,idMateria) values(2,1),(2,5);
insert into Institucion_Materia (idInstitucion,idMateria) values(3,1),(3,2),(3,3),(3,4);

-- Cursos
select * from Cursos
insert into Cursos (nombre)values('Primero A');
insert into Cursos (nombre)values('Primero B');
insert into Cursos (nombre)values('Segundo A');
insert into Cursos (nombre)values('Segundo B');

--materia por curso
insert into Materia_Curso (idMateria,idCurso) values(1,1),(2,1),(1,2),(2,2);

--curso por institucion
select * from Institucion_Curso
insert into Institucion_Curso(idInstitucion,idCurso) values(1,1),(1,2),(2,3),(2,4);

select * from Contenido_Materia_Curso
insert into Contenidos(titulo,descripcion,unidad,video) values('Clase presentacion','Bienvenidos al colegio',1,'video.mp4');
insert into Contenido_Materia_Curso(idContenido,idMateriaCurso) values(1,1);

 
insert into Estudiante_Curso (idUsuario,idCurso) values(1,1),(1,2);
insert into Curso_Docente(idCurso,idDocente) values(1,2),(2,2);

insert into Institucion_Docente(idInstitucion,idDocente) values(1,2),(2,2);
insert into Institucion_Curso (idInstitucion,idCurso)values(3,1);
--idusuario

insert into Materia_Docente (idMateria,idUsuario) values(1,2),(2,2),(3,2),(4,2);


