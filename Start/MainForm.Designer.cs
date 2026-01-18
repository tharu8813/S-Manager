
namespace S_Manager.Start {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            label3 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            groupBox2 = new GroupBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label4 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            linkLabel1 = new LinkLabel();
            button7 = new Button();
            label5 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(166, 40);
            label1.TabIndex = 0;
            label1.Text = "S Manager";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label2.Location = new Point(12, 49);
            label2.Name = "label2";
            label2.Size = new Size(287, 17);
            label2.TabIndex = 1;
            label2.Text = "ㅈ같은 핵쟁이와 학살, 방해로 부터 해방되세요!";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Location = new Point(12, 213);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(425, 182);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "게임 경로";
            // 
            // label3
            // 
            label3.Location = new Point(6, 48);
            label3.Name = "label3";
            label3.Size = new Size(413, 103);
            label3.TabIndex = 2;
            label3.Text = "[설명]\r\n경로를 설정할때 게임이 설치되어있는 폴더로 설정해주세요.\r\n\r\n[예시] (아래 경로는 기본 설치 경로입니다.)\r\nSteam : C:\\Program Files (x86)\\Steam\\steamapps\\common\\Red Dead Redemption 2";
            // 
            // button1
            // 
            button1.Location = new Point(6, 154);
            button1.Name = "button1";
            button1.Size = new Size(413, 23);
            button1.TabIndex = 1;
            button1.Text = "게임 경로 설정";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(6, 22);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(413, 23);
            textBox1.TabIndex = 0;
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.StartMenu;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox2);
            groupBox2.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, 129);
            groupBox2.Location = new Point(12, 85);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(425, 122);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "현재 상태";
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(3, 19);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(419, 100);
            textBox2.TabIndex = 0;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 432);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(344, 23);
            textBox3.TabIndex = 4;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label4.Location = new Point(12, 408);
            label4.Name = "label4";
            label4.Size = new Size(42, 21);
            label4.TabIndex = 5;
            label4.Text = "코드";
            // 
            // button2
            // 
            button2.Location = new Point(362, 432);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "자동 생성";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(12, 461);
            button3.Name = "button3";
            button3.Size = new Size(63, 23);
            button3.TabIndex = 7;
            button3.Text = "복사";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(81, 461);
            button4.Name = "button4";
            button4.Size = new Size(63, 23);
            button4.TabIndex = 8;
            button4.Text = "붙여놓기";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button5.Location = new Point(12, 501);
            button5.Name = "button5";
            button5.Size = new Size(425, 37);
            button5.TabIndex = 9;
            button5.Text = "해당 코드로 세션 변경";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(205, 461);
            button6.Name = "button6";
            button6.Size = new Size(151, 23);
            button6.TabIndex = 10;
            button6.Text = "현재 세션코드 가져오기";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(47, 579);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(354, 15);
            linkLabel1.TabIndex = 11;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "프로그램을 사용하면 서비스 약관에 동의하는것으로 간주됩니다.";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // button7
            // 
            button7.Location = new Point(12, 544);
            button7.Name = "button7";
            button7.Size = new Size(425, 23);
            button7.TabIndex = 12;
            button7.Text = "공개 세션으로 변경";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // label5
            // 
            label5.Font = new Font("맑은 고딕", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label5.Location = new Point(184, 9);
            label5.Name = "label5";
            label5.Size = new Size(253, 23);
            label5.TabIndex = 13;
            label5.Text = "null";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 603);
            Controls.Add(label5);
            Controls.Add(button7);
            Controls.Add(linkLabel1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "S Manager";
            Load += MainForm_Load_1;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private Button button1;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label label3;
        private GroupBox groupBox2;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label4;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private LinkLabel linkLabel1;
        private Button button7;
        private Label label5;
    }
}