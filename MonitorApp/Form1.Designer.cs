namespace MonitoringApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            labelInterval = new Label();
            comboBoxInterval = new ComboBox();
            buttonStart = new Button();
            buttonStop = new Button();
            textBoxLogs = new TextBox();
            labelLogs = new Label();
            buttonShowLogs = new Button();
            buttonOpenLogLocation = new Button();
            timer = new System.Windows.Forms.Timer(components);
            openFileDialog = new OpenFileDialog();
            labelCountdown = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            process_force_start = new Button();
            tabPage2 = new TabPage();
            lok_label = new Label();
            refresh_but = new PictureBox();
            process_count_label = new Label();
            pictureBox1 = new PictureBox();
            command_box = new TextBox();
            label7 = new Label();
            Proc_Save = new Button();
            label6 = new Label();
            process_lok = new Button();
            label4 = new Label();
            whoRunsProgram = new Label();
            toolTip_command_box = new ToolTip(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)refresh_but).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelInterval
            // 
            labelInterval.AutoSize = true;
            labelInterval.Location = new Point(17, 20);
            labelInterval.Margin = new Padding(4, 0, 4, 0);
            labelInterval.Name = "labelInterval";
            labelInterval.Size = new Size(137, 20);
            labelInterval.TabIndex = 0;
            labelInterval.Text = "Interwał odliczania:";
            // 
            // comboBoxInterval
            // 
            comboBoxInterval.FormattingEnabled = true;
            comboBoxInterval.Items.AddRange(new object[] { "5 minut", "15 minut", "30 minut", "1 godzina", "2 godziny" });
            comboBoxInterval.Location = new Point(156, 15);
            comboBoxInterval.Margin = new Padding(4, 5, 4, 5);
            comboBoxInterval.Name = "comboBoxInterval";
            comboBoxInterval.Size = new Size(160, 28);
            comboBoxInterval.TabIndex = 1;
            comboBoxInterval.SelectedIndexChanged += comboBoxInterval_SelectedIndexChanged;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(21, 77);
            buttonStart.Margin = new Padding(4, 5, 4, 5);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(100, 35);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "Start Monitoring";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(131, 77);
            buttonStop.Margin = new Padding(4, 5, 4, 5);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(100, 35);
            buttonStop.TabIndex = 3;
            buttonStop.Text = "Stop Monitoring";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // textBoxLogs
            // 
            textBoxLogs.Location = new Point(21, 198);
            textBoxLogs.Margin = new Padding(4, 5, 4, 5);
            textBoxLogs.Multiline = true;
            textBoxLogs.Name = "textBoxLogs";
            textBoxLogs.ReadOnly = true;
            textBoxLogs.ScrollBars = ScrollBars.Vertical;
            textBoxLogs.Size = new Size(596, 229);
            textBoxLogs.TabIndex = 6;
            // 
            // labelLogs
            // 
            labelLogs.AutoSize = true;
            labelLogs.Location = new Point(17, 174);
            labelLogs.Margin = new Padding(4, 0, 4, 0);
            labelLogs.Name = "labelLogs";
            labelLogs.Size = new Size(41, 20);
            labelLogs.TabIndex = 7;
            labelLogs.Text = "Logi:";
            // 
            // buttonShowLogs
            // 
            buttonShowLogs.Location = new Point(253, 77);
            buttonShowLogs.Margin = new Padding(4, 5, 4, 5);
            buttonShowLogs.Name = "buttonShowLogs";
            buttonShowLogs.Size = new Size(100, 35);
            buttonShowLogs.TabIndex = 8;
            buttonShowLogs.Text = "Pokaż logi";
            buttonShowLogs.UseVisualStyleBackColor = true;
            buttonShowLogs.Click += buttonShowLogs_Click;
            // 
            // buttonOpenLogLocation
            // 
            buttonOpenLogLocation.Location = new Point(363, 77);
            buttonOpenLogLocation.Margin = new Padding(4, 5, 4, 5);
            buttonOpenLogLocation.Name = "buttonOpenLogLocation";
            buttonOpenLogLocation.Size = new Size(196, 35);
            buttonOpenLogLocation.TabIndex = 9;
            buttonOpenLogLocation.Text = "Otwórz lokalizację logów";
            buttonOpenLogLocation.UseVisualStyleBackColor = true;
            buttonOpenLogLocation.Click += buttonOpenLogLocation_Click;
            // 
            // labelCountdown
            // 
            labelCountdown.AutoSize = true;
            labelCountdown.Location = new Point(333, 20);
            labelCountdown.Margin = new Padding(4, 0, 4, 0);
            labelCountdown.Name = "labelCountdown";
            labelCountdown.Size = new Size(169, 20);
            labelCountdown.TabIndex = 10;
            labelCountdown.Text = "Czas do sprawdzenia: 0s";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 600);
            tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(process_force_start);
            tabPage1.Controls.Add(labelInterval);
            tabPage1.Controls.Add(comboBoxInterval);
            tabPage1.Controls.Add(buttonStart);
            tabPage1.Controls.Add(buttonStop);
            tabPage1.Controls.Add(textBoxLogs);
            tabPage1.Controls.Add(labelLogs);
            tabPage1.Controls.Add(buttonShowLogs);
            tabPage1.Controls.Add(buttonOpenLogLocation);
            tabPage1.Controls.Add(labelCountdown);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 567);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Monitorowanie";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // process_force_start
            // 
            process_force_start.Location = new Point(698, 15);
            process_force_start.Name = "process_force_start";
            process_force_start.Size = new Size(86, 74);
            process_force_start.TabIndex = 11;
            process_force_start.Text = "Uruchom Procesy Manualnie";
            process_force_start.UseVisualStyleBackColor = true;
            process_force_start.Click += process_force_start_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(lok_label);
            tabPage2.Controls.Add(refresh_but);
            tabPage2.Controls.Add(process_count_label);
            tabPage2.Controls.Add(pictureBox1);
            tabPage2.Controls.Add(command_box);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(Proc_Save);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(process_lok);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(whoRunsProgram);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 567);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Parametry";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // lok_label
            // 
            lok_label.AutoSize = true;
            lok_label.Location = new Point(20, 104);
            lok_label.Name = "lok_label";
            lok_label.Size = new Size(64, 20);
            lok_label.TabIndex = 14;
            lok_label.Text = "File Path";
            // 
            // refresh_but
            // 
            refresh_but.Image = (Image)resources.GetObject("refresh_but.Image");
            refresh_but.Location = new Point(495, 278);
            refresh_but.Name = "refresh_but";
            refresh_but.Size = new Size(32, 32);
            refresh_but.SizeMode = PictureBoxSizeMode.AutoSize;
            refresh_but.TabIndex = 13;
            refresh_but.TabStop = false;
            refresh_but.Click += refresh_but_Click;
            // 
            // process_count_label
            // 
            process_count_label.AutoSize = true;
            process_count_label.Location = new Point(389, 189);
            process_count_label.Name = "process_count_label";
            process_count_label.Size = new Size(50, 20);
            process_count_label.TabIndex = 12;
            process_count_label.Text = "label1";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(495, 225);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            toolTip_command_box.SetToolTip(pictureBox1, resources.GetString("pictureBox1.ToolTip"));
            // 
            // command_box
            // 
            command_box.Location = new Point(20, 225);
            command_box.Multiline = true;
            command_box.Name = "command_box";
            command_box.ScrollBars = ScrollBars.Vertical;
            command_box.Size = new Size(469, 270);
            command_box.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(519, 533);
            label7.Name = "label7";
            label7.Size = new Size(268, 20);
            label7.TabIndex = 9;
            label7.Text = "Program stworzony przez Jacek Kujawa";
            // 
            // Proc_Save
            // 
            Proc_Save.Location = new Point(153, 177);
            Proc_Save.Name = "Proc_Save";
            Proc_Save.Size = new Size(137, 32);
            Proc_Save.TabIndex = 8;
            Proc_Save.Text = "Zapisz Polecenia";
            Proc_Save.UseVisualStyleBackColor = true;
            Proc_Save.Click += Proc_Save_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 183);
            label6.Name = "label6";
            label6.Size = new Size(127, 20);
            label6.TabIndex = 7;
            label6.Text = "Składnia Poleceń :";
            // 
            // process_lok
            // 
            process_lok.Location = new Point(259, 61);
            process_lok.Name = "process_lok";
            process_lok.Size = new Size(94, 29);
            process_lok.TabIndex = 6;
            process_lok.Text = "Wybierz";
            process_lok.UseVisualStyleBackColor = true;
            process_lok.Click += process_lok_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 65);
            label4.Name = "label4";
            label4.Size = new Size(233, 20);
            label4.TabIndex = 4;
            label4.Text = "Lokalizacja programu CDNWORK:";
            // 
            // whoRunsProgram
            // 
            whoRunsProgram.AutoSize = true;
            whoRunsProgram.Location = new Point(20, 18);
            whoRunsProgram.Name = "whoRunsProgram";
            whoRunsProgram.Size = new Size(0, 20);
            whoRunsProgram.TabIndex = 1;
            // 
            // toolTip_command_box
            // 
            toolTip_command_box.ShowAlways = true;
            toolTip_command_box.ToolTipTitle = "Przykład";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(tabControl1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Monitoring App";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)refresh_but).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }



        #endregion

        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.ComboBox comboBoxInterval;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox textBoxLogs;
        private System.Windows.Forms.Label labelLogs;
        private System.Windows.Forms.Button buttonShowLogs;
        private System.Windows.Forms.Button buttonOpenLogLocation;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label labelCountdown;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label whoRunsProgram;
        private Label label4;
        private Button process_lok;
        private Label label7;
        private Button Proc_Save;
        private Label label6;
        private TextBox command_box;
        private ToolTip toolTip_command_box;
        private PictureBox pictureBox1;
        private Label process_count_label;
        private PictureBox refresh_but;
        private Label lok_label;
        private Button process_force_start;
    }
}
