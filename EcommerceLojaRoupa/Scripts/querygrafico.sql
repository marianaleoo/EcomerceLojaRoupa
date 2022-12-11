
SELECT c.Descricao, Format(cc.DataCadastro, 'dd-MM-yyyy') as DataVenda, Count(c.Descricao) as Quantidade
FROM
    Categoria c
inner JOIN
 Roupa r 
 on r.CategoriaId = c.Id
 left join 
  ItemCompra ic
  on ic.RoupaId = r.Id
  right join
  Compra cc
  on cc.id = ic.CompraId
group by c.Descricao, Format(cc.DataCadastro, 'dd-MM-yyyy')
