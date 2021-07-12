CREATE TABLE minubeDB.dbo.Actividad_Materia_Unidad (
	idActividad_Materia_Unidad int IDENTITY(1,1) NOT NULL,
	idActividad int NOT NULL,
	idMateria int NOT NULL,
	unidad int NOT NULL,
	titulo varchar(200) COLLATE Modern_Spanish_CI_AS NOT NULL,
	CONSTRAINT PK_Actividad_Materia_Unidad PRIMARY KEY (idActividad_Materia_Unidad)
);

ALTER TABLE minubeDB.dbo.Actividad_Materia_Unidad ADD CONSTRAINT FK_Actividad_Materia_Unidad_Actividades FOREIGN KEY (idActividad) REFERENCES minubeDB.dbo.Actividades(idActividad);
ALTER TABLE minubeDB.dbo.Actividad_Materia_Unidad ADD CONSTRAINT FK_Actividad_Materia_Unidad_Materias FOREIGN KEY (idMateria) REFERENCES minubeDB.dbo.Materias(idMateria);