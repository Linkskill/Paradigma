-- Criacao de tabelas e insercao de registros --
CREATE TABLE Departamento (
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Nome NVARCHAR(50)
);

CREATE TABLE Pessoa(
  Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Nome NVARCHAR(50),
  Salario INT,
  DeptId INT FOREIGN KEY REFERENCES Departamento(Id)
);

insert into Departamento (Nome) values ('TI')
insert into Departamento (Nome) values ('Vendas')

insert into Pessoa (Nome, Salario, DeptId) values ('Joe', 70000, 1)
insert into Pessoa (Nome, Salario, DeptId) values ('Henry', 80000, 2)
insert into Pessoa (Nome, Salario, DeptId) values ('Sam', 60000, 2)
insert into Pessoa (Nome, Salario, DeptId) values ('Max', 90000, 1)

-- Criacao de tabelas e insercao de registros --

-- Tarefa 1 --

SELECT d.Nome AS Departamento, p.Nome AS Pessoa, p.Salario
FROM Pessoa p
JOIN Departamento d ON p.DeptId = d.Id
WHERE p.Salario = (
	SELECT MAX(Salario)
    FROM Pessoa
    WHERE DeptId = p.DeptId
);

-- Tarefa 1 --


