===============================================================
Configurações Globais
git config --global user.name "Seu Nome Aqui"
git config --global user.email "seu-email-padrao@exemplo.com"
------------
Em caso de existir credenciais salvas faça o comando pra remover usuário global:
git config --global --remove-section user

ou

git config --global --unset user.name
git config --global --unset user.email
================================================================

Subindo código - Sempre criar repositório no git antes:

git init
git add .
git commit -m "Comentário do commit"
git branch -M main
git remote add origin [LINK DO SEU REPOSITÓRIO]
git push -u origin main

=================================================================

Clonando projeto - Quando queremos baixar um projeto feito em outro pc e inserido no git

* Criar pasta com o mesmo nome que o projeto tem. 
Ex: Se o projeto tem o arquivo Aula03RH.csproj no Git, então crie uma pasta Aula03RH

* Abra a pasta 
* Abra o terminal e digite o comando
git clone [link do repositório] .
==========================================================================

Para subir a modificação de projeto já clonado
- Fazer configuração global do user.name e user.email (comando no início do txt)
git init
git add .
git commit -m "Mensagem da modificação"
git push

(Visualizar as alterações no git)
===========================================================================

Como baixar uma modificação que foi feita recentemente diretamente no git
git pull 

============================================================
Formatando Read.md

﻿# Aula 10 - Git

Aqui pode ser adicionado novos comentários para deixar a descrição do projeto mais rica.


## Comentário adicionado no início da Aula 10

**Ajuste dos textos para formatação do markdown**

```c#
//Exemplo de citação de código c# 
public class Teste
{
    int variavel = 0;
}
```

*Referências*
https://github.com/KyleGobel/MarkdownSharp-GithubCodeBlocks  
https://docs.pipz.com/central-de-ajuda/learning-center/guia-basico-de-markdown#open  
[Link direto para vídeo](https://www.markdownguide.org/getting-started/)  
Vídeo no Youtube <https://www.youtube.com/watch?v=HJ16WEmOWTw>  







