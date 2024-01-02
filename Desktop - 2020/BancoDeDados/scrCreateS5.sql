USE [master]
GO
/****** Object:  Database [Sessao5]     ******/
CREATE DATABASE [Sessao5]
GO
USE [Sessao5]
GO
/****** Object:  Table [dbo].[Comentario]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Comentario] [varchar](100) NULL,
	[DataHoraComentario] [datetime] NULL,
	[IdJogo] [int] NULL,
	[IdUsuario] [int] NULL,
 CONSTRAINT [PK_Comentario] PRIMARY KEY CLUSTERED 
([Id] ASC )) 
GO
/****** Object:  Table [dbo].[Jogadores]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jogadores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[NumeroCamisa] [int] NOT NULL,
	[SelecaoId] [int] NULL,
	[PosicaoId] [int] NULL,
PRIMARY KEY CLUSTERED 
([Id] ASC)) 
GO
/****** Object:  Table [dbo].[Jogos]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jogos](
	[Id] [int] NOT NULL,
	[SelecaoCasaId] [int] NULL,
	[PlacarCasa] [int] NULL,
	[SelecaoVisitanteId] [int] NULL,
	[PlacarVisitante] [int] NULL,
	[Data] [datetime] NULL,
	[RodadaId] [int] NULL,
 CONSTRAINT [PK__Jogos__3214EC070BF97C52] PRIMARY KEY CLUSTERED 
([Id] ASC)) 
GO
/****** Object:  Table [dbo].[Notificacoes]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notificacoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NOT NULL,
	[Descricao] [text] NOT NULL,
	[DataHoraCadastro] [datetime] NOT NULL,
	[DataHoraEnvio] [datetime] NULL,
	[Importancia] [varchar](255) NOT NULL,
	[SelecaoId] [int] NULL,
PRIMARY KEY CLUSTERED 
([Id] ASC)
) 

GO
/****** Object:  Table [dbo].[NotificacoesUsuarios]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificacoesUsuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[UsuarioId] [int] NULL,
	[NotificacaoId] [int] NULL,
PRIMARY KEY CLUSTERED 
([Id] ASC)) 

GO
/****** Object:  Table [dbo].[Posicoes]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posicoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
([Id] ASC))

GO
/****** Object:  Table [dbo].[Rodadas]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rodadas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataInicio] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
([Id] ASC))
GO

/****** Object:  Table [dbo].[Selecoes]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Selecoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
([Id] ASC))
 
GO
/****** Object:  Table [dbo].[Usuarios]     ******/
SET ANSI_NULLS ON

GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Senha] [varchar](255) NOT NULL,
	[Nascimento] [date] NOT NULL,
	[Foto] [image] NULL,
	[Sexo] [char](1) NOT NULL,
	[TimeFavoritoId] [int] NULL,
	[perfil] [char](1) NULL,
PRIMARY KEY CLUSTERED 
([Id] ASC))
GO