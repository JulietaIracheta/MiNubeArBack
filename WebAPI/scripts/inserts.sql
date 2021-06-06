alter table usuarios alter column password varchar(100);

insert into Roles (descripcion)values('estudiante');
insert into Roles (descripcion)values('docente');
insert into Roles (descripcion)values('tutor');
insert into Roles (descripcion)values('admin');

--agrego video a contenidos
alter table Contenidos add  video varchar(255);

--instituciones
select * from Instituciones
insert into Instituciones(nombre,direccion,email) values('Mariano Moreno','Urquiza 343','marianomoreno@gmail.com');
insert into Instituciones(nombre,direccion,email) values('Escuela primaria 1','Sarmiento 11','escuelapri1@gmail.com');
insert into Instituciones(nombre,direccion,email) values('Escuela secundaria 1','Sarmiento 11','escuelasec1@gmail.com');

-- Materias
select * from Materias
insert into Materias (nombre) values ('Matemática');
insert into Materias (nombre) values ('Lengua');
insert into Materias (nombre) values ('Ciencias Sociales');
insert into Materias (nombre) values ('Ciencias Naturales');
insert into Materias (nombre) values ('Inglés');

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

 
insert into Estudiante_Curso (idUsuario,idCurso) values(6,1),(6,2),(7,1),(7,1);
insert into Curso_Docente(idCurso,idDocente) values(1,5),(2,5);
