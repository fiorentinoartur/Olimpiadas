--DQL DATA QUERY LANGUAGE

USE Olimpiadas

--*************************************SIMPLES*******************************************


--1 Apresentar todos os clientes que estão sem dados no campo email

SELECT
* 
FROM
TbCliente 
WHERE 
email IS NULL OR email  = ''

--2 Mostrar o titulo em caixa alta, a quantidade de páginas e o ano de lançamento dos livros da editora 1 e 2

SELECT 
UPPER(TbTitulo.desTitulo),
TbTitulo.qtdPaginas, 
TbTitulo.DatLancamento 
FROM
TbTitulo
Where
TbTitulo.codEditora In (1,2)

/*--3 Mostrar todos os dados dos títulos das editoras 1 até 10, cujo nome tenha a palavra C#. 
Não apresentar os títulos que tenham quantidade de páginas inferior a 100.*/
SELECT 
*
FROM 
TbTitulo
WHERE
TbTitulo.codEditora BETWEEN 1 AND 10
AND TbTitulo.desTitulo LIKE '%C#%'
AND TbTitulo.qtdPaginas >= 100;--***********************************


/*--4 Mostrar os campos da tabela Funcionário alterando o rótulo do campo para Nome Funcionário, 
Endereço e Instituição. Somente apresentar os dados cujo cargo é 'Estagiário' e que tenham ddd 13*/

SELECT 
Tbfuncionario.nome AS [Nome Funcionário], 
Tbfuncionario.endereco AS [Endereço], 
Tbfuncionario.instituicao AS [Instituição]
FROM
Tbfuncionario
WHERE 
Tbfuncionario.cargo = 'Estagiária' 
AND
Tbfuncionario.telefone LIKE '13%'  --****************************



--5 Apresentar os livros lançados no mês de Janeiro (1) cujo preço esteja entre 50 e 100 
SELECT
TbTitulo.desTitulo 
FROM
TbTitulo
WHERE
MONTH(TbTitulo.DatLancamento) = 1
AND
TbTitulo.valPreco > 50 AND TbTitulo.valPreco  < 100; --*********************************

--6 Mostrar os titulos da editora 1 e 2 apresentando seu preço com 20% de acréscimo
SELECT
TbTitulo.desTitulo,
CAST(TbTitulo.valPreco * 1.20 AS DECIMAL(10,2)) AS [Preço com acrésimo 20%]
FROM
TbTitulo
WHERE
TbTitulo.codEditora IN (1,2)

--7 Mostrar a descrição do título e o dobro do valor do título na mesma coluna
SELECT 
CONCAT(TbTitulo.desTitulo, ' - Dobro do valor: ', TbTitulo.valPreco * 2) AS [Título]
FROM
TbTitulo

--8 Apresentar o nome do livro e quantos anos ele já foi lançado
SELECT
TbTitulo.desTitulo,
DATEDIFF(YEAR, TbTitulo.DatLancamento, GETDATE()) AS [Anos de Lançamento]
FROM
TbTitulo

/*--9 Mostrar o primeiro nome do livro e o ano de lançamento.
Se ano de lançamento for até 2000 escrever Fase 1, se for maior Fase 2*/
  SELECT
SUBSTRING(TbTitulo.desTitulo, 1, CHARINDEX(' ', TbTitulo.desTitulo  + ' ') - 1) AS [Primeiro Nome do Livro],
YEAR(TbTitulo.DatLancamento) AS [Ano de Lançamento],
CASE
WHEN YEAR(TbTitulo.DatLancamento) <= 2000 THEN 'Fase 1'
ELSE 'Fase 2'
END AS Fases
FROM
TbTitulo

--*************************************JOIN*******************************************


--11 Apresentar os dados do funcionário com os dados da estante que o mesmo é responsável
SELECT
Tbfuncionario. *, 
TbEstante. *
FROM
Tbfuncionario
JOIN
TbEstante ON Tbfuncionario.codFunc = TbEstante.codFuncionario

