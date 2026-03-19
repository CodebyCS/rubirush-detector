Rubirush Detector
RubiRush Detector é uma ferramenta de monitoramento de alta performance para o ecossistema Rubinot. O bot rastreia a evolução de XP dos jogadores em tempo real, detectando picos de atividade (rushes) e enviando alertas instantâneos para o seu canal do Discord.

✨ Funcionalidades
Monitoramento Automático: Varre as páginas do ranking do Rubinot em intervalos configuráveis.
Detecção de Rush: Sistema inteligente que identifica ganhos de XP acima do limite definido (ex: 150.000 XP).
Smart Cache: Utiliza memória estática para acumular ganhos pequenos e garantir que nenhum progresso seja ignorado.
Integração Discord: Alertas formatados com Rank, Nome, Level e valor exato da XP subida.
Executável Único: Compilado em Single-File, não requer instalação de dependências ou .NET externo.
🛠️ Como Usar
Configuração do Discord: Crie um Webhook no seu canal do Discord e insira a URL no campo correspondente do bot.
Defina o Radar: Escolha o valor mínimo de XP (ex: 150.000) para o bot considerar um "Rush".
Inicie o Bot: Clique em Start e o bot começará a monitorar.
Nota: O primeiro ciclo serve para popular o banco de dados, os alertas começarão a partir do segundo ciclo de consulta.
💻 Tecnologias Utilizadas
Linguagem: C# (.NET)
Interface: Windows Forms
JSON Parsing: Newtonsoft.Json / System.Text.Json
Ofuscação: Protegido contra engenharia reversa para garantir a integridade da lógica.
⚠️ Aviso Legal
Este projeto foi desenvolvido para fins de estudo e automação de inteligência competitiva. Certifique-se de respeitar os termos de uso do serviço Rubinot.

Desenvolvido por Carlos Santana
