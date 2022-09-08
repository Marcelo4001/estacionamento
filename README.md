# DIO - Trilha .NET - Fundamentos
www.dio.me

## Desafio de projeto - Estacionamento

## Solução de Marcelo Cunha Ramos

### ValidarPlaca
Foi criado o método ValidarPlaca que verifica a entrada do usuário, com expressão regular, esperando encontrar três letras seguidas de quatro dígitos. O usuário pode separar esses blocos com um espaço, com um hífem ou não separá-los.

Se a entrada for válida, a placa será formatada para que as letras sejam maiúsculas e um hífem as separe dos dígitos.

A mesma função (ou método) aceita que o usuário insira apenas o índice da placa na lista veículos e, se uma placa é encontrada desta forma, ela é retornada ao método chamador. Assim, AdicionarVeiculo não pode evitar de inserir o mesmo veículo se ele já estiver estacionado e, a remoção do veículo pode ser feita sem a necessidade de digitar toda a placa.