/*--12 Apresentar os dados do livro, mostrando também o nome do autor e da editora. 
Não apresentar os livros sem título e apresentar somente os livros da editora do estado de SP*/
SELECT
TbTitulo. *,
TbAutor.autor,
TbEditora.Editora
FROM
TbTitulo
JOIN TbAutor ON TbTitulo.codAutor = TbAutor.codautor
JOIN TbEditora ON TbTitulo.codEditora = TbEditora.codEditora
WHERE
TbTitulo.desTitulo  IS NOT NULL 
AND
TbEditora.Estado = 'SP'

/*--13 Apresentar o Nome do Livro, o Nome do Autor para os livros da categoria Administração.
Apresentar qtos anos o livro foi lançado e seu preço com um acréscimo de 15%.*/
SELECT 
TbTitulo.desTitulo,
TbAutor.autor,
DATEDIFF(YEAR,TbTitulo.DatLancamento,GETDATE()) AS [Anos de Lançamento],
CAST(TbTitulo.valPreco * 1.15 AS decimal(10,2)) AS [Preço com 15% +]
FROM
TbTitulo
JOIN TbAutor ON TbTitulo.codAutor = TbAutor.codautor
WHERE
TbTitulo.codCategoria = 1;

--14 Apresentar os dados do cliente e todas as datas que ele fez retirada de livro.
SELECT
TbCliente. *,
TbEmprestimo.datRetirada
FROM
TbCliente
JOIN TbEmprestimo on TbCliente.codCliente = TbEmprestimo.codCliente


/*--15 Apresentar: Nome do Cliente, Data de Retirada, Nome do Livro Emprestado.
Apresentar apenas os livros que ainda não foram devolvidos.*/
SELECT
TbCliente.Nome,
TbEmprestimo.datRetirada,
TbTitulo.desTitulo
FROM
TbCliente
JOIN TbEmprestimo ON TbCliente.codCliente = TbEmprestimo.codCliente
JOIN TbEmprestimoLivro ON TbEmprestimo.codEmprestimo = TbEmprestimoLivro.codEmprestimo
JOIN TbExemplar ON TbEmprestimoLivro.codExemplar = TbExemplar.codExemplar
JOIN TbTitulo ON TbExemplar.codTitulo = TbTitulo.codTitulo
WHERE 
TbEmprestimoLivro.datDevolucao IS NULL;

--16 Um cliente gostaria de ver todos os livros do autor Fábio Galuppo que o preço seja entre R$ 100,00 e R$ 150,00.
SELECT 
TbTitulo.desTitulo AS [Livros]
FROM
TbTitulo
WHERE
TbTitulo.codAutor = 1
AND
TbTitulo.valPreco > 100 AND TbTitulo.valPreco < 150

--17 Apresentar o nome dos livros emprestados no Mês Atual
SELECT 
TbTitulo.desTitulo AS Livros
FROM
TbTitulo 
JOIN TbExemplar ON TbTitulo.codTitulo = TbExemplar.codTitulo
JOIN TbEmprestimoLivro on TbEmprestimoLivro.codExemplar = TbExemplar.codExemplar
JOIN TbEmprestimo on TbEmprestimo.codEmprestimo = TbEmprestimoLivro.codEmprestimo
WHERE
MONTH(TbEmprestimo.datRetirada) = MONTH(GETDATE());

--18 Apresentar os dados dos funcionários que são estagiários. Mostrar o nome do funcionário responsável.
SELECT
Est. *,
Res.nome AS [Responsável]
FROM
Tbfuncionario AS Est
JOIN Tbfuncionario AS Res on Est.codResp = Res.codFunc

WHERE 
Est.cargo = 'Estagiária'

/*--19 Apresentar o Nome do funcionário e o nome de todos os livros que o mesmo é responsável.
Ordenar esta consulta por funcionário e por Livro.*/
SELECT
Tbfuncionario.nome,
TbTitulo.desTitulo
FROM
Tbfuncionario 
JOIN TbEmprestimo on Tbfuncionario.codFunc = TbEmprestimo.codFunc
JOIN TbEmprestimoLivro ON  TbEmprestimoLivro.codEmprestimo = TbEmprestimo.codEmprestimo
JOIN TbExemplar ON TbExemplar.codExemplar = TbEmprestimoLivro.codExemplar
JOIN TbTitulo ON TbTitulo.codTitulo = TbExemplar.codTitulo
ORDER BY
Tbfuncionario.nome, TbTitulo.desTitulo

