insert into Bandeira(Descricao, DataCadastro) values ('MasterCard' , SYSDATETIME())
insert into Bandeira(Descricao, DataCadastro) values ('Visa' , SYSDATETIME())
insert into Pais(Descricao, DataCadastro) values ('Brasil' , SYSDATETIME())
insert into Estado(Descricao, paisId, DataCadastro) values ('São Paulo' , 1,  SYSDATETIME())
insert into Cidade(Descricao, estadoId, DataCadastro) values ('Mogi das Cruzes' , 1, SYSDATETIME())
insert into TipoTelefone(Descricao, DataCadastro) values ('Celular' ,  SYSDATETIME())
insert into TipoTelefone(Descricao, DataCadastro) values ('Telefone' , SYSDATETIME())
insert into Genero(Descricao, DataCadastro) values('Feminino', SYSDATETIME())
insert into Genero(Descricao, DataCadastro) values('Masculino', SYSDATETIME())
insert into Genero(Descricao, DataCadastro) values('Outro', SYSDATETIME())

select * from CartaoCredito

insert into CartaoCredito(NumeroCartao, NomeCartao, CodigoSeguranca, BandeiraId, ClienteId, DataCadastro)
values ('123456789101', 'Mariana Léo', '123', 1, 1, SYSDATETIME())

       


--quando o cliente for cadastrado dar um insert na tabela carrinho de compra


select * from CarrinhoCompra


insert into CarrinhoCompra(DataCadastro) values(SYSDATETIME()) 

select * from Bandeira
select * from Pais
select * from Estado
select * from Cidade
select * from Genero
select * from TipoTelefone

delete  from Cliente where Id= 6

delete  from CarrinhoCompra where Id= 1
delete  from Usuario where Id= 1
insert into Usuario(Email, Senha, DataCadastro) values('mariana.leo@hotmail.com', '123', SYSDATETIME())
insert into Cliente(Ativo, Codigo, Nome, DataNascimento, Cpf, DDD, Telefone, TipoTelefoneId, Email, Senha, ConfirmarSenha, GeneroId, UsuarioId, CarrinhoId, DataCadastro)
values(1, 'M', 'Mariana de Oliveira Léo', '1997-12-05', '45745559802', '11', '998385529', 1, 'mariana.leo@hotmail.com', '123', '123', 1, 1, 1, SYSDATETIME() )
select * from Usuario where Id= 1


insert into Roupa(Nome, Codigo, Tecido, Descricao, Ativo,  Preco, ImgLink, DataCadastro) values ('Calça Sarja', 'C', 'algodão', 'Calça verde', '1', 129.90, 'https://images.tcdn.com.br/img/img_prod/889236/calca_sarja_wide_cali_129_1_628ae91f6d42c7892fc60d525ead75ef.png', SYSDATETIME())
