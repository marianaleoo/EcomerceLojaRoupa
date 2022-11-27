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

delete from CartaoCredito where Id =11

insert into CartaoCredito(NumeroCartao, NomeCartao, ValidadeCartao, CodigoSeguranca, BandeiraId, ClienteId, DataCadastro)
values ('123456789101', 'Mariana Léo', SYSDATETIME(), '123', 1, 3, SYSDATETIME())

select * from EnderecoEntrega
insert into EnderecoEntrega(TipoResidencia, TipoLogradouro, Logradouro, Numero, Bairro,
Cep, ClienteId, cidadeId, DataCadastro)values('Residencial', 'Rua', 'Pedro Paulo dos Santos', '3175', 'Jundiapeba', '08750710', 3, 1, SYSDATETIME())


select * from Cidade
select * from Cliente
select * from Roupa
       


--quando o cliente for cadastrado dar um insert na tabela carrinho de compra


select * from Cliente


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


insert into Roupa(Nome, Codigo, Tecido, Descricao, Ativo,  Preco, ImgLink, DataCadastro) values ('Shorts Saia', 'S', 'algodão', 'Shorts Saia XADREZ ', '1', 99.90, 'https://images.tcdn.com.br/img/img_prod/889236/shorts_saia_bella_2_0_xadrez_145_1_3ddc8d89a0e147ac9f7c9d5249953c40.jpg', SYSDATETIME())
