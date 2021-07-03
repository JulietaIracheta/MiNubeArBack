
	CREATE TABLE [dbo].[Answer](
	[id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[content] [nvarchar](250) NOT NULL,
	[correct] [bit] NOT NULL,
	[questionId] [int] NOT NULL
)
CREATE TABLE [dbo].[Boletin](
	[id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[año] [int] NOT NULL,
	[idEstudiante] [int] NOT NULL,
	[materia] [nvarchar](50) NOT NULL,
	[T1] [varchar](20) NULL,
	[T2] [varchar](20) NULL,
	[T3] [varchar](20) NULL,
)

CREATE TABLE [dbo].[Puntaje_Actividad](
	[idMateria] [int] NOT NULL,
	[puntaje] [int] NULL,
	[idActividad] [int] NOT NULL,
	[idActividad_Estudiante_Materia_Puntaje] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[idCurso] [int] NULL,
	[idEstudiante] [int] NULL,
)

CREATE TABLE [dbo].[Question](
	[id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[content] [nvarchar](250) NOT NULL,
	[actividadesId] [int] NULL,
)

ALTER TABLE [dbo].[Question]  WITH NOCHECK ADD  CONSTRAINT [FK_Question_Actividades] FOREIGN KEY([actividadesId])
REFERENCES [dbo].[Actividades] ([idActividad])

ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question] FOREIGN KEY([questionId])
REFERENCES [dbo].[Question] ([id])

ALTER TABLE [dbo].[Boletin]  WITH CHECK ADD  CONSTRAINT [FK_Boletin_Usuarios] FOREIGN KEY([idEstudiante])
REFERENCES [dbo].[Usuarios] ([idUsuario])

ALTER TABLE [dbo].[Puntaje_Actividad]  WITH CHECK ADD  CONSTRAINT [FK_Actividad_Puntaje_Actividad] FOREIGN KEY([idActividad])
REFERENCES [dbo].[Actividades] ([idActividad])

ALTER TABLE [dbo].[Puntaje_Actividad]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Puntaje_Actividad] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Cursos] ([idCurso])

ALTER TABLE [dbo].[Puntaje_Actividad]  WITH CHECK ADD  CONSTRAINT [FK_Estudiante_Puntaje_Actividad] FOREIGN KEY([idEstudiante])
REFERENCES [dbo].[Usuarios] ([idUsuario])

ALTER TABLE [dbo].[Puntaje_Actividad]  WITH CHECK ADD  CONSTRAINT [FK_Materia_Puntaje_Actividad] FOREIGN KEY([idMateria])
REFERENCES [dbo].[Materias] ([idMateria])

ALTER TABLE [dbo].[Actividades] ADD unidad int 


INSERT [dbo].[Actividades] ( [titulo], [descripcion], [unidad], [idMateria]) VALUES ('Actividad', N'Actividad de Preguntas y Respuestas', 2, 1)
INSERT [dbo].[Actividades] ( [titulo], [descripcion], [unidad], [idMateria]) VALUES ('Actividad', N'Actividad de Preguntas y Respuestas', 1, 1)
INSERT [dbo].[Actividades] ( [titulo], [descripcion], [unidad], [idMateria]) VALUES ('Actividad', N'Matematicas', 1, 1)
INSERT [dbo].[Actividades] ( [titulo], [descripcion], [unidad], [idMateria]) VALUES ('Actividad', N'Lengua', 1, 1)
INSERT [dbo].[Actividades] ( [titulo], [descripcion], [unidad], [idMateria]) VALUES ('Actividad', N'Ciencias Sociales', 1, 1)
INSERT [dbo].[Actividades] ( [titulo], [descripcion], [unidad], [idMateria]) VALUES ('Actividades', N'Preguntas y Respuestas Varias', 1, 1)
INSERT [dbo].[Actividades] ( [titulo], [descripcion], [unidad], [idMateria]) VALUES ('Numeros', N'Conocemos los numeros', 1, 1)


