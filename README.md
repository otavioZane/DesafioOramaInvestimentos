# DesafioOrama

# Resumo
  O projeto OramaInvestimentos apresenta uma solução de API rest com uso de asp net core e entity framework para resolver um desafio relacionado ao mercado financeiro, tendo as funcionalidades de cadastro e login, compra e venda de ações e consulta de saldo e extrato. Utilizando as tecnologias asp net core 6, entity framework e segurança para hashing da senha com método salt de criptografia.

## Introdução
  - Ao inicializar o projeto certifique-se de estar com as versões e pacotes necessários atualizados.
  - No arquivo appsettings.json preencha sua string de conexão ao SQLServer para que a base seja criada no próximo passo.
  - Selecione o terminal de packmage manager e digite os comandos "Add-Migration InitialMigration" e "update-database" e o Entity Framework ira popular a base.
  - Inicialize o projeto no botão "OramaInvestimentos" para abrir o swagger.
  - No primeiro acesso, va no método "Signup" para realizar o cadastro.
  - Após cadastrar-se, na resposta do método Signup você recebera um tolken e devera copia-lo.
  - No canto superior há o botão "Authorize", cole o token e clicke em "Authorize" em verde, então o login será efetuado liberando acesso a todas as funcionalidades.


  ## Funcionalidades
    ### Consulta de saldo:
      Para consultar seu saldo basta clickar no método "GetBalance" e em seguida no botão "Try Out".

    ### Consulta de extrato:
      Para consultar seu extrato clique no método "GetStatement" e em seguida no botão "Try Out".

    ### Consulta de ações:
      Para ver as ações disponiveis vá até o método "GetFinancialAssets" e em seguida no botão "Try Out".

    ### Compra e venda de ações:
      Para comprar e vender é necessário clickar em seus respectivos campos, para comprar você precisa ter um saldo maior do que o valor total de ações desejadas. Para vender é necessário ter comprado ações e não tentar           vender um número maior do que o valor possuido.
  
    ### HealthCheck:
      Para conferir o status de saude da API, você ira retirar o final da url e substituir seu texto como no exemplo:
      "https://localhost:7275/swagger/index.html" para "https://localhost:7275/Health".
      