/*--20 Apresentar as 10 primeiras letras do Nome do Autor, o nome da Editora em letra Maiúscula, 
a Data de Lançamento somando 2 meses, dos livros que tenha a palavra "Faça" no nome*/

SELECT TOP 10
LEFT(TbAutor.autor,10) AS Autor,
UPPER(TbEditora.Editora) AS Editora,
DATEADD(MONTH,2,TbTitulo.DatLancamento)AS [Lançamento + 2 meses]
FROM
TbAutor 
JOIN TbTitulo ON TbAutor.codautor = TbTitulo.codAutor
JOIN TbEditora ON TbEditora.codEditora = TbTitulo.codEditora
WHERE
TbTitulo.desTitulo LIKE '%Faça%';


--*************************************JOIN GROUP*******************************************


--21 Apresentar o Nome do Autor e a quantidade de livros que foram publicados entre 1990 e 2007

SELECT
TbAutor.autor,
COUNT(TbTitulo.codTitulo)
FROM
TbAutor 
JOIN TbTitulo ON TbAutor.codautor = TbTitulo.codAutor
WHERE
YEAR(TbTitulo.DatLancamento) BETWEEN 1990 AND 2007
GROUP BY
TbAutor.autor

/*--22 Apresentar o valor médio do livro por autor. Considerar para esta consulta apenas os livros
com quantidade de páginas maior ou igual a 100.*/

SELECT
TbAutor.autor,
AVG(TbTitulo.valPreco) [Valor Médio do Livro]
FROM
TbAutor
JOIN TbTitulo ON TbAutor.codautor = TbTitulo.codAutor
WHERE
TbTitulo.qtdPaginas >= 100
GROUP BY
TbAutor.autor;

--23 Apresentar o maior preço e o menor preço dos livros por Editora. Considerar apenas as Editoras do Estado do RJ e SP.
SELECT
TbEditora.Editora,
MAX(TbTitulo.valPreco),
MIN(TbTitulo.valPreco)
FROM
TbEditora
JOIN TbTitulo ON TbEditora.codEditora = TbTitulo.codEditora
WHERE
TbEditora.Estado IN ('SP','RJ')
GROUP BY 
TbEditora.Editora

--24 Apresentar o Nome do Livro, o Nome do Autor e a Quantidade de Exemplares de cada livro.
SELECT
TbTitulo.desTitulo,
TbAutor.autor,
COUNT(TbExemplar.codExemplar) [Qtd Exemplares]
FROM
TbTitulo
JOIN TbAutor ON TbAutor.codautor = TbTitulo.codAutor
JOIN TbExemplar ON TbTitulo.codTitulo = TbExemplar.codTitulo
GROUP BY
TbTitulo.desTitulo, TbAutor.autor

--25 Mostrar o último atendimento de cada funcionário.
SELECT
Tbfuncionario.nome,
MAX(TbEmprestimo.datRetirada) [Último atendimento]
FROM
Tbfuncionario
JOIN TbEmprestimo ON TbEmprestimo.codEmprestimo = Tbfuncionario.codFunc
GROUP BY 
Tbfuncionario.nome

--26 Mostrar a quantidade de livros emprestados para cada Cliente.
SELECT
TbCliente.Nome,
COUNT(TbEmprestimo.codCliente) [QtdLivrosEmprestados]
FROM
TbCliente
JOIN TbEmprestimo ON TbCliente.codCliente = TbEmprestimo.codCliente
GROUP BY
TbCliente.Nome

--27 Mostrar a quantidade de livros diferentes emprestados para cada Cliente.
SELECT
TbCliente.Nome,
COUNT(DISTINCT TbEmprestimo.codCliente) [QtdLivrosEmprestadosDif]
FROM
TbCliente
JOIN TbEmprestimo ON TbCliente.codCliente = TbEmprestimo.codCliente
GROUP BY
TbCliente.Nome

