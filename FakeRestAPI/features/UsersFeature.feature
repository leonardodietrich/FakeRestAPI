#language: pt-br
Funcionalidade: Obter os usuarios cadastrados

Contexto:
	Dado que o usuario acessou a API

Cenario: Validando busca de usuario por id
	Quando o usuario solicitar um 'get' em 'Users' da versão 'v1' passando o parametro '1'
	Entao vou receber o retorno '200'
	E vou receber um JSON com a response
	"""
	{"id":1,"userName":"User 1","password":"Password1"}
	"""

Cenario: Validando busca de usuario não existente na base
	Quando o usuario solicitar um 'get' em 'Users' da versão 'v1' passando o parametro '999'
	Entao vou receber o retorno '404'