using S_Manager.Tools;

namespace S_Manager.Start {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        bool isPlayReStart = false;

        private System.Windows.Forms.Timer? timer;

        public void UpdateStatus() {
            timer?.Stop();
            timer?.Dispose();
            timer = new System.Windows.Forms.Timer {
                Interval = 100
            };

            timer.Tick += (s, e) => {
                string status = "";
                string path = Path.Combine(textBox1.Text, "x64", "data");

                if (Tool.IsRDR2Running()) {
                    if (isPlayReStart) {
                        label5.Text = $"Red Dead Redemption 2: 실행중 (다시시작)";
                        label5.ForeColor = Color.Blue;
                    } else {
                        label5.Text = $"Red Dead Redemption 2: 실행중";
                        label5.ForeColor = Color.Green;
                    }
                } else {
                    label5.Text = "Red Dead Redemption 2: 실행 중지";
                    label5.ForeColor = Color.Red;
                    isPlayReStart = false;
                }

                if (Directory.Exists(path)) {
                    string startupMetaPath = Path.Combine(path, "startup.meta");
                    if (File.Exists(startupMetaPath)) {
                        status = $"세션 상태: 비공개 (코드: {Tool.ExtractContentFromFile(startupMetaPath, "S_Manager가 생성한 비밀번호입니다. 지우지 마세요! 삭제를 원한다면 S_Manager 프로그램에서 공개 세션으로 변경해주세요.")})";
                        button5.Enabled = true;
                        button6.Enabled = true;
                        button7.Enabled = true;
                    } else {
                        status = "세션 상태: 공개";
                        button5.Enabled = true;
                        button6.Enabled = false;
                        button7.Enabled = false;
                    }
                } else {
                    status = "세션 상태: (ERROR) 해당 경로는 Red Dead Redemption 2가 설치되지 않았습니다";
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                }

                textBox2.Text = $"""
                [세션 상태]
                {status}

                [설정된 게임 경로]
                {textBox1.Text}
                """;
            };

            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                textBox1.Text = folderBrowserDialog1.SelectedPath;

                Properties.Settings.Default.GamePath = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.Save();

                Tool.ShowMessage($"게임 경로가 설정되었습니다.\n\n{textBox1.Text}", Tool.MessageType.Info);
            }
        }

        private void MainForm_Load_1(object sender, EventArgs e) {
            textBox1.Text = Properties.Settings.Default.GamePath;
            UpdateStatus();
        }

        private void button2_Click(object sender, EventArgs e) {
            textBox3.Text = Tool.GenerateRandomPassword(16);
        }

        private void button3_Click(object sender, EventArgs e) {
            Clipboard.SetText(textBox3.Text);
            button3.Text = "복사완료";
            button3.Enabled = false;
            Task.Delay(500).ContinueWith(_ => {
                button3.Invoke(new Action(() => {
                    button3.Text = "복사";
                    button3.Enabled = true;
                }));
            });
        }

        private void button4_Click(object sender, EventArgs e) {
            textBox3.Text = Clipboard.GetText();
        }

        private void textBox3_TextChanged(object sender, EventArgs e) {
            button3.Enabled = !string.IsNullOrEmpty(textBox3.Text);
        }

        private void button5_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(textBox3.Text)) {
                Tool.ShowMessage("코드를 입력해 주세요.", Tool.MessageType.Error);
                return;
            }
            char[] specialChars = { '<', '>', '!', '-', '?' };
            if (textBox3.Text.Any(c => specialChars.Contains(c))) {
                Tool.ShowMessage("특수문자가 포함되어있습니다. '<', '>', '!', '-', '?'", Tool.MessageType.Error);
                return;
            }
            if (Tool.ShowMessage("해당 코드로 세션을 변경합니다. 계속하시겠습니까?", Tool.MessageType.Question) == DialogResult.Yes) {
                File.WriteAllText(Path.Combine(textBox1.Text, "x64", "data", "startup.meta"), Tool.CodeSession(textBox3.Text));
                isPlayReStart = true;
                Tool.RDR2Exit("비공개 세션으로 변경되었습니다.");
            }
        }

        private void button6_Click(object sender, EventArgs e) {
            textBox3.Text = Tool.ExtractContentFromFile(
                Path.Combine(textBox1.Text, "x64", "data", "startup.meta"),
                "S_Manager가 생성한 비밀번호입니다. 지우지 마세요! 삭제를 원한다면 S_Manager 프로그램에서 공개 세션으로 변경해주세요."
            );
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            new TermsOfUse().ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e) {
            if (Tool.ShowMessage("공개 세션으로 변경합니다\n\n계속하시겠습니까?", Tool.MessageType.Question) == DialogResult.Yes) {
                try {
                    File.Delete(Path.Combine(textBox1.Text, "x64", "data", "startup.meta"));
                    isPlayReStart = true;
                    Tool.RDR2Exit("공개 세션으로 변경되었습니다.");
                } catch (Exception ex) {
                    if (Tool.ShowMessage($"""
                    공개로 변경 도중 오류가 발생했습니다.
                    "예"를 누르면 수동으로 삭제할 수 있도록 폴더로 이동합니다. 이동 후 "startup.meta" 파일을 삭제해주세요.

                    [오류 메세지]
                    {ex.Message}
                    """, Tool.MessageType.Error) == DialogResult.OK) {
                        Tool.OpenExplorerAtPath(Path.Combine(textBox1.Text, "x64", "data", "startup.meta"));
                    }
                }
            }
        }
    }
}
