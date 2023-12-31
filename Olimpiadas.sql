USE [master]
GO
/****** Object:  Database [olimpiadas]    Script Date: 18/08/2023 11:23:22:a. m. ******/
CREATE DATABASE [olimpiadas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'olimpiadas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\olimpiadas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'olimpiadas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\olimpiadas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [olimpiadas] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [olimpiadas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [olimpiadas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [olimpiadas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [olimpiadas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [olimpiadas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [olimpiadas] SET ARITHABORT OFF 
GO
ALTER DATABASE [olimpiadas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [olimpiadas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [olimpiadas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [olimpiadas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [olimpiadas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [olimpiadas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [olimpiadas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [olimpiadas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [olimpiadas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [olimpiadas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [olimpiadas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [olimpiadas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [olimpiadas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [olimpiadas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [olimpiadas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [olimpiadas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [olimpiadas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [olimpiadas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [olimpiadas] SET  MULTI_USER 
GO
ALTER DATABASE [olimpiadas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [olimpiadas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [olimpiadas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [olimpiadas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [olimpiadas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [olimpiadas] SET QUERY_STORE = OFF
GO
USE [olimpiadas]
GO
/****** Object:  Table [dbo].[areaLocalizacion]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[areaLocalizacion](
	[idAreaLocalizacion] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
	[area] [decimal](18, 2) NULL,
	[idEstado] [int] NULL,
 CONSTRAINT [PK_areaLocalizacion] PRIMARY KEY CLUSTERED 
(
	[idAreaLocalizacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[areasDesignadas]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[areasDesignadas](
	[idAreaDesignada] [int] NOT NULL,
	[idTipoComplejo] [int] NULL,
	[idDeporte] [int] NULL,
	[idAreaLocalizacion] [int] NULL,
	[organizador] [varchar](100) NULL,
	[idEstado] [int] NULL,
 CONSTRAINT [PK__areas__750ECEA4B0F3794D] PRIMARY KEY CLUSTERED 
(
	[idAreaDesignada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comisarioEvento]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comisarioEvento](
	[idComisarioEvento] [int] NOT NULL,
	[idComisario] [int] NULL,
	[idEvento] [int] NULL,
	[idTipoComisario] [int] NULL,
	[idEstado] [int] NULL,
 CONSTRAINT [PK_comisarioEvento] PRIMARY KEY CLUSTERED 
(
	[idComisarioEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comisarios]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comisarios](
	[idComisario] [int] NOT NULL,
	[nombre] [varchar](100) NULL,
	[idEstado] [int] NULL,
 CONSTRAINT [PK_comisarios] PRIMARY KEY CLUSTERED 
(
	[idComisario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[complejoDeportivo]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[complejoDeportivo](
	[idComplejoDeportivo] [int] NOT NULL,
	[complejoDeportivoDes] [varchar](50) NULL,
	[idSede] [int] NULL,
	[idTipoComplejoDeportivo] [int] NULL,
	[idEstado] [int] NULL,
 CONSTRAINT [PK_complejoDeportivo] PRIMARY KEY CLUSTERED 
(
	[idComplejoDeportivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[deportes]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[deportes](
	[idDeporte] [int] NOT NULL,
	[descripcion] [varchar](100) NULL,
	[idEstado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idDeporte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[equipamientos]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[equipamientos](
	[idEquipamiento] [int] NOT NULL,
	[equipamientoDes] [varchar](100) NULL,
	[idEstado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idEquipamiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[equipamientosEvento]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[equipamientosEvento](
	[idEquipamientosEvento] [int] NOT NULL,
	[idEquipamiento] [int] NULL,
	[idEvento] [int] NULL,
 CONSTRAINT [PK_equipamientosEvento] PRIMARY KEY CLUSTERED 
(
	[idEquipamientosEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estados]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estados](
	[idEstado] [int] NOT NULL,
	[estadoDes] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eventos]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eventos](
	[idEvento] [int] NOT NULL,
	[idPresupuestoComplejoDeportivo] [int] NULL,
	[idTipoEvento] [int] NULL,
	[descripcion] [varchar](100) NULL,
	[fecha] [datetime] NULL,
	[duracion] [int] NULL,
	[idEstado] [int] NULL,
 CONSTRAINT [PK__evento__3213E83FE497A86D] PRIMARY KEY CLUSTERED 
(
	[idEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[participantes]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[participantes](
	[idParticipante] [int] NOT NULL,
	[nombre] [varchar](100) NULL,
	[edad] [int] NULL,
	[idEstado] [int] NULL,
 CONSTRAINT [PK_participante] PRIMARY KEY CLUSTERED 
(
	[idParticipante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[participantesEvento]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[participantesEvento](
	[idParticipanteEvento] [int] NOT NULL,
	[idEvento] [int] NULL,
	[idParticipante] [int] NULL,
	[idEstado] [int] NULL,
 CONSTRAINT [PK_participantesEvento] PRIMARY KEY CLUSTERED 
(
	[idParticipanteEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[presupuestoComplejoDeportivo]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[presupuestoComplejoDeportivo](
	[idPresupuestoComplejoDeportivo] [int] NOT NULL,
	[idComplejoDeportivo] [int] NULL,
	[presupuesto] [decimal](18, 2) NULL,
	[idEstado] [int] NULL,
 CONSTRAINT [PK_presupuestoComplejoDeportivo] PRIMARY KEY CLUSTERED 
(
	[idPresupuestoComplejoDeportivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sedes]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sedes](
	[idSede] [int] NOT NULL,
	[sedeDes] [varchar](100) NULL,
	[idEstado] [int] NULL,
 CONSTRAINT [PK__sedes__3213E83F1D91B123] PRIMARY KEY CLUSTERED 
(
	[idSede] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoComisarios]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoComisarios](
	[idTipoComisario] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
	[idEstado] [int] NULL,
 CONSTRAINT [PK_organizador] PRIMARY KEY CLUSTERED 
(
	[idTipoComisario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoComplejosDeportivos]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoComplejosDeportivos](
	[idTipoComplejoDeportivo] [int] NOT NULL,
	[tipoComplejoDeportivoDes] [varchar](100) NULL,
	[idEstado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoComplejoDeportivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoEvento]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoEvento](
	[idTipoEvento] [int] NOT NULL,
	[descripcion] [varchar](50) NULL,
	[idEstado] [int] NULL,
 CONSTRAINT [PK_tipoEvento] PRIMARY KEY CLUSTERED 
(
	[idTipoEvento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[usuario] [varchar](20) NOT NULL,
	[nombre] [varchar](100) NULL,
	[contrasenia] [varchar](100) NULL,
	[idEstado] [int] NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[areaLocalizacion] ([idAreaLocalizacion], [descripcion], [area], [idEstado]) VALUES (1, N'Centro', CAST(200.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[areaLocalizacion] ([idAreaLocalizacion], [descripcion], [area], [idEstado]) VALUES (2, N'Esquina', CAST(300.00 AS Decimal(18, 2)), NULL)
GO
INSERT [dbo].[areasDesignadas] ([idAreaDesignada], [idTipoComplejo], [idDeporte], [idAreaLocalizacion], [organizador], [idEstado]) VALUES (1, 2, 1, 1, N'Juan Perez', NULL)
GO
INSERT [dbo].[complejoDeportivo] ([idComplejoDeportivo], [complejoDeportivoDes], [idSede], [idTipoComplejoDeportivo], [idEstado]) VALUES (1, N'Estadio San Borja', 1, 1, 1)
INSERT [dbo].[complejoDeportivo] ([idComplejoDeportivo], [complejoDeportivoDes], [idSede], [idTipoComplejoDeportivo], [idEstado]) VALUES (2, N'Coliseo San Luis', 2, 2, 1)
GO
INSERT [dbo].[deportes] ([idDeporte], [descripcion], [idEstado]) VALUES (1, N'Tenis', 1)
INSERT [dbo].[deportes] ([idDeporte], [descripcion], [idEstado]) VALUES (2, N'Atletismo', 1)
INSERT [dbo].[deportes] ([idDeporte], [descripcion], [idEstado]) VALUES (3, N'Salto Alto', 1)
INSERT [dbo].[deportes] ([idDeporte], [descripcion], [idEstado]) VALUES (4, N'100 metros plano', 1)
INSERT [dbo].[deportes] ([idDeporte], [descripcion], [idEstado]) VALUES (5, N'Gimnasia', 1)
GO
INSERT [dbo].[equipamientos] ([idEquipamiento], [equipamientoDes], [idEstado]) VALUES (1, N'Arcos', 1)
INSERT [dbo].[equipamientos] ([idEquipamiento], [equipamientoDes], [idEstado]) VALUES (2, N'Barras paralelas', 1)
INSERT [dbo].[equipamientos] ([idEquipamiento], [equipamientoDes], [idEstado]) VALUES (3, N'Pertigas', 1)
GO
INSERT [dbo].[estados] ([idEstado], [estadoDes]) VALUES (1, N'Activo')
INSERT [dbo].[estados] ([idEstado], [estadoDes]) VALUES (2, N'Inactivo')
GO
INSERT [dbo].[eventos] ([idEvento], [idPresupuestoComplejoDeportivo], [idTipoEvento], [descripcion], [fecha], [duracion], [idEstado]) VALUES (1, 1, 1, N'Carreras en estadio', CAST(N'2023-10-20T00:00:00.000' AS DateTime), 2, NULL)
INSERT [dbo].[eventos] ([idEvento], [idPresupuestoComplejoDeportivo], [idTipoEvento], [descripcion], [fecha], [duracion], [idEstado]) VALUES (2, 1, 2, N'Mantenimiento correctivo', CAST(N'2023-10-21T00:00:00.000' AS DateTime), 1, NULL)
GO
INSERT [dbo].[presupuestoComplejoDeportivo] ([idPresupuestoComplejoDeportivo], [idComplejoDeportivo], [presupuesto], [idEstado]) VALUES (1, 1, CAST(1000.00 AS Decimal(18, 2)), NULL)
GO
INSERT [dbo].[sedes] ([idSede], [sedeDes], [idEstado]) VALUES (1, N'San Borja', 1)
INSERT [dbo].[sedes] ([idSede], [sedeDes], [idEstado]) VALUES (2, N'San Luis', 1)
GO
INSERT [dbo].[tipoComisarios] ([idTipoComisario], [descripcion], [idEstado]) VALUES (1, N'Juez', NULL)
INSERT [dbo].[tipoComisarios] ([idTipoComisario], [descripcion], [idEstado]) VALUES (2, N'Observador', NULL)
GO
INSERT [dbo].[tipoComplejosDeportivos] ([idTipoComplejoDeportivo], [tipoComplejoDeportivoDes], [idEstado]) VALUES (1, N'Deporte unico', 1)
INSERT [dbo].[tipoComplejosDeportivos] ([idTipoComplejoDeportivo], [tipoComplejoDeportivoDes], [idEstado]) VALUES (2, N'Polideportivo', 1)
GO
INSERT [dbo].[tipoEvento] ([idTipoEvento], [descripcion], [idEstado]) VALUES (1, N'Evento', NULL)
INSERT [dbo].[tipoEvento] ([idTipoEvento], [descripcion], [idEstado]) VALUES (2, N'Mantenimiento', NULL)
GO
INSERT [dbo].[usuarios] ([usuario], [nombre], [contrasenia], [idEstado]) VALUES (N'DEMO', NULL, N'6xXfMIZo21DRm8i2wM/2lA==', 1)
GO
ALTER TABLE [dbo].[areasDesignadas]  WITH CHECK ADD  CONSTRAINT [FK_areasDesignadas_areaLocalizacion] FOREIGN KEY([idAreaLocalizacion])
REFERENCES [dbo].[areaLocalizacion] ([idAreaLocalizacion])
GO
ALTER TABLE [dbo].[areasDesignadas] CHECK CONSTRAINT [FK_areasDesignadas_areaLocalizacion]
GO
ALTER TABLE [dbo].[areasDesignadas]  WITH CHECK ADD  CONSTRAINT [FK_areasDesignadas_deportes] FOREIGN KEY([idDeporte])
REFERENCES [dbo].[deportes] ([idDeporte])
GO
ALTER TABLE [dbo].[areasDesignadas] CHECK CONSTRAINT [FK_areasDesignadas_deportes]
GO
ALTER TABLE [dbo].[areasDesignadas]  WITH CHECK ADD  CONSTRAINT [FK_areasDesignadas_tipoComplejosDeportivos] FOREIGN KEY([idTipoComplejo])
REFERENCES [dbo].[tipoComplejosDeportivos] ([idTipoComplejoDeportivo])
GO
ALTER TABLE [dbo].[areasDesignadas] CHECK CONSTRAINT [FK_areasDesignadas_tipoComplejosDeportivos]
GO
ALTER TABLE [dbo].[comisarioEvento]  WITH CHECK ADD  CONSTRAINT [FK_comisarioEvento_comisarios] FOREIGN KEY([idComisario])
REFERENCES [dbo].[comisarios] ([idComisario])
GO
ALTER TABLE [dbo].[comisarioEvento] CHECK CONSTRAINT [FK_comisarioEvento_comisarios]
GO
ALTER TABLE [dbo].[comisarioEvento]  WITH CHECK ADD  CONSTRAINT [FK_comisarioEvento_eventos] FOREIGN KEY([idEvento])
REFERENCES [dbo].[eventos] ([idEvento])
GO
ALTER TABLE [dbo].[comisarioEvento] CHECK CONSTRAINT [FK_comisarioEvento_eventos]
GO
ALTER TABLE [dbo].[comisarioEvento]  WITH CHECK ADD  CONSTRAINT [FK_comisarioEvento_tipoComisarios] FOREIGN KEY([idTipoComisario])
REFERENCES [dbo].[tipoComisarios] ([idTipoComisario])
GO
ALTER TABLE [dbo].[comisarioEvento] CHECK CONSTRAINT [FK_comisarioEvento_tipoComisarios]
GO
ALTER TABLE [dbo].[complejoDeportivo]  WITH CHECK ADD  CONSTRAINT [FK_complejoDeportivo_sedes] FOREIGN KEY([idSede])
REFERENCES [dbo].[sedes] ([idSede])
GO
ALTER TABLE [dbo].[complejoDeportivo] CHECK CONSTRAINT [FK_complejoDeportivo_sedes]
GO
ALTER TABLE [dbo].[complejoDeportivo]  WITH CHECK ADD  CONSTRAINT [FK_complejoDeportivo_tipoComplejosDeportivos] FOREIGN KEY([idTipoComplejoDeportivo])
REFERENCES [dbo].[tipoComplejosDeportivos] ([idTipoComplejoDeportivo])
GO
ALTER TABLE [dbo].[complejoDeportivo] CHECK CONSTRAINT [FK_complejoDeportivo_tipoComplejosDeportivos]
GO
ALTER TABLE [dbo].[equipamientosEvento]  WITH CHECK ADD  CONSTRAINT [FK_equipamientosEvento_equipamientos] FOREIGN KEY([idEquipamiento])
REFERENCES [dbo].[equipamientos] ([idEquipamiento])
GO
ALTER TABLE [dbo].[equipamientosEvento] CHECK CONSTRAINT [FK_equipamientosEvento_equipamientos]
GO
ALTER TABLE [dbo].[equipamientosEvento]  WITH CHECK ADD  CONSTRAINT [FK_equipamientosEvento_eventos] FOREIGN KEY([idEvento])
REFERENCES [dbo].[eventos] ([idEvento])
GO
ALTER TABLE [dbo].[equipamientosEvento] CHECK CONSTRAINT [FK_equipamientosEvento_eventos]
GO
ALTER TABLE [dbo].[eventos]  WITH CHECK ADD  CONSTRAINT [FK_eventos_presupuestoComplejoDeportivo] FOREIGN KEY([idPresupuestoComplejoDeportivo])
REFERENCES [dbo].[presupuestoComplejoDeportivo] ([idPresupuestoComplejoDeportivo])
GO
ALTER TABLE [dbo].[eventos] CHECK CONSTRAINT [FK_eventos_presupuestoComplejoDeportivo]
GO
ALTER TABLE [dbo].[eventos]  WITH CHECK ADD  CONSTRAINT [FK_eventos_tipoEvento] FOREIGN KEY([idTipoEvento])
REFERENCES [dbo].[tipoEvento] ([idTipoEvento])
GO
ALTER TABLE [dbo].[eventos] CHECK CONSTRAINT [FK_eventos_tipoEvento]
GO
ALTER TABLE [dbo].[participantesEvento]  WITH CHECK ADD  CONSTRAINT [FK_participantesEvento_eventos] FOREIGN KEY([idEvento])
REFERENCES [dbo].[eventos] ([idEvento])
GO
ALTER TABLE [dbo].[participantesEvento] CHECK CONSTRAINT [FK_participantesEvento_eventos]
GO
ALTER TABLE [dbo].[participantesEvento]  WITH CHECK ADD  CONSTRAINT [FK_participantesEvento_participantes] FOREIGN KEY([idParticipante])
REFERENCES [dbo].[participantes] ([idParticipante])
GO
ALTER TABLE [dbo].[participantesEvento] CHECK CONSTRAINT [FK_participantesEvento_participantes]
GO
ALTER TABLE [dbo].[presupuestoComplejoDeportivo]  WITH CHECK ADD  CONSTRAINT [FK_presupuestoComplejoDeportivo_complejoDeportivo] FOREIGN KEY([idComplejoDeportivo])
REFERENCES [dbo].[complejoDeportivo] ([idComplejoDeportivo])
GO
ALTER TABLE [dbo].[presupuestoComplejoDeportivo] CHECK CONSTRAINT [FK_presupuestoComplejoDeportivo_complejoDeportivo]
GO
/****** Object:  StoredProcedure [dbo].[DeleteComplejoDeportivo]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[DeleteComplejoDeportivo]
@id int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM complejoDeportivo WHERE idComplejoDeportivo=@id;

	EXEC ListaComplejoDeportivo;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSedes]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteSedes]
@id int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM sedes WHERE idSede=@id;

	EXEC ListaSedes;
END
GO
/****** Object:  StoredProcedure [dbo].[ListaComplejoDeportivo]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListaComplejoDeportivo]
AS
BEGIN
	SET NOCOUNT ON;

	select a.*,b.sedeDes,c.tipoComplejoDeportivoDes,d.estadoDes from complejoDeportivo (NOLOCK) a
	INNER JOIN sedes (NOLOCK) b ON b.idSede=a.idSede
	INNER JOIN tipoComplejosDeportivos (NOLOCK) c ON c.idTipoComplejoDeportivo=a.idTipoComplejoDeportivo
	INNER JOIN estados (NOLOCK) d ON d.idEstado=a.idEstado
END
GO
/****** Object:  StoredProcedure [dbo].[ListaEquipamientos]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListaEquipamientos]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT a.*,b.estadoDes FROM equipamientos (NOLOCK) a
	INNER JOIN estados (NOLOCK) b ON b.idEstado=a.idEstado
END
GO
/****** Object:  StoredProcedure [dbo].[ListaEstados]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[ListaEstados]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM estados (NOLOCK) 
END
GO
/****** Object:  StoredProcedure [dbo].[ListaSedes]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListaSedes]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT a.*,b.estadoDes FROM sedes (NOLOCK) a
	INNER JOIN estados (NOLOCK) b ON b.idEstado=a.idEstado
END
GO
/****** Object:  StoredProcedure [dbo].[ListaTipoComplejosDeportivos]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[ListaTipoComplejosDeportivos]
AS
BEGIN
	SET NOCOUNT ON;

	select a.*,b.estadoDes from tipoComplejosDeportivos (NOLOCK) a
	INNER JOIN estados (NOLOCK)b ON b.idEstado=a.idEstado
END
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Login]
@USU VARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM usuarios (NOLOCK) WHERE usuario = @USU
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateComplejoDeportivo]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[UpdateComplejoDeportivo]
@idComplejoDeportivo int,
@complejoDeportivoDes varchar(50),
@idSede int,
@idTipoComplejoDeportivo int,
@idEstado int
AS
BEGIN
	SET NOCOUNT ON;

	IF @idComplejoDeportivo = 0
	BEGIN
		INSERT INTO complejoDeportivo
		VALUES(
		(SELECT ISNULL(MAX(idComplejoDeportivo),0)+1 FROM complejoDeportivo),
		@complejoDeportivoDes,
		@idSede,
		@idTipoComplejoDeportivo,
		@idEstado);
	END ELSE
	BEGIN
		UPDATE complejoDeportivo
		SET 
		complejoDeportivoDes=@complejoDeportivoDes,
		idTipoComplejoDeportivo=@idTipoComplejoDeportivo,
		idEstado=@idEstado
		WHERE idComplejoDeportivo=@idComplejoDeportivo
	END

	Exec ListaComplejoDeportivo
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateSedes]    Script Date: 18/08/2023 11:23:23:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateSedes]
@id int,
@sede varchar(50),
@estado int
AS
BEGIN
	SET NOCOUNT ON;

	IF @id = 0 
	BEGIN
		INSERT INTO sedes
		VALUES ((SELECT ISNULL(MAX(idSede),0)+1 FROM sedes),@sede,@estado);
	END ELSE
	BEGIN
		UPDATE sedes
		SET sedeDes=@sede, idEstado=@estado
		WHERE idSede=@id;
	END

	EXEC ListaSedes;
END
GO
USE [master]
GO
ALTER DATABASE [olimpiadas] SET  READ_WRITE 
GO
