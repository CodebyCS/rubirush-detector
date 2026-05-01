using AutoUpdaterDotNET;
using MonitorBot.Services;
using System.Timers;

namespace MonitorBot
{
    public partial class FormMain : Form
    {
        private BotService _botService = new BotService();

        private System.Timers.Timer _updateTimer;

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

            mainTimer.Start();

            await RodarProcesso();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mainTimer.Stop();

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

        private void txtConsole_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // 1. Limpeza de instâncias travadas
            try
            {
                var currentProcess = System.Diagnostics.Process.GetCurrentProcess();
                var processes = System.Diagnostics.Process.GetProcessesByName(currentProcess.ProcessName);
                foreach (var process in processes)
                {
                    if (process.Id != currentProcess.Id) process.Kill();
                }
            }
            catch { /* Ignora erros de permissão */ }

            // 2. Configuração (Onde definimos se é modo síncrono, etc)
            ConfigurarAutoUpdater();

            // 3. Início imediato
            AutoUpdater.Start("https://raw.githubusercontent.com/CodebyCS/rubirush-detector/master/AutoUpdater.xml");

            // 4. Timer de 24h
            _updateTimer = new System.Timers.Timer(24 * 60 * 60 * 1000);
            _updateTimer.Elapsed += (s, args) => {
                AutoUpdater.Start("https://raw.githubusercontent.com/CodebyCS/rubirush-detector/master/AutoUpdater.xml");
            };
            _updateTimer.AutoReset = true;
            _updateTimer.Enabled = true;
        }

        private void ConfigurarAutoUpdater()
        {
            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.Mandatory = true;
            AutoUpdater.UpdateMode = Mode.Forced;

            AutoUpdater.CheckForUpdateEvent += (args) => {
                if (args.IsUpdateAvailable)
                {
                    if (AutoUpdater.DownloadUpdate(args))
                    {
                        // Encerra o processo IMEDIATAMENTE para o Windows liberar o .exe
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                    }
                }
            };
        }
    }
}
