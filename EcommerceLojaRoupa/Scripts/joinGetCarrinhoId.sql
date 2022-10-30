select * from Usuario

select i.Quantidade, i.RoupaId, CarrinhoCompraId from
ItemCarrinho i
inner join Cliente c on
c.CarrinhoId = i.CarrinhoCompraId
where c.Id = 1 and c.CarrinhoId = 1


select * from ItemCarrinho

select * from Cliente 