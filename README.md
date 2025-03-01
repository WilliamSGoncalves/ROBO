# ROBO

Para a execução: Abra a solução da pasta API com o Visual Studio e execute, abra a pasta do robo-frontend no Visual Studio Code e execute o comando npm run dev, sem mais detalhes para a execução.

 

Segue os comando solicitados na avaliação de banco de dados.

 

1 -

SELECT p.ID_PEDIDO AS Pedido,

   p.DATA_PEDIDO AS Data,

   c.NOME AS Cliente,

   SUM(po.PRECO_UNITARIO * ip.QUANTIDADE) AS Valor_total

      FROM PEDIDO AS p

INNER JOIN ITEM_PEDIDO AS ip

ON ip.ID_PEDIDO = p.ID_PEDIDO

INNER JOIN PRODUTO AS po

ON ip.ID_PRODUTO = po.ID_PRODUTO

INNER JOIN CLIENTE AS c

ON c.ID_CLIENTE = p.ID_CLIENTE

WHERE YEAR(p.DATA_PEDIDO) = 2012

  GROUP BY p.ID_PEDIDO, p.DATA_PEDIDO, c.NOME

  ORDER BY p.DATA_PEDIDO ASC

 

2 -

  INSERT INTO PRODUTO

  (DESCRICAO,

   PRECO_UNITARIO,

   QUANTIDADE)

   VALUES ('Smart TV',

   1950.90,

   1)

  

3 -

   UPDATE PRODUTO

  SET DESCRICAO = 'Notebook'

WHERE ID_PRODUTO = 10
