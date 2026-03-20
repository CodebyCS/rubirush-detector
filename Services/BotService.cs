using MonitorBot.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;


namespace MonitorBot.Services
{
    public class BotService
    {
        private Dictionary<string, long> _cache = new Dictionary<string, long>();
        private readonly string _webhookUrl;
        private readonly HttpClient _httpClient = new HttpClient();

        public BotService()
        {
            // Leitura do ficheiro appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();

            //Busca o valor dentro de DiscordConfig -> WebhookUrl
            _webhookUrl = config["DiscordConfig:WebhookUrl"];
        }

        public async Task<List<string>> ExecutarCiclo(long minimoXp)
        {
            List<string> rushsdetectados = new List<string>();
            var tarefas = new List<Task<string>>();

            for (int p = 1; p <= 10; p++) 
            {
                string url = $"https://rubinot.net/api/highscores?world=all&category=exp_today&vocation=0&page={p}&t={DateTime.Now.Ticks}";
                tarefas.Add(_httpClient.GetStringAsync(url));
            }

            try
            {
                string[] resultadosJson = await Task.WhenAll(tarefas);

                foreach (var json in resultadosJson)
                {
                    var response = JsonConvert.DeserializeObject<HighscoreResponse>(json);
                    if (response?.Players == null) continue;

                    foreach (var player in response.Players)
                    {
                        string nomeChave = player.Name.ToLower().Trim();
                        long valorAtual = player.Value;

                        if (_cache.TryGetValue(nomeChave, out long valorAntigo))
                        {
                            long ganho = valorAtual - valorAntigo;

                            if (ganho >= minimoXp)
                            {
                                string msg = $"⭐ #{player.Rank} - **{player.Name}** - Lvl: {player.Level} - (Subiu +{ganho:N0})";
                                rushsdetectados.Add(msg);
                            }
                        }
                        _cache[nomeChave] = valorAtual; // Atualiza porque avisou
                    }
                }   
                
                } catch { }
            
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
