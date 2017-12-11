Funcionalidade: Cadastro de Organizador
	Um organizador fará seu cadastro pelo site
	para poder gerenciar seus próprios eventos
	Ao terminar o cadastro receberá uma notificação
	de sucesso ou de falha.

@TesteAutomatizadoCadastroDeOrganizadorComSucesso

Cenário: Cadastro de Organizador com Sucesso
	Dado que o Organizador está no site, na página inicial
	E clica no link de registro
	E preenche os campos com os valores
		| Campo            | Valor           |
		| nome             | Elton Diego     |
		| cpf              | 27960259267     |
		| email            | elton@gmail.com |
		| senha			   | Teste@123       |
		| senhaConfirmacao | Teste@123       |
	Quando clicar no botao registrar
	Então Será registrado e redirecionado com sucesso