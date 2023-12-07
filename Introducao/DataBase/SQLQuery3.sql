SELECT TOP (1000) [idUsuario]
      ,[email]
      ,[senha]
      ,[foto]
      ,[apelido]
      ,[timeFavorito]
      ,[corFavorita]
      ,[nascimento]
      ,[idIndicado]
      ,[dataCadastro]
      ,[dataConvite]
      ,[recebeNotificacao]
  FROM [ModuloDesktop].[dbo].[Usuarios]




  ALTER TABLE Usuarios
  ALTER COLUMN foto VARBINARY(MAX) 
  -- Criando uma nova coluna VARBINARY(MAX)
ALTER TABLE Usuarios
ADD NovaFoto VARBINARY(MAX);

-- Atualizando a nova coluna com os dados convertidos
UPDATE Usuarios
SET NovaFoto = CONVERT(VARBINARY(MAX), CAST(foto AS VARCHAR(MAX)));

-- Removendo a coluna antiga
ALTER TABLE Usuarios
DROP COLUMN foto;


-- Renomeando a nova coluna para o nome original
EXEC sp_rename 'Usuarios.NovaFoto', 'foto', 'COLUMN';
