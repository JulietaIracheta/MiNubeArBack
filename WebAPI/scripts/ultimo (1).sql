CREATE DATABASE minubeDB
go
USE minubeDB
go
Create table Personas(
idPersona int primary key IDENTITY(1,1) NOT NULL,
nombre varchar(50) not null,
apellido varchar(50) not null,
email varchar(50) not null,
telefono int not null,
);

Create table Usuarios(
idUsuario int primary key IDENTITY(1,1) NOT NULL,
idPersona int, 
usuario_nombre varchar(50) not null,
password varchar(100) not null,
fecha_creacion datetime,
fecha_modificacion datetime,
fecha_eliminacion_logico datetime,
avatar varchar(255),
CONSTRAINT fk_Persona FOREIGN KEY (idPersona) REFERENCES Personas (idPersona)
);

Create table Roles(
idRol int primary key IDENTITY(1,1) NOT NULL,
descripcion varchar(50) NOT NULL
);

Create table Usuario_Rol(
idUsuarioRol int primary key IDENTITY(1,1) NOT NULL,
idUsuario int NOT NULL,
idRol int NOT NULL,
CONSTRAINT fk_Usuario FOREIGN KEY (idUsuario) REFERENCES Usuarios (idUsuario),
CONSTRAINT fk_Rol FOREIGN KEY (idRol) REFERENCES Roles (idRol)
)

Create table Permisos(
idPermiso int primary key IDENTITY(1,1) NOT NULL,
operacion varchar(50) NOT NULL
)

Create table Rol_Permiso(
idrolPermiso int primary key IDENTITY(1,1) NOT NULL,
idRol int NOT NULL,
idPermiso int NOT NULL,
CONSTRAINT fk_Permiso FOREIGN KEY (idPermiso) REFERENCES Permisos (idPermiso),
CONSTRAINT fk_Rol_Permiso FOREIGN KEY (idRol) REFERENCES Roles (idRol)
);

Create table Tutor_Estudiante(
    idTutorEstudiante int primary key IDENTITY(1,1) NOT NULL,
    idUsuarioTutor int NOT NULL,
    idUsuarioEstudiante int NOT NULL,
    CONSTRAINT fk_Usuario_Tutor FOREIGN KEY (idUsuarioTutor) REFERENCES Usuarios (idUsuario),
    CONSTRAINT fk_Usuario_Estudiante FOREIGN KEY (idUsuarioEstudiante) REFERENCES Usuarios (idUsuario)
);

Create table NivelEducativo(
idNivelEducativo int primary key IDENTITY(1,1) NOT NULL,
nombre varchar(50) NOT NULL
);

Create table Nivel_Educativo_Estudiante(
idNivelEducativoEstudiante int primary key IDENTITY(1,1) NOT NULL,
idNivelEducativo int NOT NULL,
idUsuarioEstudiante int NOT NULL,
CONSTRAINT fk_Nivel_Educativo_Estudiante FOREIGN KEY (idNivelEducativo) REFERENCES NivelEducativo (idNivelEducativo),
CONSTRAINT fk_Usuario_Estudiante2 FOREIGN KEY (idUsuarioEstudiante) REFERENCES Usuarios (idUsuario)
);

Create table Cursos(
idCurso int primary key IDENTITY(1,1) NOT NULL,
nombre varchar(50) NOT NULL
);

Create table Estudiante_Curso(
idEstudianteCurso int primary key IDENTITY(1,1) NOT NULL,
idUsuario int NOT NULL,
idCurso int NOT NULL,
CONSTRAINT fk_Estudiante_Curso FOREIGN KEY (idUsuario) REFERENCES Usuarios (idUsuario),
CONSTRAINT fk_Curso_Estudiante FOREIGN KEY (idCurso) REFERENCES Cursos (idCurso)
);

Create table Historiales(
idHistorial int primary key IDENTITY(1,1) NOT NULL,
idUsuario int NOT NULL,
idCurso int NOT NULL,
CONSTRAINT fk_Usuario_Historial FOREIGN KEY (idUsuario) REFERENCES Usuarios (idUsuario),
CONSTRAINT fk_Curso_Historial FOREIGN KEY (idCurso) REFERENCES Cursos (idCurso)
);