--28 Mostrar a quantidade de Livros por Editora. Não apresentar as editoras que tem menos que 5 livros.
SELECT
TbEditora.Editora,
COUNT(TbTitulo.codEditora) AS QtdLivros
FROM
TbEditora
JOIN TbTitulo ON TbEditora.codEditora = TbTitulo.codEditora
GROUP BY
TbEditora.Editora
HAVING
COUNT(TbTitulo.codEditora) >= 5

--29 Mostrar a quantidade de livros alugados por Mês. Restringir esta consulta para o ano de 2007.
SELECT
YEAR(TbEmprestimo.datRetirada) ANO,
MONTH(TbEmprestimo.datRetirada) AS MES,
COUNT(TbEmprestimo.codEmprestimo) QtdLivrosAlugados
FROM
TbEmprestimo
WHERE
YEAR(TbEmprestimo.datRetirada) = 2007
GROUP BY
YEAR(TbEmprestimo.datRetirada), MONTH(TbEmprestimo.datRetirada)

--30 Mostrar a quantidade Média de Páginas por Categoria. Não inserir na Consulta os livros que tem a palavra "Net"
SELECT
TbCategoria.categoria,
AVG(TbTitulo.qtdPaginas)
FROM
TbCategoria
JOIN TbTitulo ON TbTitulo.codCategoria = TbCategoria.codCategoria
WHERE
TbTitulo.desTitulo NOT LIKE '%Net%'
GROUP BY 
TbCategoria.categoria

--31 Mostrar a quantidade de livros em cada empréstimo. Não mostrar os emprestimos com multa.

SELECT
TbEmprestimoLivro.codEmprestimo,
COUNT(TbEmprestimoLivro.codEmprestimo) [QtdDeLivros]
FROM
TbEmprestimoLivro
WHERE
TbEmprestimoLivro.valMulta IS NULL OR TbEmprestimoLivro.valMulta = ' '
GROUP BY
TbEmprestimoLivro.codEmprestimo


--*************************************SUB SELECT*******************************************


--32 Apresentar os cliente que não fizeram retirada de livros
SELECT
Cliente.Nome
FROM
TbCliente  AS Cliente
LEFT JOIN 
(SELECT DISTINCT
codCliente
FROM
TbEmprestimo
)AS ClienteEmprestimo ON Cliente.codCliente = ClienteEmprestimo.codCliente
WHERE
ClienteEmprestimo.codCliente IS NULL;

--33 Livros cujo preço seja menor que a média do preço de todos os livros
SELECT
TbTitulo.desTitulo
FROM
TbTitulo
WHERE
TbTitulo.valPreco < (SELECT AVG(TbTitulo.valPreco) FROM TbTitulo)

--34 Apresentar Livros da editora do estado de SP, exceto da estante 1 e 2
SELECT
TbTitulo.desTitulo
FROM
TbTitulo
JOIN TbEditora ON TbTitulo.codEditora = TbEditora.codEditora
JOIN TbCategoria ON TbCategoria.codCategoria = TbTitulo.codCategoria
JOIN TbEstante ON TbEstante.codCategoria = TbCategoria.codCategoria
WHERE TbEditora.Estado = 'SP'
AND
TbEstante.codEstante NOT IN (1,2)
AND
TbTitulo.desTitulo IS NOT NULL;

--35 Livros retirados em 2007 e cujo atendimento foi realizado por uma estagiária
SELECT 
TbTitulo.desTitulo
FROM
TbTitulo
JOIN TbExemplar ON TbExemplar.codTitulo = TbTitulo.codTitulo
JOIN TbEmprestimoLivro ON TbEmprestimoLivro.codExemplar = TbExemplar.codExemplar
JOIN TbEmprestimo ON TbEmprestimo.codEmprestimo = TbEmprestimoLivro.codEmprestimo
JOIN Tbfuncionario ON Tbfuncionario.codFunc = TbEmprestimo.codFunc
WHERE
YEAR(TbEmprestimo.datRetirada) = 2007
AND 
Tbfuncionario.cargo = 'Estagiária'

