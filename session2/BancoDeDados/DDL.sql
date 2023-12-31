--DDL DATA DEFINITOIN LANGUAGE

CREATE DATABASE Session2
Go

USE [Session2]
GO

---------------------------------CREATE TABLE RANKING-------------------------------------------

CREATE TABLE Ranking
(
IdRanking INT PRIMARY KEY IDENTITY,
Nome VARCHAR(100) NOT NULL ,
Pontos INT NULL
)

---------------------------------------------------------------------------------------------------



/****** Object:  Table [dbo].[cidade]    Script Date: 17/10/2023 10:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cidade](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Cidade] [nvarchar](255) NULL,
	[estadoId] [int] NULL,
 CONSTRAINT [PK_cidade] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estado]    Script Date: 17/10/2023 10:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [nvarchar](255) NULL,
	[Sigla] [nvarchar](255) NULL,
	[RegiaoId] [int] NULL,
 CONSTRAINT [PK_estado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estoque]    Script Date: 17/10/2023 10:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estoque](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[produtoId] [int] NULL,
	[lojaId] [int] NULL,
	[quantidade] [float] NULL,
 CONSTRAINT [PK_estoque] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[evento]    Script Date: 17/10/2023 10:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[evento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[evento] [nvarchar](255) NULL,
	[tipoEventoId] [int] NULL,
 CONSTRAINT [PK_evento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loja]    Script Date: 17/10/2023 10:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loja](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[loja] [nvarchar](255) NULL,
 CONSTRAINT [PK_loja] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[participante]    Script Date: 17/10/2023 10:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[participante](
	[id] [int] NOT NULL,
	[nome] [nvarchar](255) NULL,
	[idade] [float] NULL,
	[cidadeId] [int] NULL,
	[genero] [nvarchar](255) NULL,
 CONSTRAINT [PK_participante] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[participantes_evento]    Script Date: 17/10/2023 10:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[participantes_evento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[eventoId] [int] NULL,
	[participanteId] [int] NULL,
 CONSTRAINT [PK_participantes_evento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[produto]    Script Date: 17/10/2023 10:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[produto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[produto] [nvarchar](255) NULL,
	[valor] [float] NULL,
 CONSTRAINT [PK_produto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[regiao]    Script Date: 17/10/2023 10:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[regiao](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[regiao] [nvarchar](255) NULL,
 CONSTRAINT [PK_regiao] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_evento]    Script Date: 17/10/2023 10:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_evento](
	[id] [int] NOT NULL,
	[tipoevento] [nvarchar](255) NULL,
 CONSTRAINT [PK_tipo_evento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[vendas]    Script Date: 17/10/2023 10:06:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[vendas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[participanteId] [int] NULL,
	[produtoId] [int] NULL,
	[quantidade] [float] NULL,
	[eventoId] [int] NULL,
	[lojaId] [int] NULL,
	[data] [datetime] NULL,
	[hora] [datetime] NULL,
	[transa��o] [float] NULL,
 CONSTRAINT [PK_vendas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO