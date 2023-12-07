CREATE DATABASE ModuloDesktop

USE ModuloDesktop

DROP DATABASE ModuloDesktop
CREATE TABLE Usuarios
(
    idUsuario INT PRIMARY KEY IDENTITY,
    email VARCHAR(320) NOT NULL UNIQUE,
    senha VARCHAR(100) NOT NULL, 
    foto VARBINARY(MAX) NOT NULL, 
	apelido VARCHAR(20) NOT NULL,
    timeFavorito VARCHAR(50) NOT NULL, 
    corFavorita VARCHAR(50) NOT NULL, 
    nascimento DATE NOT NULL,
    idIndicado INT NOT NULL,
    dataCadastro DATE NOT NULL,
    dataConvite DATE NOT NULL,
    recebeNotificacao BIT NOT NULL
);
;

CREATE TABLE Notificacao
(
id INT PRIMARY KEY IDENTITY,
dataHora DATE NOT NULL,
notificacao VARCHAR(100) NOT NULL,
idUsuario INT FOREIGN KEY REFERENCES Usuarios(idUsuario),
[status] BIT NOT NULL
)
CREATE TABLE Pergunta
(
idPergunta INT PRIMARY KEY IDENTITY,
pergunta VARCHAR(100) NOT NULL,
campo TEXT NOT NULL,
tipo VARCHAR(50) NOT NULL 
)

CREATE TABLE PerguntaUsuario 
(
idPerguntaUsuario INT PRIMARY KEY IDENTITY,
idPergunta INT FOREIGN KEY REFERENCES Pergunta(idPergunta),
idUsuario INT FOREIGN KEY REFERENCES Usuarios(idUsuario)
)

CREATE TABLE Competicao
(
idCompeticao INT PRIMARY KEY IDENTITY,
ano DATE NOT NULL,
[local] VARCHAR(256) NOT NULL
)

CREATE TABLE Selecao
(
idSelecao INT PRIMARY KEY IDENTITY,
nome VARCHAR(100) NOT NULL,
bandeira VARBINARY(MAX) NOT NULL
)

CREATE TABLE Jogos
(
idJogo INT PRIMARY KEY IDENTITY,
[data] DATE NOT NULL,
idCompeticao INT FOREIGN KEY REFERENCES Competicao(idCompeticao) NOT NULL,
selecao1 INT FOREIGN KEY REFERENCES Selecao(idSelecao) NOT NULL,
placar1 INT NOT NULL,
penalt1 BIT NOT NULL,
selecao2 INT FOREIGN KEY REFERENCES Selecao(idSelecao) NOT NULL,
placar2 INT NOT NULL,
penalt2  BIT NOT NULL
)