--36 Autores das editoras de SP
SELECT DISTINCT
TbAutor.autor
FROM
TbAutor
JOIN TbTitulo ON TbTitulo.codAutor = TbAutor.codautor
JOIN TbEditora ON TbTitulo.codEditora = TbEditora.codEditora
WHERE
TbEditora.Estado = 'SP'

--37 Nome do autor que tem o maior preço
SELECT TOP 1
TbAutor.autor
FROM
TbAutor
JOIN TbTitulo ON TbTitulo.codAutor = TbAutor.codautor
ORDER BY
TbTitulo.valPreco DESC;

--38 Cidade onde mora o autor que tem o livro mais caro
SELECT TOP 1
TbAutor.endereco
FROM
TbAutor
JOIN TbTitulo ON TbTitulo.codAutor = TbAutor.codautor
ORDER BY
TbTitulo.valPreco DESC;

--39 Apresentar os títulos onde tem o valor maior que a metade do valor maior dos livros da editora do estado de São Paulo
SELECT 
TbTitulo.desTitulo
FROM
TbTitulo
JOIN TbEditora ON TbTitulo.codEditora = TbEditora.codEditora
WHERE
TbTitulo.valPreco >
(
SELECT 
MAX(TbTitulo.valPreco) / 2 
FROM 
TbTitulo JOIN TbEditora ON TbTitulo.codEditora = TbEditora.codEditora 
WHERE 
TbEditora.Estado = 'SP')


--***********************************SUB SELECT GROUP*********************************************


/*--40 Qtd de livros cadastrados por ano (não considerar nesta consulta os livros que se encontram nas estantes
cujo responsável não é estagiário)*/
SELECT 
YEAR(TbTitulo.DatLancamento) AS [Laçamento],
COUNT(TbTitulo.codTitulo) AS QtdLivros
FROM
TbTitulo
LEFT JOIN TbCategoria ON TbTitulo.codCategoria = TbCategoria.codCategoria
LEFT JOIN TbEstante ON TbEstante.codCategoria = TbCategoria.codCategoria
LEFT JOIN Tbfuncionario ON Tbfuncionario.codFunc = TbEstante.codFuncionario
WHERE
Tbfuncionario.cargo = 'Estagiária' --****************************************
GROUP BY
YEAR(TbTitulo.DatLancamento)

--41 Média de páginas por código de categoria, não considerar as editoras do Estado do RJ e apresentar somente quando a média for maior que 60
SELECT 
TbCategoria.codCategoria,
AVG(TbTitulo.qtdPaginas) AS MediaPag
FROM 
TbTitulo
JOIN TbCategoria ON TbTitulo.codCategoria  = TbCategoria.codCategoria
JOIN TbEditora ON TbTitulo.codEditora = TbEditora.codEditora
WHERE
TbEditora.Estado <> 'RJ'
GROUP BY
TbCategoria.codCategoria
HAVING
AVG(TbTitulo.qtdPaginas) > 60;

--42 Quantidade de Editoras por Estado que tem livros cadastrados nas categorias das estantes 2,3 e 4
SELECT
TbEditora.Estado,
COUNT(TbEditora.codEditora) AS LivrosCadastrados
FROM
TbEditora
JOIN TbTitulo ON TbEditora.codEditora = TbTitulo.codEditora
JOIN TbCategoria ON TbTitulo.codCategoria = TbCategoria.codCategoria
WHERE 
TbCategoria.codCategoria IN (2,3,4)
GROUP BY
TbEditora.Estado

/*--43 Qtd de exemplares cadastrados por código do título considerando apenas os livros
com preço menor que a média do preço dos livros da categoria Internet e Informática*/
SELECT 
TbTitulo.codTitulo,
SUM(TbExemplar.codExemplar) QtsExemplares
FROM
TbTitulo
JOIN TbExemplar ON TbExemplar.codTitulo = TbTitulo.codTitulo
JOIN TbCategoria ON TbTitulo.codCategoria = TbCategoria.codCategoria
WHERE
TbTitulo.valPreco < (SELECT AVG(TbTitulo.valPreco) FROM TbTitulo WHERE TbTitulo.codCategoria = TbCategoria.codCategoria)
AND TbCategoria.categoria IN ('Internet','Informática')
GROUP BY
TbTitulo.codTitulo


