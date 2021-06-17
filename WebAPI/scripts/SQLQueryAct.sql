alter table Actividades add unidad varchar(50)

Create table Quiz_Preguntas(
idQuiz_Pregunta int primary key IDENTITY(1,1) NOT NULL,
idActividad int, 
pregunta varchar(200)
CONSTRAINT fk_Actividad_Quiz FOREIGN KEY (idActividad) REFERENCES Actividades (idActividad)
);

Create table Quiz_Respuestas(
idQuiz_Respuesta int primary key IDENTITY(1,1) NOT NULL,
idQuiz_Pregunta int, 
respuesta varchar(200)
CONSTRAINT fk_Actividad_Quiz_Respuesta FOREIGN KEY (idQuiz_Pregunta) REFERENCES Quiz_Preguntas (idQuiz_Pregunta)
);