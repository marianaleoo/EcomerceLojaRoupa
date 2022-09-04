insert into Bandeira(Descricao, DataCadastro) values ('MasterCard' , SYSDATETIME())
insert into Bandeira(Descricao, DataCadastro) values ('Visa' , SYSDATETIME())
insert into Pais(Descricao, DataCadastro) values ('Brasil' , SYSDATETIME())
insert into Estado(Descricao, paisId, DataCadastro) values ('São Paulo' , 1,  SYSDATETIME())
insert into Cidade(Descricao, estadoId, DataCadastro) values ('Mogi das Cruzes' , 3, SYSDATETIME())
insert into TipoEndereco(Descricao, DataCadastro) values ('Cobrança' ,  SYSDATETIME())
insert into TipoEndereco(Descricao, DataCadastro) values ('Entrega' , SYSDATETIME())
insert into Genero(Descricao, DataCadastro) values('Feminino', SYSDATETIME())
insert into Genero(Descricao, DataCadastro) values('Masculino', SYSDATETIME())
insert into Genero(Descricao, DataCadastro) values('Outro', SYSDATETIME())


select * from Bandeira
select * from Pais
select * from Estado
select * from Cidade
select * from TipoEndereco
select * from Genero
