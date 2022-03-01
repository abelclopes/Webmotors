# Webmotors Api!

Esta api usa o Mediatr que é um padrão de projeto Comportamental criado pelo GoF, que nos ajuda a garantir um baixo acoplamento entre os objetos de nossa aplicação. Ele permite que um objeto se comunique com outros sem saber suas estruturas. Para isso foi definir um ponto central que irá encapsular como os objetos irão se comunicar uns com os outros


## MediatR

Basicamente temos dois componentes principais chamados de Request e Handler, que implementamos através das interfaces  **_IRequest_**  e  **_IRequestHandler<TRequest>_**  respectivamente.

-   Request → mensagem que será processada.
-   Handler → responsável por processar determinada(s) mensagen(s).

> Não confunda o Request do MediatR com um request HTTP. Request é o nome usado pelo MediatR para descrever uma mensagem que será processada por um Handler. Além disso, algumas literaturas usam o termo Command para descrever essas mensagens, eu mesmo ainda uso esse termo de vez em quando.

veja mais sobre isso em [MediatR](https://github.com/jbogard/MediatR.Extensions.Microsoft.DependencyInjection)

## AutoMapper

O **AutoMapper** é uma biblioteca pequena e simples construída para resolver um problema aparentemente complexo, que é livrar-se de um código que mapeou um objeto para outro. Este tipo de problema é muito comum e relativamente trabalhoso de resolver, a ferramenta **AutoMapper** atua nesse cenário de forma simples e elegante.


## Database Docker-Composer
usei um SQLServer rodando, deixei o script do docker-compose.yml


## Database Entity Framework
Foi utilizado o Entity Framework Core como mapeador  de banco de dados

para utilizar este sistema deve rodar primeiramente o console
 

	dotnet ef database update
    ou executar este o script SQL   
    ![enter image description here](https://github.com/abelclopes/Webmotors/blob/develop/Screenshot_3.png?raw=true)

### Inicia o migrations

	dotnet ef migrations add InitialCreate

  

### Engenharia reversa 

	dotnet ef dbcontext scaffold "Server=localhost,11433;Database=teste_webmotors;User ID=sa;Password=Testing1122;Trusted_Connection=False; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer


