USE [master]
GO
/****** Object:  Database [MiNubeTest]    Script Date: 06/06/2021 20:54:59 ******/
CREATE DATABASE [MiNubeTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MiNubeTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MiNubeTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MiNubeTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MiNubeTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MiNubeTest] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MiNubeTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MiNubeTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MiNubeTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MiNubeTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MiNubeTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MiNubeTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [MiNubeTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MiNubeTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MiNubeTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MiNubeTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MiNubeTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MiNubeTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MiNubeTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MiNubeTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MiNubeTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MiNubeTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MiNubeTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MiNubeTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MiNubeTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MiNubeTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MiNubeTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MiNubeTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MiNubeTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MiNubeTest] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MiNubeTest] SET  MULTI_USER 
GO
ALTER DATABASE [MiNubeTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MiNubeTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MiNubeTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MiNubeTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MiNubeTest] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MiNubeTest] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MiNubeTest] SET QUERY_STORE = OFF
GO
USE [MiNubeTest]
GO
/****** Object:  User [admin]    Script Date: 06/06/2021 20:55:00 ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Actividad_Curso]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actividad_Curso](
	[idActividadCurso] [int] IDENTITY(1,1) NOT NULL,
	[idActividad] [int] NOT NULL,
	[idCurso] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idActividadCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Actividades]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actividades](
	[idActividad] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](50) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idActividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comentarios]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentarios](
	[idComentario] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[idContenido] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idComentario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comunicados]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comunicados](
	[idComunicado] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[descripcion] [varchar](1000) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idComunicado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contenido_Materia_Curso]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contenido_Materia_Curso](
	[idContenidoMateriaCurso] [int] IDENTITY(1,1) NOT NULL,
	[idContenido] [int] NOT NULL,
	[idMateriaCurso] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idContenidoMateriaCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contenidos]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contenidos](
	[idContenido] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](50) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[unidad] [int] NOT NULL,
	[video] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[idContenido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso_Docente]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso_Docente](
	[idCursoDocente] [int] IDENTITY(1,1) NOT NULL,
	[idCurso] [int] NOT NULL,
	[idDocente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCursoDocente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursos]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursos](
	[idCurso] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiante_Curso]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiante_Curso](
	[idEstudianteCurso] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[idCurso] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEstudianteCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evento]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evento](
	[idEvento] [int] IDENTITY(1,1) NOT NULL,
	[titl] [varchar](50) NOT NULL,
	[start] [datetime] NOT NULL,
	[idCurso] [int] NOT NULL,
	[url] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Historiales]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historiales](
	[idHistorial] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[idCurso] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idHistorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Informes]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Informes](
	[idInforme] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](1000) NOT NULL,
	[idCurso] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idInforme] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Institucion_Curso]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institucion_Curso](
	[idInstitucionCurso] [int] IDENTITY(1,1) NOT NULL,
	[idInstitucion] [int] NOT NULL,
	[idCurso] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idInstitucionCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Institucion_Docente]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institucion_Docente](
	[idInstitucionDocente] [int] IDENTITY(1,1) NOT NULL,
	[idInstitucion] [int] NOT NULL,
	[idDocente] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idInstitucionDocente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Institucion_Estudiante]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institucion_Estudiante](
	[idInstitucionEstudiante] [int] IDENTITY(1,1) NOT NULL,
	[idInstitucion] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idInstitucionEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Institucion_Materia]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institucion_Materia](
	[idInstitucionMateria] [int] IDENTITY(1,1) NOT NULL,
	[idInstitucion] [int] NOT NULL,
	[idMateria] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idInstitucionMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Institucion_Tutor]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Institucion_Tutor](
	[idInstitucionTutor] [int] IDENTITY(1,1) NOT NULL,
	[idInstitucion] [int] NOT NULL,
	[idTutor] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idInstitucionTutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instituciones]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instituciones](
	[idInstitucion] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idInstitucion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia_Curso]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia_Curso](
	[idMateriaCurso] [int] IDENTITY(1,1) NOT NULL,
	[idMateria] [int] NOT NULL,
	[idCurso] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idMateriaCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia_Docente]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia_Docente](
	[idMateriaDocente] [int] IDENTITY(1,1) NOT NULL,
	[idMateria] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idMateriaDocente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materias]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materias](
	[idMateria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idMateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nivel_Educativo_Estudiante]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nivel_Educativo_Estudiante](
	[idNivelEducativoEstudiante] [int] IDENTITY(1,1) NOT NULL,
	[idNivelEducativo] [int] NOT NULL,
	[idUsuarioEstudiante] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idNivelEducativoEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NivelEducativo]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NivelEducativo](
	[idNivelEducativo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idNivelEducativo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[idPermiso] [int] IDENTITY(1,1) NOT NULL,
	[operacion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[idPersona] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[telefono] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tutor_Estudiante]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tutor_Estudiante](
	[idTutorEstudiante] [int] IDENTITY(1,1) NOT NULL,
	[idUsuarioTutor] [int] NOT NULL,
	[idUsuarioEstudiante] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTutorEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Rol]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Rol](
	[idUsuarioRol] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[idRol] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuarioRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 06/06/2021 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[idPersona] [int] NULL,
	[usuario_nombre] [varchar](50) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[fecha_creacion] [datetime] NULL,
	[fecha_modificacion] [datetime] NULL,
	[fecha_eliminacion_logico] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Contenidos] ON 

INSERT [dbo].[Contenidos] ([idContenido], [titulo], [descripcion], [unidad], [video]) VALUES (1, N'Video', N'Video Matematoca', 1, N'video.mp4')
INSERT [dbo].[Contenidos] ([idContenido], [titulo], [descripcion], [unidad], [video]) VALUES (6, N'Video', N'Video Lengua', 2, N'video.mp4')
SET IDENTITY_INSERT [dbo].[Contenidos] OFF
GO
SET IDENTITY_INSERT [dbo].[Curso_Docente] ON 

INSERT [dbo].[Curso_Docente] ([idCursoDocente], [idCurso], [idDocente]) VALUES (1, 1, 29)
INSERT [dbo].[Curso_Docente] ([idCursoDocente], [idCurso], [idDocente]) VALUES (2, 2, 29)
INSERT [dbo].[Curso_Docente] ([idCursoDocente], [idCurso], [idDocente]) VALUES (3, 3, 36)
INSERT [dbo].[Curso_Docente] ([idCursoDocente], [idCurso], [idDocente]) VALUES (4, 4, 36)
SET IDENTITY_INSERT [dbo].[Curso_Docente] OFF
GO
SET IDENTITY_INSERT [dbo].[Cursos] ON 

INSERT [dbo].[Cursos] ([idCurso], [nombre]) VALUES (1, N'1A')
INSERT [dbo].[Cursos] ([idCurso], [nombre]) VALUES (2, N'2A')
INSERT [dbo].[Cursos] ([idCurso], [nombre]) VALUES (3, N'1B')
INSERT [dbo].[Cursos] ([idCurso], [nombre]) VALUES (4, N'2B')
INSERT [dbo].[Cursos] ([idCurso], [nombre]) VALUES (9, N'3A')
SET IDENTITY_INSERT [dbo].[Cursos] OFF
GO
SET IDENTITY_INSERT [dbo].[Estudiante_Curso] ON 

INSERT [dbo].[Estudiante_Curso] ([idEstudianteCurso], [idUsuario], [idCurso]) VALUES (1, 32, 1)
INSERT [dbo].[Estudiante_Curso] ([idEstudianteCurso], [idUsuario], [idCurso]) VALUES (2, 5, 1)
INSERT [dbo].[Estudiante_Curso] ([idEstudianteCurso], [idUsuario], [idCurso]) VALUES (3, 6, 1)
INSERT [dbo].[Estudiante_Curso] ([idEstudianteCurso], [idUsuario], [idCurso]) VALUES (4, 7, 1)
INSERT [dbo].[Estudiante_Curso] ([idEstudianteCurso], [idUsuario], [idCurso]) VALUES (5, 13, 3)
INSERT [dbo].[Estudiante_Curso] ([idEstudianteCurso], [idUsuario], [idCurso]) VALUES (7, 14, 3)
SET IDENTITY_INSERT [dbo].[Estudiante_Curso] OFF
GO
SET IDENTITY_INSERT [dbo].[Evento] ON 

INSERT [dbo].[Evento] ([idEvento], [titl], [start], [idCurso], [url]) VALUES (16, N'Reunión de Padres', CAST(N'2021-06-22T09:45:00.000' AS DateTime), 1, N'#')
INSERT [dbo].[Evento] ([idEvento], [titl], [start], [idCurso], [url]) VALUES (17, N'Evaluación', CAST(N'2021-06-22T09:45:00.000' AS DateTime), 1, N'#')
INSERT [dbo].[Evento] ([idEvento], [titl], [start], [idCurso], [url]) VALUES (18, N'Finales', CAST(N'2021-06-25T15:00:00.000' AS DateTime), 1, NULL)
INSERT [dbo].[Evento] ([idEvento], [titl], [start], [idCurso], [url]) VALUES (21, N'Clase en Vivo', CAST(N'2021-06-08T09:20:00.000' AS DateTime), 1, N'https://meet.jit.si/matematicas')
INSERT [dbo].[Evento] ([idEvento], [titl], [start], [idCurso], [url]) VALUES (22, N'Gimnasia', CAST(N'2021-06-09T10:30:00.000' AS DateTime), 1, N'#')
SET IDENTITY_INSERT [dbo].[Evento] OFF
GO
SET IDENTITY_INSERT [dbo].[Institucion_Curso] ON 

INSERT [dbo].[Institucion_Curso] ([idInstitucionCurso], [idInstitucion], [idCurso]) VALUES (2, 1, 1)
INSERT [dbo].[Institucion_Curso] ([idInstitucionCurso], [idInstitucion], [idCurso]) VALUES (3, 1, 2)
INSERT [dbo].[Institucion_Curso] ([idInstitucionCurso], [idInstitucion], [idCurso]) VALUES (4, 2, 3)
INSERT [dbo].[Institucion_Curso] ([idInstitucionCurso], [idInstitucion], [idCurso]) VALUES (5, 2, 4)
SET IDENTITY_INSERT [dbo].[Institucion_Curso] OFF
GO
SET IDENTITY_INSERT [dbo].[Institucion_Docente] ON 

INSERT [dbo].[Institucion_Docente] ([idInstitucionDocente], [idInstitucion], [idDocente]) VALUES (1, 1, 29)
INSERT [dbo].[Institucion_Docente] ([idInstitucionDocente], [idInstitucion], [idDocente]) VALUES (2, 2, 29)
INSERT [dbo].[Institucion_Docente] ([idInstitucionDocente], [idInstitucion], [idDocente]) VALUES (3, 2, 36)
INSERT [dbo].[Institucion_Docente] ([idInstitucionDocente], [idInstitucion], [idDocente]) VALUES (4, 1, 45)
SET IDENTITY_INSERT [dbo].[Institucion_Docente] OFF
GO
SET IDENTITY_INSERT [dbo].[Institucion_Estudiante] ON 

INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (1, 1, 32)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (2, 4, 33)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (3, 6, 34)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (4, 2, 36)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (5, 2, 38)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (6, 6, 39)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (7, 2, 40)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (8, 2, 41)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (9, 2, 42)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (10, 1, 43)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (11, 4, 44)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (12, 2, 46)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (13, 6, 47)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (14, 2, 48)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (15, 2, 49)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (16, 2, 50)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (17, 2, 51)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (18, 2, 52)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (19, 2, 53)
INSERT [dbo].[Institucion_Estudiante] ([idInstitucionEstudiante], [idInstitucion], [idUsuario]) VALUES (20, 1, 54)
SET IDENTITY_INSERT [dbo].[Institucion_Estudiante] OFF
GO
SET IDENTITY_INSERT [dbo].[Instituciones] ON 

INSERT [dbo].[Instituciones] ([idInstitucion], [nombre], [direccion], [email]) VALUES (1, N'Escuela 145', N'Av.Guemes 110', N'145@gmail.com')
INSERT [dbo].[Instituciones] ([idInstitucion], [nombre], [direccion], [email]) VALUES (2, N'Escuela 8', N'Alvarez 754', N'8@gmail.com')
INSERT [dbo].[Instituciones] ([idInstitucion], [nombre], [direccion], [email]) VALUES (4, N'Escuela Nocturna', N'Juncal 11', N'nocturna@gmail.com')
INSERT [dbo].[Instituciones] ([idInstitucion], [nombre], [direccion], [email]) VALUES (6, N'Unlam', N'Varela 2354', N'unlam@unlam.edu.ar')
INSERT [dbo].[Instituciones] ([idInstitucion], [nombre], [direccion], [email]) VALUES (7, N'Escuela Etchegaray', N'Av. Luro 1234', N'etchegaray@gmail.com')
SET IDENTITY_INSERT [dbo].[Instituciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Materias] ON 

INSERT [dbo].[Materias] ([idMateria], [nombre]) VALUES (1, N'Matematica')
INSERT [dbo].[Materias] ([idMateria], [nombre]) VALUES (2, N'Lengua')
INSERT [dbo].[Materias] ([idMateria], [nombre]) VALUES (3, N'Ciencias Sociales')
INSERT [dbo].[Materias] ([idMateria], [nombre]) VALUES (4, N'Ciencias Naturales')
SET IDENTITY_INSERT [dbo].[Materias] OFF
GO
SET IDENTITY_INSERT [dbo].[Personas] ON 

INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (1, N'Admin', N'Admin', N'admin@gmail.com', 11111111)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (2, N'Sebastian', N'Basconcelo', N'sebastian.basco@outlook.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (3, N'Ambar', N'Basconcelo', N'ambarbasconcelo11@gmail.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (4, N'Carlos', N'Morales', N'carlos@gmail.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (5, N'Ana', N'maria', N'ana@gmail.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (6, N'dasd', N'sdasd', N'asdasd@gmail.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (7, N'Momo', N'Vargas', N'momo@gmail.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (8, N'mama', N'amama', N'amama@sdasda,cn', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (9, N'adasdas', N'asdasd', N'1asdasdq@asdasd.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (10, N'fafafa', N'fafafa', N'fafafa@gmail.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (11, N'Amama', N'aamama', N'sdasda@asdasd.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (12, N'Estudiante', N'Estudiante', N'estudiante@gmail.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (13, N'Cesar', N'Segovia', N'cesar@gmail.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (14, N'Calos rod', N'Rod', N'rod@gmail.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (15, N'j', N'j', N'j@j.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (16, N'k', N'k', N'k@k.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (17, N'e', N'e', N'e@r11', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (18, N'fernando', N'Delarua', N'delaria@gamil.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (19, N'Sebastian', N'Basconcelo', N'el_basco@hotmail.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (20, N'M', N'G', N'mg@email.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (21, N'FF', N'FF', N'FF@FF.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (22, N'2', N'2', N'2@g.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (23, N'victor', N'hugo', N'vh@com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (24, N'dadadad', N'asdadad', N'asdadad@com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (25, N'Sebastina', N'ASDadsqwe', N'dadasdqweasdq@alksdlkqwlknl', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (26, N'gagaga', N'gagagaga', N'agagagaga@aaa', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (27, N'jkjhhkh', N'jhkjhkjh', N'kjhkhkj@kjlkjlk', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (28, N'Docente', N'Docente', N'docente@gmail.com', 0)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (29, N'Diego', N'Maradona', N'diego@maradona.com.ar', 43434343)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (30, N'tutor', N'tutor', N'tutor@gmail.com', 44564534)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (31, N'Sergio', N'Olarticoechea', N'ola@gmail.com', 11223344)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (32, N'Alberso', N'Fernandez', N'alber@gmail.com', 11223344)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (33, N'Gerardo', N'Sofovicj', N'g@g.com', 11223344)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (34, N'Ana', N'Katerina', N'kata@gmail.com', 12131415)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (35, N'Geronimo', N'Rulli', N'rulli@gmail.com', 11223311)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (36, N'Tutot', N'tuto', N'tuto@gmail.com', 112233)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (37, N'sebastian', N'Ayala', N'ayala@gmail.com', 112233)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (38, N'Carlos', N'molinari', N'basco799@hotmail.com', 1168201037)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (39, N'Estudiante', N'Estudiante', N'estudiante2@gmail.com', 112233)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (40, N'Estudiante', N'Estudiante', N'estudiante3@gmail.com', 11223344)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (41, N'Estudiante', N'Estudiante', N'estudiante4@gmail.com', 11223344)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (42, N'Federico', N'Manriquez', N'fede@gmail.com', 1123)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (43, N'dasdada', N'asdasdad', N'asdasdadadada@gmail.com', 111111)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (44, N'Doña', N'Catalina', N'di@gmail.com', 112233)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (45, N'Kata', N'Kata', N'kata22@gmail.com', 1122334)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (46, N'Kata', N'Kata', N'kata33@gmail.com', 1122334)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (47, N'Samantha', N'Farjat', N'sam@gmail.com', 44653344)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (48, N'Kata', N'Kata', N'kata2@gmail.com', 1122334)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (49, N'Marcos', N'Cabral', N'marcoscabral@gmail.com', 112233)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (50, N'Julieta', N'Iracheta', N'julieta@gmail.com', 44871122)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (51, N'Ambar', N'Josefina', N'josefina@gmaail.com', 112234)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (52, N'Jorge', N'Gonzalez', N'jg@hotmail.com', 11223344)
INSERT [dbo].[Personas] ([idPersona], [nombre], [apellido], [email], [telefono]) VALUES (53, N'Juan', N'Pablo', N'jp@outlook.com', 112234)
SET IDENTITY_INSERT [dbo].[Personas] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([idRol], [descripcion]) VALUES (1, N'Estudiante')
INSERT [dbo].[Roles] ([idRol], [descripcion]) VALUES (2, N'Docente')
INSERT [dbo].[Roles] ([idRol], [descripcion]) VALUES (3, N'Tutor')
INSERT [dbo].[Roles] ([idRol], [descripcion]) VALUES (4, N'Admin')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario_Rol] ON 

INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (1, 1, 4)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (2, 3, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (3, 4, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (4, 5, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (5, 6, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (6, 7, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (7, 8, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (8, 9, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (9, 10, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (10, 11, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (11, 12, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (12, 13, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (13, 14, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (14, 15, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (15, 16, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (16, 17, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (17, 18, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (18, 19, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (19, 20, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (20, 21, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (21, 22, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (22, 23, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (23, 24, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (24, 25, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (25, 26, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (26, 27, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (27, 28, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (28, 29, 2)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (29, 30, 2)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (30, 31, 3)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (31, 32, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (32, 33, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (33, 34, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (34, 35, 2)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (35, 36, 2)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (36, 37, 3)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (37, 38, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (38, 39, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (39, 40, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (40, 41, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (41, 42, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (42, 43, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (43, 44, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (44, 45, 2)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (45, 46, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (46, 47, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (47, 48, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (48, 49, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (49, 50, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (50, 51, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (51, 52, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (52, 53, 1)
INSERT [dbo].[Usuario_Rol] ([idUsuarioRol], [idUsuario], [idRol]) VALUES (53, 54, 1)
SET IDENTITY_INSERT [dbo].[Usuario_Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (1, 1, N'Admin', N'$2b$10$AVDyfmT22arGYxbNeoEGz./uSVIdlOTcH5Ezni5aST7LW/U2UP4v2', NULL, NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (3, 2, N'sebastian.basco@outlook.com', N'1234', NULL, NULL, CAST(N'2021-05-30T17:21:57.057' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (4, 3, N'ambarbasconcelo11@gmail.com', N'1234', NULL, NULL, CAST(N'2021-06-04T20:03:35.077' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (5, 4, N'carlos@gmail.com', N'1234', NULL, NULL, CAST(N'2021-06-04T22:00:57.250' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (6, 5, N'ana@gmail.com', N'1234', NULL, NULL, CAST(N'2021-05-30T17:26:31.147' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (7, 6, N'asdasd@gmail.com', N'1234', NULL, NULL, CAST(N'2021-06-04T22:35:39.773' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (8, 7, N'momo@gmail.com', N'1234', NULL, NULL, CAST(N'2021-06-04T22:09:31.163' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (9, 8, N'amama@sdasda,cn', N'1234', NULL, NULL, CAST(N'2021-06-04T22:35:54.150' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (10, 9, N'1asdasdq@asdasd.com', N'1234', NULL, NULL, CAST(N'2021-06-04T22:15:50.907' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (11, 10, N'fafafa@gmail.com', N'1234', NULL, NULL, CAST(N'2021-06-04T22:36:06.420' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (12, 11, N'sdasda@asdasd.com', N'1234', NULL, NULL, CAST(N'2021-06-04T22:15:59.790' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (13, 12, N'estudiante@gmail.com', N'1234', NULL, NULL, CAST(N'2021-06-04T22:38:14.020' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (14, 13, N'cesar@gmail.com', N'1234', NULL, NULL, CAST(N'2021-06-04T22:38:21.880' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (15, 14, N'rod@gmail.com', N'1234', NULL, NULL, CAST(N'2021-06-04T22:42:10.047' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (16, 15, N'j@j.com', N'1234', NULL, NULL, CAST(N'2021-06-04T22:42:43.120' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (17, 16, N'k@k.com', N'1234', NULL, NULL, CAST(N'2021-06-04T22:42:51.807' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (18, 17, N'e@r11', N'1234', NULL, NULL, CAST(N'2021-06-04T22:56:13.847' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (19, 18, N'delaria@gamil.com', N'1234', NULL, NULL, CAST(N'2021-06-04T22:57:01.740' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (20, 19, N'el_basco@hotmail.com', N'1234', NULL, NULL, CAST(N'2021-06-04T23:00:37.843' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (21, 20, N'mg@email.com', N'1234', NULL, NULL, CAST(N'2021-06-04T23:01:22.143' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (22, 21, N'FF@FF.com', N'1234', NULL, NULL, CAST(N'2021-06-04T23:11:10.933' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (23, 22, N'2@g.com', N'1234', NULL, NULL, CAST(N'2021-06-04T23:11:19.017' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (24, 23, N'vh@com', N'1234', NULL, NULL, CAST(N'2021-06-04T23:11:32.483' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (25, 24, N'asdadad@com', N'1234', NULL, NULL, CAST(N'2021-06-05T11:13:37.403' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (26, 25, N'dadasdqweasdq@alksdlkqwlknl', N'1234', NULL, NULL, CAST(N'2021-06-05T11:14:25.760' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (27, 26, N'agagagaga@aaa', N'1234', NULL, NULL, CAST(N'2021-06-05T11:18:45.220' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (28, 27, N'kjhkhkj@kjlkjlk', N'1234', NULL, NULL, CAST(N'2021-06-05T11:18:52.163' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (29, 28, N'docente@gmail.com', N'$2b$10$AVDyfmT22arGYxbNeoEGz./uSVIdlOTcH5Ezni5aST7LW/U2UP4v2', NULL, NULL, CAST(N'2021-06-05T11:18:58.133' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (30, 29, N'diego@maradona.com.ar', N'1234', NULL, NULL, CAST(N'2021-06-05T11:19:24.660' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (31, 30, N'tutor@gmail.com', N'1234', NULL, NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (32, 31, N'ola@gmail.com', N'1234', NULL, NULL, CAST(N'2021-06-05T11:20:03.857' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (33, 32, N'alber@gmail.com', N'1111', NULL, NULL, CAST(N'2021-06-05T11:20:11.623' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (34, 33, N'g@g.com', N'1111', NULL, NULL, CAST(N'2021-06-05T11:20:19.860' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (35, 34, N'kata@gmail.com', N'1111', NULL, NULL, CAST(N'2021-06-05T12:55:16.097' AS DateTime))
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (36, 35, N'rulli@gmail.com', N'$2b$10$AVDyfmT22arGYxbNeoEGz./uSVIdlOTcH5Ezni5aST7LW/U2UP4v2', CAST(N'2021-06-02T18:51:56.607' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (37, 36, N'tuto@gmail.com', N'$2b$10$sCldAzja2RkXNCOc4UY0V.ULdA.Yj6Wur9ojEv0AAaCZgAOTh/Rve', CAST(N'2021-06-03T19:00:26.667' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (38, 37, N'ayala@gmail.com', N'$2b$10$UBQPCY1Iec/MnS3pJHWjEe7v3jnfykSbrnj3Fmz0P6QXsGy6mLNde', CAST(N'2021-06-04T22:00:45.220' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (39, 38, N'basco799@hotmail.com', N'$2b$10$knL6SH7ZInb41vN.WbuZY.ZiaYLjhxx78u7fBYTJ50n/NeVw1xFPy', CAST(N'2021-06-04T22:06:41.040' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (40, 39, N'estudiante2@gmail.com', N'$2b$10$x04.jEpzQynXKmegH8K4FuDwzibjm/XUd3d6oCKuj9Fd42DoOkfrW', CAST(N'2021-06-04T22:21:33.380' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (41, 40, N'estudiante3@gmail.com', N'$2b$10$Sg4CjTH5.dxWqbNG9k7GluuyziEGy4VB4w9V1QWQSBCSAKDHw/oVC', CAST(N'2021-06-04T22:23:27.577' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (42, 41, N'estudiante4@gmail.com', N'$2b$10$0bu5HMZQqaimsj8ynww.2.qRDnuqgjyLGZWKqRx4pUGy951FBd/rC', CAST(N'2021-06-04T22:24:16.197' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (43, 42, N'fede@gmail.com', N'$2b$10$DjZYR6aL1TLfBpvBjj.n/e2H3f3gaaRpcGmWNiWnJPyIHeNFx0sUy', CAST(N'2021-06-04T22:58:37.323' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (44, 43, N'asdasdadadada@gmail.com', N'$2b$10$7eZnfTUoY/KLKVi8QxSDdewhB6tyYADsyzWUtZFqyGncd7hdWkwZW', CAST(N'2021-06-04T23:01:39.667' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (45, 44, N'di@gmail.com', N'$2b$10$jum0XtrhOBWi8llRtswVeuMeoPLi5ARm0rt5SidepVanD7TuNDWsq', CAST(N'2021-06-04T23:12:09.630' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (46, 45, N'kata22@gmail.com', N'$2b$10$jynZH9hwv.VZ2DrDQ3/Xvu0FiQ3y8quVXUbyHhul9XPqx3AVHzY3m', CAST(N'2021-06-05T11:27:12.777' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (47, 46, N'kata33@gmail.com', N'$2b$10$HtmfdmgsR08qtgeNCQ6R.eViB3LAJyLviJ3WzA0t8OdRDSnq9hq.6', CAST(N'2021-06-05T11:41:00.260' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (48, 47, N'sam@gmail.com', N'$2b$10$hHkr15I.3LG4RSd.hRbOuOpDco3TNs5QtaAvwO4ZjRdDKC9.x3p02', CAST(N'2021-06-05T11:42:26.327' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (49, 48, N'kata2@gmail.com', N'$2b$10$wEkZvqEJ.BcQ/APDao0U9OJjJU6r3nw/BU0IDh.B1Z9skE8cZPjai', CAST(N'2021-06-05T12:55:38.300' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (50, 49, N'marcoscabral@gmail.com', N'$2b$10$.xNxjJNDQo1.DAcdgBKDqeNzSTkEgBkNoWRO/RCIDJ/4R1SaIH7qW', CAST(N'2021-06-05T15:31:20.640' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (51, 50, N'julieta@gmail.com', N'$2b$10$bXRJw075qlghzhZHQNeJm.jwvsq0Iajv.Jyub.Gjw7SNwbrhaXObS', CAST(N'2021-06-05T15:37:41.193' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (52, 51, N'josefina@gmaail.com', N'$2b$10$i/TrpeiCQY/FcyCO5zuUauOBMZLzxTf74DDmzSJsashDxlV6cXU/m', CAST(N'2021-06-05T15:42:54.397' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (53, 52, N'jg@hotmail.com', N'$2b$10$AKDP0lr37RrjW4KcqWCqV.n7H5YLIFXNdbPBioQNF3kJAnk.V6K8W', CAST(N'2021-06-05T15:45:44.993' AS DateTime), NULL, NULL)
INSERT [dbo].[Usuarios] ([idUsuario], [idPersona], [usuario_nombre], [password], [fecha_creacion], [fecha_modificacion], [fecha_eliminacion_logico]) VALUES (54, 53, N'jp@outlook.com', N'$2b$10$nmYjE.fWFYS29BJpu1FDtu2esbMF.EzxitVKbHKdfw7/VIwQ6PxPu', CAST(N'2021-06-05T15:47:52.940' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Actividad_Curso]  WITH CHECK ADD  CONSTRAINT [fk_Actividad_Curso] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Cursos] ([idCurso])
GO
ALTER TABLE [dbo].[Actividad_Curso] CHECK CONSTRAINT [fk_Actividad_Curso]
GO
ALTER TABLE [dbo].[Actividad_Curso]  WITH CHECK ADD  CONSTRAINT [fk_Curso_Actividad] FOREIGN KEY([idActividad])
REFERENCES [dbo].[Actividades] ([idActividad])
GO
ALTER TABLE [dbo].[Actividad_Curso] CHECK CONSTRAINT [fk_Curso_Actividad]
GO
ALTER TABLE [dbo].[Comentarios]  WITH CHECK ADD  CONSTRAINT [fk_Comentario_Contenido] FOREIGN KEY([idContenido])
REFERENCES [dbo].[Contenidos] ([idContenido])
GO
ALTER TABLE [dbo].[Comentarios] CHECK CONSTRAINT [fk_Comentario_Contenido]
GO
ALTER TABLE [dbo].[Comunicados]  WITH CHECK ADD  CONSTRAINT [fk_Usuario_Comunicado] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Comunicados] CHECK CONSTRAINT [fk_Usuario_Comunicado]
GO
ALTER TABLE [dbo].[Contenido_Materia_Curso]  WITH CHECK ADD  CONSTRAINT [fk_Contenido_Materia_Curso] FOREIGN KEY([idContenido])
REFERENCES [dbo].[Contenidos] ([idContenido])
GO
ALTER TABLE [dbo].[Contenido_Materia_Curso] CHECK CONSTRAINT [fk_Contenido_Materia_Curso]
GO
ALTER TABLE [dbo].[Contenido_Materia_Curso]  WITH CHECK ADD  CONSTRAINT [fk_Materia_Curso_Contenido] FOREIGN KEY([idMateriaCurso])
REFERENCES [dbo].[Materia_Curso] ([idMateriaCurso])
GO
ALTER TABLE [dbo].[Contenido_Materia_Curso] CHECK CONSTRAINT [fk_Materia_Curso_Contenido]
GO
ALTER TABLE [dbo].[Curso_Docente]  WITH CHECK ADD  CONSTRAINT [fk_Curso_Docente] FOREIGN KEY([idDocente])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Curso_Docente] CHECK CONSTRAINT [fk_Curso_Docente]
GO
ALTER TABLE [dbo].[Curso_Docente]  WITH CHECK ADD  CONSTRAINT [fk_Docente_Curso] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Cursos] ([idCurso])
GO
ALTER TABLE [dbo].[Curso_Docente] CHECK CONSTRAINT [fk_Docente_Curso]
GO
ALTER TABLE [dbo].[Estudiante_Curso]  WITH CHECK ADD  CONSTRAINT [fk_Curso_Estudiante] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Cursos] ([idCurso])
GO
ALTER TABLE [dbo].[Estudiante_Curso] CHECK CONSTRAINT [fk_Curso_Estudiante]
GO
ALTER TABLE [dbo].[Estudiante_Curso]  WITH CHECK ADD  CONSTRAINT [fk_Estudiante_Curso] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Estudiante_Curso] CHECK CONSTRAINT [fk_Estudiante_Curso]
GO
ALTER TABLE [dbo].[Evento]  WITH CHECK ADD  CONSTRAINT [fk_Evento_Curso] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Cursos] ([idCurso])
GO
ALTER TABLE [dbo].[Evento] CHECK CONSTRAINT [fk_Evento_Curso]
GO
ALTER TABLE [dbo].[Historiales]  WITH CHECK ADD  CONSTRAINT [fk_Curso_Historial] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Cursos] ([idCurso])
GO
ALTER TABLE [dbo].[Historiales] CHECK CONSTRAINT [fk_Curso_Historial]
GO
ALTER TABLE [dbo].[Historiales]  WITH CHECK ADD  CONSTRAINT [fk_Usuario_Historial] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Historiales] CHECK CONSTRAINT [fk_Usuario_Historial]
GO
ALTER TABLE [dbo].[Informes]  WITH CHECK ADD  CONSTRAINT [fk_Curso_Informe] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Cursos] ([idCurso])
GO
ALTER TABLE [dbo].[Informes] CHECK CONSTRAINT [fk_Curso_Informe]
GO
ALTER TABLE [dbo].[Informes]  WITH CHECK ADD  CONSTRAINT [fk_Usuario_Informe] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Informes] CHECK CONSTRAINT [fk_Usuario_Informe]
GO
ALTER TABLE [dbo].[Institucion_Curso]  WITH CHECK ADD  CONSTRAINT [fk_Institucion_Curso] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Cursos] ([idCurso])
GO
ALTER TABLE [dbo].[Institucion_Curso] CHECK CONSTRAINT [fk_Institucion_Curso]
GO
ALTER TABLE [dbo].[Institucion_Curso]  WITH CHECK ADD  CONSTRAINT [fk_Institucion4] FOREIGN KEY([idInstitucion])
REFERENCES [dbo].[Instituciones] ([idInstitucion])
GO
ALTER TABLE [dbo].[Institucion_Curso] CHECK CONSTRAINT [fk_Institucion4]
GO
ALTER TABLE [dbo].[Institucion_Docente]  WITH CHECK ADD  CONSTRAINT [fk_Institucion_Docente] FOREIGN KEY([idDocente])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Institucion_Docente] CHECK CONSTRAINT [fk_Institucion_Docente]
GO
ALTER TABLE [dbo].[Institucion_Docente]  WITH CHECK ADD  CONSTRAINT [fk_Institucion2] FOREIGN KEY([idInstitucion])
REFERENCES [dbo].[Instituciones] ([idInstitucion])
GO
ALTER TABLE [dbo].[Institucion_Docente] CHECK CONSTRAINT [fk_Institucion2]
GO
ALTER TABLE [dbo].[Institucion_Estudiante]  WITH CHECK ADD  CONSTRAINT [fk_Estudiante_Institucion] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Institucion_Estudiante] CHECK CONSTRAINT [fk_Estudiante_Institucion]
GO
ALTER TABLE [dbo].[Institucion_Estudiante]  WITH CHECK ADD  CONSTRAINT [fk_Institucion_Estudiante] FOREIGN KEY([idInstitucion])
REFERENCES [dbo].[Instituciones] ([idInstitucion])
GO
ALTER TABLE [dbo].[Institucion_Estudiante] CHECK CONSTRAINT [fk_Institucion_Estudiante]
GO
ALTER TABLE [dbo].[Institucion_Materia]  WITH CHECK ADD  CONSTRAINT [fk_Institucion_Materia] FOREIGN KEY([idMateria])
REFERENCES [dbo].[Materias] ([idMateria])
GO
ALTER TABLE [dbo].[Institucion_Materia] CHECK CONSTRAINT [fk_Institucion_Materia]
GO
ALTER TABLE [dbo].[Institucion_Materia]  WITH CHECK ADD  CONSTRAINT [fk_Institucion3] FOREIGN KEY([idInstitucion])
REFERENCES [dbo].[Instituciones] ([idInstitucion])
GO
ALTER TABLE [dbo].[Institucion_Materia] CHECK CONSTRAINT [fk_Institucion3]
GO
ALTER TABLE [dbo].[Institucion_Tutor]  WITH CHECK ADD  CONSTRAINT [fk_Institucion] FOREIGN KEY([idInstitucion])
REFERENCES [dbo].[Instituciones] ([idInstitucion])
GO
ALTER TABLE [dbo].[Institucion_Tutor] CHECK CONSTRAINT [fk_Institucion]
GO
ALTER TABLE [dbo].[Institucion_Tutor]  WITH CHECK ADD  CONSTRAINT [fk_Institucion_Tutor] FOREIGN KEY([idTutor])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Institucion_Tutor] CHECK CONSTRAINT [fk_Institucion_Tutor]
GO
ALTER TABLE [dbo].[Materia_Curso]  WITH CHECK ADD  CONSTRAINT [fk_Curso_Materia] FOREIGN KEY([idMateria])
REFERENCES [dbo].[Materias] ([idMateria])
GO
ALTER TABLE [dbo].[Materia_Curso] CHECK CONSTRAINT [fk_Curso_Materia]
GO
ALTER TABLE [dbo].[Materia_Curso]  WITH CHECK ADD  CONSTRAINT [fk_Materia_Curso] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Cursos] ([idCurso])
GO
ALTER TABLE [dbo].[Materia_Curso] CHECK CONSTRAINT [fk_Materia_Curso]
GO
ALTER TABLE [dbo].[Materia_Docente]  WITH CHECK ADD  CONSTRAINT [fk_Docente_Materia] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Materia_Docente] CHECK CONSTRAINT [fk_Docente_Materia]
GO
ALTER TABLE [dbo].[Materia_Docente]  WITH CHECK ADD  CONSTRAINT [fk_Materia_Docente] FOREIGN KEY([idMateria])
REFERENCES [dbo].[Materias] ([idMateria])
GO
ALTER TABLE [dbo].[Materia_Docente] CHECK CONSTRAINT [fk_Materia_Docente]
GO
ALTER TABLE [dbo].[Nivel_Educativo_Estudiante]  WITH CHECK ADD  CONSTRAINT [fk_Nivel_Educativo_Estudiante] FOREIGN KEY([idNivelEducativo])
REFERENCES [dbo].[NivelEducativo] ([idNivelEducativo])
GO
ALTER TABLE [dbo].[Nivel_Educativo_Estudiante] CHECK CONSTRAINT [fk_Nivel_Educativo_Estudiante]
GO
ALTER TABLE [dbo].[Nivel_Educativo_Estudiante]  WITH CHECK ADD  CONSTRAINT [fk_Usuario_Estudiante2] FOREIGN KEY([idUsuarioEstudiante])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Nivel_Educativo_Estudiante] CHECK CONSTRAINT [fk_Usuario_Estudiante2]
GO
ALTER TABLE [dbo].[Tutor_Estudiante]  WITH CHECK ADD  CONSTRAINT [fk_Usuario_Estudiante] FOREIGN KEY([idUsuarioEstudiante])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Tutor_Estudiante] CHECK CONSTRAINT [fk_Usuario_Estudiante]
GO
ALTER TABLE [dbo].[Tutor_Estudiante]  WITH CHECK ADD  CONSTRAINT [fk_Usuario_Tutor] FOREIGN KEY([idUsuarioTutor])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Tutor_Estudiante] CHECK CONSTRAINT [fk_Usuario_Tutor]
GO
ALTER TABLE [dbo].[Usuario_Rol]  WITH CHECK ADD  CONSTRAINT [fk_Rol] FOREIGN KEY([idRol])
REFERENCES [dbo].[Roles] ([idRol])
GO
ALTER TABLE [dbo].[Usuario_Rol] CHECK CONSTRAINT [fk_Rol]
GO
ALTER TABLE [dbo].[Usuario_Rol]  WITH CHECK ADD  CONSTRAINT [fk_Usuario] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Usuario_Rol] CHECK CONSTRAINT [fk_Usuario]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [fk_Persona] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Personas] ([idPersona])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [fk_Persona]
GO
USE [master]
GO
ALTER DATABASE [MiNubeTest] SET  READ_WRITE 
GO
