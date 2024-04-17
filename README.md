# Microsserviço Wallet
Este repositório contém um microsserviço Balance.App desenvolvido em .NET para gerenciar os saldos das contas, integrado com o microsserviço Wallet Core feito com Go através do Apache Kafka. O microsserviço Balance.App é capaz de receber eventos gerados pelo Wallet Core através do Kafka e persistir os saldos atualizados no banco de dados.

# Funcionalidades
Recebe eventos via Kafka do microsserviço Wallet Core através do tópico `balances`e persiste os saldos atualizados no banco de dados PostgreSQL.

# Como Executar
Certifique-se de ter o Docker e o Docker Compose instalados em sua máquina.

1. Clone este repositório: git clone https://github.com/bjsneto/fc-ms-wallet-core.git
2. Navegue até o diretório clonado: `cd fc-ms-wallet-core`
3. Execute `docker-compose up -d` para iniciar todos os serviços.
4. Aguarde até que todos os serviços estejam disponíveis.


# Testando o Microsserviço
Utilize o arquivo `.http` fornecido para realizar chamadas ao microsserviço Wallet Core. Utilize o endpoint ` POST /transactions` para realizar uma transação. O microsserviço Balance.App receberá essa transação via Kafka e persistirá no banco de dados. Utilize o endpoint `GET /balances/{account_id}` fornecido no microsserviço Balance.App no arquivo .http para consultar o saldo atualizado pelo microsserviço Wallet Core.

Observações
Este desafio tem como objetivo principal compreender os conceitos de produção e consumo de eventos em uma arquitetura de microsserviços.