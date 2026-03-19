using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using MonitorBot.Models;


namespace MonitorBot.Services
{
    public class BotService
    {
        private Dictionary<string, long> _cache = new Dictionary<string, long>();
        private readonly string _webhookUrl = "SUA_WEBHOOK_AQUI";
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<string>> ExecutarCiclo(long minimoXp)
        {
            List<string> rushsdetectados = new List<string>();

            for (int p = 1; p <= 10; p++)
            {
                try
                {
                    string url = $"https://rubinot.net/api/highscores?world=all&category=exp_today&vocation=0&page={p}&t={DateTime.Now.Ticks}";
                    string json = await _httpClient.GetStringAsync(url);

                    var response = JsonConvert.DeserializeObject<HighscoreResponse>(json);

                    if(response?.Players != null)
                    {
                        foreach (var player in response.Players)
                        {
                            string nomeChave = player.Name.ToLower().Trim();
                            long valorAtual = player.Value;

                            if (_cache.TryGetValue(nomeChave, out long valorAntigo))
                            {
                                if (valorAtual > valorAntigo) // Só entra se a XP subiu
                                {
                                    long ganho = valorAtual - valorAntigo;

                                    if (ganho >= minimoXp)
                                    {
                                        rushsdetectados.Add($"⭐ #{player.Rank} - **{player.Name}** - Lvl: {player.Level} - (Subiu +{ganho:N0})");

                                        // SÓ atualiza o cache se enviamos o alerta. 
                                        // Assim, se ele subir 50k agora e 110k depois, o bot soma e avisa quando bater 150k!
                                        _cache[nomeChave] = valorAtual;
                                    }
                                    // Se o ganho foi pequeno (ex: 10k), NÃO atualizamos o cache. 
                                    // Deixamos o valor antigo lá para ele acumular no próximo ciclo.
                                }
                                else if (valorAtual < valorAntigo)
                                {
                                    // Trata reset de meia-noite (XP zerou no site)
                                    _cache[nomeChave] = valorAtual;
                                }
                            }
                            else
                            {
                                _cache[nomeChave] = valorAtual;
                            }
                        }
                    }

                } catch { }
            }
            return rushsdetectados;
        }

        public async Task EnviarDiscord(string conteudo)
        {
            const int LIMITE = 1900;

            if (conteudo.Length <= LIMITE)
            {
                await PostToDiscord(conteudo);
                return;
            }

            var linhas = conteudo.Split('\n');
            StringBuilder mensagemAtual = new StringBuilder();

            foreach (var linha in linhas)
            {
                if (mensagemAtual.Length + linha.Length + 1 > LIMITE)
                {
                    await PostToDiscord(mensagemAtual.ToString() + "\n🔹 **Continuação...**");
                    mensagemAtual.Clear();
                }
                mensagemAtual.AppendLine(linha);
            }

            if(mensagemAtual.Length > 0)
            {
                await PostToDiscord(mensagemAtual.ToString());
            }
        }

        private async Task PostToDiscord(string textoParaEnviar)
        {

            var payload = new { content = textoParaEnviar };
            var json = JsonConvert.SerializeObject(payload);
            await _httpClient.PostAsync(_webhookUrl, new StringContent(json, Encoding.UTF8, "application/json"));

            await Task.Delay(500);
        }
    }
}
