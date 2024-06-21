using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitorApp.Properties;
using Newtonsoft.Json;

namespace MonitoringApp
{

    public partial class Form1 : Form
    {

        private int interval;
        private List<string> logs;
        private string logFilePath;
        private int remainingTime;
        private bool whoRun;
        private int count;
        public string savedPath;
        private int checkAttempts;
        private const int maxAttempts = 2;
        private bool anyNotResponding;
        private string basepath;
        private string[] commandsArray;



        public Form1()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            logs = new List<string>();
            interval = 1800000; //def 1800000
            remainingTime = interval / 1000;
            logFilePathCheck();
            UpdateWhoRunsProgram();
            this.Load += new EventHandler(Form1_Load);
            Start_process_trigger();
            LoadSavedPath();
            anyNotResponding = false;//powinno byc flase na ini
            checkAttempts = 0;
            basepath = AppDomain.CurrentDomain.BaseDirectory;

        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            if (sender != null)
            {
                remainingTime--;
                if (remainingTime <= 0)
                {
                    CheckProcesses();
                    remainingTime = interval / 1000; // Jeœli czas dobiegnie koñca, resetujemy licznik odliczania
                }
                UpdateCountdownLabel(); // Aktualizacja wyœwietlanego czasu odliczania
            }
        }

        private void UpdateCountdownLabel()
        {
            labelCountdown.Text = $"Czas do sprawdzenia: {remainingTime}s";
        }


        private void logFilePathCheck()
        {
            basepath = "logs";

            // Sprawdzanie, czy folder istnieje
            if (!Directory.Exists(basepath))
            {
                // Tworzenie folderu
                Directory.CreateDirectory(basepath);
            }

            // Tworzenie œcie¿ki do pliku
            logFilePath = $"{basepath}/log_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt";

        }

        private void CheckProcesses()
        {
            var processes = Process.GetProcessesByName("CDNWORK");
            if (processes.Length < count) // powinno byc processes.Length < count
            {
                foreach (var process in processes)
                {
                    process.Kill();
                }
                Log("Zamkniêto wszystkie procesy CDNWORK.exe, ponowne uruchamianie po 10 sekundach...");
                Task.Delay(10000).ContinueWith(_ => StartProcess());
            }
            else
            {

                foreach (var process in processes)
                {
                    if (!process.Responding)
                    {
                        anyNotResponding = true;
                        break;
                    }
                }

                if (anyNotResponding)
                {
                    checkAttempts++;
                    Log("Proces nie odpowiada. Licznik sprawdzeñ" + checkAttempts);
                    if (checkAttempts >= maxAttempts)
                    {
                        SendEmail();
                        Log("Wys³ano e-mail informacyjny o stanie procesów CDNWORK.exe.");
                        checkAttempts = 0; // Reset liczby prób po wys³aniu e-maila
                    }
                }
                else
                {
                    checkAttempts = 0; // Reset liczby prób jeœli procesy odpowiadaj¹
                }
            }

            Log($"Aktualna liczba procesów CDNWORK.exe: {processes.Length}");
        }



        private EmailSettings LoadEmailSettings()
        {
            string filePath = "emailSettings.json";

            if (!File.Exists(filePath))
            {
                // Jeœli plik nie istnieje, stwórz plik z domyœlnymi ustawieniami
                var defaultSettings = new EmailSettings
                {
                    SmtpServer = "smtp.example.com",
                    Port = 578,
                    EnableSsl = true,
                    EmailFrom = "yourEmail@example.com",
                    EmailPassword = "yourEmailPassword",
                    EmailTo = "recipient@example.com",
                    EmailSubject = "Process CDNWORK.exe Not Responding",
                    EmailBody = "Process CDNWORK.exe has not been responding for 3 consecutive checks."
                };

                string json = JsonConvert.SerializeObject(defaultSettings, Formatting.Indented);
                File.WriteAllText(filePath, json);
                Log("Utworzono plik emailSettings.json z domyœlnymi ustawieniami.");

                return defaultSettings;
            }
            else
            {
                // Odczytaj plik JSON
                string json = File.ReadAllText(filePath);
                Log("Za³adowano plik emailSettings.json");
                return JsonConvert.DeserializeObject<EmailSettings>(json);
            }
        }


