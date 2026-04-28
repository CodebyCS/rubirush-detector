using AutoUpdaterDotNET;
using MonitorBot.Services;

namespace MonitorBot
{
    public partial class FormMain : Form
    {
        private BotService _botService = new BotService();

        private System.Windows.Forms.Timer timerGuild;

        private List<string> listaAntigaInimigos = new List<string>();

        public FormMain()
        {
            InitializeComponent();
        }

        private void numMinimoXp_ValueChanged(object sender, EventArgs e)
        {

        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            numMinimoXp.Enabled = false; // trava o input enquanto roda

            Log("Bot On");

            // --- CONFIGURAÇÃO DO TIMER DA GUILD (ADICIONE ISSO) ---
            if (timerGuild == null)
            {
                timerGuild = new System.Windows.Forms.Timer();
                timerGuild.Interval = 3600000; // 1 hora
                timerGuild.Tick += async (s, ev) => await AtualizarListaGuild();
            }
            timerGuild.Start();

            // Já carrega a lista assim que clica no Start pela primeira vez
            _ = AtualizarListaGuild();
            // -------------------------------------------------------

            mainTimer.Start();

            await RodarProcesso();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mainTimer.Stop();

            timerGuild?.Stop();

            btnStart.Enabled = true;
            btnStop.Enabled = false;
            numMinimoXp.Enabled = true;
            Log("Bot Off");
        }

        private async void mainTimer_Tick(object sender, EventArgs e)
        {
            await RodarProcesso();
        }

        private async Task RodarProcesso()
        {
            long minimo = (long)numMinimoXp.Value;
            Log($"Consultando API (Radar: {minimo:N0})...");

            var resultados = await _botService.ExecutarCiclo(minimo);

            if (resultados != null && resultados.Count > 0)
            {
                // Envia para o discord
                string msg = "**RELATÓRIO EXP**\n" + string.Join("\n", resultados);
                await _botService.EnviarDiscord(msg);

                //Log no console do Bot
                Log($"{resultados.Count} rushs enviados!");
            }
            else
            {
                Log("❌ Nenhum rush detectado.");
            }
        }
        private void Log(string txt)
        {
            txtConsole.AppendText($"[{DateTime.Now:HH:mm:ss}] {txt}\r\n");

            txtConsole.SelectionStart = txtConsole.Text.Length;
            txtConsole.ScrollToCaret();

        }

        private async Task AtualizarListaGuild()
        {
            try
            {
                var listaNova = await _botService.BuscarInimigos();

                // Verificação de saida de membro da guild

                var sairam = listaAntigaInimigos.Except(listaNova).ToList();
                foreach (var nome in sairam)
                {
                    Log($"⚠️-- {nome} -- SAIU da Ghost Division");
                    MessageBox.Show($"{nome} saiu da Ghost Division!", "Baixa na Guild", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Detectar novos membros na guild

                if (listaAntigaInimigos.Count > 0)
                {
                    var entraram = listaNova.Except(listaAntigaInimigos).ToList();
                    foreach (var nome in entraram)
                    {
                        Log($"⚔️ NOVO INIMIGO: {nome}");
                        MessageBox.Show($"{nome} acabou de entrar na Ghost Division!", "Novo Inimigo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Atualiza a memória para a proxima hora
                listaAntigaInimigos = listaNova;

                this.Invoke((Action)(() =>
                {
                    lstMembrosInimigos.Items.Clear();
                    foreach (var inimigo in listaNova)
                    {
                        lstMembrosInimigos.Items.Add(inimigo);
                    }

                    // Contador para quantidade total de players na Guild

                    lblTituloGuild.Text = $"Ghost Division - {listaNova.Count} Membros";
                }));
            }
            catch { /* Erro silencioso para não travar o bot */ }
        }

        private void txtConsole_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AutoUpdater.Start("https://raw.githubusercontent.com/CodebyCS/rubirush-detector/master/AutoUpdater.xml");
        }

        private void GhostDivisionMembers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