Create table Comunicados(
idComunicado int primary key IDENTITY(1,1) NOT NULL,
idUsuario int NOT NULL,
descripcion varchar(1000) NOT NULL,
idDocente int NULL,
fecha datetime,
CONSTRAINT fk_Usuario_Comunicado FOREIGN KEY (idUsuario) REFERENCES Usuarios (idUsuario),
CONSTRAINT fk_docente FOREIGN KEY (idDocente) REFERENCES Usuarios (idUsuario)
);

Create table Informes(
idInforme int primary key IDENTITY(1,1) NOT NULL,
descripcion varchar(1000) NOT NULL,
idCurso int NOT NULL,
idUsuario int NOT NULL,
año int,
CONSTRAINT fk_Usuario_Informe FOREIGN KEY (idUsuario) REFERENCES Usuarios (idUsuario),
CONSTRAINT fk_Curso_Informe FOREIGN KEY (idCurso) REFERENCES Cursos (idCurso)
);

Create table Materias(
idMateria int primary key IDENTITY(1,1) NOT NULL,
nombre varchar(50) NOT NULL,
icon varchar(100) NULL
);

Create table Materia_Estudiante(
idMateriaEstudiante int primary key IDENTITY(1,1) NOT NULL,
idMateria int NOT NULL,
idUsuario int NOT NULL,
CONSTRAINT fk_Estudiante_Materia FOREIGN KEY (idUsuario) REFERENCES Usuarios (idUsuario),
CONSTRAINT fk_Materia_Estudiante FOREIGN KEY (idMateria) REFERENCES Materias (idMateria),
);

Create table Materia_Docente(
idMateriaDocente int primary key IDENTITY(1,1) NOT NULL,
idMateria int NOT NULL,
idUsuario int NOT NULL,
CONSTRAINT fk_Docente_Materia FOREIGN KEY (idUsuario) REFERENCES Usuarios (idUsuario),
CONSTRAINT fk_Materia_Docente FOREIGN KEY (idMateria) REFERENCES Materias (idMateria),
);

Create table Instituciones(
idInstitucion int primary key IDENTITY(1,1) NOT NULL,
nombre varchar(50) NOT NULL,
direccion varchar(50) NOT NULL,
email varchar(50) NOT NULL
);

Create table Institucion_Estudiante(
idInstitucionEstudiante int primary key IDENTITY(1,1) NOT NULL,
idInstitucion int NOT NULL,
idUsuario int NOT NULL,
CONSTRAINT fk_Estudiante_Institucion FOREIGN KEY (idUsuario) REFERENCES Usuarios (idUsuario),
CONSTRAINT fk_Institucion_Estudiante FOREIGN KEY (idInstitucion) REFERENCES Instituciones (idInstitucion),

);

Create table Rol_Institucion(
idRolInstitucion int primary key IDENTITY(1,1) NOT NULL,
idRol int NOT NULL,
idInstitucion int NOT NULL,
CONSTRAINT fk_Institucion_Rol FOREIGN KEY (idInstitucion) REFERENCES Instituciones (idInstitucion),
CONSTRAINT fk_Rol_Institucion FOREIGN KEY (idRol) REFERENCES Roles (idRol)
);

Create table Institucion_Tutor(
idInstitucionTutor int primary key IDENTITY(1,1) NOT NULL,
idInstitucion int NOT NULL,
idTutor int NOT NULL,
CONSTRAINT fk_Institucion FOREIGN KEY (idInstitucion) REFERENCES Instituciones (idInstitucion),
CONSTRAINT fk_Institucion_Tutor FOREIGN KEY (idTutor) REFERENCES Usuarios (idUsuario),
);

Create table Institucion_Docente(
idInstitucionDocente int primary key IDENTITY(1,1) NOT NULL,
idInstitucion int NOT NULL,
idDocente int NOT NULL,
CONSTRAINT fk_Institucion2 FOREIGN KEY (idInstitucion) REFERENCES Instituciones (idInstitucion),
CONSTRAINT fk_Institucion_Docente FOREIGN KEY (idDocente) REFERENCES Usuarios (idUsuario),
);

Create table Institucion_Materia(
idInstitucionMateria int primary key IDENTITY(1,1) NOT NULL,
idInstitucion int NOT NULL,
idMateria int NOT NULL,
CONSTRAINT fk_Institucion3 FOREIGN KEY (idInstitucion) REFERENCES Instituciones (idInstitucion),
CONSTRAINT fk_Institucion_Materia FOREIGN KEY (idMateria) REFERENCES Materias (idMateria),
);

Create table Institucion_Curso(
idInstitucionCurso int primary key IDENTITY(1,1) NOT NULL,
idInstitucion int NOT NULL,
idCurso int NOT NULL,
CONSTRAINT fk_Institucion4 FOREIGN KEY (idInstitucion) REFERENCES Instituciones (idInstitucion),
CONSTRAINT fk_Institucion_Curso FOREIGN KEY (idCurso) REFERENCES Cursos (idCurso),
);

Create table Contenidos(
idContenido int primary key IDENTITY(1,1) NOT NULL,
titulo varchar(50) NOT NULL,
descripcion varchar(50) NOT NULL,
unidad int NOT NULL,
fecha date,
fechaBaja date,
video varchar(255)
);

Create table Actividades(
idActividad int primary key IDENTITY(1,1) NOT NULL,
titulo varchar(50) NOT NULL,
descripcion varchar(50) NOT NULL,
idContenido int,
unidad int,
idMateria int,
idCurso int,
CONSTRAINT fk_contenido FOREIGN KEY (idContenido) REFERENCES Contenidos (idContenido)
);

Create table Actividad_Curso(
idActividadCurso int primary key IDENTITY(1,1) NOT NULL,
idActividad int NOT NULL,
idCurso int NOT NULL,
CONSTRAINT fk_Actividad_Curso FOREIGN KEY (idCurso) REFERENCES Cursos (idCurso),
CONSTRAINT fk_Curso_Actividad FOREIGN KEY (idActividad) REFERENCES Actividades (idActividad),
);

Create table Curso_Docente(
idCursoDocente int primary key IDENTITY(1,1) NOT NULL,
idCurso int NOT NULL,
idDocente int NOT NULL,
CONSTRAINT fk_Curso_Docente FOREIGN KEY (idDocente) REFERENCES Usuarios (idUsuario),
CONSTRAINT fk_Docente_Curso FOREIGN KEY (idCurso) REFERENCES Cursos (idCurso),
);

Create table Evento(
idEvento int primary key IDENTITY(1,1) NOT NULL,
title varchar(50) NOT NULL,
start datetime NOT NULL,
idCurso int NOT NULL,
url varchar(100) NULL,
CONSTRAINT fk_Evento_Curso FOREIGN KEY (idCurso) REFERENCES Cursos (idCurso),
);



CREATE TABLE ContenidoHistorico(
	idContenidoHistorico int PRIMARY KEY IDENTITY(1,1)  NOT NULL,
	idContenido int not null,
	CONSTRAINT fk_ContenidoHistorico FOREIGN KEY (idContenido) REFERENCES Contenidos (idContenido)
)

Create table Comentarios(
idComentario int primary key IDENTITY(1,1) NOT NULL, 
descripcion varchar(50) NOT NULL,
fecha datetime NOT NULL,
idUsuario int NOT NULL,
idContenido int NOT NULL,
video varchar(255) NOT NULL,
CONSTRAINT fk_Comentario_Contenido FOREIGN KEY (idContenido) REFERENCES Contenidos (idContenido)
);

Create table Materia_Curso(
idMateriaCurso int primary key IDENTITY(1,1) NOT NULL,
idMateria int NOT NULL,
idCurso int NOT NULL,
CONSTRAINT fk_Materia_Curso FOREIGN KEY (idCurso) REFERENCES Cursos (idCurso),
CONSTRAINT fk_Curso_Materia FOREIGN KEY (idMateria) REFERENCES Materias (idMateria),
);

Create table Contenido_Materia_Curso(
idContenidoMateriaCurso int primary key IDENTITY(1,1) NOT NULL,
idContenido int NOT NULL, 
idMateriaCurso int NOT NULL,
CONSTRAINT fk_Contenido_Materia_Curso FOREIGN KEY (idContenido) REFERENCES Contenidos (idContenido),
CONSTRAINT fk_Materia_Curso_Contenido FOREIGN KEY (idMateriaCurso) REFERENCES Materia_Curso (idMateriaCurso)
);

CREATE TABLE Question(
	id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	content nvarchar(250) NOT NULL,
	actividadesId int NULL,
	CONSTRAINT FK_Question_Actividades FOREIGN KEY(actividadesId) REFERENCES Actividades (idActividad)
);

CREATE TABLE Answer(
	id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	content nvarchar(250) NOT NULL,
	correct bit NOT NULL,
	questionId int NOT NULL,
	CONSTRAINT FK_Answer_Question FOREIGN KEY(questionId) REFERENCES Question (id)
);