        private void SendEmail()
        {
            var settings = LoadEmailSettings();

            // Ignorowanie b³êdów certyfikatu SSL
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
                (sender, certificate, chain, sslPolicyErrors) => true;

            try
            {
                using (var smtpClient = new SmtpClient(settings.SmtpServer))
                {
                    smtpClient.Port = settings.Port;
                    smtpClient.Credentials = new System.Net.NetworkCredential(settings.EmailFrom, settings.EmailPassword);
                    smtpClient.EnableSsl = settings.EnableSsl;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(settings.EmailFrom),
                        Subject = settings.EmailSubject,
                        Body = settings.EmailBody,
                        IsBodyHtml = true,
                    };
                    mailMessage.To.Add(settings.EmailTo);

                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                Log($"B³¹d podczas wysy³ania e-maila. Szczegó³y b³êdu: {ex.Message}");
            }
            finally
            {
                // Resetowanie ServerCertificateValidationCallback do wartoœci domyœlnej
                System.Net.ServicePointManager.ServerCertificateValidationCallback = null;
            }
        }






        private void SaveCommands(List<string> commands)
        {
            try
            {
                var config = new CommandConfig { Commands = commands };
                string json = JsonConvert.SerializeObject(config, Formatting.Indented);
                File.WriteAllText("commands.json", json);
                Log("Pomyœlnie zapisano komendy.");
                UpdateProcessCountLabel();
            }
            catch (Exception ex)
            {
                Log($"B³¹d podczas zapisywania komend. Szczegó³y b³êdu: {ex.Message}");
            }
        }

        private List<string> LoadCommands()
        {
            try
            {
                if (File.Exists("commands.json"))
                {
                    string json = File.ReadAllText("commands.json");
                    var config = JsonConvert.DeserializeObject<CommandConfig>(json);
                    Log("Pomyœlnie odczytano komendy.");
                    return config?.Commands ?? new List<string>();
                }
                else
                {
                    Log("Plik z komendami nie istnieje.");
                    return new List<string>();
                }
            }
            catch (Exception ex)
            {
                Log($"B³¹d podczas odczytywania komend. Szczegó³y b³êdu: {ex.Message}");
                return new List<string>();
            }
        }

        private void Proc_Save_Click(object sender, EventArgs e)
        {
            var commands = command_box.Lines.ToList(); // Pobranie komend z pola tekstowego
            SaveCommands(commands);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var commands = LoadCommands();
            if (commands.Any())
            {
                command_box.Lines = commands.ToArray(); // Ustawienie komend w polu tekstowym
            }
        }

        

        private void StartProcess()
        {
            var commands = command_box.Lines.ToList();
            commandsArray = commands.ToArray(); // Zapisanie komend do tablicy commandsArray

            if (!commands.Any())
            {
                Log("Brak komend do uruchomienia.");
                return;
            }

            string allCommands = string.Join(" && ", commands);

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C {allCommands}",
                    WorkingDirectory = savedPath,
                    CreateNoWindow = true
                };

