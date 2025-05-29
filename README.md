##  💸 API de transferências bancárias 💰

API desenvolvida em C# com o .NET 8 utilizando o framework ASP.NET Core, neste projeto foram abordados os princípios do **Domain-Driven Design (DDD)**.
A aplicação permite pagamentos de forma simplificada, possibilitando depósitos e transferências de dinheiro entre usuários. 

Existem 2 tipos de usuários: 
- **Comuns**: pode enviar e receber transferências
- **Lojistas**: apenas recebe transferências.

Ambos possuem carteiras digitais, mas somente os usuários comuns conseguem realizar transferências. 

Todas as informações são guardadas de forma segura em um banco de dados SQLite com EntityFramework atuando como um ORM (Object-Relational-Mapper), simplificando e facilitando as interações com o banco de dados diretamente com objetos .NET.

No momento do registro, as senhas são criptografadas e armazenadas de maneira segura no banco de dados, garantindo a segurança e integridade dos dados dos usuários.

A arquitetura da aplicação baseia-se em RESTful.

⚙️ 🔗 Endpoints

```
POST /RegisterUser
{
  "nomeCompleto": "string",
  "cpf": "string",
  "email": "string",
  "senha": "string",
  "userType": "typeUser",
  "saldo": 0
}

```

```
POST /transfer

{
  "value": 0,
  "payer": 0,
  "payee": 0
}
```

## ⚙️ Comportamento da aplicação 

Antes da transferência ser finalizada, a aplicação consulta um serviço autorizador externo.
- Mock utilizado: GET https://util.devi.tools/api/v2/authorize.
- Se a autorização falhar, a transferência é cancelada.

A operação de transferência é uma transação, ou seja, em caso de falhas durante o processo, a transação é revertida automaticamente e o valor volta para a carteira do usuário pagador.

Após o recebimento da transação, o usuário (ou lojista) recebe uma notificação via serviço de terceiros
- Mock utilizado: POST https://util.devi.tools/api/v1/notify.
- Caso o serviço de notificação esteja indisponível ou instável, a transação é concluída normalmente, a falha não impede a finalização da transação.

### Instalação 

1. Clone o repositório: 
    ```sh
    git clone https://github.com/lhspinheiro/SnapCash.git
     ```
2. Execute o seguinte comando no terminal:
    ```sh
    docker compose up -d
     ```
3. Acesse a aplicação em:
    ```sh
    http://localhost:5000 
     ```
4. Acesse o Swagger ui:
    ```sh
    http://localhost:5000/Swagger 
     ```

 