CREATE TABLE Boletin(
	id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	año int NOT NULL,
	idEstudiante int NOT NULL,
	materia nvarchar(50) NOT NULL,
	T1 money NULL,
	T2 money NULL,
	T3 money NULL,
	CONSTRAINT FK_Boletin_Usuarios FOREIGN KEY(idEstudiante) REFERENCES Usuarios (idUsuario)
);


CREATE TABLE Puntaje_Actividad(
	idMateria int NOT NULL,
	puntaje int NULL,
	idActividad int NOT NULL,
	idActividad_Estudiante_Materia_Puntaje int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	idCurso int NULL,
	idEstudiante int NULL,
	CONSTRAINT FK_Actividad_Puntaje_Actividad FOREIGN KEY(idActividad) REFERENCES Actividades (idActividad),
	CONSTRAINT FK_Curso_Puntaje_Actividad FOREIGN KEY(idCurso) REFERENCES Cursos (idCurso),
	CONSTRAINT FK_Estudiante_Puntaje_Actividad FOREIGN KEY(idEstudiante) REFERENCES Usuarios (idUsuario),
	CONSTRAINT FK_Materia_Puntaje_Actividad FOREIGN KEY(idMateria) REFERENCES Materias (idMateria)
);

create table Notificacion(
	idNotificacion int primary key IDENTITY(1,1) NOT NULL,
	mensaje varchar(100) not null,
	descripcion varchar(255) not null,
	fecha datetime not null,
	tipoNotificacion int not null,
	idDestinatario int not null,
	CONSTRAINT fk_destinatario FOREIGN KEY (idDestinatario) REFERENCES Usuarios (idUsuario)
);

CREATE TABLE Actividad_Materia_Unidad (
	idActividad_Materia_Unidad int IDENTITY(1,1) NOT NULL,
	idActividad int NOT NULL,
	idMateria int NOT NULL,
	unidad int NOT NULL,
	titulo varchar(200) COLLATE Modern_Spanish_CI_AS NOT NULL,
	CONSTRAINT PK_Actividad_Materia_Unidad PRIMARY KEY (idActividad_Materia_Unidad),
	CONSTRAINT FK_Actividad_Materia_Unidad_Actividades FOREIGN KEY (idActividad) REFERENCES Actividades(idActividad),
	CONSTRAINT FK_Actividad_Materia_Unidad_Materias FOREIGN KEY (idMateria) REFERENCES Materias(idMateria)
);

CREATE TABLE Trayectoria(
id int primary key IDENTITY(1,1) NOT NULL,
materia nvarchar(50) NOT NULL,
calificacion nvarchar(250) NOT NULL,
idInforme int NULL,
año int NULL,
CONSTRAINT FK_Informe_Trayectoria FOREIGN KEY (idInforme) REFERENCES Informes(idInforme)
);

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

 
insert into Tutor_Estudiante(idUsuarioTutor,idUsuarioEstudiante) values(6,3),(6,5);

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

INSERT INTO Materia_Estudiante (idMateria,idUsuario) VALUES
(1,1),
(7,1),
(2,1),
(3,1),
(1,3),
(2,3),
(3,3),
(4,3),
(1,5),
(2,5),
(3,5),
(4,5);

 
-- Institucion por Materia
insert into Institucion_Materia (idInstitucion,idMateria) values(1,1),(1,2),(1,3),(1,4),(1,5);
insert into Institucion_Materia (idInstitucion,idMateria) values(2,1),(2,5);
insert into Institucion_Materia (idInstitucion,idMateria) values(3,1),(3,2),(3,3),(3,4);

-- Cursos
insert into Cursos (nombre)values('Primero A');
insert into Cursos (nombre)values('Primero B');
insert into Cursos (nombre)values('Segundo A');
insert into Cursos (nombre)values('Segundo B');
insert into Cursos (nombre)values('Tercero A');
insert into Cursos (nombre)values('Tercero B');
insert into Cursos (nombre)values('Cuarto A');
insert into Cursos (nombre)values('Cuarto B');
insert into Cursos (nombre)values('Quinto A');
insert into Cursos (nombre)values('Quinto B');
insert into Cursos (nombre)values('Sexto A');
insert into Cursos (nombre)values('Sexto B');

--materia por curso
insert into Materia_Curso (idMateria,idCurso) values(1,1),(2,1),(1,2),(2,2);

--curso por institucion
insert into Institucion_Curso(idInstitucion,idCurso) values(1,1),(1,2),(2,3),(2,4);