                if (whoRun) // Jeœli whoRun jest true (uruchamianie jako administrator)
                {
                    startInfo.Verb = "runas"; // Ustawienie Verb na "runas" uruchamia jako administrator
                }

                
                Process.Start(startInfo);
                Log("Pomyœlnie uruchomiono wszystkie procesy.");
            }
            catch (Exception ex)
            {
                Log($"B³¹d podczas uruchamiania procesów. Szczegó³y b³êdu: {ex.Message}");
            }
        }


        private void UpdateProcessCountLabel()
        {
            count = CountCommands(); // Wywo³aj metodê CountCommands() aby pobraæ liczbê komend
            process_count_label.Text = $"Liczba komend: {count}";
        }

        private int CountCommands()
        {
            string[] lines = command_box.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return lines.Length;
        }




        private void Log(string message)
        {
            logs.Add($"{DateTime.Now}: {message}");
            textBoxLogs.AppendText($"{DateTime.Now}: {message}\r\n");
            File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}\r\n");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {


            timer.Interval = 1000;
            timer.Start();
            Log("Monitoring rozpoczêty");
            int interval_mess = (interval / 1000) / 60;
            if (interval_mess <= 1)
            {
                Log("Interwa³ " + (interval / 1000) + " sekund");
            }
            else
            {
                Log("Interwa³ " + (interval / 1000) / 60 + " minut");
            }


        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Log("Monitoring zatrzymany");

        }

        private void comboBoxInterval_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (comboBoxInterval.SelectedItem.ToString())
            {
                /* interwaly do debugowania -> zmienic tez w designer pole combo
                 case "10s":

                     interval = 10000;
                     remainingTime = interval / 1000;
                     break;
                 case "30s":

                     interval = 30000;
                     remainingTime = interval / 1000;
                     break; 
                case "1 minuta":

                    interval = 60000;
                    remainingTime = interval / 1000;
                    break;
                */
                case "5 minut":

                    interval = 300000;
                    remainingTime = interval / 1000;
                    break;
                case "15 minut":

                    interval = 900000;
                    remainingTime = interval / 1000;
                    break;
                case "30 minut":

                    interval = 1800000;
                    remainingTime = interval / 1000;
                    break;
                case "1 godzina":

                    interval = 3600000;
                    remainingTime = interval / 1000;
                    break;
                case "2 godziny":

                    interval = 7200000;
                    remainingTime = interval / 1000;
                    break;
                default:

                    interval = 60000;
                    remainingTime = interval / 1000;
                    Log("Nie wybrano interwa³u. Domyœlny wyniosi 1min");
                    break;
            }
        }

        private void buttonShowLogs_Click(object sender, EventArgs e)
        {
            Form logForm = new Form
            {
                Text = "Logi",
                Width = 800,
                Height = 600
            };
            TextBox logTextBox = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Text = File.ReadAllText(logFilePath)
            };
            logForm.Controls.Add(logTextBox);
            logForm.Show();
        }

        private void buttonOpenLogLocation_Click(object sender, EventArgs e)
        {
            
            string logsFolder = Path.Combine(basepath, "logs");

            // Sprawdzanie, czy folder logs istnieje
            if (Directory.Exists(logsFolder))
            {
                // Pobieranie listy plików .txt w folderze logs
                string[] txtFiles = Directory.GetFiles(logsFolder, "*.txt");

                // Sprawdzenie, czy s¹ jakieœ pliki .txt
                if (txtFiles.Length > 0)
                {
                    // £¹czenie œcie¿ki z pierwszym plikiem .txt w explorer.exe
                    Process.Start("explorer.exe", $"/select,\"{txtFiles[0]}\"");
                }
                else
                {
                    MessageBox.Show("Brak plików tekstowych (.txt) w folderze 'logs'.");
                }
            }
            else
            {
                MessageBox.Show("Folder 'logs' nie istnieje.");
            }


        }

        public async Task Start_process_trigger()
        {
            // Oczekiwanie przez 2 s
            await Task.Delay(2000);
            UpdateProcessCountLabel();
            Log("Zaktualizowano licznik procesów: " + count);
            LoadEmailSettings();

        }

        private void UpdateWhoRunsProgram()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            bool isAdmin = new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator);
            string userName = identity.Name;
            whoRun = isAdmin;
            if (isAdmin)
            {
                whoRunsProgram.Text = $"Program zosta³ uruchomiony przez u¿ytkownika: {userName} jako administrator";
            }
            else
            {
                whoRunsProgram.Text = $"Program zosta³ uruchomiony przez u¿ytkownika: {userName}";
            }
        }

        private void refresh_but_Click(object sender, EventArgs e)
        {
            UpdateProcessCountLabel();
            Log("Odœwierzono licznik liczby procesów. Iloœæ: " + count);
        }

        private void process_lok_Click(object sender, EventArgs e)
        {
            // Inicjalizacja okna dialogowego wyboru folderu
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Wybierz folder";

            // Wyœwietlenie okna dialogowego i sprawdzenie czy u¿ytkownik wybra³ folder
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Pobranie wybranej œcie¿ki folderu
                string folderPath = folderBrowserDialog.SelectedPath;

                // Ustawienie œcie¿ki folderu w etykiecie
                lok_label.Text = folderPath;

                // Zapisanie œcie¿ki do ustawieñ aplikacji
                SavePathToConfig(folderPath);
            }
        }

        private void LoadSavedPath()
        {
            // £adowanie zapisanej œcie¿ki z ustawieñ aplikacji
            savedPath = Settings.Default.FilePath;
            if (!string.IsNullOrEmpty(savedPath))
            {
                lok_label.Text = savedPath;
                
            }
        }

        private void SavePathToConfig(string path)
        {
            // Zapisanie œcie¿ki do ustawieñ aplikacji
            Settings.Default.FilePath = path;
            Settings.Default.Save();
        }

        private void process_force_start_Click(object sender, EventArgs e)
        {
            CheckProcesses();
            Log("Uruchomiono procesy na rz¹danie.");
        }
    }

    public class CommandConfig
    {
        public List<string> Commands { get; set; }
    }

    public class EmailSettings
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string EmailFrom { get; set; }
        public string EmailPassword { get; set; }
        public string EmailTo { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
    }

}
