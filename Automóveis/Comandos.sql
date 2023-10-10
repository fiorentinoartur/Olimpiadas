
ALTER TABLE Marcas ALTER COLUMN IdMarca INT NOT NULL;
ALTER TABLE Vendas ALTER COLUMN Idconcessionaria INT NOT NULL;
ALTER TABLE Locacao ALTER COLUMN IdArea INT NOT NULL;
ALTER TABLE Estoque ALTER COLUMN  IdConcessionaria INT NOT NULL;
ALTER TABLE Clientes ALTER COLUMN IdCidade INT NOT NULL;
ALTER TABLE Concessionaria ALTER COLUMN IdConcessionaria INT NOT NULL;
ALTER TABLE Cidades ALTER COLUMN IdCidade INT NOT NULL;
ALTER TABLE Capacidade ALTER COLUMN IdCapacidade INT NOT NULL;
ALTER TABLE Automovel ALTER COLUMN IdMarca INT NOT NULL;
ALTER TABLE Area ALTER COLUMN IdAndar INT NOT NULL;
ALTER TABLE Andar ALTER COLUMN IdAndar INT NOT NULL;

--********************************Adicionando as Primary Key******************************

ALTER TABLE Marcas ADD CONSTRAINT PK_Marcas PRIMARY KEY (IdMarca) 
ALTER TABLE Vendas ADD CONSTRAINT PK_Vendas PRIMARY KEY (IdVenda) 
ALTER TABLE Locacao ADD CONSTRAINT PK_Locacao PRIMARY KEY (IdLocacao) 
ALTER TABLE Estoque ADD CONSTRAINT PK_ PRIMARY KEY (IdEstoque)
ALTER TABLE Clientes ADD CONSTRAINT PK_Cliente PRIMARY KEY(IdCliente)
ALTER TABLE Concessionaria ADD CONSTRAINT PK_Concessionaria PRIMARY KEY(IdConcessionaria)
ALTER TABLE Cidades ADD CONSTRAINT PK_Cidades PRIMARY KEY(IdCidade)
ALTER  TABLE Capacidade ADD CONSTRAINT PK_Capacidade PRIMARY KEY (IdCapacidade)
ALTER TABLE Automovel ADD CONSTRAINT PK_Automovel PRIMARY KEY (IdAutomovel)
ALTER TABLE Area ADD CONSTRAINT PK_Area PRIMARY KEY (IdArea)
ALTER TABLE Andar ADD CONSTRAINT PK_Andar PRIMARY KEY (IdAndar)

--**********************************Adicionando as Foreign Key*******************************
ALTER TABLE Automovel ADD CONSTRAINT FK_Marca FOREIGN KEY (IdMarca) REFERENCES Marcas(IdMarca)
ALTER TABLE Area ADD CONSTRAINT FK_Capacidade FOREIGN KEY (IdCapacidade) REFERENCES Capacidade(IdCapacidade)
ALTER TABLE Area ADD CONSTRAINT FK_Andar FOREIGN KEY (IdAndar) REFERENCES Andar(IdAndar)  
ALTER TABLE Estoque ADD CONSTRAINT FK_Automovel FOREIGN KEY(IdAutomovel) REFERENCES Automovel(IdAutomovel)
ALTER TABLE Estoque ADD CONSTRAINT FK_Concessionaria FOREIGN KEY(IdConcessionaria) REFERENCES Concessionaria(IdConcessionaria)
ALTER TABLE Locacao ADD CONSTRAINT FK_Estoque FOREIGN KEY(IdEstoque) REFERENCES Estoque(IdEstoque)
ALTER TABLE Locacao ADD CONSTRAINT FK_Area FOREIGN KEY(IdArea) REFERENCES Area(IdArea)
ALTER TABLE Clientes ADD CONSTRAINT FK_Cidade FOREIGN KEY(IdCidade) REFERENCES Cidades(IdCidade)
ALTER TABLE Vendas ADD CONSTRAINT FK_Cliente FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente)
ALTER TABLE Vendas ADD CONSTRAINT FK_ConcessionariaVenda FOREIGN KEY (IdConcessionaria) REFERENCES Concessionaria(IdConcessionaria)
ALTER TABLE Vendas ADD CONSTRAINT FK_AutomovelVenda FOREIGN KEY (IdAutomovel) REFERENCES Automovel(IdAutomovel)