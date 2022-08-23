insert into Bandeira(Descricao, DataCadastro) values ('MasterCard' , SYSDATETIME())
insert into Bandeira(Descricao, DataCadastro) values ('Visa' , SYSDATETIME())
insert into Pais(Descricao, DataCadastro) values ('Brasil' , SYSDATETIME())
insert into Estado(Descricao, paisId, DataCadastro) values ('São Paulo' , 2,  SYSDATETIME())
insert into Cidade(Descricao, estadoId, DataCadastro) values ('Mogi das Cruzes' , 2, SYSDATETIME())
insert into TipoEndereco(Descricao, DataCadastro) values ('Cobrança' ,  SYSDATETIME())
insert into TipoEndereco(Descricao, DataCadastro) values ('Entrega' , SYSDATETIME())

select * from CartaoCredito

