# Mádrage Back End Challenge #

Desafio de back end da Mádrage.

# Guia
- [Requisitos](#requisitos)
- [Documentação da Api](#documentação-da-Api)
- [Rodando a aplicação com o Docker](#rodando-a-aplicação-com-o-docker)

# Requisitos

- Docker
- Docker Compose

# Documentação da Api

Para facilitar o entendimento do Api segue a [coleção](madrage-back-end-challenge.postman_collection.json) do Postman para consulta.

# Rodando a aplicação com o Docker

Para executar a aplicação precisamos levantar o Docker Compose, Para isso vamos abrir um terminal na raiz do projeto e executar o seguinte comando

``# docker-compose up -d``

Nesse momento a aplicação deve esta rodando normalmente.

Se achar necessario podemos observar o log da aplicação com o seguinte comando.

``# docker logs madrage-back-end-challenge -f``