--***********************************UNION*********************************************


--44 Apresentar o titulo dos livros identificando os mesmos como Antigos (data lançamento < 2000) e Recentes (data lançamento <=2000)
SELECT
TbTitulo.desTitulo,
CASE
WHEN YEAR(TbTitulo.DatLancamento) < 2000 THEN'Antigos'
ELSE  'Recentes'
END AS Categoria
FROM
TbTitulo

/*--45 Nome do funcionário. Caso seja estagiário, apresentar o nome do Responsável e a instituição de ensino.
Caso seja Funcionário, identificar que ele é responsável e deixar o 3o. Campo vazio*/

SELECT
F.nome,
CASE
WHEN F.cargo = 'Estagiária' THEN R.nome
WHEN F.codResp IS NULL THEN 'Responsável'
ELSE ''
END AS [Responsável],
CASE
WHEN  F.cargo = 'Estagiária' THEN F.instituicao
ELSE ''
END AS InstituicaoEnsino
FROM
Tbfuncionario F
LEFT JOIN Tbfuncionario R ON F.codResp = R.codFunc;

--46 Apresentar o nome do cliente e a quantidade de livros retirados. Caso não tenha retirado nenhum livro, colocar 0.
SELECT
TbCliente.Nome,
ISNULL(COUNT(TbEmprestimo.codCliente), 0) AS QtdLivrosRetirado
FROM
TbCliente
LEFT JOIN TbEmprestimo ON TbCliente.codCliente = TbEmprestimo.codCliente
GROUP BY
TbCliente.Nome

--***********************************SELECT INTO*********************************************

--47  Transferir os dados dos títulos Expirados (ano lançamento < 2000) para uma tabela temporária

CREATE TABLE  TitulosExpirados
(
IdTituloExpirado INT PRIMARY KEY IDENTITY,
Titulo VARCHAR(256) UNIQUE NOT NULL,
AnoLancamento DATE NOT NULL,
Preco FLOAT NOT NULL,
Paginas INT NOT NULL
)
INSERT INTO TitulosExpirados(Titulo,AnoLancamento,Preco,Paginas)
SELECT 
TbTitulo.desTitulo, 
TbTitulo.DatLancamento,
TbTitulo.valPreco,
TbTitulo.qtdPaginas
FROM
TbTitulo
WHERE YEAR(TbTitulo.DatLancamento) < 2000;


--48 transferir os dados dos autores que tem mais que 1 publicação para uma tabela temporária


CREATE TABLE AutorTemporaria
(
IdAutorTemporaria INT PRIMARY KEY IDENTITY,
NomeAutor VARCHAR(256) NOT NULL UNIQUE,
Endereco VARCHAR(256) NOT NULL,
Telefone VARCHAR(50) NOT NULL,
QtdLivrosPublicados INT NOT NULL
)

INSERT INTO AutorTemporaria(NomeAutor,Endereco,Telefone,QtdLivrosPublicados)
SELECT
TbAutor.autor,
TbAutor.endereco,
TbAutor.telefone,
COUNT(TbTitulo.codAutor) AS QtdLivrosPublicados
FROM
TbAutor
JOIN TbTitulo ON TbTitulo.codAutor = TbAutor.codautor
GROUP BY TbAutor.endereco,TbAutor.autor,TbAutor.telefone
HAVING COUNT(TbTitulo.codAutor) > 1;

SELECT * FROM AutorTemporaria
select * from TitulosExpirados
select * from TbEmprestimo
select * from TbCliente
select * from Tbfuncionario
select * from TbEstante
select * from TbTitulo
select * from TbAutor
select * from TbEditora
select * from TbEmprestimoLivro
select * from TbExemplar
select * from TbCategoria
select * from tmpAutor





