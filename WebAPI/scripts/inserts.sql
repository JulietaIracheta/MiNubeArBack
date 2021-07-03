-- agrego url a evento y cambio nombres de campo
use minubeDB
go
EXEC sp_rename 'evento.descripcion', 'title'
go
EXEC sp_rename 'evento.fecha', 'start'
go
alter table evento add url varchar(100)
go
alter table Materias add icon varchar(100)
go
alter table usuarios alter column password varchar(100);
go
alter table Contenidos add  video varchar(255);
go
alter table Comunicados add idDocente int;
go
alter table Usuarios add avatar varchar(255);

go
alter table Comunicados add CONSTRAINT fk_docente FOREIGN KEY (idDocente) REFERENCES Usuarios (idUsuario)
go
alter table Comunicados add fecha datetime;
go
CREATE TABLE [dbo].[Answer](
	[id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[content] [nvarchar](250) NOT NULL,
	[correct] [bit] NOT NULL,
	[questionId] [int] NOT NULL
)
go
CREATE TABLE [dbo].[Boletin](
	[id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[año] [int] NOT NULL,
	[idEstudiante] [int] NOT NULL,
	[materia] [nvarchar](50) NOT NULL,
	[T1] [varchar](20) NULL,
	[T2] [varchar](20) NULL,
	[T3] [varchar](20) NULL,
)
go
CREATE TABLE [dbo].[Puntaje_Actividad](
	[idMateria] [int] NOT NULL,
	[puntaje] [int] NULL,
	[idActividad] [int] NOT NULL,
	[idActividad_Estudiante_Materia_Puntaje] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[idCurso] [int] NULL,
	[idEstudiante] [int] NULL,
)
go
CREATE TABLE [dbo].[Question](
	[id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[content] [nvarchar](250) NOT NULL,
	[actividadesId] [int] NULL,
)
go
ALTER TABLE [dbo].[Question]  WITH NOCHECK ADD  CONSTRAINT [FK_Question_Actividades] FOREIGN KEY([actividadesId])
REFERENCES [dbo].[Actividades] ([idActividad])
go
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([questionId])
REFERENCES [dbo].[Question] ([id])
go
ALTER TABLE [dbo].[Boletin]  WITH CHECK ADD  CONSTRAINT [FK_Boletin_Usuarios] FOREIGN KEY([idEstudiante])
REFERENCES [dbo].[Usuarios] ([idUsuario])
go
ALTER TABLE [dbo].[Puntaje_Actividad]  WITH CHECK ADD  CONSTRAINT [FK_Actividad_Puntaje_Actividad] FOREIGN KEY([idActividad])
REFERENCES [dbo].[Actividades] ([idActividad])
go
ALTER TABLE [dbo].[Puntaje_Actividad]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Puntaje_Actividad] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Cursos] ([idCurso])
go
ALTER TABLE [dbo].[Puntaje_Actividad]  WITH CHECK ADD  CONSTRAINT [FK_Estudiante_Puntaje_Actividad] FOREIGN KEY([idEstudiante])
REFERENCES [dbo].[Usuarios] ([idUsuario])
go
ALTER TABLE [dbo].[Puntaje_Actividad]  WITH CHECK ADD  CONSTRAINT [FK_Materia_Puntaje_Actividad] FOREIGN KEY([idMateria])
REFERENCES [dbo].[Materias] ([idMateria])

-- agrego url a evento y cambio nombres de campos
go
ALTER TABLE Actividades ADD unidad int 
go
alter table Actividades add idMateria int
 go
-- agrego actividades y quiz
Create table Quiz_Preguntas(
idQuiz_Pregunta int primary key IDENTITY(1,1) NOT NULL,
idActividad int, 
pregunta varchar(200)
CONSTRAINT fk_Actividad_Quiz FOREIGN KEY (idActividad) REFERENCES Actividades (idActividad)
);
go
Create table Quiz_Respuestas(
idQuiz_Respuesta int primary key IDENTITY(1,1) NOT NULL,
idQuiz_Pregunta int, 
respuesta varchar(200)
CONSTRAINT fk_Actividad_Quiz_Respuesta FOREIGN KEY (idQuiz_Pregunta) REFERENCES Quiz_Preguntas (idQuiz_Pregunta)
);
go
--creo tabla de notificaciones
create table Notificacion(
	idNotificacion int primary key IDENTITY(1,1) NOT NULL,
	mensaje varchar(100) not null,
	descripcion varchar(255) not null,
	fecha datetime not null,
	tipoNotificacion int not null,
	idDestinatario int not null,
	CONSTRAINT fk_destinatario FOREIGN KEY (idDestinatario) REFERENCES Usuarios (idUsuario)
)
go

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

insert into Personas(nombre,apellido,email,telefono) values('Romina','Soto','rsoto@gmail.com',15003231);
INSERT [dbo].[Usuarios] ([idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion],
[fecha_eliminacion_logico]) 
VALUES ( 3, N'rsoto@gmail.com', N'$2b$10$AVDyfmT22arGYxbNeoEGz./uSVIdlOTcH5Ezni5aST7LW/U2UP4v2',NULL, NULL, null)

insert into Personas(nombre,apellido,email,telefono) values('Admin','Admin','admin@gmail.com',15003231);
INSERT [dbo].[Usuarios] ([idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion],
[fecha_eliminacion_logico]) 
VALUES ( 4, N'admin@gmail.com', N'$2b$10$AVDyfmT22arGYxbNeoEGz./uSVIdlOTcH5Ezni5aST7LW/U2UP4v2',NULL, NULL, null)
 --usuario rol

--estudiante
insert into Personas(nombre,apellido,email,telefono) values('Sofia','Acevedo','sacevedo@gmail.com',15003231);
INSERT [dbo].[Usuarios] ([idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion],
[fecha_eliminacion_logico]) 
VALUES ( 5, N'sacevedo@gmail.com', N'$2b$10$AVDyfmT22arGYxbNeoEGz./uSVIdlOTcH5Ezni5aST7LW/U2UP4v2',NULL, NULL, null)

 --tutor
insert into Personas(nombre,apellido,email,telefono) values('Ramiro','Acevedo','racevedo@gmail.com',15003231);
INSERT [dbo].[Usuarios] ([idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion],
[fecha_eliminacion_logico]) 
VALUES ( 6, N'racevedo@gmail.com', N'$2b$10$AVDyfmT22arGYxbNeoEGz./uSVIdlOTcH5Ezni5aST7LW/U2UP4v2',NULL, NULL, null)

insert into Usuario_Rol (idUsuario,idRol) values (1,1),(2,2),(3,1),(4,4),(4,4),(5,1),(6,3);

 
insert into Tutor_Estudiante(idUsuarioTutor,idUsuarioEstudiante) values(6,1),(6,5);

select * from Usuario_Rol
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
(3,1),
(1,3),
(2,3),
(3,3),
(4,3);
 
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

 
insert into Estudiante_Curso (idUsuario,idCurso) values(3,1),(1,1),(1,2);
insert into Curso_Docente(idCurso,idDocente) values(1,2),(2,2);

insert into Institucion_Docente(idInstitucion,idDocente) values(1,2),(2,2);
insert into Institucion_Curso (idInstitucion,idCurso)values(3,1);
--idusuario

insert into Materia_Docente (idMateria,idUsuario) values(1,2),(2,2),(3,2),(4,2);
