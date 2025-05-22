##  💸 API de transferências bancárias 💰

API desenvolvida em C# com o .NET 8 utilizando o framework ASP.NET Core, neste projeto foram abordado os princípios do **Domain-Driven Design (DDD)**.
A aplicação permite pagamentos de forma simplificada, possibilitando depósitos e transferências de dinheiro entre usuários. 

Existe 2 tipos de usuários: 
- **Comuns**: pode enviar e receber transferências
- **Lojistas**: apenas recebe transferências.

Ambos possuem carteiras digitais, mas somente os usuários comuns conseguem realizar transferências. 

Todas as informações são guardadas de forma segura em um banco de dados SQLite com EntityFramework atuando como um ORM (Object-Relational-Mapper), simplificando e facilitando as interações com o banco de dados diretamente com objetos .NET.

No momento do registro, as senhas são criptografadas e armazenadas de maneira segura no banco de dados, garantia a segurança e integridade dos dados dos usuários.

A arquitetura da aplicação se baseaia-se em RESTFul.

## 🔗 Endpoints

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