INSERT [dbo].[Question] ([content], [actividadesId]) VALUES ( 'Quién descubrió América?', 1)
INSERT [dbo].[Question] ( [content], [actividadesId]) VALUES ( 'Cuál es la capital de Argentina?', 1)
INSERT [dbo].[Question] ( [content], [actividadesId]) VALUES ( 'En qué mes se festeja Navidad?', 1)
INSERT [dbo].[Question] ( [content], [actividadesId]) VALUES ( 'Cuánto es 2 + 2?', 1)
INSERT [dbo].[Question] ( [content], [actividadesId]) VALUES ('De qué color es la bandera de Argentina?', 1)
INSERT [dbo].[Question] ( [content], [actividadesId]) VALUES ('Qué se festeja el 9 de Julio?', 1)
INSERT [dbo].[Question] ( [content], [actividadesId]) VALUES ('Quién ganó la Copa del Mundo de Fútbol en 1986', 2)
INSERT [dbo].[Question] ( [content], [actividadesId]) VALUES ('De qué color era el perro de Alicia?', 2)
INSERT [dbo].[Question] ( [content], [actividadesId]) VALUES ('Cuantas patas tiene una araña?', 2)
INSERT [dbo].[Question] ( [content], [actividadesId]) VALUES ('Qué numero sigue al 9?', 2)

INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('Cornelio Saavedra', 0, 1)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('Cristobal Colón', 1, 1)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('Marcelo tinelli', 0, 1)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('Córdoba', 0, 2)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('Santa Fe', 0, 2)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('Buenos Aires ', 1, 2)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('Uruguay', 0, 3)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('Argentina', 1, 3)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('Alemania', 0, 3)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('3', 0, 4)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('5', 0, 4)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('4', 1, 4)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('2', 0, 5)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('4', 0, 5)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('8', 1, 5)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('Enero', 0, 6)
INSERT [dbo].[Answer] ([content], [correct], [questionId]) VALUES ('Marzo', 0, 6)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('Diciembre', 1, 6)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('Roja y Blanca', 0, 7)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('Azul, Verde y Amarillo', 0, 7)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('Celeste y Blanca', 1, 7)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('La Revolución de Mayo', 0, 8)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('El descubrimiento de América', 0, 8)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('El día de la independencia', 1, 8)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('Gris', 0, 9)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('Blanco', 0, 9)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('Negro', 1, 9)
INSERT [dbo].[Answer] ( [content], [correct], [questionId]) VALUES ('8', 0, 10)
INSERT [dbo].[Answer] ([content], [correct], [questionId]) VALUES ('10', 1, 10)
INSERT [dbo].[Answer] ([content], [correct], [questionId]) VALUES ('20', 0, 10)

INSERT [dbo].[Boletin] ([año], [idEstudiante], [materia], [T1], [T2], [T3]) VALUES (2020, 3, 'Matematicas', '8','8', '7')
INSERT [dbo].[Boletin] ([año], [idEstudiante], [materia], [T1], [T2], [T3]) VALUES (2020, 3, 'Ciencias Sociales', '8', '8', '8')
INSERT [dbo].[Boletin] ([año], [idEstudiante], [materia], [T1], [T2], [T3]) VALUES (2020, 3, 'Ciencias Naturales', '10', '10', '9')
INSERT [dbo].[Boletin] ([año], [idEstudiante], [materia], [T1], [T2], [T3]) VALUES (2020, 3, 'Literatura', '5', '9', '9')

INSERT [dbo].[Puntaje_Actividad] ([idMateria], [puntaje], [idActividad],  [idCurso], [idEstudiante]) VALUES (1, 6, 1,  1, 3)
INSERT [dbo].[Puntaje_Actividad] ([idMateria], [puntaje], [idActividad],  [idCurso], [idEstudiante]) VALUES (1, NULL,  3, 1, 3)
INSERT [dbo].[Puntaje_Actividad] ([idMateria], [puntaje], [idActividad],  [idCurso], [idEstudiante]) VALUES (1, 9, 3,  1, 3)
INSERT [dbo].[Puntaje_Actividad] ([idMateria], [puntaje], [idActividad],  [idCurso], [idEstudiante]) VALUES (1, NULL, 3, 1, 3)
INSERT [dbo].[Puntaje_Actividad] ([idMateria], [puntaje], [idActividad],  [idCurso], [idEstudiante]) VALUES (1, 7, 5,  1, 3)
INSERT [dbo].[Puntaje_Actividad] ([idMateria], [puntaje], [idActividad],  [idCurso], [idEstudiante]) VALUES (1, 7, 1,  1, 3)
INSERT [dbo].[Puntaje_Actividad] ([idMateria], [puntaje], [idActividad],  [idCurso], [idEstudiante]) VALUES (1, 6, 1, 1, 3)



