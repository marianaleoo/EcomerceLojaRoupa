insert into Bandeira(Descricao, DataCadastro) values ('MasterCard' , SYSDATETIME())
insert into Bandeira(Descricao, DataCadastro) values ('Visa' , SYSDATETIME())
insert into Pais(Descricao, DataCadastro) values ('Brasil' , SYSDATETIME())
insert into Estado(Descricao, paisId, DataCadastro) values ('S�o Paulo' , 1,  SYSDATETIME())
insert into Cidade(Descricao, estadoId, DataCadastro) values ('Mogi das Cruzes' , 1, SYSDATETIME())
insert into TipoTelefone(Descricao, DataCadastro) values ('Celular' ,  SYSDATETIME())
insert into TipoTelefone(Descricao, DataCadastro) values ('Telefone' , SYSDATETIME())
insert into Genero(Descricao, DataCadastro) values('Feminino', SYSDATETIME())
insert into Genero(Descricao, DataCadastro) values('Masculino', SYSDATETIME())
insert into Genero(Descricao, DataCadastro) values('Outro', SYSDATETIME())


select * from Bandeira
select * from Pais
select * from Estado
select * from Cidade
select * from Genero