--contenido
insert into Contenidos(titulo,descripcion,unidad,video) values('Clase presentacion','Bienvenidos al colegio',1,'video.mp4');
insert into Contenido_Materia_Curso(idContenido,idMateriaCurso) values(1,1);
 
insert into Estudiante_Curso (idUsuario,idCurso) values(3,1),(1,1);
insert into Curso_Docente(idCurso,idDocente) values(1,2),(2,2);

insert into Institucion_Docente(idInstitucion,idDocente) values(1,2),(2,2);
insert into Institucion_Curso (idInstitucion,idCurso)values(3,1);


insert into Institucion_Estudiante(idInstitucion,idUsuario) values(1,1),(1,3);

insert into Materia_Docente (idMateria,idUsuario) values(1,2),(2,2),(3,2),(4,2);

INSERT Actividades ( titulo, descripcion, idContenido, unidad, idMateria, idCurso) 
VALUES ('Actividad', N'Actividad de Preguntas y Respuestas', 1, 1, 1,1);

INSERT Actividad_Curso (idActividad, idCurso) VALUES (1,1)
insert into Actividad_Materia_Unidad (idActividad,idMateria,unidad,titulo) values(1,1,1,'Aprendiendo a sumar');


INSERT Question (content, actividadesId) VALUES ( 'Cuánto es 5 + 5?', 1);

INSERT Answer ( content, correct, questionId) VALUES ('5', 0, 1);
INSERT Answer ( content, correct, questionId) VALUES ('10', 1, 1);
INSERT Answer ( content, correct, questionId) VALUES ('1', 0, 1);

INSERT Boletin (año, idEstudiante, materia, T1, T2, T3) VALUES (2021, 3, 'Matematicas', 8,8, 7);
INSERT Boletin (año, idEstudiante, materia, T1, T2, T3) VALUES (2021, 3, 'Ciencias Sociales', 8, 8, 8);
INSERT Boletin (año, idEstudiante, materia, T1, T2, T3) VALUES (2021, 3, 'Ciencias Naturales', 10, 10, 9);
INSERT Boletin (año, idEstudiante, materia, T1, T2, T3) VALUES (2021, 3, 'Literatura',5, 9, 9);

INSERT Boletin (año, idEstudiante, materia, T1, T2, T3) VALUES (2021, 1, 'Matematicas', 6,9, 9);
INSERT Boletin (año, idEstudiante, materia, T1, T2, T3) VALUES (2021, 1, 'Ciencias Sociales', 10, 10, 9);
INSERT Boletin (año, idEstudiante, materia, T1, T2, T3) VALUES (2021, 1, 'Ciencias Naturales', 8, 8, 9);
INSERT Boletin (año, idEstudiante, materia, T1, T2, T3) VALUES (2021, 1, 'Literatura',5, 7, 8);


INSERT Boletin (año, idEstudiante, materia, T1, T2, T3) VALUES (2021, 5, 'Matematicas', 8,6, 7);
INSERT Boletin (año, idEstudiante, materia, T1, T2, T3) VALUES (2021, 5, 'Ciencias Sociales', 7, 7, 7);
INSERT Boletin (año, idEstudiante, materia, T1, T2, T3) VALUES (2021, 5, 'Ciencias Naturales', 7, 6, 9);
INSERT Boletin (año, idEstudiante, materia, T1, T2, T3) VALUES (2021, 5, 'Literatura',10, 9, 10);

go
alter table Informes add idInstitucion int NOT NULL DEFAULT 0;
go
go
alter table Informes ADD CONSTRAINT fk_Institucion_Informe 
FOREIGN KEY (idInstitucion) REFERENCES Instituciones (idInstitucion)
GO

INSERT Informes (descripcion, idCurso, idUsuario, año, idInstitucion) VALUES ('Romina_Soto_2021.pdf',11,3,2021,1);
INSERT Informes (descripcion, idCurso, idUsuario, año, idInstitucion) VALUES ('Romina_Soto_2020.pdf',9,3,2020,1);
INSERT Informes (descripcion, idCurso, idUsuario, año, idInstitucion) VALUES ('Romina_Soto_2019.pdf',7,3,2019,1);
INSERT Informes (descripcion, idCurso, idUsuario, año, idInstitucion) VALUES ('Romina_Soto_2018.pdf',5,3,2018,1);
INSERT Informes (descripcion, idCurso, idUsuario, año, idInstitucion) VALUES ('Romina_Soto_2017.pdf',3,3,2017,2);
INSERT Informes (descripcion, idCurso, idUsuario, año, idInstitucion) VALUES ('Romina_Soto_2016.pdf',1,3,2016,2);

INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Matemática', 'Bueno', 2, 2020);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Literatura', 'Sobresaliente', 2, 2020);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Ciencias Sociales', 'Bueno', 2, 2020);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Ciencias Naturales', 'Sobresaliente', 2, 2020);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Matemática', 'Bueno', 3, 2019);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Literatura', 'Bueno', 3, 2019);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Ciencias Sociales', 'Sobresaliente', 3, 2019);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Ciencias Naturales', 'Bueno', 3, 2019);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Matemática', 'Sobresaliente', 4, 2018);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Literatura', 'Bueno', 4, 2018);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Ciencias Sociales', 'Bueno', 4, 2018);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Ciencias Naturales', 'Sobresaliente', 4, 2018);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Matemática', 'Bueno', 5, 2017);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Literatura', 'Sobresaliente', 5, 2017);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Ciencias Sociales', 'Bueno', 5, 2017);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Ciencias Naturales', 'Sobresaliente', 5, 2017);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Matemática', 'Sobresaliente', 6, 2016);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Literatura', 'Sobresaliente', 6, 2016);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Ciencias Sociales', 'Bueno', 6, 2016);
INSERT Trayectoria(materia, calificacion, idInforme, año) VALUES ('Ciencias Naturales', 'Bueno', 6, 2016);


insert into Contenidos (titulo,descripcion,unidad,fecha, fechaBaja,video) 
values('Multiplicación','Video de multiplicaciones',2,'2020-07-14','2020-07-14','multiplicaciones.mp4');

insert into Contenidos (titulo,descripcion,unidad,fecha, fechaBaja,video) 
values('Sumas y restas','Video de sumas y restas',1,'2020-07-14','2020-07-14','sumasrestas.mp4');

insert into ContenidoHistorico (idContenido) values(2),(3);

insert into Contenido_Materia_Curso (idContenido,idMateriaCurso) values(2,1),(3,1);
go
create table PuntajeContenido(
	idPuntajeContenido int primary key IDENTITY(1,1) NOT NULL,
	idContenido int not null,
	idEstudiante int not null,
	fecha datetime not null,
	puntaje int not null,
	CONSTRAINT fk_Contenido_Puntaje FOREIGN KEY (idContenido) REFERENCES Contenidos (idContenido),
	CONSTRAINT fk_Contenido_Puntaje_Estudiante FOREIGN KEY (idEstudiante) REFERENCES Usuarios (idUsuario)
);
go
 alter table Contenidos add visto bit NOT NULL DEFAULT 0;
go
alter table Trayectoria add idEstudiante int null

--2016
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2016,3,'Lengua',8.00,7.00,8.00);
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2016,3,'Matemáticas',8.00,9.00,9.00);
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2016,3,'Ciencias Naturales',10.00,9.00,9.00);
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2016,3,'Ciencias Sociales',8.00,8.00,8.00);
--2017
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2017,3,'Lengua',7.00,7.00,8.00);
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2017,3,'Matemáticas',7.00,7.00,7.00);
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2017,3,'Ciencias Sociales',9.00,9.00,8.00);
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2017,3,'Ciencias Naturales',8.00,10.00,8.00);

--2018
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2018,3,'Lengua',9.00,8.00,8.00);
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2018,3,'Matemáticas',7.00,7.00,7.00);
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2018,3,'Ciencias Sociales',10.00,9.00,6.00);
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2018,3,'Ciencias Naturales',6.00,10.00,8.00);

--2019
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2019,3,'Lengua',7.00,8.00,8.00);
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2019,3,'Matemáticas',8.00,6.00,7.00);
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2019,3,'Ciencias Sociales',10.00,10.00,8.00);
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2019,3,'Ciencias Naturales',6.00,10.00,8.00);
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2019,3,'Inglés',6.00,7.00,9.00);

--2020
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2020,3,'Lengua',8.00,8.00,6.00);
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2020,3,'Matemáticas',9.00,6.00,7.00);
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2020,3,'Ciencias Sociales',9.00,7.00,8.00);
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2020,3,'Ciencias Naturales',6.00,6.00,10.00);
insert into Boletin (año,idEstudiante,materia,T1,T2,T3) values(2020,3,'Inglés',7.00,8.00,7.00);
GO


